using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Serialization_on_Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\binaryDemo.dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Employee emp = new Employee
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Salary = Convert.ToInt32(txtSalary.Text)
                };
                binaryFormatter.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("Binary Serialization for Employee Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\binaryDemo.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Employee emp = (Employee)binaryFormatter.Deserialize(fs);
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\xmlDemo.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee emp = (Employee)xmlSerializer.Deserialize(fs);
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\xmlDemo.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee emp = new Employee
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Salary = Convert.ToInt32(txtSalary.Text)
                };
                xmlSerializer.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("Employee XML Serialization Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\soapDemo.soap", FileMode.Create, FileAccess.Write);
                SoapFormatter soapFormatter = new SoapFormatter();
               Employee emp = new Employee
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Salary = Convert.ToInt32(txtSalary.Text)
                };
                soapFormatter.Serialize(fs, emp);
                fs.Close();
                MessageBox.Show("SOAP Serialization Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\soapDemo.soap", FileMode.Open, FileAccess.Read);
                SoapFormatter soapFormatter = new SoapFormatter();
                Employee emp = (Employee)soapFormatter.Deserialize(fs);
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
                fs.Close();
                MessageBox.Show("SOAP Deserialization Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\jsonDemo.json", FileMode.Create, FileAccess.Write);
                Employee prod = new Employee
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Salary = Convert.ToInt32(txtSalary.Text)
                };
                JsonSerializer.Serialize(fs, prod);
                fs.Close();
                MessageBox.Show("JSON Serialization Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\jsonDemo.json", FileMode.Open, FileAccess.Read);
                Employee emp = JsonSerializer.Deserialize<Employee>(fs);
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtSalary.Clear();
        }
    }
}
