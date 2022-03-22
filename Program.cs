using console.Class;
using console.Enum;
using static System.Console;

string userOption = GetByUser();

while (userOption.ToUpper() != "X")
{

  switch (userOption)
  {
    case "1":
      ListSeries();
      break;
    case "2":
      InsertSerie();
      break;
    case "3":
      UpdateSerie();
      break;
    case "4":
      EraseSerie();
      break;
    case "5":
      ViewSerie();
      break;
    case "C":
      Clear();
      break;
    default:
      throw new ArgumentOutOfRangeException();
  }

  userOption = GetByUser();
}

static void ListSeries()
{
  WriteLine("List Series");

  var series = SerieRepository.ReturnInstance().List();

  if (series.Count == 0)
  {
    WriteLine("There isn't list");
    return;
  }

  foreach (var serie in series)
  {
      WriteLine($"ID {serie.returnId()}: {serie.returnTitle()} - {(serie.returnIfWasErase() ? "*it was erase*" : "")}");
  }
}

static void InsertSerie()
{
  WriteLine("Inserting new serie");

  foreach (int i in Enum.GetValues(typeof(Genre)))
  {
      WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
  }

  Write("Choose between the options above: ");
  int genreInput = int.Parse(ReadLine());

  Write("Insert the title: ");
  string titleInput = ReadLine();

  Write("Insert the start year: ");
  int yearInput = int.Parse(ReadLine());

  Write("Insert the description: ");
  string descriptionInput = ReadLine();

  var serieRepository = SerieRepository.ReturnInstance();
  Serie serie = new Serie(serieRepository.NextId(),
      (Genre) genreInput, titleInput, descriptionInput, yearInput);

  serieRepository.Insert(serie);
}

static void UpdateSerie()
{
  Write("Insert the serie id: ");
  int serieIndex = int.Parse(ReadLine());

  foreach (int i in Enum.GetValues(typeof(Genre)))
  {
      WriteLine($"{i}: {Enum.GetName(typeof(Genre), i)}");
  }

  Write("Insert the genre between the options above: ");
  int genreInput = int.Parse(ReadLine());

  Write("Insert the serie title: ");
  string titleInput = ReadLine();

  Write("Insert the start year: ");
  int yearInput = int.Parse(ReadLine());

  Write("Insert the description: ");
  string descriptionInput = ReadLine();

  var serieRepository = SerieRepository.ReturnInstance();
  Serie updatedSerie = new Serie(serieIndex,
      (Genre) genreInput, titleInput, descriptionInput, yearInput);

  serieRepository.Update(updatedSerie);
}

static void EraseSerie()
{
  Write("Insert the id of serie: ");
  int serieIndex = int.Parse(ReadLine());

  var serieRepository = SerieRepository.ReturnInstance();
  serieRepository.Erase(serieIndex);
}

static void ViewSerie()
{
  Write("Insert the id of serie: ");
  int serieIndex = int.Parse(ReadLine());

  var serieRepository = SerieRepository.ReturnInstance();
  WriteLine(serieRepository.ReturnById(serieIndex));
}

static string GetByUser()
{
  WriteLine();
  WriteLine("DIO Series");
  WriteLine("Insert the option");

  WriteLine("1- List series");
  WriteLine("2- Insert new serie");
  WriteLine("3- Update serie");
  WriteLine("4- Erase serie");
  WriteLine("5- Show serie");
  WriteLine("C- Clean screen");
  WriteLine("X- Exit");
  WriteLine();

  string userOption = ReadLine();
  WriteLine();
  return userOption;
}
