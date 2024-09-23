using giuaC.FileBrowserContextMenu;

namespace FileBrowserTest;

public sealed partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();
		components = new System.ComponentModel.Container();

		var fileBrowserContextMenuStrip = new FileBrowserContextMenuStrip(components);
		fileBrowserContextMenuStrip.OptionsFormTitle = "Shortcut Browser Options";

		_startPathLabel.DataBindings.Add(
			new Binding(
				nameof(_startPathLabel.Text),
				fileBrowserContextMenuStrip,
				nameof(fileBrowserContextMenuStrip.StartPath),
				true));

		_showFileExtensionsCheckBox.DataBindings.Add(
			new Binding(
				nameof(_showFileExtensionsCheckBox.Checked),
				fileBrowserContextMenuStrip,
				nameof(fileBrowserContextMenuStrip.ShowFileExtensions)));

		fileBrowserContextMenuStrip.FileMenuItemClicked += FileBrowserContextMenuStrip_FileMenuItemClicked;

		ContextMenuStrip = fileBrowserContextMenuStrip;
	}

	private void FileBrowserContextMenuStrip_FileMenuItemClicked(object? sender, FileInfo fileInfo)
	{
		_mouseClicksTextBox.AppendText(fileInfo.FullName + "\r\n");
	}

}