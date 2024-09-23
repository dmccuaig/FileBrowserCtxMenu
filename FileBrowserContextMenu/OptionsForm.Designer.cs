namespace giuaC.FileBrowserContextMenu
{
	partial class OptionsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			_startPathTextBox = new TextBox();
			_startPathBrowseButton = new Button();
			_okButton = new Button();
			_showFileExtensionsCheckBox = new CheckBox();
			toolTip1 = new ToolTip(components);
			_cancelButton = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 0;
			label1.Text = "Start Path";
			// 
			// _startPathTextBox
			// 
			_startPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_startPathTextBox.Location = new Point(76, 6);
			_startPathTextBox.Name = "_startPathTextBox";
			_startPathTextBox.Size = new Size(433, 23);
			_startPathTextBox.TabIndex = 1;
			toolTip1.SetToolTip(_startPathTextBox, "Root folder to start browsing from");
			// 
			// _startPathBrowseButton
			// 
			_startPathBrowseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			_startPathBrowseButton.AutoSize = true;
			_startPathBrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			_startPathBrowseButton.Location = new Point(515, 6);
			_startPathBrowseButton.Name = "_startPathBrowseButton";
			_startPathBrowseButton.Size = new Size(26, 25);
			_startPathBrowseButton.TabIndex = 2;
			_startPathBrowseButton.Text = "...";
			toolTip1.SetToolTip(_startPathBrowseButton, "Browse folders for Start Path");
			_startPathBrowseButton.UseVisualStyleBackColor = true;
			// 
			// _okButton
			// 
			_okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			_okButton.DialogResult = DialogResult.OK;
			_okButton.Location = new Point(385, 60);
			_okButton.Name = "_okButton";
			_okButton.Size = new Size(75, 23);
			_okButton.TabIndex = 3;
			_okButton.Text = "OK";
			_okButton.UseVisualStyleBackColor = true;
			// 
			// _showFileExtensionsCheckBox
			// 
			_showFileExtensionsCheckBox.AutoSize = true;
			_showFileExtensionsCheckBox.Location = new Point(12, 35);
			_showFileExtensionsCheckBox.Name = "_showFileExtensionsCheckBox";
			_showFileExtensionsCheckBox.Size = new Size(114, 19);
			_showFileExtensionsCheckBox.TabIndex = 4;
			_showFileExtensionsCheckBox.Text = "Show Extensions";
			toolTip1.SetToolTip(_showFileExtensionsCheckBox, "Show or hide file extensions");
			_showFileExtensionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// _cancelButton
			// 
			_cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			_cancelButton.DialogResult = DialogResult.Cancel;
			_cancelButton.Location = new Point(466, 60);
			_cancelButton.Name = "_cancelButton";
			_cancelButton.Size = new Size(75, 23);
			_cancelButton.TabIndex = 6;
			_cancelButton.Text = "Cancel";
			_cancelButton.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(553, 90);
			Controls.Add(_cancelButton);
			Controls.Add(_showFileExtensionsCheckBox);
			Controls.Add(_okButton);
			Controls.Add(_startPathBrowseButton);
			Controls.Add(_startPathTextBox);
			Controls.Add(label1);
			Name = "OptionsForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Options";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox _startPathTextBox;
		private Button _startPathBrowseButton;
		private Button _okButton;
		private CheckBox _showFileExtensionsCheckBox;
		private Button _cancelButton;
		private ToolTip toolTip1;
	}
}