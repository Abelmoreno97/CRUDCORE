using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Data
{
    public class ContactData
    {
        public List<ContactModel> Listar()
        {
            var oLista = new List<ContactModel>();
            var cn = new Conection();
            using (var conection = new SqlConnection(cn.getCadenaSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conection);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactModel Obtener(int IdContacto)
        {
            var oContacto = new ContactModel();
            var cn = new Conection();
            using (var conection = new SqlConnection(cn.getCadenaSQL()))
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conection);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }
        
        public bool Guardar(ContactModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conection();
                using (var conection = new SqlConnection(cn.getCadenaSQL()))
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conection);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
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

        public bool Editar(ContactModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conection();
                using (var conection = new SqlConnection(cn.getCadenaSQL()))
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conection);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
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

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conection();
                using (var conection = new SqlConnection(cn.getCadenaSQL()))
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conection);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
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
