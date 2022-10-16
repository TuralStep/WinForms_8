using WinForms_8.Models;
using WinForms_8.Repositories.Contexts;

namespace WinForms_8.Repositories;


public class EfStudentRepository : IStudentRepository
{


    private readonly MyDbContext _context;



    public EfStudentRepository()
    {
        _context = new MyDbContext();
    }



    public Student? Get(Func<Student, bool> predicate)
        => _context.Students?.FirstOrDefault(predicate);

    public Student? GetById(Guid id)
        => _context.Students?.Find(id);

    public List<Student>? GetList(Func<Student, bool>? predicate = null)
        => (predicate == null) switch
        {
            true => _context.Students?.ToList(),
            false => _context.Students?.Where(predicate).ToList()
        };


    public void Add(Student item)
    {
        _context.Students?.Add(item);
        _context.SaveChanges();
    }

    public void Remove(Student item)
    {
        _context.Students?.Remove(item);
        _context.SaveChanges();
    }

    public void Update(Student item)
    {
        _context.Students?.Update(item);
        _context.SaveChanges();
    }
}