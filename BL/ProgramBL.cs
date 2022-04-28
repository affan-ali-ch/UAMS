using System.Collections.Generic;

namespace UAMS.BL
{
    internal class ProgramBL
    {
        private string DegreeTitle;
        private string DurationOfDegree;
        private int Seats;
        private List<SubjectBL> OfferedSubjects = new List<SubjectBL>();

        public ProgramBL(string DegreeTitle, string DurationOfDegree, int Seats)
        {
            this.DegreeTitle = DegreeTitle;
            this.DurationOfDegree = DurationOfDegree;
            this.Seats = Seats;
        }

        public ProgramBL(string DegreeTitle, string DurationOfDegree, int Seats, List<SubjectBL> OfferedSubjects)
        {
            this.DegreeTitle = DegreeTitle;
            this.DurationOfDegree = DurationOfDegree;
            this.Seats = Seats;
            this.OfferedSubjects = OfferedSubjects;
        }

        // getters and setters
        public string GetDegreeTitle()
        {
            return DegreeTitle;
        }

        public string GetDurationOfDegree()
        {
            return DurationOfDegree;
        }

        public int GetSeats()
        {
            return Seats;
        }

        public List<SubjectBL> GetOfferedSubjects()
        {
            return OfferedSubjects;
        }

        public void SetDegreeTitle(string DegreeTitle)
        {
            this.DegreeTitle = DegreeTitle;
        }

        public void SetDurationOfDegree(string DurationOfDegree)
        {
            this.DurationOfDegree = DurationOfDegree;
        }

        public void SetSeats(int Seats)
        {
            this.Seats = Seats;
        }

        public void SetOfferedSubjects(List<SubjectBL> OfferedSubjects)
        {
            this.OfferedSubjects = OfferedSubjects;
        }

        //AddOfferedSubjects
        public void AddOfferedSubjects(SubjectBL OfferedSubject)
        {
            OfferedSubjects.Add(OfferedSubject);
        }


    }
}
