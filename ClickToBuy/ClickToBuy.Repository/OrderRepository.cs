﻿using ClickToBuy.Model;
using ClickToBuy.Repository.Base;
using ClickToBuy.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickToBuy.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
    }
}
