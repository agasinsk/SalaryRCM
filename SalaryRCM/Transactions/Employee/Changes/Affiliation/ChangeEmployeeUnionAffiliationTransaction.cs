using PayrollSystem.Models;

namespace PayrollSystem.Transactions.Employee.Changes.Affiliation
{
    public class ChangeEmployeeUnionAffiliationTransaction : ChangeEmployeeAffiliationTransaction
    {
        private readonly double dues;
        private readonly int memberId;

        public ChangeEmployeeUnionAffiliationTransaction(int employeeId, int memberId, double dues) : base(employeeId)
        {
            this.dues = dues;
            this.memberId = memberId;
        }

        protected override Models.Affiliation GetAffiliation()
        {
            return new UnionAffiliation(memberId, dues);
        }

        protected override void RecordAffiliation(Models.Employee employee)
        {
            payrollDatabase.AddUnionMember(memberId, employee);
        }
    }
}