using System.Diagnostics;

namespace System.Windows.Forms.FileBrowserContextMenu;

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

	protected override void OnMouseLeftUp()
	{
		Debug.WriteLine(nameof(FileMenuItem) + " " + nameof(OnMouseLeftUp));
		FileBrowserContextMenuStrip? ctxMenuStrip = GetContextMenuStrip();
		ctxMenuStrip?.OnFileClicked(_fileInfo);
	}

	protected override void OnShowShellMenu()
	{
		Debug.WriteLine(nameof(FileMenuItem) + " " + nameof(OnShowShellMenu));
		var shellContextMenu = new giuaC.ShellContextMenu.ShellContextMenu();
		shellContextMenu.ShowContextMenu(_fileInfo, Cursor.Position);
	}

}