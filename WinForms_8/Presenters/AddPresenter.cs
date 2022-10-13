using System.Text;
using WinForms_8.Views;

namespace WinForms_8.Presenters;


public class AddPresenter
{

    private readonly IAddView _addView;

    public AddPresenter(IAddView addView)
    {
        _addView = addView;

        _addView.SaveEvent += _addView_SaveEvent;
        _addView.CancelEvent += _addView_CancelEvent;

    }

    private void _addView_CancelEvent(object? sender, EventArgs e)
    {
        ((Form)_addView).DialogResult = DialogResult.Cancel;
    }

    private void _addView_SaveEvent(object? sender, EventArgs e)
    {
        StringBuilder sb = new();

        string fName = _addView.FirstName;
        string lName = _addView.LastName;
        DateTime bDate = _addView.DateOfBirth;

        if (string.IsNullOrWhiteSpace(fName) || fName.Length < 3)
            sb.Append("First name is incorrect...\n");

        if (string.IsNullOrWhiteSpace(lName) || lName.Length < 3)
            sb.Append("Last name is incorrect...\n");

        if ((DateTime.Now - bDate).Days / 365 < 18)
            sb.Append("Age must be at least 18...\n");

        if (sb.Length > 0)
        {
            MessageBox.Show(sb.ToString(), "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ((Form)_addView).DialogResult = DialogResult.OK;
    }
}