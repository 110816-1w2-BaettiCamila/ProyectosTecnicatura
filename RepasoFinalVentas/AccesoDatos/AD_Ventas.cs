using RepasoFinalVentas.Models;
using RepasoFinalVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RepasoFinalVentas.AccesoDatos
{
    public class AD_Ventas
    {
        public static List<FPItemViewModel> ObtenerListaFormaPago()
        {
            List<FPItemViewModel> resultado = new List<FPItemViewModel>();

            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM FormaPago";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        FPItemViewModel aux = new FPItemViewModel();
                        aux.id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.PorcentajeInteres = float.Parse(dr["PorcentajeInteres"].ToString());


                        resultado.Add(aux);
                    }

                }
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
        public static List<PLItemViewModel> ObtenerPlanCuotas()
        {
            List<PLItemViewModel> resultado = new List<PLItemViewModel>();

            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM PlanesCuotas";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        PLItemViewModel aux = new PLItemViewModel();
                        aux.id = int.Parse(dr["Id"].ToString());
                        aux.cantidadCuotas = int.Parse(dr["CantidadCuotas"].ToString());
                        aux.porcentajeInteres = float.Parse(dr["PorcentajeInteres"].ToString());


                        resultado.Add(aux);
                    }

                }
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


        public static bool InsertarVenta(Ventas venta)
        {
            bool resultado = false;
            //setear la cadena de conexion de la bd desde webConfig
            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Ventas values(@NombreCliente, @idFormaPago, @idPlanesCuota, @Importe)";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@NombreCliente", venta.pNombreCliente);
                cmd.Parameters.AddWithValue("@idFormaPago", venta.pIdFormaPago);
                cmd.Parameters.AddWithValue("@idPlanesCuota", venta.pIdPlanesCuotas);
                cmd.Parameters.AddWithValue("@Importe", venta.pImporte);
                

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