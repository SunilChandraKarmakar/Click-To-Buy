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
    public class ConditionRepository : BaseRepository<Condition>, IConditionRepository 
    {
        public override ICollection<Condition> GetAll()
        {
            List<Condition> conditionList = ctbContext.Conditions.Include(c => c.Products).ToList();
            return conditionList;
        }
    }
}
