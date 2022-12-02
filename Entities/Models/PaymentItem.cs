using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PaymentItem
    {
        [Column("PaymentItemId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Payment))]
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey(nameof(Sku))]
        public Guid SkuId { get; set; }
        public Sku Sku { get; set; }
    }
}
