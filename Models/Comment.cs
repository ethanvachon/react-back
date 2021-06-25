namespace react_back.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Time { get; set; }
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}