using System;
using System.Collections.Generic;

using System.Configuration; // Leer web.config
using System.Data;          // propiedades para los elementos de ADO .Net
using System.Data.SqlClient; // utilizar los modelos de SQL Client
using pj_MVC_CRUD_bdventas.Models; //utilizar los modelos
using System.Reflection;
using System.Linq;
using System.Web;

namespace pj_MVC_CRUD_bdventas.Controllers
{
    public class ClienteDAO
    {
        string cad_cn =
            ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<ClienteModel> ListarClientes(string eli_cli)
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("PA_LISTAR_CLIENTES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            cmd.Parameters.AddWithValue("@eli_cli", eli_cli);
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            ClienteModel var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new ClienteModel()
                {
                    // llenar desde el reader a los campos del modelo
                    cod_cli = dr.GetString(0),
                    nom_cli = (string)dr["nom_cli"],
                    tel_cli = dr.GetString(2),
                    cor_cli = dr.GetString(3),
                    dir_cli = dr.GetString(4),
                    cred_cli = (Int32)dr["cred_cli"], // es igual al getInt32 pues es entero
                    fec_nac = (DateTime)dr["fec_nac"],
                    cod_dist = dr.GetInt32(dr.GetOrdinal("cod_dist")) //trae la columna 7, no importa el orden
                };
                //
                lista.Add(var_modelo);
            }
            //
            dr.Close();
            //
            cnx.Close();
            //
            return lista;
        }

        public String GrabarCliente(ClienteModel var_objeto)
        {
            String mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("PA_INSERTAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 8 parámetros
                cmd.Parameters.AddWithValue("@cod_cli", var_objeto.cod_cli);
                cmd.Parameters.AddWithValue("@nom_cli", var_objeto.nom_cli);
                cmd.Parameters.AddWithValue("@tel_cli", var_objeto.tel_cli);
                cmd.Parameters.AddWithValue("@cor_cli", var_objeto.cor_cli);
                cmd.Parameters.AddWithValue("@dir_cli", var_objeto.dir_cli);
                cmd.Parameters.AddWithValue("@cred_cli", var_objeto.cred_cli);
                cmd.Parameters.AddWithValue("@fec_nac", var_objeto.fec_nac);
                cmd.Parameters.AddWithValue("@cod_dist", var_objeto.cod_dist);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "El Cliente: " + var_objeto.nom_cli + " fué agregado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }
        public String ActualizarCliente(ClienteModel var_objeto)
        {
            String mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("PA_ACTUALIZAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 8 parámetros
                cmd.Parameters.AddWithValue("@cod_cli", var_objeto.cod_cli);
                cmd.Parameters.AddWithValue("@nom_cli", var_objeto.nom_cli);
                cmd.Parameters.AddWithValue("@tel_cli", var_objeto.tel_cli);
                cmd.Parameters.AddWithValue("@cor_cli", var_objeto.cor_cli);
                cmd.Parameters.AddWithValue("@dir_cli", var_objeto.dir_cli);
                cmd.Parameters.AddWithValue("@cred_cli", var_objeto.cred_cli);
                cmd.Parameters.AddWithValue("@fec_nac", var_objeto.fec_nac);
                cmd.Parameters.AddWithValue("@cod_dist", var_objeto.cod_dist);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "El Cliente: " + var_objeto.cod_cli +
                          " fué actualizado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }

        public String EliminarCliente(string cod_cli)
        {
            String mensaje = "";
            //
            SqlConnection cn = new SqlConnection(cad_cn);
            try
            {
                cn.Open();
                //
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 1 parámetro
                cmd.Parameters.AddWithValue("@cod_cli", cod_cli);
                //
                cmd.ExecuteNonQuery();
                //
                mensaje = "El Cliente: " + cod_cli +
                          " fué eliminado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }


    }
}