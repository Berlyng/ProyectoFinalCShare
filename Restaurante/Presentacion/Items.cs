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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Conexion();
            ShowItems();
            GetCategoria();
        }
        Conexion Con;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ShowItems()
        {
            try
            {
                string Query = "Select * From ItemTbl";
                ItemList.DataSource = Con.GetData(Query);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void GetCategoria()
        {
            string Query = "Select * From CategoriaTbl";
            Catcb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            Catcb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            Catcb.DataSource = Con.GetData(Query);
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || Catcb.SelectedIndex == -1)
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Categoria = Catcb.SelectedValue.ToString();
                    int precio = Convert.ToInt32(PriceTb.Text);
                    string Query = "Insert into ItemTbl Values ('{0}','{1}','{2}')";
                    Query = string.Format(Query, Name, Categoria, precio);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item agregado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar categoría: " + ex.Message);
                }

            }
        }
        int key = 0;
        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ItemList.SelectedRows[0].Cells[1].Value.ToString();
            Catcb.Text = ItemList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemList.SelectedRows[0].Cells[3].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void Editbtx_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || Catcb.SelectedIndex == -1)
            {
                MessageBox.Show("Los campos no pueden estar vacio");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Categoria = Catcb.SelectedValue.ToString();
                    int precio = Convert.ToInt32(PriceTb.Text);
                    string Query = "update ItemTbl set ItName = '{0}', ItCategoria = '{1}', ItPrice = '{2}' where ItNum = '{3}'";
                    Query = string.Format(Query, Name,Categoria, precio, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Actualizado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Actualizar categoría: " + ex.Message);
                }

            }
        }

        private void Deletebtx_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Debe seleccionar un elemento valido");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Categoria = Catcb.SelectedValue.ToString();
                    int precio = Convert.ToInt32(PriceTb.Text);
                    string Query = "delete from ItemTbl where ItNum = '{0}'";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Eiminado con exito");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al Actualizar categoría: " + ex.Message);
                }

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

        private void label4_Click(object sender, EventArgs e)
        {
            Categoria obj = new Categoria();
            obj.Show();
            this.Hide();
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
