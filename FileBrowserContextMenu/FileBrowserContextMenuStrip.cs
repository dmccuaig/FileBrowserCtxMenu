using System.ComponentModel;
using System.Diagnostics;

namespace giuaC.FileBrowserContextMenu;

public class FileBrowserContextMenuStrip : ContextMenuStrip
{
	internal Properties.Settings Options => Properties.Settings.Default;

	public string? StartPath
	{
		get => Options.StartPath;
		set => Options.StartPath = value;
	}

	public bool ShowFileExtensions
	{
		get => Options.ShowFileExtensions;
		set => Options.ShowFileExtensions = value;
	}

	public bool RunProgram
	{
		get => Options.RunProgram;
		set => Options.RunProgram = value;
	}

	private readonly ToolStripMenuItem? _optionsMenuItem;
	private string? _startPath;
	private bool _showFileExtensions;
	private bool _runProgram;

	public FileBrowserContextMenuStrip() : this(null) { }

	public FileBrowserContextMenuStrip(IContainer? components)
		: base(components!)
	{
		var icon = SystemIcons.GetStockIcon(StockIconId.Application).ToBitmap();
		_optionsMenuItem = new ToolStripMenuItem("Options", icon);
		_optionsMenuItem.Click += OptionsMenuItem_Click;
		AddOptionsMenuItem();
	}

	#region Options

	private void OptionsMenuItem_Click(object? sender, EventArgs e) => SetOptions();

	private void SetOptions()
	{
		var dlg = new OptionsForm();
		dlg.StartPath = StartPath;
		dlg.ShowFileExtensions = ShowFileExtensions;
		dlg.RunProgram = RunProgram;

		if (dlg.ShowDialog(this) != DialogResult.OK)
			return;

		StartPath = dlg.StartPath;
		ShowFileExtensions = dlg.ShowFileExtensions;
		RunProgram = dlg.RunProgram;
		Options.Save();

		ClearMenu(Items);
		FillMenu();
	}

	private void AddOptionsMenuItem() => Items.Add(_optionsMenuItem!);

	#endregion

	public void ClearMenu(ToolStripItemCollection menuItems)
	{
		foreach (var toolStripItem in menuItems.OfType<ToolStripMenuItem>())
		{
			// Release event handler
			toolStripItem.Click -= OnFileMenuItemClicked;

			if(toolStripItem.DropDownItems.Count > 0)
				ClearMenu(toolStripItem.DropDownItems);
		}

		menuItems.Clear();
	}

	public void FillMenu()
	{
		if (string.IsNullOrWhiteSpace(StartPath) == false)
		{
			var dirInfo = new DirectoryInfo(StartPath);
			if(dirInfo.Exists)
			{
				var folderMenuItems = CreateFolderMenuItem(dirInfo);
				Items.AddRange(folderMenuItems.DropDownItems);
			}
		}

		if(Items.Count > 0)
			Items.Add(new ToolStripSeparator());

		Items.Add(_optionsMenuItem!);
	}

	public ToolStripMenuItem CreateFolderMenuItem(DirectoryInfo directoryInfo, ToolStripItemCollection? menuItemCollection = null)
	{
		var folderMenuItem = new ToolStripMenuItem(directoryInfo.Name);

		using Icon folderIcon = SystemIcons.GetStockIcon(StockIconId.Folder);
		{
			var folderBitMap = folderIcon.ToBitmap();
			folderMenuItem.Image = folderBitMap;
		}

		menuItemCollection?.Add(folderMenuItem);

		foreach (var fileSysInfo in directoryInfo.EnumerateFileSystemInfos())
		{
			switch (fileSysInfo)
			{
				case DirectoryInfo dirInfo:
					CreateFolderMenuItem(dirInfo, folderMenuItem.DropDownItems);
					break;
				case FileInfo fileInfo:
					CreateFileMenuItem(folderMenuItem.DropDownItems, fileInfo);
					break;
				default:
					continue;
			}
		}

		return folderMenuItem;
	}

	public void CreateFileMenuItem(ToolStripItemCollection menuItemCollection, FileInfo fileInfo)
	{
		string name = ShowFileExtensions ? fileInfo.Name : Path.GetFileNameWithoutExtension(fileInfo.Name);
		var fileMenuItem = new ToolStripMenuItem(name);
		fileMenuItem.Tag = fileInfo.FullName;

		Icon? icon = null;
		try
		{
			icon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
			if (icon != null)
			{
				if (icon is { Width: >= 16, Height: >= 16 })
				{
					fileMenuItem.Image = icon.ToBitmap();
				}
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

		if (RunProgram)
		{
			fileMenuItem.Click += OnFileMenuItemClicked;
		}

		menuItemCollection.Add(fileMenuItem);
	}

	private void OnFileMenuItemClicked(object? sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;
		if (menuItem?.Tag is string path && string.IsNullOrWhiteSpace(path) == false)
		{
			using var process = new Process();
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = path;
			process.Start();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ClearMenu(Items);
			_optionsMenuItem!.Click -= OptionsMenuItem_Click;
		}

		base.Dispose(disposing);
	}
}
