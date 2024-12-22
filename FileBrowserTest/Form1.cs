using System.Windows.Forms.FileBrowserContextMenu;

namespace FileBrowserTest;

/// <exclude />
public sealed partial class Form1 : Form
{
	private readonly FileBrowserContextMenuStrip _fileBrowserContextMenuStrip;

	public Form1()
	{
		InitializeComponent();
		components = new System.ComponentModel.Container();

		_fileBrowserContextMenuStrip = new FileBrowserContextMenuStrip(components);
		_fileBrowserContextMenuStrip.OptionsFormTitle = "Shortcut Browser Options";

		OnShowExtensionsCheckChanged();
		OnShowShellMenuCheckChanged();

		_startPathLabel.DataBindings.Add(
			new Binding(
				nameof(_startPathLabel.Text),
				_fileBrowserContextMenuStrip,
				nameof(_fileBrowserContextMenuStrip.StartPath),
				true));

		_showFileExtensionsCheckBox.CheckedChanged += (s,e) => OnShowExtensionsCheckChanged();
		_showShellMenuCheckbox.CheckedChanged += (s,e) => OnShowShellMenuCheckChanged();

		_fileBrowserContextMenuStrip.FileMenuItemClicked += OnFileMenuItemClicked;

		ContextMenuStrip = _fileBrowserContextMenuStrip;
	}

	private void OnFileMenuItemClicked(object? sender, FileInfo fileInfo)
	{
		_mouseClicksTextBox.AppendText($"{fileInfo.FullName}\r\n");
	}

	private void OnShowExtensionsCheckChanged()
		{
			_fileBrowserContextMenuStrip.ShowFileExtensions = _showFileExtensionsCheckBox.Checked;
		}

		private void OnShowShellMenuCheckChanged()
		{
			_fileBrowserContextMenuStrip.ShowShellMenu = _showShellMenuCheckbox.Checked;
		}

}