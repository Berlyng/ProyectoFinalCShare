using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurante.Datos
{
    public class Conexion
    {
        // Campos privados para la conexión y comandos SQL
        public SqlConnection Con { get; private set; }
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter Sda;
        private string ConStr;

        // Constructor que inicializa la conexión con la base de datos
        public Conexion()
        {
            // Cadena de conexión generada con el archivo .udl
            ConStr = @"Data Source=Berlyng;Initial Catalog=BD_RESTAURANTE;Persist Security Info=True;User ID=user_vr;Password=admin;Encrypt=True;TrustServerCertificate=True";

            // Inicializar la conexión y el comando
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public string GetConnectionString()
        {
            return ConStr;
        }

        // Método para obtener datos de la base de datos
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            try
            {
                // Utilizar la conexión SqlConnection en lugar de la cadena de conexión directamente
                using (Sda = new SqlDataAdapter(Query, Con))
                {
                    Sda.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al obtener datos: " + ex.Message);
            }

            return dt;
        }


        // Método para ejecutar comandos de modificación de datos (INSERT, UPDATE, DELETE)
        public int SetData(string Query)
        {
            int Cnt = 0;
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                Cmd.CommandText = Query;
                Cnt = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al modificar datos: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }

            return Cnt;
        }

        // Método opcional para probar la conexión
        public bool TestConnection()
        {
            try
            {
                Con.Open();
                Console.WriteLine("Conexión exitosa.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return false;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }
    }
}



