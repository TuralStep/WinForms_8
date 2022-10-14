namespace WinForms_8.Repositories;


public interface IRepository<T>
{

    T? Get(Func<T, bool> predicate);
    List<T>? GetList(Func<T, bool>? predicate = null);

    void Add(T item);
    void Update(T item);
    void Remove(T item);

}