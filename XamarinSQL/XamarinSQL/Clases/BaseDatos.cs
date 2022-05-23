// En serio, en serio, no sigas este tutorial
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace XamarinSQL.Clases
{
    public static class BaseDatos
    {
        static string cadenaConexion = @"data source=10.12.129.226;initial catalog=Empresa;user id=sa;password=tupassword; Connect Timeout=60";

        public static List<Empleados> ObtenerEmpleados()
        {
            List<Empleados> listaEmpleados = new List<Empleados>();
            string sql = "SELECT * FROM Empleados";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleados empleado = new Empleados()
                            {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Salario = reader.GetDecimal(2)
                            };

                            listaEmpleados.Add(empleado);
                        }
                    }
                }

                con.Close();

                return listaEmpleados;
            }
        }

        public static void AgregarEmpleado(Empleados empleado)
        {
            string sql = "INSERT INTO Empleados (Nombre,Salario) VALUES(@nombre, @salario)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = empleado.Nombre;
                    comando.Parameters.Add("@salario", SqlDbType.Decimal).Value = empleado.Salario;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static void ModificarEmpleado(Empleados empleado)
        {
            string sql = "UPDATE Empleados set Nombre = @nombre, Salario = @salario WHERE ID = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = empleado.Nombre;
                        comando.Parameters.Add("@salario", SqlDbType.Decimal).Value = empleado.Salario;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = empleado.ID;
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void EliminarEmpleado(Empleados empleado)
        {
            string sql = "DELETE FROM Empleados WHERE ID = @id";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = empleado.ID;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
}
