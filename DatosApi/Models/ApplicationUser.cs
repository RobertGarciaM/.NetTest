using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Api.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        public string Genero { get; set; }
        public string NombreCompleto { get; set; }
        public bool Eliminado { get; set; } = false;
    }
}
