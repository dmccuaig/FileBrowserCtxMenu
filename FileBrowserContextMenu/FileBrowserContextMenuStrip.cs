using System.ComponentModel;
using System.Runtime.CompilerServices;
using giuaC.FileBrowserContextMenu.Properties;
using Microsoft.Win32;

namespace giuaC.FileBrowserContextMenu;

public class FileBrowserContextMenuStrip : ContextMenuStrip, INotifyPropertyChanged
{
	private string? _startPath;
	public string? StartPath
	{
		get => _startPath;
		set => SetField(ref _startPath, value);
	}

	private bool _showFileExtensions;
	public bool ShowFileExtensions
	{
		get => _showFileExtensions;
		set => SetField(ref _showFileExtensions, value);
	}


	private bool _isPopulated;
	private ToolStripMenuItem? _optionsMenuItem;

	public FileBrowserContextMenuStrip() : this(null) { }

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

	#region Options

	private void OnSetOptions_Click(object? sender, EventArgs e) => SetOptions();

	private void SetOptions()
	{
		var dlg = new OptionsForm();
		dlg.StartPath = StartPath;
		dlg.ShowFileExtensions = ShowFileExtensions;

		if (dlg.ShowDialog(this) != DialogResult.OK)
			return;

		StartPath = dlg.StartPath;
		ShowFileExtensions = dlg.ShowFileExtensions;
		SaveOptions();
	}

	public string PersistenceId { get; set; } = "eace7d61-8a93-4bda-b7ff-f1aed2aeaa0d";

	private RegistryKey GetPersistenceKey()
	{
		using  RegistryKey parentRegKey = Registry.CurrentUser.CreateSubKey($"{nameof(giuaC)}.{nameof(FileBrowserContextMenu)}");
		return parentRegKey.CreateSubKey(PersistenceId);
	}

	private void SaveOptions()
	{
		using RegistryKey regKey = GetPersistenceKey();
		regKey.SetValue(nameof(StartPath), StartPath ?? string.Empty);
		regKey.SetValue(nameof(ShowFileExtensions), ShowFileExtensions ? "1" : "0");
	}

	private void RestoreOptions()
	{
		using RegistryKey regKey = GetPersistenceKey();
		_startPath = regKey.GetValue(nameof(StartPath), StartPath ?? string.Empty) as string;
		string? showFileExtensions = regKey.GetValue(nameof(ShowFileExtensions)) as string;
		_showFileExtensions = showFileExtensions == "1";
	}

	#endregion

	#region PropertyChanged

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