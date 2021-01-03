﻿using System;
using System.Collections.Generic;

namespace Abstract_Factory_Pattern.Business.Models.Commerce.Invoice
{
    public interface IInvoice
    {
        public byte[] GenerateInvoice();
    }
}
