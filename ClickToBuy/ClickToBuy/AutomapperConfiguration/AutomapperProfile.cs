using AutoMapper;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickToBuy.AutomapperConfiguration
{
    public class AutomapperProfile : Profile 
    {
        public AutomapperProfile()
        {
            CreateMap<PurchaseCreateView, Purchase>();
            CreateMap<PurchaseCreateView, PurchasePayment>();
            CreateMap<PurchaseCreateView, StockProduct>();
        }
    }
}
