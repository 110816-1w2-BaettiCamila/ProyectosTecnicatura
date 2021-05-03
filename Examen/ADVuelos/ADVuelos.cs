using AeropuertoBAETTI.Models;
using AeropuertoBAETTI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AeropuertoBAETTI.ADVuelos
{
    public class ADVuelos
    {
        public static List<DestinoItemViewModel> ObtenerListaDestinos()
        {
            List<DestinoItemViewModel> resultado = new List<DestinoItemViewModel>();

            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Destino";
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
                        DestinoItemViewModel aux = new DestinoItemViewModel();
                        aux.idDestino = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();


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
        public static List<TipoItemViewModel> ObtenerListaTipos()
        {
            List<TipoItemViewModel> resultado = new List<TipoItemViewModel>();

            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM TipoCarga";
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
                        TipoItemViewModel aux = new TipoItemViewModel();
                        aux.idTipoCarga = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();


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

        internal static List<Vuelo> ObtenerListaVuelosConsigna()
        {


            List<Vuelo> resultado = new List<Vuelo>();

            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT DISTINCT * FROM Vuelo ORDER BY idTipoDeCarga DESC ";
                                
                                
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
                        Vuelo aux = new Vuelo();
                        aux.pidDestino = int.Parse(dr["IdDestino"].ToString());
                        aux.pidTipoCarga = int.Parse(dr["IdTipoDeCarga"].ToString());
                        aux.ptipo = int.Parse(dr["Tipo"].ToString());
                        aux.pIdVuelo = int.Parse(dr["Id"].ToString());
                        aux.pfecha = DateTime.Parse(dr["Fecha"].ToString());
                        aux.pobservaciones = dr["Tipo"].ToString();



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



        public static bool InsertarVuelo(Vuelo vuelo)
        {
            bool resultado = false;
            //setear la cadena de conexion de la bd desde webConfig
            string cadenaBD = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaBD);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Vuelo values(@Observaciones, @idDestino, @idTipoDeCarga, @Fecha, @Tipo)";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Observaciones", vuelo.pobservaciones);
                cmd.Parameters.AddWithValue("@idDestino", vuelo.pidDestino);
                cmd.Parameters.AddWithValue("@idTipoDeCarga", vuelo.pidTipoCarga);
                cmd.Parameters.AddWithValue("@Fecha", vuelo.pfecha);
                cmd.Parameters.AddWithValue("@Tipo", vuelo.ptipo);

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
