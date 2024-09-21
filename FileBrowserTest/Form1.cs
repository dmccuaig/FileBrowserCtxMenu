using MaterialSkin.Controls;

namespace FileBrowserTest;

public partial class Form1 : MaterialForm
{
	public Form1()
	{
		InitializeComponent();
		Closing += Form1_Closing;
	}

	private void Form1_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
	{
		Properties.Settings.Default.SomeString = "Modified";
	}
}