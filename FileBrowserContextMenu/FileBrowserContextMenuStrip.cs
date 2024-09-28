using System.ComponentModel;
using System.Runtime.CompilerServices;
using giuaC.FileBrowserContextMenu.Properties;
using Microsoft.Win32;

namespace giuaC.FileBrowserContextMenu;

/// <summary>
/// ContextMenuStrip for cascading browsing of folders and files.
/// </summary>
public class FileBrowserContextMenuStrip : ContextMenuStrip, INotifyPropertyChanged
{
	private string? _startPath = "";
	/// <summary>
	/// Path to start browsing from.
	/// </summary>
	[Bindable(true)]
	public string? StartPath
	{
		get => _startPath;
		set => SetField(ref _startPath, value);
	}

	private bool _showFileExtensions;
	/// <summary>
	/// If true, show file extensions in the menu items.
	/// </summary>
	[Bindable(true)]
	public bool ShowFileExtensions
	{
		get => _showFileExtensions;
		set => SetField(ref _showFileExtensions, value);
	}

	/// <summary>
	/// Title for the options dialog
	/// </summary>
	public string OptionsFormTitle { get; set; } = "Options";

	private bool _isPopulated;
	private ToolStripMenuItem? _optionsMenuItem;

	/// <summary>
	/// .ctor
	/// </summary>
	public FileBrowserContextMenuStrip() : this(null) { }

	/// <summary>
	/// .ctor
	/// </summary>
	/// <param name="components">Form components for disposing.</param>
	public FileBrowserContextMenuStrip(IContainer? components)
		: base(components!)
	{
		InitializeComponents();
		PropertyChanged += OnPropertyChanged;
		RestoreOptions();
		ClearMenu();
	}

	private void InitializeComponents()
	{
		_optionsMenuItem = new ToolStripMenuItem("Options...");
		_optionsMenuItem.Image = Resources.Settings_16x;
		_optionsMenuItem.Click += OnSetOptions_Click;
	}

	protected override void OnOpening(CancelEventArgs e)
	{
		PopulateMenu();
		base.OnOpening(e);
	}

	private void PopulateMenu()
	{
		if (_isPopulated) return;

		if (string.IsNullOrWhiteSpace(StartPath) == false && Path.Exists(StartPath))
		{
			var dirInfo = new DirectoryInfo(StartPath);
			var dirMenuItem = new FolderMenuItem(dirInfo, ShowFileExtensions);
			dirMenuItem.PopulateChildren();
			Items.AddRange(dirMenuItem.DropDownItems);
		}

		if (Items.Count > 0)
			Items.Add(new ToolStripSeparator());

		Items.Add(_optionsMenuItem!);

		_isPopulated = true;
	}

	private void ClearMenu()
	{
		Items.Clear();
		_isPopulated = false;
		Items.Add(_optionsMenuItem!);
	}

	/// <summary>
	/// Raised when the user clicks on a file menuitem.
	/// </summary>
	public event EventHandler<FileInfo>? FileMenuItemClicked;

	internal void OnFileClicked(FileInfo fileInfo)
	{
		FileMenuItemClicked?.Invoke(this, fileInfo);
	}

	#region Options

	private void OnSetOptions_Click(object? sender, EventArgs e) => SetOptions();

	private void SetOptions()
	{
		var dlg = new OptionsForm();
		dlg.StartPath = StartPath;
		dlg.Text = OptionsFormTitle;
		dlg.ShowFileExtensions = ShowFileExtensions;

		if (dlg.ShowDialog(this) != DialogResult.OK)
			return;

		StartPath = dlg.StartPath ?? "";
		ShowFileExtensions = dlg.ShowFileExtensions;
		SaveOptions();
	}

	/// <summary>
	/// Persistence identifier to make multiple instances unique.
	/// </summary>
	public string PersistenceId { get; set; } = "Default";
	private const string ProductKeyName = $"{nameof(giuaC)}.{nameof(FileBrowserContextMenu)}";

	private RegistryKey CreatePersistenceKey()
	{
		using RegistryKey productRegKey = Registry.CurrentUser.CreateSubKey(ProductKeyName);
		return productRegKey.CreateSubKey(PersistenceId);
	}

	private RegistryKey? GetPersistenceKey()
	{
		using RegistryKey? productRegKey = Registry.CurrentUser.OpenSubKey(ProductKeyName);
		return productRegKey?.OpenSubKey(PersistenceId);
	}

	private void SaveOptions()
	{
		using RegistryKey regKey = CreatePersistenceKey();
		regKey.SetValue(nameof(StartPath), StartPath ?? string.Empty);
		regKey.SetValue(nameof(ShowFileExtensions), ShowFileExtensions ? "1" : "0");
	}

	private void RestoreOptions()
	{
		using RegistryKey? regKey = GetPersistenceKey();
		if(regKey == null)
			return;

		_startPath = regKey.GetValue(nameof(StartPath), StartPath ?? string.Empty) as string;
		string? showFileExtensions = regKey.GetValue(nameof(ShowFileExtensions)) as string;
		_showFileExtensions = showFileExtensions == "1";
	}

	#endregion

	#region PropertyChanged

	/// <summary>
	/// Raised when a property changes.
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;
		RaisePropertyChanged(propertyName);
		return true;
	}

	private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
			case nameof(StartPath):
			case nameof(ShowFileExtensions):
				ClearMenu();
				SaveOptions();
				break;
		}
	}

	#endregion

}