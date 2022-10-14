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
    public partial class AddView : Form, IAddView
    {
        public AddView()
        {
            InitializeComponent();
            ClearTexts();
        }

        public string FirstName => txt_firstName.Text;

        public string LastName => txt_lastName.Text;

        public decimal Score => numeric_score.Value;

        public DateTime DateOfBirth => datePicker_birth.SelectionStart;

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
