﻿using pj_MVC_CRUD_bdventas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
                    cred_cli = (Int32)dr["cred_cli"],
                    fec_nac = (DateTime)dr["fec_nac"],
                    cod_dist = dr.GetInt32(dr.GetOrdinal("cod_dist"))
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