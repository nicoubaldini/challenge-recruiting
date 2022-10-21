using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresentationLogic.Services
{
    public class RepuestoService : IRepuestoService
    {
        private readonly string _connString;
        public RepuestoService(string connString)
        {
            this._connString = connString;
        }

        public List<Repuesto> GetAllRepuestos()
        {
            List<Repuesto> lRepuestos = new List<Repuesto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAllRepuestos", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oRepuesto = new Repuesto
                        {
                            IdRepuesto = (Int32)rows[i]["id"],
                            Nombre = rows[i]["nombre"].ToString(),
                            Precio = Convert.ToDouble(rows[i]["precio"])
                        };

                        lRepuestos.Add(oRepuesto);
                    }
                }
            }
            return lRepuestos;
        }

        public Repuesto GetRepuesto(int id)
        {
            Repuesto oRepuesto;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectRepuesto", conn);
                sqlComm.Parameters.AddWithValue("@id", id);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var row = dt.Rows[0];

                    oRepuesto = new Repuesto
                    {
                        IdRepuesto = (Int32)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Precio = Convert.ToDouble(row["precio"])
                    };

                    return oRepuesto;
                }
            }
        }

        public List<Repuesto> GetRepuestosFromDesperfecto(int idRepuesto)
        {
            List<Repuesto> lRepuestos = new List<Repuesto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectRepuestosFromDesperfectos", conn);
                sqlComm.Parameters.AddWithValue("@id_desperfecto", idRepuesto);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oRepuesto = new Repuesto
                        {
                            IdRepuesto = (Int32)rows[i]["id"],
                            Nombre = rows[i]["nombre"].ToString(),
                            Precio = Convert.ToDouble(rows[i]["precio"])
                        };

                        lRepuestos.Add(oRepuesto);
                    }
                }
            }

         
            return lRepuestos;
            
        }

        public void InsertRepuesto(Repuesto repuestoToInsert)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_insertRepuesto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@nombre", repuestoToInsert.Nombre);
                sqlComm.Parameters.AddWithValue("@precio", repuestoToInsert.Precio);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateRepuesto(Repuesto repuestoToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_updateRepuesto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_repuesto", repuestoToUpdate.IdRepuesto);
                sqlComm.Parameters.AddWithValue("@nombre", repuestoToUpdate.Nombre);
                sqlComm.Parameters.AddWithValue("@precio", repuestoToUpdate.Precio);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteRepuesto(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_deleteRepuesto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_repuesto", id);

                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}