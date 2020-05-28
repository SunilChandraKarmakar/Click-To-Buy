using ClickToBuy.Model;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickToBuy.Repository
{
    public class ProductPhotoRepository : BaseRepository<ProductPhoto>, IProductPhotoRepository
    {
        public override ICollection<ProductPhoto> GetAll()
        {
            ICollection<ProductPhoto> productPhotos = ctbContext.ProductPhotos
                                                      .Include(pp => pp.Product).ToList();
            return productPhotos;
        }
    }
}
