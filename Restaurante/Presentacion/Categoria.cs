using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurante.Datos;

namespace Restaurante.Presentacion
{
    public partial class Categoria : Form
    {
        Conexion Con;
       
        public Categoria()
        {
            InitializeComponent();
            Con = new Conexion();
            ShowCategory();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ShowCategory() 
        {
            try
            {
                string Query = "Select * From CategoriaTbl";
                CategoriasList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (CatNameTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Categoria = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Insert into CategoriaTbl Values ('{0}','{1}')";
                    Query = string.Format(Query, Categoria, Desc);
                    Con.SetData(Query);
                    ShowCategory();
                    MessageBox.Show("Categoria agregada con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar categoría: " + ex.Message);
                }
            
            }
        }

        int key = 0;
        private void CategoriasList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNameTb.Text = CategoriasList.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = CategoriasList.SelectedRows[0].Cells[2].Value.ToString();
            DescTb.Text = CategoriasList.SelectedRows[0].Cells[2].Value.ToString();

            if (CatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriasList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (CatNameTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Categoria = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "update CategoriaTbl set CatName = '{0}', CatDesc = '{1}' where CatCode = '{2}'";
                    Query = string.Format(Query, Categoria, Desc, key);
                    Con.SetData(Query);
                    ShowCategory();
                    MessageBox.Show("Categoria Actualiza con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Actualizar categoría: " + ex.Message);
                }

            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Debe seleccionar un elemento valido");
            }
            else
            {
                try
                {
                    string Categoria = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "delete from CategoriaTbl where CatCode = '{0}'";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowCategory();
                    MessageBox.Show("Categoria Eiminada con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Actualizar categoría: " + ex.Message);
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Pago obj = new Pago();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Pago obj = new Pago();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Categoria obj = new Categoria();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DescTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CatNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {

        }
    }
    }

        


