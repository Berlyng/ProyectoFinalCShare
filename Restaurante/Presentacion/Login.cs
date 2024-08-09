using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Con = new Conexion();
        }
        Conexion Con;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Usuariotb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacíos");
            }
            else if (Usuariotb.Text == "Admin" && PassTb.Text == "Admin")
            {
                Usuario obj = new Usuario();
                obj.Show();
                this.Hide();
            }
            else
            {
                // Asegúrate de que las cadenas estén rodeadas por comillas simples
                string Query = "Select * From UsuarioTbl where UName = '{0}' AND UPass = '{1}'";
                Query = string.Format(Query, Usuariotb.Text, PassTb.Text);

                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
                else
                {
                    Pago obj = new Pago();
                    obj.Show();
                    this.Hide();
                }
            }
        }
    }

}
