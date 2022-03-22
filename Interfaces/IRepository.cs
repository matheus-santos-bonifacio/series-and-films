namespace console.Interfaces;

public interface IRepository<T>
{
  List<T> List();
  T ReturnById(int id);
  void Insert(T entitie);
  void Erase(int id);
  void Update(int id, T entitie);
  int NextId();
}
