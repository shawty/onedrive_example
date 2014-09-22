using System;

namespace Onedrive
{
  public class FileSystemBase
  {
    public string ID { get; set; }
    public FromUser From { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public object Parent_ID { get; set; }
    public long Size { get; set; }
    public string Upload_Location { get; set; }
    public int Comments_Count { get; set; }
    public bool Comments_Enabled { get; set; }
    public bool Is_Embeddable { get; set; }
    public int Count { get; set; }
    public string Link { get; set; }
    public string Type { get; set; }
    public SharePermissions Shared_With { get; set; }
    public object Created_Time { get; set; }
    public DateTime Updated_Time { get; set; }
    public DateTime Client_Updated_Time { get; set; }
  }

  public class FromUser
  {
    public object Name { get; set; }
    public object ID { get; set; }
  }

  public class SharePermissions
  {
    public string Access { get; set; }
  }

}


