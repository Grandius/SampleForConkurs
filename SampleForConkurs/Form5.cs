using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleForConkurs
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "someDatabaseDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.someDatabaseDataSet.Employees);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*for (int i = 1; i <= 8; i++)
            {
                SomeDatabaseDataSet.EditsHistoryRow editsRow = someDatabaseDataSet.EditsHistory.FindByHistory_ID(i);
                if (editsRow.Equals(null))
                {
                    MessageBox.Show("No edit found");
                }
                else
                {
                    MessageBox.Show("some text"+editsRow.ToString());
                }
            }*/
            //SomeDatabaseDataSet.EditsHistoryRow editsRow = someDatabaseDataSet.;
            //employeeSurname = employeeRow.Employee_Surname;
            //employeeName = employeeRow.Employee_Name;
            //MessageBox.Show(editsRow.EditBeginDate.ToShortDateString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createDoc();
            ExportTable("Otchet");
            SaveWorkbook();
            shutDown();
            MessageBox.Show("Excel-документ успешно сгенерирован!");
        }

        private Microsoft.Office.Interop.Excel.Application app;

        private Workbook workbook;
        private Worksheet previousWorksheet;

        string employeeSurname;
        string employeeName;
        string date;

        private void createDoc()

        {
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                Range workSheet_range = null;
                app.Visible = false;
                workbook = app.Workbooks.Add(1);


            }
            catch (Exception e)
            {
                Console.Write(e.ToString());

            }
            finally
            {
            }
        }

        public void shutDown()

        {
            try
            {
                workbook = null;

                app.Quit();
            }
            catch (Exception e)

            {
                Console.Write(e.ToString());
            }

            finally
            {
            }
        }

        public void ExportTable(string sheetName)

        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                "C:\\Users\\Адриан\\documents\\visual studio 2015\\Projects\\SampleForConkurs\\SampleForConkurs\\SomeDatabase.mdf" + ";Integrated Security=True";


            string ID = textBox1.Text;
            if (ID.Equals(null))
            {
                ID = "1";
            }
            int idInt = 0;
            date = dateTimePicker1.Text;
            string month = date.Substring(0, 2);
            string year = date.Substring(2, 4);

            try
            {
                idInt = int.Parse(ID);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            SomeDatabaseDataSet.EmployeesRow employeeRow = someDatabaseDataSet.Employees.FindByEmployee_ID(idInt);
            employeeSurname = employeeRow.Employee_Surname;
            employeeName = employeeRow.Employee_Name;

            string sql = "SELECT eh.Product_ID AS 'Код издания', p.ProductName AS 'Название издания', et.EditType_Name AS 'Название вида работы', eh.EditBeginDate AS 'Дата начала выполнения работы', " +
               "eh.EditEndDate AS 'Дата окончания выполнения работы' FROM EditsHistory eh, EditsType et, Products p WHERE p.Product_ID=eh.Product_ID AND et.EditTypeID=eh.EditType_ID AND" +
               " Employee_ID = " + ID + "AND eh.EditBeginDate";

            SqlConnection myConnection = new SqlConnection(connectionString);

            SqlDataReader myReader = null;



            try
            {
                Worksheet worksheet = (Worksheet)workbook.Sheets.Add(Missing.Value, Missing.Value, 1, XlSheetType.xlWorksheet);
                worksheet.Name = sheetName;
                previousWorksheet = worksheet;
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myReader = myCommand.ExecuteReader();
                int columnCount = myReader.FieldCount;
                for (int n = 0; n < columnCount; n++)
                {
                    Console.Write(myReader.GetName(n) + "\t");

                    createHeaders(worksheet, 1, n + 1, myReader.GetName(n));

                }
                int rowCounter = 2;
                while (myReader.Read())
                {
                    for (int n = 0; n < columnCount; n++)
                    {
                        Console.WriteLine();
                        Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                        addData(worksheet, rowCounter, n + 1, myReader[myReader.GetName(n)].ToString());
                    }
                    rowCounter++;
                }
                worksheet.Columns.AutoFit();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (myConnection != null)
                {
                    myConnection.Close();
                }

                myReader = null;
                myConnection = null;
            }

        }
        
        public void createHeaders(Worksheet worksheet, int row, int col, string htext)

        {
            worksheet.Cells[row, col] = htext;
        }

        public void addData(Worksheet worksheet, int row, int col, string data)

        {
            worksheet.Cells[row, col] = data;

        }
        
        public void SaveWorkbook()
        {
            String folderPath = "e:\\SampleConcursExcel\\";

            if (!System.IO.Directory.Exists(folderPath))
            {

                System.IO.Directory.CreateDirectory(folderPath);

            }

            string fileNameBase = employeeSurname + " "+ employeeName + " Отчёт";
            String fileName = fileNameBase;
            string ext = ".xlsx";
            int counter = 1;

            while (System.IO.File.Exists(folderPath + fileName + ext))
            {

                fileName = fileNameBase + counter;
                counter++;
            }

            fileName = fileName + ext;

            string filePath = folderPath + fileName;

            try
            {
                workbook.SaveAs(filePath, XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }
    }
}
