using ClickToBuy.Manager.Base;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Manager
{
    public class SliderManager : BaseManager<Slider>, ISliderManager
    {
        private readonly ISliderRepository _iSliderRepository;

        public SliderManager(ISliderRepository iSliderRepository) : base(iSliderRepository)
        {
            _iSliderRepository = iSliderRepository;
        }
    }
}
