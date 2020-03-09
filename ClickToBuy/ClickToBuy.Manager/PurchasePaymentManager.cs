using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class PurchasePaymentManager : BaseManager<PurchasePayment>, IPurchasePaymentManager 
    {
        private readonly IPurchasePaymentRepository _iPurchasePaymentRepository;

        public PurchasePaymentManager(IPurchasePaymentRepository iPurchasePaymentRepository) : base(iPurchasePaymentRepository)
        {
            _iPurchasePaymentRepository = iPurchasePaymentRepository;
        }
    }
}
