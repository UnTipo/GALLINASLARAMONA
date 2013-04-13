using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Business_Objects;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Clase que nos devuelve todos los viajes guardados en la bbdd
    /// </summary>
    class Path_Repository
    {
        public string _connection;
        /// <summary>
        /// Metodo para establecer la cadena de conexion
        /// </summary>
        /// <param name="Connection">Connection String</param>
        public Path_Repository(string Connection)
        {
            _connection = Connection;
        }

        public List<Paths> GetAllthePaths()
        {
            return GetAllthePathsStore();
        }

        private List<Paths> GetAllthePathsStore()
        {
            throw new NotImplementedException();
        }

    }
}
