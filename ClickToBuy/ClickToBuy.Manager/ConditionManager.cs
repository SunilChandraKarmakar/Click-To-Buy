using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class ConditionManager : BaseManager<Condition>, IConditionManager 
    {
        private readonly IConditionRepository _iConditionRepository;

        public ConditionManager(IConditionRepository iConditionRepository) : base(iConditionRepository)
        {
            _iConditionRepository = iConditionRepository;
        }

        public override ICollection<Condition> GetAll()
        {
            return _iConditionRepository.GetAll();
        }
    }
}
