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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void authorsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.authorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void productTypeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productTypeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.someDatabaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.ProductType". При необходимости она может быть перемещена или удалена.
            this.productTypeTableAdapter.Fill(this.someDatabaseDataSet.ProductType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Authors". При необходимости она может быть перемещена или удалена.
            this.authorsTableAdapter.Fill(this.someDatabaseDataSet.Authors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.someDatabaseDataSet.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
