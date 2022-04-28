using System;
using System.IO;
using UAMS.UI;
using UAMS.DL;
using UAMS.BL;

namespace UAMS
{
    internal class main
    {
        static void Main()
        {
            string project_bin_debug = Environment.CurrentDirectory.ToString();
            string project_bin = Directory.GetParent(project_bin_debug).FullName;
            string project = Directory.GetParent(project_bin).FullName;
            string TextFilesFolderPath = project + "\\Text Files\\";

            string SubjectsFilePath = TextFilesFolderPath + "Subjects.txt";
            string StudentsFilePath = TextFilesFolderPath + "Students.txt";
            string ProgramsFilePath = TextFilesFolderPath + "Programs.txt";

            SubjectDL.LoadSubjects(SubjectsFilePath);

            ProgramDL.LoadProgramFromFile(ProgramsFilePath);

            StudentDL.LoadStudentsFromFile(StudentsFilePath);

            while (true)
            {
                int option = MenuUI.MainMenu();

                if (option == 1)
                {
                    StudentBL student = StudentUI.AddStudent(ProgramDL.OfferedPrograms);
                    if(student != null)
                    {
                        StudentDL.Students.Add(student);
                    }
                }

                if (option == 2)
                {
                    ProgramBL program = ProgramUI.AddProgram();
                    
                    if(program != null)
                    {
                        ProgramDL.OfferedPrograms.Add(program);
                    }
                }

                if (option == 3)
                {
                    StudentUI.GenerateMerit(ProgramDL.OfferedPrograms, StudentDL.Students);
                }

                if (option == 4)
                {
                    StudentUI.PrintRegisteredStudents(StudentDL.Students);
                }

                if (option == 5)
                {
                    ProgramUI.PrintSpecificDegree(ProgramDL.OfferedPrograms, StudentDL.Students);
                }

                if (option == 6)
                {
                    StudentUI.RegisterSubjects(ProgramDL.OfferedPrograms, StudentDL.Students);
                }
                if (option == 7)
                {
                    StudentUI.GenerateFees(ProgramDL.OfferedPrograms, StudentDL.Students);
                }
                if (option == 8)
                {
                    ProgramDL.WriteAllProgramsToFile(ProgramsFilePath);
                    SubjectDL.GetUniqueSubjects();
                    SubjectDL.StoreSubjects(SubjectsFilePath);
                    StudentDL.StoreAllStudentsToFile(StudentsFilePath);
                    break;
                }
            }
        }
    }
}
