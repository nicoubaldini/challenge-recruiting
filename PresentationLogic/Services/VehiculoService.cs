using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public class VehiculoService : IVehiculoService
    {/*
        private readonly string _connString;

        public VehiculoService(string connString)
        {
            this._connString = connString;
        }

        public Vehiculo GetVehiculo(int id)
        {
            Vehiculo oVehiculo;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectVehiculo", conn);
                sqlComm.Parameters.AddWithValue("@id", id);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var row = dt.Rows[0];

                    oVehiculo = new Vehiculo
                    {
                        IdVehiculo = (Int32)row["Id"],
                        Marca = row["marca"].ToString(),
                        Modelo = row["modelo"].ToString(),
                        Patente = row["patente"].ToString(),
                    };

                    return oVehiculo;
                }

            }
        }
        

        public List<Vehiculo> GetAllVehiculos()
        {
            List<Vehiculo> lVehiculos = new List<Vehiculo>();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_selectAllVehiculos", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    var rows = dt.Rows;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var oVehiculo = new Vehiculo
                        {
                            IdVehiculo = (Int32)rows[i]["Id"],
                            Marca = rows[i]["marca"].ToString(),
                            Modelo = rows[i]["modelo"].ToString(),
                            Patente = rows[i]["patente"].ToString(),
                        };

                        lVehiculos.Add(oVehiculo);
                    }
                }
            }
            return lVehiculos;
        }
        

        public void InsertVehiculo(Vehiculo vehiculoToInsert)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {

                SqlCommand sqlComm = new SqlCommand("pr_insertVehiculo", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@marca", vehiculoToInsert.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", vehiculoToInsert.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", vehiculoToInsert.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void UpdateVehiculo(Vehiculo vehiculoToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_updateVehiculo", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id", vehiculoToUpdate.IdVehiculo);
                sqlComm.Parameters.AddWithValue("@marca", vehiculoToUpdate.Marca);
                sqlComm.Parameters.AddWithValue("@modelo", vehiculoToUpdate.Modelo);
                sqlComm.Parameters.AddWithValue("@patente", vehiculoToUpdate.Patente);
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteVehiculo(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand sqlComm = new SqlCommand("pr_deleteVehiculo", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@id", id);
 
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }
        */
    }
}
