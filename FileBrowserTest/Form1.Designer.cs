namespace FileBrowserTest
{
	sealed partial class Form1
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
			Label label1;
			GroupBox groupBox1;
			_mouseClicksTextBox = new TextBox();
			_startPathLabel = new Label();
			_showFileExtensionsCheckBox = new CheckBox();
			label1 = new Label();
			groupBox1 = new GroupBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 0;
			label1.Text = "StartPath:";
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(_mouseClicksTextBox);
			groupBox1.Location = new Point(12, 355);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(365, 94);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Menu Item Clicks:";
			// 
			// _mouseClicksTextBox
			// 
			_mouseClicksTextBox.Dock = DockStyle.Fill;
			_mouseClicksTextBox.Location = new Point(3, 19);
			_mouseClicksTextBox.Multiline = true;
			_mouseClicksTextBox.Name = "_mouseClicksTextBox";
			_mouseClicksTextBox.Size = new Size(359, 72);
			_mouseClicksTextBox.TabIndex = 0;
			// 
			// _startPathLabel
			// 
			_startPathLabel.AutoSize = true;
			_startPathLabel.Location = new Point(76, 9);
			_startPathLabel.Name = "_startPathLabel";
			_startPathLabel.Size = new Size(0, 15);
			_startPathLabel.TabIndex = 2;
			// 
			// _showFileExtensionsCheckBox
			// 
			_showFileExtensionsCheckBox.AutoSize = true;
			_showFileExtensionsCheckBox.Location = new Point(12, 36);
			_showFileExtensionsCheckBox.Name = "_showFileExtensionsCheckBox";
			_showFileExtensionsCheckBox.Size = new Size(135, 19);
			_showFileExtensionsCheckBox.TabIndex = 3;
			_showFileExtensionsCheckBox.Text = "Show File Extensions";
			_showFileExtensionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(384, 461);
			Controls.Add(groupBox1);
			Controls.Add(_showFileExtensionsCheckBox);
			Controls.Add(_startPathLabel);
			Controls.Add(label1);
			MaximizeBox = false;
			Name = "Form1";
			Text = "Form1";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label _startPathLabel;
		private CheckBox _showFileExtensionsCheckBox;
		private TextBox _mouseClicksTextBox;
	}
}
