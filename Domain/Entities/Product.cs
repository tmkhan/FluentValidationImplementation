using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product:BaseEntity
    {
        //public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal rate { get; set; }
    }
}
