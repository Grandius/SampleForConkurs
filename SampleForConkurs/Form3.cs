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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void editsTypeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.editsTypeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void editsHistoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.editsHistoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.someDatabaseDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.someDatabaseDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.EditsType". При необходимости она может быть перемещена или удалена.
            this.editsTypeTableAdapter.Fill(this.someDatabaseDataSet.EditsType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.EditsHistory". При необходимости она может быть перемещена или удалена.
            this.editsHistoryTableAdapter.Fill(this.someDatabaseDataSet.EditsHistory);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
