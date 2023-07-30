﻿using StudentsRating;
using System.Threading.Tasks.Dataflow;
Console.WriteLine("Welcome to Students Rating Program");

var journal = new Dictionary<Student, List<Mark>>();
var teachersList = new List<Teacher>();
var studentsList = new List<Student>();
var subjectsList = new List<Subject>();

//Subject
Subject CE = new Subject() { NameSubj = "Combat Evolved" };
Subject MG = new Subject() { NameSubj = "Metal Gear" };
//Student
Student Okita = new Student()
{
    Id = 1,
    FirstName = "Okita",
    LastName = "Sogo",
    Age = 15,
    Group = "Shinsengumi"
};
Student Rasta = new Student()
{
    Id = 2,
    FirstName = "Bob",
    LastName = "Marley",
    Age = 26,
    Group = "Jamaica"
};
Student Halo = new Student()
{
    Id = 3,
    FirstName = "343",
    LastName = "GuiltySpark",
    Age = 999,
    Group = "Halo"
};
//Teacher
Teacher Chief = new Teacher()
{
    Id = 1,
    FirstName = "John",
    LastName = "117",
    Age = 45,
    Subject = CE
};
Teacher Jack = new Teacher()
{
    Id = 2,
    FirstName = "Jack",
    LastName = "Ripper",
    Age = 32,
    Subject = MG
};
//Mark
studentsList.Add(Halo);
studentsList.Add(Okita);
studentsList.Add(Rasta);
//marksList.Add(mark);
foreach (Student student in studentsList)
{
    journal.Add(student, new List<Mark>());
}
MenuCategory main = new MenuCategory("Главное меню", new MenuItem[]
    {
        new MenuAction("Показать студентов", ShowList =>
        {
            ILists.ShowList(studentsList);
        }),
        new MenuAction("Показать учителей", ShowList =>
        {
            ILists.ShowList(teachersList);
        }),
        new MenuAction("Показать предметы", ShowList =>
        {
            ILists.ShowList(subjectsList);
        }),
        new MenuCategory("Работа со списком студентов", new MenuItem[]
        {
            new MenuAction("Поставить оценку", AddMark=>
            {
                Console.WriteLine("Выберите студента(Введите id): ");
                int id = int.Parse(Console.ReadLine());
                foreach(Student student in studentsList)
                {
                    if(id == student.Id)
                    {
                        Console.WriteLine($"Вы выбрали студента: {student.ToString()}");
                        Console.WriteLine("Введите оценку: ");
                        var temp = Console.ReadLine();
                        Mark mark = new Mark()
                        {
                            Value = Convert.ToInt32(temp),
                            Teacher = Jack
                        };
                        journal[student].Add(mark);
                    }
                }
            } ),
            new MenuAction("Посмотреть оценки студента", ShowMarks=>
            {
                Console.WriteLine("Выберите студента(Введите id): ");
                int id = int.Parse(Console.ReadLine());
                foreach(Student student in studentsList)
                {
                    if(id == student.Id)
                    {   
                        Console.WriteLine($"Вы выбрали студента: {student.ToString()}");
                        ILists.ShowList(journal[student]);
                    }
                }
            }),
            new MenuAction("Добавить студента", MenuAction.SomeActionMethod),
            new MenuAction("Удалить студента", MenuAction.SomeActionMethod),
            new MenuBack()
        }),
        new MenuCategory("Работа со списком учителей", new MenuItem[]
        {
            new MenuAction("Добавить учителя", MenuAction.SomeActionMethod),
            new MenuAction("Удалить учителя", MenuAction.SomeActionMethod),
            new MenuBack()
        }),
         new MenuCategory("Работа со списком предметов", new MenuItem[]
        {
            new MenuAction("Добавить предмет", MenuAction.SomeActionMethod),
            new MenuAction("Удалить предмет", MenuAction.SomeActionMethod),
            new MenuBack()
        }),
        new MenuBack("Выход")
    });

Menu menu = new Menu(main);
menu.RunMenu();

Console.WriteLine("Выход из приложения, нажмите любую клавишу...");
Console.ReadKey();