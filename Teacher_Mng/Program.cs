using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Mng
{
    // Class to represent a Teacher
    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassSection { get; set; }
        public override string ToString()
        {   return $"ID: {ID}, Name: {Name}, Class and Section: {ClassSection}";    }
    }
    internal class Program     // Main program class
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = "teacher_data.txt";
        static void Main(string[] args)         // Main method
        {   LoadData();
            while (true)             // Main program loop
            {   Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. View All Teachers");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        ViewAllTeachers();
                        break;
                    case 3:
                        UpdateTeacher();
                        break;
                    case 4:
                        SaveData();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void LoadData()         // Method to load data from a file
        {   if (File.Exists(filePath))
            {   string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)                 // Parse each line and create Teacher objects
                {   string[] parts = line.Split(',');
                    Teacher teacher = new Teacher
                    {   ID = int.Parse(parts[0]),
                        Name = parts[1],
                        ClassSection = parts[2]
                    };
                    teachers.Add(teacher);
                }
            }
        }
        static void SaveData()         // Method to save data to a file
        {   List<string> lines = new List<string>();
            foreach (Teacher teacher in teachers)             // Convert each Teacher object to a string and add to the list
            {   lines.Add($"{teacher.ID},{teacher.Name},{teacher.ClassSection}");   }
            File.WriteAllLines(filePath, lines);             // Write all lines to the file
        }
        static void AddTeacher()               // Method to add a new teacher
        {   Teacher teacher = new Teacher();
            Console.Write("Enter ID: ");
            teacher.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Enter Class and Section: ");
            teacher.ClassSection = Console.ReadLine();
            teachers.Add(teacher);
            Console.WriteLine("Teacher added successfully.");
        }
        static void ViewAllTeachers()            // Method to view all teachers
        {   if (teachers.Count == 0)
            {   Console.WriteLine("No teachers found.");    }
            else
            {   foreach (Teacher teacher in teachers)
                {   Console.WriteLine(teacher);    }
            }
        }
        static void UpdateTeacher()           // Method to update an existing teacher
        {   Console.Write("Enter the ID of the teacher to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());
            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);             // Find the teacher with the specified ID
            if (teacherToUpdate == null)
            {   Console.WriteLine("Teacher not found.");    }
            else
            {   Console.Write("Enter updated Name: ");
                teacherToUpdate.Name = Console.ReadLine();
                Console.Write("Enter updated Class and Section: ");
                teacherToUpdate.ClassSection = Console.ReadLine();
                Console.WriteLine("Teacher updated successfully.");
            }
        }
    }
}