using System;

namespace Onedrive
{
  public class AccessToken
  {
    public string Token
    {
      get { return _token; }
      set
      { 
        _token = value;
        _generationTime = DateTime.Now;
      }
    }

    public bool IsValid
    {
      get
      {
        if (string.IsNullOrEmpty(_token)) return false;
        return (DateTime.Now - _generationTime).TotalMinutes < 60;
      }
    }

    private string _token = string.Empty;
    private DateTime _generationTime;

  }
}
