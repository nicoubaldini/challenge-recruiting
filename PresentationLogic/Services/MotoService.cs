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
    public class MotoService : IMotoService
    {
        private readonly string _connString;
        public MotoService(string connString)
        {
            this._connString = connString;
        }
        public List<Moto> GetAllMotos()
        {
            List<Moto> lMotos = new List<Moto>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAllMotos", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oMoto = new Moto
                        {
                            IdMoto = (Int32)rows[i]["Id"],
                            Cilindrada = (bool)rows[i]["cilindrada"],
                            Marca = rows[i]["marca"].ToString(),
                            Modelo = rows[i]["modelo"].ToString(),
                            Patente = rows[i]["patente"].ToString(),
                        };

                        lMotos.Add(oMoto);
                    }
                }
            }
            return lMotos;
        }

        public Moto GetMoto(int id)
        {
            Moto oMoto;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectMoto", conn);
                sqlComm.Parameters.AddWithValue("@id", id);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var row = dt.Rows[0];

                    oMoto = new Moto
                    {
                        IdMoto = (Int32)row["Id"],
                        Cilindrada = (bool)row["cilindrada"],
                        Marca = row["marca"].ToString(),
                        Modelo = row["modelo"].ToString(),
                        Patente = row["patente"].ToString(),
                    };

                    return oMoto;
                }

            }
        }

        public void InsertMoto(Moto motoToInsert)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_insertMoto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@cilindrada", motoToInsert.Cilindrada);
                sqlComm.Parameters.AddWithValue("@marca", motoToInsert.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", motoToInsert.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", motoToInsert.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateMoto(Moto motoToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_updateMoto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_moto", motoToUpdate.IdMoto);
                sqlComm.Parameters.AddWithValue("@cilindrada", motoToUpdate.Cilindrada);
                sqlComm.Parameters.AddWithValue("@marca", motoToUpdate.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", motoToUpdate.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", motoToUpdate.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteMoto(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_deleteMoto", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id_moto", id);

                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
