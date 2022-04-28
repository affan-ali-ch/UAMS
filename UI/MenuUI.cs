using System;


namespace UAMS.UI
{
    internal class MenuUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("  *********************************************");
            Console.WriteLine("  *                    UAMS                   *");
            Console.WriteLine("  *********************************************");

        }

        public static int MainMenu()
        {
            Console.Title = "University Admission Management System";
            Console.WriteLine();
            Header();
            Console.WriteLine();
            Console.WriteLine("  Main Menu");
            Console.WriteLine("  -------------");
            Console.WriteLine();

            Console.WriteLine("  1. Add Student");
            Console.WriteLine("  2. Add Degree Program");
            Console.WriteLine("  3. Generate Merit");
            Console.WriteLine("  4. View Registered Students");
            Console.WriteLine("  5. View Students of a Specific Program");
            Console.WriteLine("  6. Register Subjects for a Specific Student");
            Console.WriteLine("  7. Calculate Fees for all Registered Students");
            Console.WriteLine("  8. Exit");

            Console.WriteLine();

            Console.Write("  Enter Option: ");
            int option;

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("  Invalid Option");
                Console.Write("  Press Any Key to Continue...");
                Console.ReadKey();
                return 0;
            }

            return option;
        }
    }
}
