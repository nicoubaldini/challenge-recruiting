using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresentationLogic.Services
{
    public class DesperfectoService : IDesperfectoService
    {
        private readonly string _connString;
        public DesperfectoService(string connString)
        {
            this._connString = connString;
        }
        public List<Desperfecto> GetAllDesperfectos()
        {
            List<Desperfecto> lDesperfectos = new List<Desperfecto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAllDesperfectos", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oDesperfecto = new Desperfecto
                        {
                            IdDesperfecto = (Int32)rows[i]["id"],
                            IdVehiculo = (Int32)rows[i]["id_vehiculo"],
                            Descripcion = rows[i]["descripcion"].ToString(),
                            ManoObra = Convert.ToDouble(rows[i]["mano_obra"]),
                            TiempoDias = (Int32)rows[i]["tiempo_dias"],
                        };

                        lDesperfectos.Add(oDesperfecto);
                    }
                }
            }
            return lDesperfectos;
        }

        public Desperfecto GetDesperfecto(int id)
        {
            Desperfecto oDesperfecto;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectDesperfecto", conn);
                sqlComm.Parameters.AddWithValue("@id", id);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var row = dt.Rows[0];

                    oDesperfecto = new Desperfecto
                    {
                        IdDesperfecto = (Int32)row["id"],
                        IdVehiculo = (Int32)row["id_vehiculo"],
                        Descripcion = row["descripcion"].ToString(),
                        ManoObra = Convert.ToDouble(row["mano_obra"]),
                        TiempoDias = (Int32)row["tiempo_dias"],
                    };

                    return oDesperfecto;
                }

            }
        }

        public List<Desperfecto> GetDesperfectosFromRepuesto(int idRepuesto)
        {
            List<Desperfecto> lDesperfectos = new List<Desperfecto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectDesperfectosFromRepuestos", conn);
                sqlComm.Parameters.AddWithValue("@id_repuesto", idRepuesto);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oDesperfecto = new Desperfecto
                        {
                            IdDesperfecto = (Int32)rows[i]["id"],
                            IdVehiculo = (Int32)rows[i]["id_vehiculo"],
                            Descripcion = rows[i]["descripcion"].ToString(),
                            ManoObra = Convert.ToDouble(rows[i]["mano_obra"]),
                            TiempoDias = (Int32)rows[i]["tiempo_dias"],
                        };

                        lDesperfectos.Add(oDesperfecto);
                    }
                }
            }
            return lDesperfectos;
        }


        public List<Desperfecto> GetDesperfectosFromVehiculo(int idVehiculo)
        {
            List<Desperfecto> lDesperfectos = new List<Desperfecto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectDesperfectosFromVehiculos", conn);
                sqlComm.Parameters.AddWithValue("@id_vehiculo", idVehiculo);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oDesperfecto = new Desperfecto
                        {
                            IdDesperfecto = (Int32)rows[i]["id"],
                            IdVehiculo = (Int32)rows[i]["id_vehiculo"],
                            Descripcion = rows[i]["descripcion"].ToString(),
                            ManoObra = Convert.ToDouble(rows[i]["mano_obra"]),
                            TiempoDias = (Int32)rows[i]["tiempo_dias"],
                        };

                        lDesperfectos.Add(oDesperfecto);
                    }
                }
            }
            return lDesperfectos;
        }

        public void InsertDesperfecto(Desperfecto desperfectoToInsert)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_insertDesperfecto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_vehiculo", desperfectoToInsert.IdVehiculo);
                sqlComm.Parameters.AddWithValue("@descripcion", desperfectoToInsert.Descripcion);
                sqlComm.Parameters.AddWithValue("@mano_obra", desperfectoToInsert.ManoObra);
                sqlComm.Parameters.AddWithValue("@tiempo_dias", desperfectoToInsert.TiempoDias);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateDesperfecto(Desperfecto desperfectoToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_updateDesperfecto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_desperfecto", desperfectoToUpdate.IdDesperfecto);
                sqlComm.Parameters.AddWithValue("@id_vehiculo", desperfectoToUpdate.IdVehiculo);
                sqlComm.Parameters.AddWithValue("@descripcion", desperfectoToUpdate.Descripcion);
                sqlComm.Parameters.AddWithValue("@mano_obra", desperfectoToUpdate.ManoObra);
                sqlComm.Parameters.AddWithValue("@tiempo_dias", desperfectoToUpdate.TiempoDias);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteDesperfecto(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_deleteDesperfecto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_desperfecto", id);

                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}