using System.Collections.Generic;


namespace UAMS.BL
{
    internal class StudentBL
    {
        private string Name;
        private int Age;
        private float FSC_Marks;
        private float ECAT_Marks;
        private List<string> preferences = new List<string>();
        private bool isRegistered;
        private string RegisteredProgram;
        private List<SubjectBL> RegisteredSubjects = new List<SubjectBL>();


        
        public StudentBL(string Name, int Age, float FSC_Marks, float ECAT_Marks)
        {
            this.Name = Name;
            this.Age = Age;
            this.FSC_Marks = FSC_Marks;
            this.ECAT_Marks = ECAT_Marks;
            isRegistered = false;
        }

        public float Merit()
        {
            float merit;

            merit = (FSC_Marks * 70 / 1100) + (ECAT_Marks * 30 / 400);

            return merit;
        }

        // Getters and Setters
        public string GetName()
        {
            return Name;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public int GetAge()
        {
            return Age;
        }

        public void SetAge(int Age)
        {
            this.Age = Age;
        }

        public float GetFSC_Marks()
        {
            return FSC_Marks;
        }

        public void SetFSC_Marks(float FSC_Marks)
        {
            this.FSC_Marks = FSC_Marks;
        }

        public float GetECAT_Marks()
        {
            return ECAT_Marks;
        }

        public void SetECAT_Marks(float ECAT_Marks)
        {
            this.ECAT_Marks = ECAT_Marks;
        }

        public List<string> GetPreferences()
        {
            return preferences;
        }

        public void SetPreferences(List<string> preferences)
        {
            this.preferences = preferences;
        }

        public bool GetIsRegistered()
        {
            return isRegistered;
        }

        public void SetIsRegistered(bool isRegistered)
        {
            this.isRegistered = isRegistered;
        }

        public string GetRegisteredProgram()
        {
            return RegisteredProgram;
        }

        public void SetRegisteredProgram(string RegisteredProgram)
        {
            this.RegisteredProgram = RegisteredProgram;
        }

        public List<SubjectBL> GetRegisteredSubjects()
        {
            return RegisteredSubjects;
        }

        public void SetRegisteredSubjects(List<SubjectBL> RegisteredSubjects)
        {
            this.RegisteredSubjects = RegisteredSubjects;
        }



        
        public void AddPreference(string preference)
        {
            preferences.Add(preference);
        }

        public void AddSubject(SubjectBL subject)
        {
            RegisteredSubjects.Add(subject);
        }



    }
}
