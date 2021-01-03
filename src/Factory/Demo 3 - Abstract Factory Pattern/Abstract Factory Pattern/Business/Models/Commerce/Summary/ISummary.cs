﻿using System.Collections.Generic;
using System.Text;

namespace Abstract_Factory_Pattern.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);
        void Send();
    }
}
