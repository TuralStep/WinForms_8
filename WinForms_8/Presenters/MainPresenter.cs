using WinForms_8.Models;
using WinForms_8.Repositories;
using WinForms_8.Views;

namespace WinForms_8.Presenters;


public class MainPresenter
{

    private readonly IMainView _mainView;
    private readonly IAddUpdateView _addUpdateView;

    private readonly BindingSource _bindingSource;
    private readonly IStudentRepository _repository;

    public MainPresenter(IMainView mainView, IAddUpdateView addUpdateView, IStudentRepository repo)
    {
        _mainView = mainView;
        _addUpdateView = addUpdateView;

        // Binding Source
        _bindingSource = new();
        _bindingSource.DataSource = _repository.GetList();
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


        bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(srcValue);

        _bindingSource.DataSource = isNullOrWhiteSpace switch
        {
            true => _repository.GetList(),
            false => _repository.GetList(s =>
                            s.FirstName
                            .Contains(srcValue, StringComparison.OrdinalIgnoreCase)
                            ||
                            s.LastName
                            .ToLower()
                            .Contains(srcValue, StringComparison.OrdinalIgnoreCase))
        };
    }


    private void _mainView_DeleteEvent(object? sender, EventArgs e)
    {
        var deletedItem = _bindingSource.Current as Student;

        if (deletedItem is null)
        {
            MessageBox.Show("You should select a student to delete...");
            return;
        }

        _repository.Remove(deletedItem);
        _bindingSource.Remove(deletedItem);

        MessageBox.Show($"Deleted student...");

    }


    private void _mainView_AddEvent(object? sender, EventArgs e)
    {

        ((Form)_addUpdateView).Text = "Add Page";
        _addUpdateView.ClearTexts();
        var result = _addUpdateView.ShowDialog();

        if (result == DialogResult.Cancel)
            return;

        var student = new Student()
        {
            FirstName = _addUpdateView.FirstName,
            LastName = _addUpdateView.LastName,
            BirthOfDate = _addUpdateView.DateOfBirth,
            Score = (float)_addUpdateView.Score
        };

        _repository.Add(student);
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

        ((Form)_addUpdateView).Text = "Update Page";
        var updatingItem = (current as Student)!;

        _addUpdateView.FirstName = updatingItem.FirstName;
        _addUpdateView.LastName = updatingItem.LastName;
        _addUpdateView.Score = (decimal)updatingItem.Score;
        _addUpdateView.DateOfBirth = updatingItem.BirthOfDate;

        var result = _addUpdateView.ShowDialog();

        if (result is DialogResult.Cancel)
            return;

        updatingItem.FirstName = _addUpdateView.FirstName;
        updatingItem.LastName = _addUpdateView.LastName;
        updatingItem.BirthOfDate = _addUpdateView.DateOfBirth;
        updatingItem.Score = Convert.ToSingle(_addUpdateView.Score);

        _repository.Update(updatingItem);
        _bindingSource.ResetCurrentItem();

        MessageBox.Show("Succesfully updated student...");
    }

}