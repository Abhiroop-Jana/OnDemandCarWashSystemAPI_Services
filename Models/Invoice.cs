﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDemandCarWashSystemAPI.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public string CustomerName { get; set; }
        public DateTime DateTime { get; set; }
        public decimal OrderTotal { get; set; }
        public string PaymentStatus { get; set; }
        public string PackageName { get; set; }
        public string CarName { get; set; }
        public string WasherName { get; set; }
    }
}
