using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Business_Objects
{
    /// <summary>
    /// Objeto Path
    /// </summary>
    class Paths
    {
        #region Propiedades publicas
        public int idPath { get; set; }
        public int idFromCity { get; set; }
        public string PickUpPoint { get; set; }
        public string PickUpStreet { get; set; }
        public string PickUpNumber { get; set; }
        public string PickUpPostCode { get; set; }
        public int idToCity { get; set; }
        public string DropPoint { get; set; }
        public string DropStreet { get; set; }
        public string DropPostCode { get; set; }
        public int idThroughFrom1 { get; set; }
        public int idThroughFrom2 { get; set; }
        public int idThroughFrom3 { get; set; }
        public int idThroughFrom4 { get; set; }
        public int idThroughTo1 { get; set; }
        public int idThroughTo2 { get; set; }
        public int idThroughTo3 { get; set; }
        public int idThroughTo4 { get; set; }
        #endregion
    }
}
