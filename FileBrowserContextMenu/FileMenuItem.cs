namespace giuaC.FileBrowserContextMenu;

public sealed class FileMenuItem : ToolStripMenuItem
{
	private readonly FileInfo _fileInfo;

	public FileMenuItem(FileInfo fileInfo, bool showFileExtensions = true)
	{
		_fileInfo = fileInfo;

		string name = showFileExtensions ? fileInfo.Name : Path.GetFileNameWithoutExtension(fileInfo.Name);
		Text = name;


		Icon? icon = null;
		try
		{
			icon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
			if (icon is { Width: >= 16, Height: >= 16 })
			{
				Image = icon.ToBitmap();
			}
		}
		catch
		{
			// Don't fail if cannot set icon.
		}
		finally
		{
			icon?.Dispose();
		}
	}

	private FileBrowserContextMenuStrip? GetContextMenuStrip()
	{
		ToolStripItem? menuItem = this;

		while (menuItem.OwnerItem != null)
		{
			menuItem = menuItem.OwnerItem;
		}

		return menuItem.Owner as FileBrowserContextMenuStrip;
	}

	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);

		FileBrowserContextMenuStrip? ctxMenuStrip = GetContextMenuStrip();
		ctxMenuStrip?.OnFileClicked(_fileInfo);
	}

}