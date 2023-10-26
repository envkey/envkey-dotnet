﻿namespace TestWinClient
{
  partial class MainForm
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
      this.LoadEnvKeyButton = new System.Windows.Forms.Button();
      this.ResultTextbox = new System.Windows.Forms.TextBox();
      this.EnvKeyToUseTextbox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // LoadEnvKeyButton
      // 
      this.LoadEnvKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LoadEnvKeyButton.Location = new System.Drawing.Point(12, 36);
      this.LoadEnvKeyButton.Name = "LoadEnvKeyButton";
      this.LoadEnvKeyButton.Size = new System.Drawing.Size(483, 49);
      this.LoadEnvKeyButton.TabIndex = 2;
      this.LoadEnvKeyButton.Text = "Load EnvKey Information";
      this.LoadEnvKeyButton.UseVisualStyleBackColor = true;
      this.LoadEnvKeyButton.Click += new System.EventHandler(this.LoadEnvKeyButton_Click);
      // 
      // ResultTextbox
      // 
      this.ResultTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ResultTextbox.Location = new System.Drawing.Point(12, 91);
      this.ResultTextbox.Multiline = true;
      this.ResultTextbox.Name = "ResultTextbox";
      this.ResultTextbox.Size = new System.Drawing.Size(483, 130);
      this.ResultTextbox.TabIndex = 3;
      // 
      // EnvKeyToUseTextbox
      // 
      this.EnvKeyToUseTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.EnvKeyToUseTextbox.Location = new System.Drawing.Point(63, 10);
      this.EnvKeyToUseTextbox.Name = "EnvKeyToUseTextbox";
      this.EnvKeyToUseTextbox.Size = new System.Drawing.Size(432, 20);
      this.EnvKeyToUseTextbox.TabIndex = 1;
      this.EnvKeyToUseTextbox.Text = "eke4nuFE6XNCb9tSztxyYKfC-37M59z121nqigZkXiCJq8o";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "EnvKey";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(507, 233);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.EnvKeyToUseTextbox);
      this.Controls.Add(this.ResultTextbox);
      this.Controls.Add(this.LoadEnvKeyButton);
      this.Name = "MainForm";
      this.Text = "EnvKey Test";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button LoadEnvKeyButton;
    private System.Windows.Forms.TextBox ResultTextbox;
    private System.Windows.Forms.TextBox EnvKeyToUseTextbox;
    private System.Windows.Forms.Label label1;
  }
}

