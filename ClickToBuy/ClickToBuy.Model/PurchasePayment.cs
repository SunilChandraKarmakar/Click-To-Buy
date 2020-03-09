using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Model
{
    public class PurchasePayment
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }

        public Purchase Purchase { get; set; }
    }
}
