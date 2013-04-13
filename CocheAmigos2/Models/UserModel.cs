using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CocheAmigos2.Models
{
    public class UserModel
    {

    }

    public class RegisterUserSimple
    {
        [Required]
        [Display(Name = "Sexo")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Año de nacimiento")]
        public string YearOfBirth { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Pais")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Código postal")]
        [DataType(DataType.Text)]
        public string PostCode { get; set; }


        
    }
}