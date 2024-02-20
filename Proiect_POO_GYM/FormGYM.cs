namespace Proiect_POO_GYM
{
    public partial class FormGYM : Form
    {
        FormTransylvania form;
        public FormGYM()
        {
            InitializeComponent();
            form = new FormTransylvania(this);
        }

        private void FormGYM_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            DbSubscription.DisplayAndSearch("SELECT ID, Name, Sex, Location, Type FROM subscription_tabel", dataGridView1);

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbSubscription.DisplayAndSearch("SELECT ID, Name, Sex, Location, Type FROM subscription_tabel WHERE Name LIKE '%"+ txtSearch.Text +"%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //EDIT
                form.Clear();
                form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.sex = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.location = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.type = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //DELETE
                if(MessageBox.Show("Do you want to delete?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbSubscription.DeleteSubscription(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}