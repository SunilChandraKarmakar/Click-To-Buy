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
    public class CloseTypeRepository : BaseRepository<CloseType>, ICloseTypeRepository 
    {
        public override ICollection<CloseType> GetAll()
        {
            List<CloseType> closeTypesList = ctbContext.CloseTypes.Include(c => c.Products).ToList();
            return closeTypesList;
        }
    }
}
