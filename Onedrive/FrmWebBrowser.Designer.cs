namespace Onedrive
{
  partial class FrmWebBrowser
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
      this.AuthenticationBrowser = new System.Windows.Forms.WebBrowser();
      this.SuspendLayout();
      // 
      // AuthenticationBrowser
      // 
      this.AuthenticationBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AuthenticationBrowser.Location = new System.Drawing.Point(0, 0);
      this.AuthenticationBrowser.MinimumSize = new System.Drawing.Size(20, 20);
      this.AuthenticationBrowser.Name = "AuthenticationBrowser";
      this.AuthenticationBrowser.Size = new System.Drawing.Size(484, 566);
      this.AuthenticationBrowser.TabIndex = 0;
      // 
      // FrmWebBrowser
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 566);
      this.Controls.Add(this.AuthenticationBrowser);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FrmWebBrowser";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Authenticate OneDrive";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser AuthenticationBrowser;
  }
}