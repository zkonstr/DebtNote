using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Payment
    {
        [Column("PaymentId")]
        public Guid Id { get; set; }
    }
}
