using giuaC.FileBrowserContextMenu;

namespace FileBrowserTest
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			_fileBrowserContextMenuStrip = new FileBrowserContextMenuStrip(components);
			SuspendLayout();
			// 
			// _fileBrowserContextMenuStrip
			// 
			_fileBrowserContextMenuStrip.Name = "_fileBrowserContextMenuStrip";
			_fileBrowserContextMenuStrip.Size = new Size(61, 4);
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			ContextMenuStrip = _fileBrowserContextMenuStrip;
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private FileBrowserContextMenuStrip _fileBrowserContextMenuStrip;
	}
}
