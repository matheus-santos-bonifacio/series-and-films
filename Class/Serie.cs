using console.Enum;

namespace console.Class;

public class Serie : BaseEntitie
{
  private Genre _genre { get; set; }
  private string _title { get; set; }
  private string _description { get; set; }
  private int _year { get; set; }
  private bool _isErase { get; set; }

  public Serie(int id, Genre genre, string title, string description, int year)
  {
    Id = id;
    _genre = genre;
    _title = title;
    _description = description;
    _year = year;
    _isErase = false;
  }

  public override string ToString()
  {
    string result = "";

    result += $"Genre: {_genre}{Environment.NewLine}";
    result += $"Title: {_title}{Environment.NewLine}";
    result += $"Description: {_description}{Environment.NewLine}";
    result += $"Start year: {_year}{Environment.NewLine}";
    result += $"Deleted: {_isErase}{Environment.NewLine}";

    return result;
  }

  public string returnTitle()
  {
    return _title;
  }

  public int returnId()
  {
    return Id;
  }

  public bool returnIfWasErase()
  {
    return _isErase;
  }

  public void Erase()
  {
    _isErase = true;
  }
}
