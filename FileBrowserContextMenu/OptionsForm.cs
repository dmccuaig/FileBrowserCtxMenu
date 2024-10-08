﻿namespace giuaC.FileBrowserContextMenu;

/// <exclude />
public partial class OptionsForm : Form
{
	public string? StartPath
	{
		get => _startPathTextBox.Text;
		set => _startPathTextBox.Text = value;
	}

	public bool ShowFileExtensions
	{
		get => _showFileExtensionsCheckBox.Checked;
		set => _showFileExtensionsCheckBox.Checked = value;
	}

	public OptionsForm()
	{
		InitializeComponent();
		Icon = Icon.FromHandle(Properties.Resources.Settings_16x.GetHicon());
		Closing += OptionsForm_Closing;
		_startPathBrowseButton.Click += OnStartPathClick;
		_startPathTextBox.DoubleClick += OnStartPathClick;
	}

	private void OnStartPathClick(object? sender, EventArgs e)
	{
		string? startPath = GetDirectory(StartPath);
		if (startPath != null)
		{
			StartPath = startPath;
		}
	}

	private void OptionsForm_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
	{
		if (DialogResult == DialogResult.OK && Directory.Exists(StartPath) == false)
		{
			MessageBox.Show($"The StartPath folder\n'{StartPath}'\ndoes not exist.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			e.Cancel = true;
		}
	}

	private static string? GetDirectory(string? initialDirectory = null)
	{
		using FolderBrowserDialog dlg = new FolderBrowserDialog();

		if (string.IsNullOrWhiteSpace(initialDirectory) == false && Directory.Exists(initialDirectory))
		{
			dlg.InitialDirectory = initialDirectory;
		}
		else
		{
			dlg.RootFolder = Environment.SpecialFolder.Desktop;
		}

		return dlg.ShowDialog() == DialogResult.OK ? dlg.SelectedPath : null;
	}
}