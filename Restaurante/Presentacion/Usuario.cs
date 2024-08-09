using Restaurante.Datos;
using Restaurante.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            Con = new Conexion();
            ShowUsers();

        }
        Conexion Con;

        private void ShowUsers()
        {
            try
            {
                string Query = "Select * From UsuarioTbl";
                UserList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nametb.Text == "" || Gencb.SelectedIndex == -1 || Passwordtb.Text == "" || Phonetb.Text == "" || Directiontb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Nombre = Nametb.Text;
                    string Genero = Gencb.SelectedItem.ToString();
                    string Clave = Passwordtb.Text;
                    string Telefono = Phonetb.Text;
                    string Direccion = Directiontb.Text;
                    string Query = "Insert into UsuarioTbl Values ('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Nombre, Genero, Clave, Telefono, Direccion);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("Usuario agregado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar Usuario: " + ex.Message);
                }

            }

        }
        int key = 0;

        private void UserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nametb.Text = UserList.SelectedRows[0].Cells[1].Value.ToString();
            Gencb.Text = UserList.SelectedRows[0].Cells[2].Value.ToString();
            Passwordtb.Text = UserList.SelectedRows[0].Cells[3].Value.ToString();
            Phonetb.Text = UserList.SelectedRows[0].Cells[4].Value.ToString();
            Directiontb.Text = UserList.SelectedRows[0].Cells[5].Value.ToString();

            if (Nametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = 0;
            if (Nametb.Text == "" || Gencb.SelectedIndex == -1 || Passwordtb.Text == "" || Phonetb.Text == "" || Directiontb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Nombre = Nametb.Text;
                    string Genero = Gencb.SelectedItem.ToString();
                    string Clave = Passwordtb.Text;
                    string Telefono = Phonetb.Text;
                    string Direccion = Directiontb.Text;
                    string Query = "Update UsuarioTbl set UName = '{0}',UGen = '{1}',UPass = '{2}',UPhone = '{3}',UAdrres ='{4}' where UId = {5}";
                    Query = string.Format(Query, Nombre, Genero, Clave, Telefono, Direccion, key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("Usuario Actualizado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al actualizar Usuario: " + ex.Message);
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Nombre = Nametb.Text;
                    string Genero = Gencb.SelectedItem.ToString();
                    string Clave = Passwordtb.Text;
                    string Telefono = Phonetb.Text;
                    string Direccion = Directiontb.Text;
                    string Query = "Delete from UsuarioTbl where UId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("Usuario Eliminado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al eliminar Usuario: " + ex.Message);
                }


            }
        }

        private void Categorialbl_Click(object sender, EventArgs e)
        {
            Categoria obj = new Categoria();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
