using Model.Entities;
using Repository.Conection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class EmployeerRepository : IEmployerRepository
    {

        private readonly IConexion _conexionBd;

        //Inyeccion de dependencias
        public EmployeerRepository(IConexion conexion)
        {
            this._conexionBd = conexion;
        }

        public List<EmployeerEntity> List()
        {
            var oLista = new List<EmployeerEntity>();

            using (var conexion = new SqlConnection(_conexionBd.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_list_employeer", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                //Leer el resultado del sp_get_employeer
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmployeerEntity()
                        {
                            IdEmployeers = Convert.ToInt32(dr["IdEmployee"]),
                            Name = dr["NameEmployee"].ToString(),
                            Position = dr["Position"].ToString(),
                            Office = dr["Office"].ToString(),
                            Salary = Convert.ToDecimal(dr["Salary"])
                        });
                    }
                }
            }
            return oLista;
        }


        //Metodo para obtener un contacto a través de su id
        public EmployeerEntity Get(int IdEmployeers)
        {
            var oEmployee = new EmployeerEntity();

            using (var conexion = new SqlConnection(_conexionBd.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_get_employee", conexion);
                cmd.Parameters.AddWithValue("IdEmployee", IdEmployeers);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmployee.IdEmployeers = Convert.ToInt32(dr["IdEmployee"]);
                        oEmployee.Name = dr["NameEmployee"].ToString();
                        oEmployee.Position = dr["Position"].ToString();
                        oEmployee.Office = dr["Office"].ToString();
                        oEmployee.Salary = Convert.ToDecimal(dr["Salary"]);
                    }
                }
            }
            return oEmployee;
        }


        //Metodo para añadir un empleado 
        public bool Add(EmployeerEntity oemployee)
        {
            bool rpta;
            
            try
            {
                using (var conexion = new SqlConnection(_conexionBd.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_add_employee", conexion);
                    cmd.Parameters.AddWithValue("NameEmployee", oemployee.Name);
                    cmd.Parameters.AddWithValue("Position", oemployee.Position);
                    cmd.Parameters.AddWithValue("Office", oemployee.Office);
                    cmd.Parameters.AddWithValue("Salary", oemployee.Salary);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        //Método para editar un empleado
        public bool Update(EmployeerEntity oemployee)
        {
            bool rpta;

            try
            {
                using (var conexion = new SqlConnection(_conexionBd.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_employee", conexion);
                    cmd.Parameters.AddWithValue("IdEmployee", oemployee.IdEmployeers);
                    cmd.Parameters.AddWithValue("NameEmployee", oemployee.Name);
                    cmd.Parameters.AddWithValue("Position", oemployee.Position);
                    cmd.Parameters.AddWithValue("Office", oemployee.Office);
                    cmd.Parameters.AddWithValue("Salary", oemployee.Salary);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        //Método para eliminar un empleado
        public bool Delete(int IdEmployeers)
        {
            bool rpta;

            try
            {
                using (var conexion = new SqlConnection(_conexionBd.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_employee", conexion);
                    cmd.Parameters.AddWithValue("IdEmployee", IdEmployeers);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

    }
}
