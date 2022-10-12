using WinForms_8.Models;
using WinForms_8.Views;

namespace WinForms_8.Presenters;


public class MainPresenter
{

    private readonly IMainView _mainView;
    private readonly IAddView _addView;
    private readonly BindingSource _bindingSource;
    private readonly List<Student> _students;

    public MainPresenter(IMainView mainView, IAddView addView)
    {
        _mainView = mainView;
        _addView = addView;

        _students = new List<Student>()
        {
            new Student("Miri","Huseynzade",new DateOnly(2003,9,1),8.3f),
            new Student("Tural","Haci-Nebili",new DateOnly(2007,6,24),9.7f),
            new Student("Kamran","Kerimzade",new DateOnly(1999,3,27),10.2f)
        };

        // Binding Source
        _bindingSource = new();
        _bindingSource.DataSource = _students;
        _mainView.SetStudentListBindingSource(_bindingSource);


        // Events
        _mainView.SearchEvent += _mainView_SearchEvent;
        _mainView.DeleteEvent += _mainView_DeleteEvent;
        _mainView.AddEvent += _mainView_AddEvent;
    }


    private void _mainView_SearchEvent(object? sender, EventArgs e)
    {
        var srcValue = _mainView.SearchValue;
        if (!string.IsNullOrWhiteSpace(srcValue))
            _bindingSource.DataSource = _students
                .Where(s =>
                            s.FirstName
                            .ToLower()
                            .Contains(srcValue)
                            ||
                            s.LastName
                            .ToLower()
                            .Contains(srcValue))
                .ToList();
        else
            _bindingSource.DataSource = _students;
    }


    private void _mainView_DeleteEvent(object? sender, EventArgs e)
    {
        var deletedItem = _bindingSource.Current;

        if (deletedItem is null)
        {
            MessageBox.Show("You should select a student to delete...");
            return;
        }

        _bindingSource.Remove(deletedItem);

        MessageBox.Show($"Deleted student...");

    }


    private void _mainView_AddEvent(object? sender, EventArgs e)
    {

        var result = ((Form)_addView).ShowDialog();

        if (result == DialogResult.Cancel)
            return;

        var student = new Student()
        {
            FirstName = _addView.FirstName,
            LastName = _addView.LastName,
            BirthOfDate = DateOnly.Parse(_addView.DateOfBirth.ToShortDateString()),
            Score = (float)_addView.Score
        };

        _bindingSource.Add(student);

        MessageBox.Show("Succesfully added student...");

    }

}