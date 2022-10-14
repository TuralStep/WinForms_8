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
        _mainView.UpdateEvent += _mainView_UpdateEvent;
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

        ((Form)_addView).Text = "Add Page";
        _addView.ClearTexts();
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


    private void _mainView_UpdateEvent(object? sender, EventArgs e)
    {
        var current = _bindingSource.Current;

        if (current is null)
        {
            MessageBox.Show("You should select a student to update it...", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        ((Form)_addView).Text = "Update Page";
        var updatingItem = (current as Student)!;

        foreach (var control in ((Form)_addView).Controls)
        {
            if (control is TextBox)
            {
                TextBox tb = (control as TextBox)!;
                switch (tb.Name)
                {
                    case "txt_firstName":
                        tb.Text = updatingItem.FirstName;
                        break;
                    case "txt_lastName":
                        tb.Text = updatingItem.LastName;
                        break;
                }
            }
            else if (control is NumericUpDown)
                (control as NumericUpDown)!.Value = (decimal)updatingItem.Score;
            else if (control is MonthCalendar)
            {
                (control as MonthCalendar)!.TodayDate = updatingItem.BirthOfDate.ToDateTime(new TimeOnly(0, 0, 0));
                (control as MonthCalendar)!.Update();
            }
        }

        var result = ((Form)_addView).ShowDialog();

        if (result is DialogResult.Cancel)
            return;

        updatingItem.FirstName = _addView.FirstName;
        updatingItem.LastName = _addView.LastName;
        updatingItem.BirthOfDate = DateOnly.Parse(_addView.DateOfBirth.ToShortDateString());
        updatingItem.Score = Convert.ToSingle(_addView.Score);

        _bindingSource[_bindingSource.IndexOf(current)] = updatingItem;

        MessageBox.Show("Succesfully updated student...");
    }

}