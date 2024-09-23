namespace giuaC.FileBrowserContextMenu;

public sealed class FolderMenuItem : ToolStripMenuItem
{
	private readonly bool _showFileExtensions;
	private bool _isPopulated;

	public DirectoryInfo DirectoryInfo { get; }

	public FolderMenuItem(DirectoryInfo dirInfo, bool showFileExtensions)
	{
		_showFileExtensions = showFileExtensions;
		DirectoryInfo = dirInfo;

		using Icon folderIcon = SystemIcons.GetStockIcon(StockIconId.Folder);
		{
			Text = dirInfo.Name;
			var folderBitMap = folderIcon.ToBitmap();
			Image = folderBitMap;
		}

		if (HasFiles(dirInfo))
			DropDownItems.Add(new ToolStripMenuItem()); // Dummy item to get right triangle glyph
	}

	public static bool HasFiles(DirectoryInfo directoryInfo)
	{
		using var fileInfo = directoryInfo.EnumerateFileSystemInfos().GetEnumerator();
		return fileInfo.MoveNext();
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		if (_isPopulated == false)
			PopulateChildren();
	}

	public void PopulateChildren()
	{
		using (new WaitCursor())
		{
			DropDownItems.Clear();
			if (DirectoryInfo.Exists)
			{
				foreach (var fileSysInfo in DirectoryInfo.EnumerateFileSystemInfos())
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