using System;
using System.Collections.Generic;
using System.Text;
using Factory_Method_Pattern.Business.Models.Commerce;

namespace Factory_Method_Pattern.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
