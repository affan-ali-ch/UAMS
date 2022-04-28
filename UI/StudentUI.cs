using System;
using System.Collections.Generic;
using System.Linq;

using UAMS.BL;

namespace UAMS.UI
{
    internal class StudentUI
    {
        public static void PrintRegisteredStudents(List<StudentBL> Students)
        {

            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > List of Registered Students");
            Console.WriteLine("  -----------------------------------------");
            Console.WriteLine();

            List<StudentBL> RegisteredStudents = Students.Where(student => student.GetIsRegistered() == true).ToList();


            if (RegisteredStudents.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  No Student Registered Yet !!");
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }

            int y = 9;

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


            foreach (StudentBL s in RegisteredStudents)
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

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Press Any Key to Continue...");
            Console.ReadKey();
        }

        static public StudentBL AddStudent(List<ProgramBL> OfferedPrograms)
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Add Student");
            Console.WriteLine("  -------------------------------");
            Console.WriteLine();

            #region Checking If Any Program is Offered or Not
            if (OfferedPrograms.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  No Programs Available !!");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            #endregion


            Console.Write("  Enter Student Name: ");
            string Name = Console.ReadLine();

            #region Validation on Student Age
            Console.Write("  Enter Student Age: ");
            int Age = 0;
            try
            {
                Age = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Age");
                Console.WriteLine();
                Console.WriteLine("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            #endregion


            #region Validations on Student Fsc Marks
            Console.Write("  Enter Student Fsc Marks: ");
            float FSC_Marks = 0;
            try
            {
                FSC_Marks = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Fsc Marks");
                Console.WriteLine();
                Console.WriteLine("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            if (FSC_Marks < 0 || FSC_Marks > 1100)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid Fsc Marks");
                Console.WriteLine();
                Console.WriteLine("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            #endregion


            #region Validations on Student ECAT Marks
            Console.Write("  Enter Student ECAT Marks: ");
            float ECAT_Marks;
            try
            {
                ECAT_Marks = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid ECAT Marks");
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }

            if (ECAT_Marks < 0 || ECAT_Marks > 400)
            {
                Console.WriteLine();
                Console.WriteLine("  Invalid ECAT Marks");
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            #endregion


            Console.WriteLine();
            Console.WriteLine("  Available Degree Programs");
            Console.WriteLine("  -------------------------");


            foreach (ProgramBL program in OfferedPrograms)
            {
                Console.Write("  ");
                Console.Write(program.GetDegreeTitle());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  Enter How Many Preference to Enter: ");
            int preferences;
            try
            {
                preferences = int.Parse(Console.ReadLine());
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

            #region Checking if Input Number of Preferences is Less than or Equal to Number of Available Programs
            if (preferences > OfferedPrograms.Count)
            {
                Console.WriteLine();
                Console.WriteLine("  Input is Greater Than Available Programs");
                Console.WriteLine();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return null;
            }
            #endregion
            
            
            StudentBL student = new StudentBL(Name, Age, FSC_Marks, ECAT_Marks);

            for (int i = 0; i < preferences; i++)
            {
                Console.WriteLine();
                Console.Write("  Enter Preference {0}: ", i + 1);
                string preference = Console.ReadLine();

                #region Checking if Input Preference is Available in Offered Programs
                int flag = 0;
                foreach (ProgramBL program in OfferedPrograms)
                {
                    if (program.GetDegreeTitle() == preference)
                    {
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("  Invalid Preference");
                    Console.WriteLine();
                    Console.Write("  Press Any Key to Continue...");
                    Console.ReadKey();
                    return null;
                }
                #endregion

                

                #region Checking if Input Preference is Already Entered

                for (int j = 0; j < student.GetPreferences().Count; j++)
                {
                    if (student.GetPreferences()[j] == preference)
                    {
                        Console.WriteLine();
                        Console.WriteLine("  Preference Already Entered");
                        Console.WriteLine();
                        Console.Write("  Press Any Key to Continue...");
                        Console.ReadKey();
                        return null;
                    }
                }

                #endregion


                student.AddPreference(preference);
            }

            //Students.Add(student);

            Console.WriteLine();
            Console.WriteLine("  Student Added Successfully !!");
            Console.WriteLine();
            Console.Write("  Press Any Key to Continue...");
            Console.ReadKey();
            return student;
        }

        public static void GenerateMerit(List<ProgramBL> OfferedPrograms, List<StudentBL> Students)
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Merit List");
            Console.WriteLine("  -------------------------------");
            Console.WriteLine();


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


            

            var StudentListByMerit = Students.OrderByDescending(student => student.Merit()).ToList();

            foreach (StudentBL s in StudentListByMerit)
            {
                foreach (string preferences in s.GetPreferences())
                {
                    foreach (ProgramBL p in OfferedPrograms)
                    {
                        if (p.GetDegreeTitle() == preferences)
                        {
                            if (s.GetIsRegistered() == false)
                            {
                                if (p.GetSeats() > 0)
                                {
                                    p.SetSeats(p.GetSeats() - 1);
                                    s.SetIsRegistered(true);
                                    s.SetRegisteredProgram(p.GetDegreeTitle());   
                                }
                            }
                        }
                    }
                }
            }

            foreach (StudentBL s in StudentListByMerit)
            {
                if (s.GetIsRegistered() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  {0} Did Not Get Admission", s.GetName());
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  {0} Got Admission in {1} Program", s.GetName(), s.GetRegisteredProgram());
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("  Press Any Key to Continue...");
            Console.ReadKey();

        }

        
        public static void RegisterSubjects(List<ProgramBL> OfferedPrograms, List<StudentBL> Students)
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Register Subjects for Students");
            Console.WriteLine("  --------------------------------------------");
            Console.WriteLine();

            #region Checking if Any Student is Registered or Not  
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

            Console.Write("  Enter Student Name: ");
            string studentName = Console.ReadLine();

            

            #region Checking if Input Student Name is Available in Registered Students

            List<StudentBL> RegisteredStudents = Students.Where(student => student.GetIsRegistered() == true).ToList();
            List<StudentBL> validation = RegisteredStudents.Where(student => student.GetName() == studentName).ToList();
            
            
            if (validation.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Invalid Student Name !!");
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return;
            }
            #endregion

            Console.WriteLine();

            foreach (StudentBL s in RegisteredStudents)
            {
                if (s.GetName() == studentName)
                {
                    foreach (ProgramBL p in OfferedPrograms)
                    {
                        if (p.GetDegreeTitle() == s.GetRegisteredProgram())
                        {
                            Console.WriteLine("  {0} is Registered in {1} Program", s.GetName(), s.GetRegisteredProgram());

                            Console.WriteLine();

                            Console.WriteLine("  {0} Program has {1} Subjects", s.GetRegisteredProgram(), p.GetOfferedSubjects().Count);

                            #region Printing All Subjects Offered in Degree Program of Student

                            Console.ForegroundColor = ConsoleColor.Green;
                            int y = 14;

                            Console.SetCursorPosition(3, y);
                            Console.Write("Subject Code");

                            Console.SetCursorPosition(20, y);
                            Console.Write("Subject Title");

                            Console.SetCursorPosition(40, y);
                            Console.Write("Credit Hours");

                            Console.SetCursorPosition(60, y);
                            Console.Write("Subject Fees");

                            y++;

                            Console.SetCursorPosition(3, y);
                            Console.Write("-------------");

                            Console.SetCursorPosition(20, y);
                            Console.Write("--------------");

                            Console.SetCursorPosition(40, y);
                            Console.Write("-------------");

                            Console.SetCursorPosition(60, y);
                            Console.Write("-------------");

                            y++;

                            foreach (SubjectBL sb in p.GetOfferedSubjects())
                            {
                                Console.SetCursorPosition(4, y);
                                Console.Write(sb.GetSubjectCode());

                                Console.SetCursorPosition(21, y);
                                Console.Write(sb.GetSubjectType());

                                Console.SetCursorPosition(41, y);
                                Console.Write(sb.GetCreditHours());

                                Console.SetCursorPosition(61, y);
                                Console.Write(sb.GetSubjectFees());

                                y++;
                            }
                            Console.ResetColor();
                            #endregion


                            Console.WriteLine();

                            int creditHours = 0;
                            while (creditHours <= 9)
                            {
                                Console.WriteLine();
                                Console.Write("  Enter Subject Code Which You Want to Register: ");
                                string subjectCode = Console.ReadLine();

                                #region Checking if Input Subject Code is Available in Offered Subjects of Degree Program of Student
                                var check = p.GetOfferedSubjects().Where(subject => subject.GetSubjectCode() == subjectCode).ToList();
                                if (check.Count == 0)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("  Invalid Subject Code !!");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    Console.Write("  Press Any Key to Continue...");
                                    Console.ReadKey();
                                    return;
                                }
                                #endregion

                                #region Checking if Input Subject Code is Already Registered or Not
                                var check2 = s.GetRegisteredSubjects().Where(subject => subject.GetSubjectCode() == subjectCode).ToList();
                                if (check2.Count != 0)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("  Subject Already Registered !!");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    Console.Write("  Press Any Key to Continue...");
                                    Console.ReadKey();
                                    return;
                                }
                                #endregion

                                foreach (SubjectBL sb in p.GetOfferedSubjects())
                                {
                                    if (sb.GetSubjectCode() == subjectCode)
                                    {
                                        if ((creditHours + sb.GetCreditHours()) <= 9)
                                        {
                                            creditHours += sb.GetCreditHours();
                                        }
                                        else
                                        {
                                            #region Generate Error -->  You can't Register more than 9 Credit Hours !! 
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("  You can't Register more than 9 Credit Hours !!");
                                            Console.WriteLine();
                                            Console.ResetColor();
                                            Console.Write("  Press Any Key to Continue...");
                                            Console.ReadKey();

                                            return;
                                            #endregion
                                        }
                                        s.AddSubject(sb);
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("  Subject Registered Successfully !!");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    }
                                }

                                #region Checking if Student has Registered 9 Credit Hours or Not
                                if (creditHours >= 9)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("  You Have Registered Subjects of 9 Credit Hours !!");
                                    Console.WriteLine();
                                    Console.Write("  Press Any Key to Continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                #endregion


                                #region Checking if Student has Registered All Subjects of Degree Program or Not
                                if (p.GetOfferedSubjects().Count == s.GetRegisteredSubjects().Count)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("  You Have Registered All Subjects of {0} Degree Program !!", s.GetRegisteredProgram());
                                    Console.WriteLine();
                                    break;
                                }
                                #endregion


                                #region Asking User Choice to Register More Subjects
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  Do You Want to Register More Subjects? (Y/N)  >> ");
                                Console.ResetColor();
                                string choice = Console.ReadLine();
                                if (choice == "Y" || choice == "y")
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                                #endregion

                            }


                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("  Press Any Key to Continue...");
            Console.ReadKey();
        }

        public static void GenerateFees(List<ProgramBL> OfferedPrograms, List<StudentBL> Students)
        {
            Console.Clear();
            Console.WriteLine();
            MenuUI.Header();
            Console.WriteLine();

            Console.WriteLine("  Main Menu > Generate Fees");
            Console.WriteLine("  --------------------------------------");
            Console.WriteLine();

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


            //#region Checking if Any Student is Registered or Not
            //if (RegisteredStudents.Count == 0)
            //{
            //    Console.WriteLine();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("  No Student is Registered Yet !!");
            //    Console.WriteLine();
            //    Console.ResetColor();
            //    Console.Write("  Press Any Key to Continue...");
            //    Console.ReadKey();
            //    return;
            //}
            //#endregion

            List<StudentBL> RegisteredStudents = Students.Where(student => student.GetIsRegistered() == true).ToList();

            int fees = 0;
            foreach (StudentBL s in RegisteredStudents)
            {
                foreach (ProgramBL p in OfferedPrograms)
                {
                    if (p.GetDegreeTitle() == s.GetRegisteredProgram())
                    {
                        if (s.GetRegisteredSubjects().Count == 0)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("  No Subject is Registered By {0} !!", s.GetName());
                            Console.ResetColor();
                            continue;
                        }
                        foreach (SubjectBL sb in s.GetRegisteredSubjects())
                        {
                            fees += sb.GetSubjectFees();
                        }

                        Console.WriteLine();
                        Console.WriteLine("  Fees of {0} is {1} Rs.", s.GetName(), fees);
                    }
                }
            }

            Console.WriteLine();
            Console.Write("  Press Any Key to Continue...");
            Console.ReadKey();
        }

    }

    
}
