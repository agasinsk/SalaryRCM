﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Models.PaymentClassifications
{
    public class CommisionedPaymentClassification : PaymentClassification
    {
        private readonly List<SalesReceipt> salesReceipts;
        public double CommisionRate { get; }
        public double Salary { get; }

        public CommisionedPaymentClassification(double salary, double commisionRate)
        {
            Salary = salary;
            CommisionRate = commisionRate;
            salesReceipts = new List<SalesReceipt>();
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            salesReceipts.Add(salesReceipt);
        }

        public override double CalculatePay(DateTime paycheckDate)
        {
            var salesAmount = salesReceipts.Where(sr => IsSalesReceiptInPayPeriod(sr, paycheckDate)).Sum(sr => sr.Amount);
            return Salary + salesAmount * CommisionRate;
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            return salesReceipts.Find(sr => sr.Date == date);
        }

        private bool IsSalesReceiptInPayPeriod(SalesReceipt sr, DateTime paycheckDate)
        {
            var payPeriodStart = paycheckDate.Subtract(TimeSpan.FromDays(12));

            return sr.Date <= paycheckDate && sr.Date >= payPeriodStart;
        }
    }
}