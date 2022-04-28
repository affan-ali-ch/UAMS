using System;
using System.Collections.Generic;
using System.Linq;
using UAMS.BL;

namespace UAMS.UI
{
    internal class ProgramUI
    {
        public static void PrintSpecificDegree(List<ProgramBL> OfferedPrograms, List<StudentBL> Students)
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Specific Degree Students");
            Console.WriteLine("  --------------------------------------");
            Console.WriteLine();

            List<StudentBL> RegisteredStudents = Students.Where(student => student.GetIsRegistered() == true).ToList();


            #region Checking if Any Degree Program is Available or Not
            if (OfferedPrograms.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  No Program is Offered !!");
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion


            #region Checking if Any Student is Available or Not
            if (Students.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  No Student is Added !!");
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion


            #region Checking if Any Student is Registered or Not
            if (RegisteredStudents.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  No Student is Registered Yet !!");
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion




            Console.Write("  Enter Degree Title: ");
            string degreeTitle = Console.ReadLine();


            #region Checking if Input Degree Title is Available in Offered Programs
            var validation = OfferedPrograms.Where(program => program.GetDegreeTitle() == degreeTitle).ToList();
            if (validation.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Degree Title");
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion


            #region Checking if Any Student is Registered with Input Degree Title or Not
            var check = RegisteredStudents.Where(student => student.GetRegisteredProgram() == degreeTitle).ToList();
            if (check.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  No Student Registered With this Degree");
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion


            int y = 11;

            Console.SetCursorPosition(3, y);
            Console.Write("Name");

            Console.SetCursorPosition(30, y);
            Console.Write("Age");

            Console.SetCursorPosition(50, y);
            Console.Write("FSC Marks");

            Console.SetCursorPosition(70, y);
            Console.Write("ECAT Marks");

            y++;

            Console.SetCursorPosition(3, y);
            Console.Write("-------");

            Console.SetCursorPosition(30, y);
            Console.Write("----");

            Console.SetCursorPosition(50, y);
            Console.Write("---------");

            Console.SetCursorPosition(70, y);
            Console.Write("----------");

            y++;


            foreach (ProgramBL p in OfferedPrograms)
            {
                if (p.GetDegreeTitle() == degreeTitle)
                {
                    foreach (StudentBL s in RegisteredStudents)
                    {
                        if (s.GetRegisteredProgram() == degreeTitle)
                        {
                            Console.SetCursorPosition(3, y);
                            Console.Write(s.GetName());


                            Console.SetCursorPosition(30, y);
                            Console.Write(s.GetAge());

                            Console.SetCursorPosition(50, y);
                            Console.Write(s.GetFSC_Marks());

                            Console.SetCursorPosition(70, y);
                            Console.Write(s.GetECAT_Marks());


                            y++;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Press Any Key to Continue...");
            Console.ReadKey();

        }

        public static ProgramBL AddProgram()
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Add Degree Program");
            Console.WriteLine("  -------------------------------");
            Console.WriteLine();

            Console.Write("  Enter Degree Title: ");
            string DegreeTitle = Console.ReadLine();

            Console.Write("  Enter Duration of Degree: ");
            string DurationOfDegree = Console.ReadLine();

            Console.Write("  Enter Seats for Degree: ");
            int Seats = 0;
            try
            {
                Seats = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Input !!");
                Console.WriteLine();
                Console.WriteLine("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }

            ProgramBL program = new ProgramBL(DegreeTitle, DurationOfDegree, Seats);

            int subjects;
            Console.Write("  Enter How Many Subjects to Enter: ");
            try
            {
                subjects = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Input !!");
                Console.WriteLine();
                Console.WriteLine("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }


            for (int i = 0; i < subjects; i++)
            {
                Console.WriteLine();
                SubjectBL subject = new SubjectBL();

                Console.Write("  Enter Subject Code: ");
                subject.SetSubjectCode(Console.ReadLine());

                // check if subject code already exists
                if (program.GetOfferedSubjects().Exists(x => x.GetSubjectCode() == subject.GetSubjectCode()))
                {
                    Console.WriteLine();
                    Console.WriteLine("  Subject Code Already Exists !!");
                    Console.WriteLine();
                    Console.Write("  Press Any Key to Continue...");
                    Console.ReadKey();
                    return null;
                }

                Console.Write("  Enter Subject Type: ");
                subject.SetSubjectType(Console.ReadLine());

                Console.Write("  Enter Subject Credit Hours: ");
                subject.SetCreditHours(int.Parse(Console.ReadLine()));

                Console.Write("  Enter Subject Fees: ");
                subject.SetSubjectFees(int.Parse(Console.ReadLine()));

                program.AddOfferedSubjects(subject);
            }


            //OfferedPrograms.Add(program);

            Console.WriteLine();
            Console.Write("  Press Any Key to Go Back...");
            Console.ReadKey();
            return program;

        }
        
    }
}
