using ClickToBuy.Database.Migrations;
using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager 
    {
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryManager(ICategoryRepository iCategoryRepository) : base(iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        public override ICollection<Category> GetAll()
        {
            return _iCategoryRepository.GetAll();
        }

        public Category CheckName(string name)
        {
            return _iCategoryRepository.CheckName(name);
        }

        public ICollection<Category> GetCategoryForPurchaseProduct()
        {
            return _iCategoryRepository.GetCategoryForPurchaseProduct();
        }
    }
}
