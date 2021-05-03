using StoneHengue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace StoneHengue.AccesoDatos
{
    public class AccesoDatos
    {
        public static bool InsertarAlumno(Alumno alumno)
        {
            bool resultado = false;
            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Alumnos values(@nombre, @apellido, @hermano, @estado )";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nombre", alumno.pNombre);
                cmd.Parameters.AddWithValue("@apellido", alumno.pApellido);
                cmd.Parameters.AddWithValue("@hermano", alumno.pHermanos);
                cmd.Parameters.AddWithValue("@estado", alumno.pEstado);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;

        }

        public static bool InsertarCuota(Cuota cuota)
        {
            bool resultado = false;
            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Cuotas values(@nro, @fechaPago, @monto, @idAlumno )";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nro", cuota.pNro);
                cmd.Parameters.AddWithValue("@fechaPago", cuota.pFechaPago);
                cmd.Parameters.AddWithValue("@monto", cuota.pMonto);
                cmd.Parameters.AddWithValue("@idAlumno", cuota.pidAlumno);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;

        }



    }
}