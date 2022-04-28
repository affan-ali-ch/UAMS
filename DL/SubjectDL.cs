using System.Collections.Generic;
using System.Linq;

using UAMS.BL;
using System.IO;

namespace UAMS.DL
{
    internal class SubjectDL
    {
        public static List<SubjectBL> UniqueSubjects = new List<SubjectBL>();

        // get Unique Subjects from ProgramDL.OfferedPrograms
        public static void GetUniqueSubjects()
        {
            foreach (var program in ProgramDL.OfferedPrograms)
            {
                foreach (var subject in program.GetOfferedSubjects())
                {
                    var temp = UniqueSubjects.Select(x => x.GetSubjectCode()).ToList();

                    bool flag = true;
                    foreach (string SubjectCode in temp)
                    {
                        if ((subject.GetSubjectCode() == SubjectCode))
                        {
                            flag = false;
                        }
                    }
                    if(flag == true)
                    {
                        UniqueSubjects.Add(subject);
                    }
                }
            }
        }

        // store the subjects in the text file
        public static void StoreSubjects(string path)
        {
            
            StreamWriter file = new StreamWriter(path, false);

            int counter = 0;
            foreach (var subject in UniqueSubjects)
            {
                if(counter != 0)
                {
                    file.WriteLine();
                }
                file.Write(subject.GetSubjectCode());
                file.Write(",");
                file.Write(subject.GetSubjectType());
                file.Write(",");
                file.Write(subject.GetCreditHours());
                file.Write(",");
                file.Write(subject.GetSubjectFees());

                counter++;
            }
            
            file.Flush();
            file.Close();

        }

        // Load Subjects from file
        public static void LoadSubjects(string path)
        {
            string[] lines = File.ReadAllLines(path);

            foreach(string line in lines)
            {
                string[] elements = line.Split(',');
                string SubjectCode = elements[0];
                string SubjectType = elements[1];
                string CreditHours = elements[2];
                string SubjectFees = elements[3];

                SubjectBL subject = new SubjectBL(SubjectCode, int.Parse(CreditHours), SubjectType, int.Parse(SubjectFees));
                UniqueSubjects.Add(subject);

            }
        }
        

    }
}
