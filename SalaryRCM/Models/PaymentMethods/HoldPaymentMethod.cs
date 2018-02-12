﻿using System;

namespace PayrollSystem.Models.PaymentMethods
{
    public class HoldPaymentMethod : PaymentMethod
    {
        public string Address { get; }

        public HoldPaymentMethod(string address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}