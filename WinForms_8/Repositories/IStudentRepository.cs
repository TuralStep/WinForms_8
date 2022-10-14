using WinForms_8.Models;

namespace WinForms_8.Repositories;


public interface IStudentRepository : IRepository<Student>
{

    Student GetById(Guid id);

}