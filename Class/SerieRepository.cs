using console.Interfaces;

namespace console.Class;

public class SerieRepository : IRepository<Serie>
{
    private List<Serie> serieList = new List<Serie>();
    private static SerieRepository? _serieRepository;

    private SerieRepository()
    {
    }

    public static SerieRepository ReturnInstance()
    {
        if (_serieRepository == null)
            _serieRepository = new SerieRepository();

        return _serieRepository;
    }

    public static void KillInstance()
    {
        _serieRepository = null;
    }

    public void Erase(int id)
    {
        serieList[id].Erase();
    }

    public void Insert(Serie entitie)
    {
        serieList.Add(entitie);
    }

    public List<Serie> List()
    {
        return serieList;
    }

    public int NextId()
    {
        return serieList.Count;
    }

    public Serie ReturnById(int id)
    {
        return serieList[id];
    }

    public void Update(Serie entitie)
    {
        serieList[entitie.Id] = entitie;
    }
}
