using System;
using System.Windows.Forms;

namespace Onedrive
{
  public partial class FrmWebBrowser : Form
  {
    public string AccessToken { get { return _accessToken; }}

    private string _accessToken = string.Empty;

    private const string _scope = "wl.skydrive_update";
    private const string _clientID = "00000000481275D0"; // Remember to change this to your own ClientID
    private const string _signInUrl = @"https://login.live.com/oauth20_authorize.srf?client_id={0}&redirect_uri=https://login.live.com/oauth20_desktop.srf&response_type=token&scope={1}";
    private Timer _closeTimer;

    public FrmWebBrowser()
    {
      InitializeComponent();
      StartAuthenticationProcess();
    }

    private void StartAuthenticationProcess()
    {
      AuthenticationBrowser.DocumentCompleted += AuthenticationBrowserDocumentCompleted;
      AuthenticationBrowser.Navigate(string.Format(_signInUrl, _clientID, _scope));
    }

    void AuthenticationBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (e.Url.AbsoluteUri.Contains("#access_token="))
      {
        var x = e.Url.AbsoluteUri.Split(new[] { "#access_token" }, StringSplitOptions.None);
        _accessToken = x[1].Split(new[] {'&'})[0];
        _closeTimer = new Timer {Interval = 500};
        _closeTimer.Tick += CloseTimerTick;
        _closeTimer.Enabled = true;
      }
    }

    private void CloseTimerTick(object sender, EventArgs e)
    {
      _closeTimer.Enabled = false;
      DialogResult = DialogResult.OK;
      Close();
    }

  }
}
