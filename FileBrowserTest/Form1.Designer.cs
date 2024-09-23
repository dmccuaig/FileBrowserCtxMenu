﻿using giuaC.FileBrowserContextMenu;

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
			Label label1;
			startPathLabel = new Label();
			showFileExtensionsCheckBox = new CheckBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// _fileBrowserContextMenuStrip
			// 
			_fileBrowserContextMenuStrip.Name = "_fileBrowserContextMenuStrip";
			_fileBrowserContextMenuStrip.Size = new Size(61, 4);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(42, 36);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 0;
			label1.Text = "StartPath:";
			label1.Click += label1_Click;
			// 
			// startPathLabel
			// 
			startPathLabel.AutoSize = true;
			startPathLabel.Location = new Point(106, 36);
			startPathLabel.Name = "startPathLabel";
			startPathLabel.Size = new Size(0, 15);
			startPathLabel.TabIndex = 2;
			// 
			// showFileExtensionsCheckBox
			// 
			showFileExtensionsCheckBox.AutoSize = true;
			showFileExtensionsCheckBox.Location = new Point(49, 80);
			showFileExtensionsCheckBox.Name = "showFileExtensionsCheckBox";
			showFileExtensionsCheckBox.Size = new Size(83, 19);
			showFileExtensionsCheckBox.TabIndex = 3;
			showFileExtensionsCheckBox.Text = "checkBox1";
			showFileExtensionsCheckBox.UseVisualStyleBackColor = true;
			ContextMenuStrip = _fileBrowserContextMenuStrip;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(showFileExtensionsCheckBox);
			Controls.Add(startPathLabel);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private FileBrowserContextMenuStrip _fileBrowserContextMenuStrip;
		private Label label1;
		private Label label2;
		private Label startPathLabel;
		private CheckBox showFileExtensionsCheckBox;
		private Label label4;
	}
}
