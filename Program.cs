using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===学生成绩管理系统===");
                Console.WriteLine("1.添加学生");
                Console.WriteLine("2.显示所有学生");
                Console.WriteLine("3.统计信息");
                Console.WriteLine("4.按分数排序");
                Console.WriteLine("5.退出");
                Console.WriteLine("请选择：");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1": AddStudent();break;
                    case "2": ShowAll(); break;
                    case "3": ShowStats(); break;
                    case "4": SortAndShow(); break;
                    case "5": return;
                    default: Console.WriteLine("无效选择，请重新输入");break;
                }
                
            }
        }
        static void AddStudent()
        {
            Console.WriteLine("姓名");
            string name = Console.ReadLine();

            Console.WriteLine("分数:");
            double score = double.Parse(Console.ReadLine());

            Student stu = new Student( name,score);
            students.Add(stu);
            Console.WriteLine("添加成功");
            
        }
        static void ShowAll()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("暂无学生信息");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("姓名\t\t成绩");
            foreach(Student stu in students)
            {
                Console.WriteLine("{0}\t\t{1}", stu.Name, stu.Score);
            }
            Console.ReadLine();
        }
        static void ShowStats()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("暂无学生信息");
                Console.ReadLine();
                return;
            }
            double sum = 0;
            double max = students[0].Score;
            double min = students[0].Score;
            foreach(Student stu in students)
            {
                sum = sum + stu.Score;
                if (stu.Score > max)
                {
                    max = stu.Score;
                }
                if(stu.Score < min)
                {min = stu.Score; }
            }double avg = sum / students.Count;
            Console.WriteLine("平均分：" + avg);
            Console.WriteLine("最高分：" + max);
            Console.WriteLine("最低分：" + min);
            Console.ReadLine();
        }
        static void SortAndShow()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("暂无学生数据");
                Console.ReadLine();
                return;
            }
            students.Sort((a, b) => b.Score.CompareTo(a.Score));
            Console.WriteLine("姓名\t\t成绩");
            foreach (Student s in students)
            { 
                Console.WriteLine("{0}\t\t{1}", s.Name, s.Score);
            }Console.ReadLine();
        }
   
    }

    class Student
    {
        public double Score { get; set; }
        public string Name { get; set; }
        public Student(string name,double score)
        {
            Score = score;
            Name = name;
        }
    }
}
