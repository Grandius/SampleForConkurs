using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleForConkurs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }
        private void departmentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.departmentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }
        private void positionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.positionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.someDatabaseDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.someDatabaseDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Departments". При необходимости она может быть перемещена или удалена.
            this.departmentsTableAdapter.Fill(this.someDatabaseDataSet.Departments);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
