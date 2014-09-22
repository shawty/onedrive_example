using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Onedrive
{
  public partial class FrmMainForm : Form
  {
    private string _accessToken;
    private string _filename = @"c:\Users\Shawty\Pictures\IMAG0067.jpg";
    private string _uploadLocation = @"https://apis.live.net/v5.0/folder.4515677bdf99b35f/files/"; // Change this to get info from the info part

    private AccessToken myAccessToken;

    public FrmMainForm()
    {
      InitializeComponent();
    }

    private string GetAccessToken()
    {
      if (myAccessToken != null && myAccessToken.IsValid)
      {
        return myAccessToken.Token;
      }

      using (FrmWebBrowser authBrowser = new FrmWebBrowser())
      {
        if (authBrowser.ShowDialog() != DialogResult.OK) return string.Empty;
        myAccessToken = new AccessToken();
        myAccessToken.Token = authBrowser.AccessToken;
        return myAccessToken.Token;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //GetSkydriveInfo();
      //GetSkyDriveRootFileListing();
      //GetStorageQuota();

      lsbOutput.Items.Add("Getting file list...");
      OneDriveFileList driveRoot = GetOneDriveRootListing();

      lsbOutput.Items.Add("Extracting images from list");
      List<FileSystemImage> myImages = GetIamgesFromFileList(driveRoot);

      lsbOutput.Items.Add("Downloading first image found");
      DownloadFile(driveRoot, myImages[0].ID);

      lsbOutput.Items.Add("Done.");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      UploadFileToSkyDrive(_filename);
    }

    private OneDriveFileList GetOneDriveRootListing()
    {
      var accessToken = GetAccessToken();
      string jsonData;

      string url = string.Format(@"https://apis.live.net/v5.0/me/skydrive?access_token={0}", accessToken);
      using (var client = new WebClient())
      {
        var result = client.OpenRead(new Uri(url));
        var sr = new StreamReader(result);
        jsonData = sr.ReadToEnd();
      }

      FileSystemBase driveInfo = JsonConvert.DeserializeObject<FileSystemBase>(jsonData);

      url = string.Format("{0}?access_token{1}", driveInfo.Upload_Location, accessToken);
      using (var client = new WebClient())
      {
        var result = client.OpenRead(new Uri(url));
        var sr = new StreamReader(result);
        jsonData = sr.ReadToEnd();
      }

      OneDriveFileList rootList = JsonConvert.DeserializeObject<OneDriveFileList>(jsonData);

      return rootList;
    }


    private List<FileSystemImage> GetIamgesFromFileList(OneDriveFileList inputList)
    {
      List<FileSystemImage> results = new List<FileSystemImage>();

      using (var client = new WebClient())
      {
        var images = inputList.Data.Where(x => x.Type.Equals("photo"));
        foreach (var fileSystemBase in images)
        {
          string url = string.Format("{0}?access_token={1}", fileSystemBase.Upload_Location.Replace("content/", string.Empty), GetAccessToken());
          var webResult = client.OpenRead(new Uri(url));
          var sr = new StreamReader(webResult);
          var jsonData = sr.ReadToEnd();

          results.Add(JsonConvert.DeserializeObject<FileSystemImage>(jsonData));
        }
      }

      return results;
    }

    private void DownloadFile(OneDriveFileList inputList, string fileIdToDownload)
    {
      var fileToDownload = inputList.Data.FirstOrDefault(x => x.ID == fileIdToDownload);

      if (fileIdToDownload == null) return;
      using (var client = new WebClient())
      {
        string url = string.Format("{0}?access_token={1}", fileToDownload.Upload_Location, GetAccessToken());
        var webResult = client.OpenRead(new Uri(url));
        if (webResult == null) return;
        using (var fileStream = File.Create(fileToDownload.Name))
        {
          webResult.CopyTo(fileStream);
        }
      }
    }

    private void UploadFileToSkyDrive(string localFile)
    {
      string url = string.Format(@"https://apis.live.net/v5.0/folder.4515677bdf99b35f/files/{0}?access_token={1}", Path.GetFileName(localFile), GetAccessToken());
      using (var client = new WebClient())
      {
        var result = client.UploadData(new Uri(url), "PUT", FileToByteArray(_filename));
        string strResult = Encoding.UTF8.GetString(result);
        MessageBox.Show(strResult);
      }
    }

    private byte[] FileToByteArray(string fileName)
    {
      FileStream fileStream = File.OpenRead(fileName);
      byte[] fileData = new byte[fileStream.Length];
      fileStream.Read(fileData, 0, fileData.Length);
      fileStream.Close();
      return fileData;
    }


























    private void GetSkydriveInfo()
    {
    }

    private void GetSkyDriveRootFileListing()
    {
      string url = string.Format(@"{0}?access_token={1}", _uploadLocation, _accessToken);
      using (var client = new WebClient())
      {
        var result = client.OpenRead(new Uri(url));
        var sr = new StreamReader(result);
        var response = sr.ReadToEnd();
        MessageBox.Show(response);
      }
    }

    private void GetStorageQuota()
    {
      string url = string.Format(@"https://apis.live.net/v5.0/me/skydrive/quota?access_token={0}", _accessToken);
      using (var client = new WebClient())
      {
        var result = client.OpenRead(new Uri(url));
        var sr = new StreamReader(result);
        var response = sr.ReadToEnd();
        MessageBox.Show(response);
      }
    }

    private void DownloadFileFromSkyDrive()
    {
      string url = string.Format(@"https://apis.live.net/v5.0/file.4515677bdf99b35f.4515677BDF99B35F!1021/content?access_token={0}", _accessToken);
      using (var client = new WebClient())
      {
        var result = client.DownloadData(new Uri(url));
        File.WriteAllBytes("frogs", result);
      }
    }


  }
}
