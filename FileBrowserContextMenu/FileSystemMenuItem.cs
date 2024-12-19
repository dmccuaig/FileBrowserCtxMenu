namespace giuaC.FileBrowserContextMenu;

public class FileSystemMenuItem(IFileBrowserOptions options) : ToolStripMenuItem, IFileBrowserOptions
{
	/// <summary>
	/// Path to start browsing from.
	/// </summary>
	public string? StartPath { get; } = options.StartPath;

	/// <summary>
	/// If true, show file extensions in the menu items.
	/// </summary>
	public bool ShowFileExtensions { get; } = options.ShowFileExtensions;

	/// <summary>
	/// If true, Show Shell Menu on right-click
	/// </summary>
	public bool ShowShellMenu { get; } = options.ShowShellMenu;
}