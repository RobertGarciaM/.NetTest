using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Api.Models
{
    [Table("ReserveProduct", Schema = "dbo")]
    public class ReserveProductModel
    {
        [Key]
        public int idReserva { get; set; }
        public bool delete { get; set; }        
        public int idProducto { get; set; }
        public string idUser { get; set; }
        public virtual ProductsModel ProductsModel { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
