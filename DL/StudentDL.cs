using System.Collections.Generic;

using UAMS.BL;


namespace UAMS.DL
{
    internal class StudentDL
    {
        static public List<StudentBL> Students = new List<StudentBL>();

        static public void LoadStudentsFromFile(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                string Name = fields[0];
                int Age = int.Parse(fields[1]);
                int FSCMarks = int.Parse(fields[2]);
                int ECATMarks = int.Parse(fields[3]);
                string[] Preferences = fields[4].Split(';');
                bool IsRegistered = bool.Parse(fields[5]);
                string RegisteredProgram = fields[6];
                string[] RegisteredSubjects = fields[7].Split(':');

                StudentBL student = new StudentBL(Name, Age, FSCMarks, ECATMarks);
                
                foreach(string preference in Preferences)
                {
                    student.AddPreference(preference);
                }

                student.SetIsRegistered(IsRegistered);

                student.SetRegisteredProgram(RegisteredProgram);

                foreach(string subject in RegisteredSubjects)
                {
                    SubjectBL s = SubjectDL.UniqueSubjects.Find(x => x.GetSubjectCode() == subject);
                    student.AddSubject(s);
                }

                Students.Add(student);
            }
        }
        
        static public void StoreAllStudentsToFile(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            foreach (StudentBL student in Students)
            {
                string line = student.GetName() + "," + student.GetAge() + "," + student.GetFSC_Marks() + "," + student.GetECAT_Marks() + ",";
                foreach (string preference in student.GetPreferences())
                {
                    line += preference + ";";
                }
                line = line.Substring(0, line.Length - 1);
                line += "," + student.GetIsRegistered() + "," + student.GetRegisteredProgram() + ",";
                foreach (SubjectBL subject in student.GetRegisteredSubjects())
                {
                    line += subject.GetSubjectCode() + ":";
                }
                line = line.Substring(0, line.Length - 1);
                file.WriteLine(line);
            }

            file.Flush();
            file.Close();
            
        }

    }
}
