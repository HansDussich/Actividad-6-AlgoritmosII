using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace actividad6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con =new SqlConnection("server=DESKTOP-4UL2PG6; database=actividad6; integrated security = true");


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string cadena = "select * from tb_inventario";

            SqlCommand comand = new SqlCommand(cadena, con);

            SqlDataReader registros = comand.ExecuteReader();

            while(registros.Read())
            {

                textBox1.AppendText(registros["codigo"].ToString());
                textBox1.AppendText(" - "); 
                textBox1.AppendText(registros["nombre"].ToString()); 
                textBox1.AppendText(" - "); 
                textBox1.AppendText(registros["precio"].ToString());
                
                textBox1.AppendText(Environment.NewLine);

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string tex = textBox2.Text;
            string cad = "select * from tb_inventario where nombre='" + tex + "'";

            SqlCommand comand = new SqlCommand(cad, con);

            SqlDataReader registro = comand.ExecuteReader();

            if (registro.Read())
            {
                textBox1.Clear();

                textBox1.AppendText(registro["codigo"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText(registro["nombre"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText(registro["precio"].ToString());

            }
            else
            {
                MessageBox.Show("El producto " + tex + " no se encuentra");
            }
            con.Close();

        }
    }
}
