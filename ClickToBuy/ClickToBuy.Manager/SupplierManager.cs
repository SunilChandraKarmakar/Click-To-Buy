using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class SupplierManager : BaseManager<Supplier>, ISupplierManager 
    {
        private readonly ISupplierRepository _iSupplierRepository;

        public SupplierManager(ISupplierRepository iSupplierRepository) : base(iSupplierRepository)
        {
            _iSupplierRepository = iSupplierRepository;
        }
    }
}
