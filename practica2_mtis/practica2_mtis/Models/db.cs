using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Collections;

namespace practica2_mtis.Models
{
    public class db
    {

        private SqlConnection c;

        public db()
        {
            c = new SqlConnection();
            c.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFileName=|DataDirectory|\\db_mtis.mdf; Integrated Security=True";
        }

        public void AsignarUsuario(string dni, string sala)
        {
            c.Open();

            SqlCommand cmd = new SqlCommand("insert into Sala (Sala, dni) values(@Sala, @dni)", c);
            
            cmd.Parameters.AddWithValue("@Sala", sala);
            cmd.Parameters.AddWithValue("@dni", dni);
           
            cmd.ExecuteNonQuery();
            c.Close();
        }

        public bool ValidarSalaUsuario(string dni, string sala)
        {
            bool existe = false;
            c.Open();
            SqlCommand com = new SqlCommand("Select * from Sala where dni ='" + dni + "' and Sala ='" + sala + "'", c);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                existe = true;
            }
            dr.Close();
            c.Close();

            return existe;
        }

        public void CrearEmpleado(string dni, string nombre, string apellidos, string direccion, string poblacion, string telefono, string email, string fecha_nacimiento, string nss, string iban)
        {
            c.Open();

            SqlCommand cmd = new SqlCommand("insert into Empleado (DNI, Nombre, Apellidos, Direccion, Poblacion, Telefono, Email, Fecha_Nacimiento, NSS, IBAN) values(@DNI, @Nombre, @Apellidos, @Direccion, @Poblacion, @Telefono, @Email, @Fecha_Nacimiento, @NSS, @IBAN)", c);

            DateTime fn = DateTime.Parse(fecha_nacimiento);
            cmd.Parameters.AddWithValue("@DNI", dni);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Apellidos", apellidos);
            cmd.Parameters.AddWithValue("@Direccion", direccion);
            cmd.Parameters.AddWithValue("@Poblacion", poblacion);
            cmd.Parameters.AddWithValue("@Telefono",telefono );
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fn);
            cmd.Parameters.AddWithValue("@NSS", nss);
            cmd.Parameters.AddWithValue("@IBAN", iban);

            cmd.ExecuteNonQuery();
            c.Close();
        }

        public void BorrarEmpleado(string dni)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand("delete from Empleado where DNI =  @dni", c);

            cmd.Parameters.AddWithValue("@dni", dni);

            cmd.ExecuteNonQuery();
            c.Close();
        }

        public void BorraUsuarioSala(string dni, string sala)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand("delete from Sala where dni =  @dni AND Sala = @sala", c);

            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@sala",sala);

            cmd.ExecuteNonQuery();
            c.Close();
        }

        public bool ComprobarApiKey(string restkey)
        {
            bool existe = false;
            c.Open();
            SqlCommand com = new SqlCommand("Select * from restkey where restkey =" + restkey, c);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                existe = true;
            }
            dr.Close();
            c.Close();

            return existe;
        }

        public List<string> ListaNiveles(string dni)
        {
            c.Open();
            SqlCommand com = new SqlCommand("SELECT Sala FROM Sala WHERE dni ='" + dni + "'", c);
            SqlDataReader dr = com.ExecuteReader();

            List<string> lista = new List<string>();

            while(dr.Read())
            {
                lista.Add(dr.GetString(0));
            }
            dr.Close();
            c.Close();

            return lista;
        }

        public practica2_mtis.Empleado.Models.Empleado ConsultarEmpleado(string dni)
        {
            practica2_mtis.Empleado.Models.Empleado empleado = null;
            
            c.Open();
            SqlCommand com = new SqlCommand("Select * from Empleado where DNI ='" + dni + "'", c);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                empleado = new practica2_mtis.Empleado.Models.Empleado();

                empleado.DNI = dr["DNI"].ToString();
                empleado.Nombre = dr["Nombre"].ToString();
                empleado.Apellidos = dr["Apellidos"].ToString();
                empleado.Telefono = dr["Telefono"].ToString();
                empleado.Direccion = dr["Direccion"].ToString();
                empleado.Poblacion = dr["Poblacion"].ToString();
                empleado.Email = dr["Email"].ToString();
                empleado.Fecha_nacimiento = dr["Fecha_nacimiento"].ToString();
                empleado.NSS = dr["NSS"].ToString();
                empleado.IBAN = dr["IBAN"].ToString();
            }
            dr.Close();
            c.Close();

            return empleado;
        }

        public void ModificarEmpleado(string dni, string nombre, string apellidos, string direccion, string poblacion, string telefono, string email, string fecha_nacimiento, string nss, string iban)
        {
            c.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Empleado SET Nombre = @nombre, Apellidos = @apellidos, Direccion = @direccion, Poblacion = @poblacion, Telefono = @telefono, Email = @email, Fecha_nacimiento = @fn, NSS = @nss, IBAN = @iban WHERE DNI = '" + dni + "'", c);
            
            DateTime fn = DateTime.Parse(fecha_nacimiento);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@poblacion", poblacion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@nss", nss);
            cmd.Parameters.AddWithValue("@iban", iban);
            
            cmd.ExecuteNonQuery();
            c.Close();
        }

        
    }
}