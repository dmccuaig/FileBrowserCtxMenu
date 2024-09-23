using System.Runtime.InteropServices;

namespace giuaC.FileBrowserContextMenu
{
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
			_startPathBrowseButton.Click += (_, _) => EditStartPath();
			_startPathTextBox.DoubleClick += (_, _) => EditStartPath();
		}

		private void OptionsForm_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
		{
			if (DialogResult == DialogResult.OK && Directory.Exists(StartPath) == false)
			{
				MessageBox.Show($"The StartPath folder\n'{StartPath}'\ndoes not exist.", "Shortcut Browser", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.Cancel = true;
			}
		}

		private void EditStartPath()
		{
			string? startPath = GetDirectory(StartPath);
			if (startPath != null)
			{
				StartPath = startPath;
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

			if (dlg.ShowDialog() != DialogResult.OK)
				return null;

			return dlg.SelectedPath;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DestroyIcon(IntPtr handle);

	}
}
