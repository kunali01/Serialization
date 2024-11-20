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

namespace Serialization
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
                Product prod = new Product
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text)
                };
                binaryFormatter.Serialize(fs, prod);
                fs.Close();
                MessageBox.Show("Binary Serialization Done!");
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
                Product prod = (Product)binaryFormatter.Deserialize(fs);
                txtId.Text = prod.Id.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product prod = new Product
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text)
                };
                xmlSerializer.Serialize(fs, prod);
                fs.Close();
                MessageBox.Show("XML Serialization Done!");
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
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product prod = (Product)xmlSerializer.Deserialize(fs);
                txtId.Text = prod.Id.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
                fs.Close();
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
                Product prod = new Product
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text)
                };
                soapFormatter.Serialize(fs, prod);
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
                Product prod = (Product)soapFormatter.Deserialize(fs);
                txtId.Text = prod.Id.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
                fs.Close();
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
                Product prod = new Product
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text)
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
                Product prod = JsonSerializer.Deserialize<Product>(fs);
                txtId.Text = prod.Id.ToString();
                txtName.Text = prod.Name;
                txtPrice.Text = prod.Price.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
        }
    }
}
