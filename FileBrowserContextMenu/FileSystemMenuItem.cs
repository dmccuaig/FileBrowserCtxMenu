using System.Diagnostics;

namespace System.Windows.Forms.FileBrowserContextMenu;

public  abstract class FileSystemMenuItem(IFileBrowserOptions options) : ToolStripMenuItem, IFileBrowserOptions
{
	/// <summary>
	/// Path to start browsing from.
	/// </summary>
	public string? StartPath => options.StartPath;

	/// <summary>
	/// If true, show file extensions in the menu items.
	/// </summary>
	public bool ShowFileExtensions => options.ShowFileExtensions;

	/// <summary>
	/// If true, Show Shell Menu on right-click
	/// </summary>
	public bool ShowShellMenu => options.ShowShellMenu;

	protected override void OnMouseDown(MouseEventArgs e)
	{
		Debug.WriteLine($"{nameof(FileSystemMenuItem)} {nameof(OnMouseDown)} {e.Button} {e.Clicks}");

		if (ShowShellMenu && e is { Button: MouseButtons.Right, Clicks: 1 })
		{
			OnShowShellMenu();
		}

		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		Debug.WriteLine($"{nameof(FileSystemMenuItem)} {nameof(OnMouseDown)} {e.Button} {e.Clicks}");

		base.OnMouseUp(e);

		if (e is { Button: MouseButtons.Left, Clicks: 1 })
		{
			OnMouseLeftUp();
		}
	}

	protected abstract void OnShowShellMenu();

	protected abstract void OnMouseLeftUp();
}