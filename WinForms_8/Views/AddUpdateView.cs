using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_8.Views
{
    public partial class AddUpdateView : Form, IAddUpdateView
    {
        public AddUpdateView()
        {
            InitializeComponent();
            ClearTexts();
        }

        public string FirstName { get => txt_firstName.Text; set => txt_firstName.Text = value; }

        public string LastName { get => txt_lastName.Text; set => txt_lastName.Text = value; }

        public decimal Score { get => numeric_score.Value; set => numeric_score.Value = value; }

        public DateTime DateOfBirth { get => datePicker_birth.SelectionStart; set => datePicker_birth.SelectionStart = value; }

        public event EventHandler? SaveEvent;
        public event EventHandler? CancelEvent;

        private void btn_save_Click(object sender, EventArgs e) =>
            SaveEvent?.Invoke(sender, e);

        private void btn_cancel_Click(object sender, EventArgs e) =>
            CancelEvent?.Invoke(sender, e);

        public void ClearTexts()
        {
            txt_firstName.Text = string.Empty;
            txt_lastName.Text = string.Empty;
            numeric_score.Value = 1;
            datePicker_birth.SelectionStart = DateTime.Now;
        }
    }
}
