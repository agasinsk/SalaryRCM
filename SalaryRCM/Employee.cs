﻿namespace SalaryRCM
{
    public class Employee
    {
        public string Address { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public PaymentClassification PaymentClassification { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentSchedule PaymentSchedule { get; set; }

        public Employee(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}