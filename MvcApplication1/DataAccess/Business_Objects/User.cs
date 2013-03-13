using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.DataAccess.Business_Objects
{
    public class User
    {

        public int iduser { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string photoPath { get; set; }
        public string genre { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int idCity { get; set; }
        public string mobileTelephone { get; set; }
        public string homeTelephone { get; set; }
        public string occupation { get; set; }
        public DateTime dateOfRegistration { get; set; }
        public DateTime dateLastSession { get; set; }
        public bool isEmailConfirmed { get; set; }
        public string personalDescription { get; set; }
    }
}