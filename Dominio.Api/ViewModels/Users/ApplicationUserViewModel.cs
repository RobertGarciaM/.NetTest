using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Api.ViewModels.Users
{
    public class ApplicationUserViewModel
    {
        public string UserName { get; set; }
        public string NombreCompleto { get; set; }
        public int? Edad { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; }
        public string Rol { get; set; }
    }
}
