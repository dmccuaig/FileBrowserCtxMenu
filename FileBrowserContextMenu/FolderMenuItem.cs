using System.Diagnostics;

namespace System.Windows.Forms.FileBrowserContextMenu;

/// <exclude />
public sealed class FolderMenuItem : FileSystemMenuItem
{
	private bool _isPopulated;
	private readonly DirectoryInfo _directoryInfo;

	public FolderMenuItem(DirectoryInfo dirInfo, IFileBrowserOptions options)
		: base(options)
	{
		_directoryInfo = dirInfo;

		using( Icon folderIcon = SystemIcons.GetStockIcon(StockIconId.Folder))
		{
			Text = dirInfo.Name;
			var folderBitMap = folderIcon.ToBitmap();
			Image = folderBitMap;
		}

		if (HasFiles(dirInfo))
			DropDownItems.Add(new ToolStripMenuItem()); // Dummy item to get right triangle glyph

		DropDownOpening += OnDropDownOpening;
	}

	private void OnDropDownOpening(object? sender, EventArgs e)
	{
		if (_isPopulated == false)
			PopulateChildren();
	}

	private static bool HasFiles(DirectoryInfo directoryInfo)
	{
		using var fileInfo = directoryInfo.EnumerateFileSystemInfos().GetEnumerator();
		return fileInfo.MoveNext();
	}

	internal void PopulateChildren()
	{
		using (new WaitCursor())
		{
			DropDownItems.Clear();
			if (_directoryInfo.Exists)
			{
				foreach (var fileSysInfo in _directoryInfo.EnumerateFileSystemInfos())
				{
					switch (fileSysInfo)
					{
						case DirectoryInfo dirInfo:
							DropDownItems.Add(new FolderMenuItem(dirInfo, this));
							break;
						case FileInfo fileInfo:
							DropDownItems.Add(new FileMenuItem(fileInfo, this));
							break;
						default:
							continue;
					}
				}
			}

			_isPopulated = true;
		}
	}

	protected override void OnMouseLeftUp()
	{
		Debug.WriteLine(nameof(FolderMenuItem) + " " + nameof(OnMouseLeftUp));

	}

	protected override void OnShowShellMenu()
	{
		Debug.WriteLine(nameof(FolderMenuItem) + " " + nameof(OnShowShellMenu));

		var shellContextMenu = new giuaC.ShellContextMenu.ShellContextMenu();
		shellContextMenu.ShowContextMenu(_directoryInfo, Cursor.Position);
	}

}