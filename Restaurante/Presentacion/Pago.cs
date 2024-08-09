using Restaurante.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.Presentacion
{
    public partial class Pago : Form
    {
        public Pago()
        {
            InitializeComponent();
            Con = new Conexion();
            ShowItems();
        }
        Conexion Con;
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
        private void EditBtn_Click(object sender, EventArgs e)
        {
            Itemtb.Text = "";
            Preicetb.Text = "";
            CantidadTb.Text = "";
            key = 0;

        }

        private void PagoCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int GrTotal = 0;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            
            int n = PagoDGV.Rows.Count + 1; // Asegúrate de que el índice n sea único y no se resetee en cada click

            if (CantidadTb.Text == "" || Preicetb.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacíos");
            }
            else
            {
                int Total = Convert.ToInt32(CantidadTb.Text) * Convert.ToInt32(Preicetb.Text);

                // Crea una nueva fila y asigna celdas
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(PagoDGV); // Esto inicializa las celdas basadas en las columnas del DataGridView

                newRow.Cells[0].Value = n;
                newRow.Cells[1].Value = Itemtb.Text;
                newRow.Cells[2].Value = Preicetb.Text;
                newRow.Cells[3].Value = CantidadTb.Text;
                newRow.Cells[4].Value = "Rs " + Total;
                GrTotal = GrTotal + Total;
                GrTotallbl.Text = "Rs" + GrTotal;
                

                PagoDGV.Rows.Add(newRow);
            }
        }


        private void Pago_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Itemtb.Text = ItemList.SelectedRows[0].Cells[1].Value.ToString();
            //Catcb.Text = ItemList.SelectedRows[0].Cells[2].Value.ToString();
            Preicetb.Text = ItemList.SelectedRows[0].Cells[2].Value.ToString();
            if (Itemtb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void GrTotallbl_Click(object sender, EventArgs e)
        {

        }

        private void Cerrarbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Limpiarbtn_Click(object sender, EventArgs e)
        {
            // Limpia todas las filas del DataGridView
            PagoDGV.Rows.Clear();

            // Opcional: Reinicia el total general a 0
            GrTotal = 0;
            GrTotallbl.Text = "Rs " + GrTotal;

            // También puedes limpiar los campos de texto si es necesario
            Itemtb.Text = "";
            Preicetb.Text = "";
            CantidadTb.Text = "";
        }
    }
}
