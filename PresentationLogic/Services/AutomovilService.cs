
using Enums.PresentationLogic;
using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public class AutomovilService : IAutomovilService
    {
        private readonly string _connString;
        public AutomovilService(string connString)
        {
            this._connString = connString;
        }

        public Automovil GetAutomovil(int id)
        {
            Automovil oAutomovil;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAutomovil", conn);
                sqlComm.Parameters.AddWithValue("@id", id);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var row = dt.Rows[0];

                    TipoAutomovil tipo;
                    Enum.TryParse(row["tipo"].ToString(), out tipo);

                    oAutomovil = new Automovil
                    {
                        IdAutomovil = (Int32)row["id"],
                        Tipo = tipo,
                        CantPuertas = (Int32)row["cant_puertas"],
                        Marca = row["marca"].ToString(),
                        Modelo = row["modelo"].ToString(),
                        Patente = row["patente"].ToString(),
                    };

                    return oAutomovil;
                }

            }
        }

        public List<Automovil> GetAllAutomoviles()
        {
            List<Automovil> lAutomoviles = new List<Automovil>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAllAutomoviles", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TipoAutomovil tipo;
                        Enum.TryParse(rows[i]["tipo"].ToString(), out tipo);
                        var oAutomovil = new Automovil
                        {
                            IdAutomovil = (Int32)rows[i]["id"],
                            IdVehiculo = (Int32)rows[i]["id_vehiculo"],
                            Tipo = tipo,
                            CantPuertas = (Int32)rows[i]["cant_puertas"],
                            Marca = rows[i]["marca"].ToString(),
                            Modelo = rows[i]["modelo"].ToString(),
                            Patente = rows[i]["patente"].ToString(),
                        };

                        lAutomoviles.Add(oAutomovil);
                    }
                }
            }
            return lAutomoviles;
        }

        public void InsertAutomovil(Automovil automovilToInsert)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_insertAutomovil", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@tipo", automovilToInsert.Tipo);
                sqlComm.Parameters.AddWithValue("@cant_puertas", automovilToInsert.CantPuertas);
                sqlComm.Parameters.AddWithValue("@marca", automovilToInsert.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", automovilToInsert.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", automovilToInsert.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateAutomovil(Automovil automovilToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_updateAutomovil", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_automovil", automovilToUpdate.IdAutomovil);
                sqlComm.Parameters.AddWithValue("@tipo", automovilToUpdate.Tipo);
                sqlComm.Parameters.AddWithValue("@cant_puertas", automovilToUpdate.CantPuertas);
                sqlComm.Parameters.AddWithValue("@marca", automovilToUpdate.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", automovilToUpdate.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", automovilToUpdate.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteAutomovil(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_deleteAutomovil", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_automovil", id);

                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
