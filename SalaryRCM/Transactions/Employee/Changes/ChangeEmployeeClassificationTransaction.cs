﻿using PayrollSystem.PaymentClassifications;
using PayrollSystem.PaymentSchedules;

namespace PayrollSystem.Transactions.Employee.Changes
{
    public abstract class ChangeEmployeeClassificationTransaction : ChangeEmployeeTransaction
    {
        protected ChangeEmployeeClassificationTransaction(int employeeId) : base(employeeId)
        {
        }

        protected override void Change(Models.Employee employee)
        {
            employee.PaymentClassification = GetPaymentClassification();
            employee.PaymentSchedule = GetPaymentSchedule();
        }

        protected abstract PaymentClassification GetPaymentClassification();

        protected abstract PaymentSchedule GetPaymentSchedule();
    }
}