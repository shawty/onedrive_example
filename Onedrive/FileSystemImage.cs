namespace Onedrive
{

  public class FileSystemImage : FileSystemBase
  {
    public int Tags_Count { get; set; }
    public bool Tags_Enabled { get; set; }
    public string Picture { get; set; }
    public string Source { get; set; }
    public ImageInfo[] Images { get; set; }
    public object When_Taken { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public object Location { get; set; }
    public object Camera_Make { get; set; }
    public object Camera_Model { get; set; }
    public int Focal_Ratio { get; set; }
    public int Focal_Length { get; set; }
    public int Exposure_Numerator { get; set; }
    public int Exposure_Denominator { get; set; }
  }

  public class ImageInfo
  {
    public int Height { get; set; }
    public int Width { get; set; }
    public string Source { get; set; }
    public string Type { get; set; }
  }







}
