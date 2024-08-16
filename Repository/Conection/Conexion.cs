using Microsoft.Extensions.Configuration;
using System.IO;
using Repository.Conection;

namespace Repository.Conection
{
    public class Conexion : IConexion
    {
        //Operaciones a través de ADO .NET
        private string cadenaSQL = string.Empty;
        //Constructor de la clase
        public Conexion()
        {
            //Obtener la cadena de conexión
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        //Metodo para devolver la cadena
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}