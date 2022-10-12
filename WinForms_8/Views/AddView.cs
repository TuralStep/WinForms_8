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
        }

        public string FirstName => txt_firstName.Text;

        public string LastName => txt_lastName.Text;

        public decimal Score => numeric_score.Value;

        public DateTime DateOfBirth => datePicker_birth.SelectionStart;

        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
