namespace giuaC.FileBrowserContextMenu;

public sealed class FolderMenuItem : ToolStripMenuItem
{
	private readonly bool _showFileExtensions;
	private bool _isPopulated;
	private readonly DirectoryInfo _directoryInfo;

	public FolderMenuItem(DirectoryInfo dirInfo, bool showFileExtensions)
	{
		_showFileExtensions = showFileExtensions;
		_directoryInfo = dirInfo;

		using Icon folderIcon = SystemIcons.GetStockIcon(StockIconId.Folder);
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
							DropDownItems.Add(new FolderMenuItem(dirInfo, _showFileExtensions));
							break;
						case FileInfo fileInfo:
							DropDownItems.Add(new FileMenuItem(fileInfo, _showFileExtensions));
							break;
						default:
							continue;
					}
				}
			}

			_isPopulated = true;
		}
	}
}