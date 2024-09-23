namespace giuaC.FileBrowserContextMenu;

public sealed class FileMenuItem : ToolStripMenuItem
{
	public FileMenuItem(FileInfo fileInfo, bool showFileExtensions = true)
	{
		string name = showFileExtensions ? fileInfo.Name : Path.GetFileNameWithoutExtension(fileInfo.Name);
		Text = name;
		Tag = fileInfo;

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
}