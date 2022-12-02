using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserItemReference
    {
        [Column("UserItemReferenceId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(PaymentItem))]
        public Guid PaymentItemId { get; set; }
        public PaymentItem? PaymentItem { get; set; }

        [ForeignKey(nameof(Commiter))]
        public Guid CommiterId { get; set; }
        public User? Commiter { get; set; }

        [ForeignKey(nameof(Recepient))]
        public Guid RecepientId { get; set; }
        public User? Recepient { get; set; }

    }
}
