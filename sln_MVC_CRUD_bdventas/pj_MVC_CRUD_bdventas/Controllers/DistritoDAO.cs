using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration; // leer web.config
using System.Data; // propiedades para los elementos de  ADO .Net
using System.Data.SqlClient; // utilizar los elementos de SQL Client
using pj_MVC_CRUD_bdventas.Models; // utilizar los modelos


namespace pj_MVC_CRUD_bdventas.Controllers
{
    public class DistritoDAO
    {
        string cad_cn =
            ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<DistritoModel> ListarDistritos()
        {
            List<DistritoModel> lista = new List<DistritoModel>();
            //
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open();
            //
            SqlCommand cmd = new SqlCommand("PA_LISTAR_DISTRITOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //
            SqlDataReader dr = cmd.ExecuteReader();
            //
            DistritoModel var_modelo = null;
            //
            while (dr.Read())
            {
                var_modelo = new DistritoModel()
                {
                    // llenar desde el reader a los campos del modelo
                    cod_dist = dr.GetInt32(0),
                    nom_dist = (string)dr["nom_dist"]
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

    }
}