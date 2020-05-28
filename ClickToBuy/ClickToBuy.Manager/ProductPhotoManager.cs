using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class ProductPhotoManager : BaseManager<ProductPhoto>, IProductPhotoManager
    {
        private readonly IProductPhotoRepository _iProductPhotoRepository;

        public ProductPhotoManager(IProductPhotoRepository iProductPhotoRepository) : base(iProductPhotoRepository)
        {
            _iProductPhotoRepository = iProductPhotoRepository;
        }

        public override ICollection<ProductPhoto> GetAll()
        {
            return _iProductPhotoRepository.GetAll();
        }
    }
}
