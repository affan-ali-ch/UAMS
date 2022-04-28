
namespace UAMS.BL
{
    internal class SubjectBL
    {
        private string SubjectCode;
        private int CreditHours;
        private string SubjectType;
        private int SubjectFees;

        public SubjectBL()
        {
            SubjectCode = "";
            CreditHours = 0;
            SubjectType = "";
            SubjectFees = 0;
        }

        public SubjectBL(string SubjectCode, int CreditHours, string SubjectType, int SubjectFees)
        {
            this.SubjectCode = SubjectCode;
            this.CreditHours = CreditHours;
            this.SubjectType = SubjectType;
            this.SubjectFees = SubjectFees;
        }

        public string GetSubjectCode()
        {
            return SubjectCode;
        }

        public int GetCreditHours()
        {
            return CreditHours;
        }

        public string GetSubjectType()
        {
            return SubjectType;
        }

        public int GetSubjectFees()
        {
            return SubjectFees;
        }

        public void SetSubjectCode(string SubjectCode)
        {
            this.SubjectCode = SubjectCode;
        }

        public void SetCreditHours(int CreditHours)
        {
            this.CreditHours = CreditHours;
        }

        public void SetSubjectType(string SubjectType)
        {
            this.SubjectType = SubjectType;
        }

        public void SetSubjectFees(int SubjectFees)
        {
            this.SubjectFees = SubjectFees;
        }


    }
}
