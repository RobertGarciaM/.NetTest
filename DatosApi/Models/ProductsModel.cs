using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Api.Models
{
    [Table("Products", Schema = "dbo")]
    public class ProductsModel
    {
        [Key]
        public int idProduct { get; set; }
        public string Descripcion { get; set; }
        public int amount { get; set; }
        public int avalaible { get; set; }
    }
}
