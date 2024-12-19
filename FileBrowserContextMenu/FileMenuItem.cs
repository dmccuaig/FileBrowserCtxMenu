namespace giuaC.FileBrowserContextMenu;

/// <exclude />
public sealed class FileMenuItem : FileSystemMenuItem
{
	private readonly FileInfo _fileInfo;

	public FileMenuItem(FileInfo fileInfo, IFileBrowserOptions options)
	: base(options)
	{
		_fileInfo = fileInfo;

		string name = ShowFileExtensions ? fileInfo.Name : Path.GetFileNameWithoutExtension(fileInfo.Name);
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

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (ShowShellMenu && e is { Button: MouseButtons.Right, Clicks: 1 })
		{
			var shellContextMenu = new ShellContextMenu.ShellContextMenu();
			shellContextMenu.ShowContextMenu(_fileInfo, Cursor.Position);
			return;
		}

		base.OnMouseDown(e);

	}
}