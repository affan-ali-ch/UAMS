using System.Collections.Generic;
using System.Linq;

using System.IO;
using UAMS.BL;

namespace UAMS.DL
{
    internal class ProgramDL
    {
        static public List<ProgramBL> OfferedPrograms = new List<ProgramBL>();

        public static void WriteAllProgramsToFile(string path)
        {
 
            try
            {
                StreamWriter file = new StreamWriter(path, false);
                int temp = 0;
                if (file != null)
                {
                    foreach (ProgramBL program in OfferedPrograms)
                    {
                        if (temp != 0)
                        {
                            file.WriteLine();
                        }
                        temp++;
                        
                        file.Write(program.GetDegreeTitle());
                        file.Write(",");
                        file.Write(program.GetDurationOfDegree());
                        file.Write(",");
                        file.Write(program.GetSeats());
                        file.Write(",");

                        int counter = 0;
                        foreach (SubjectBL subject in program.GetOfferedSubjects())
                        {
                            if (counter != 0)
                            {
                                file.Write(";");
                            }
                            counter++;
                            file.Write(subject.GetSubjectCode());
                        }

                    }
                    file.Close();
                }
            }
            catch (FileNotFoundException)
            {
                File.Create(path);
            }

        }

        public static void LoadProgramFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            
            foreach(string line in lines)
            {
                string[] elements = line.Split(',');

                string DegreeTitle = elements[0];
                string DurationOfDegree = elements[1];
                int Seats = int.Parse(elements[2]);
                string OfferedSubjects = elements[3];

                ProgramBL program = new ProgramBL(DegreeTitle, DurationOfDegree, Seats);
                

                string[] subjects = OfferedSubjects.Split(';');

                foreach (string subject in subjects)
                {

                    SubjectBL s = SubjectDL.UniqueSubjects.Where(x => x.GetSubjectCode() == subject).First();

                    program.AddOfferedSubjects(s);


                }
                OfferedPrograms.Add(program);

            }
        }

        
    }
}
