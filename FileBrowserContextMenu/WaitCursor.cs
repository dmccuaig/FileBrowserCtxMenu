namespace System.Windows.Forms.FileBrowserContextMenu;

/// <exclude />
public class WaitCursor : IDisposable
{
	private readonly Cursor? _oldCursor;

	public WaitCursor()
	{
		_oldCursor = Cursor.Current;
		Cursor.Current = Cursors.WaitCursor;
	}

	public void Dispose()
	{
		Cursor.Current = _oldCursor;
	}
}