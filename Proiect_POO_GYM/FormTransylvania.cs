using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_POO_GYM
{
    public partial class FormTransylvania : Form
    {
        private readonly FormGYM _parent;
        public string id, name, sex, location, type;
        public FormTransylvania( FormGYM parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Subscription ";
            btnSave.Text = "Update";
            textName.Text = name;
            textSex.Text = sex;
            textLocation.Text = location;
            textType.Text = type;

        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Subscription ";
            btnSave.Text = "Save";
        }

        public void Clear()
        {
            textName.Text = textSex.Text = textLocation.Text = textType.Text = String.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(textName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Subscription name is Empty (> 3).");
                return;
            }
            if (textSex.Text.Trim().Length < 1)
            {
                MessageBox.Show("Subscription sex is Empty (> 3).");
                return;
            }
            if (textLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("Subscription location is Empty (> 3).");
                return;
            }
            if (textType.Text.Trim().Length == 0)
            {
                MessageBox.Show("Subscription type is Empty (> 3).");
                return;
            }
            if(btnSave.Text == "Save")
            {
                Subscription std = new Subscription(textName.Text.Trim(), textSex.Text.Trim(), textLocation.Text.Trim(), textType.Text.Trim());
                DbSubscription.AddSubscription(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Subscription std = new Subscription(textName.Text.Trim(), textSex.Text.Trim(), textLocation.Text.Trim(), textType.Text.Trim());
                DbSubscription.UpdateSubscription(std, id);
            }
            _parent.Display();
        }
    }
}
