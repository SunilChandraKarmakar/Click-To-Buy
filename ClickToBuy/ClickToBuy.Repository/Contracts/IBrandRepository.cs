using ClickToBuy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository.Contracts
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        public Brand CheckName(string name);
    }
}
