using System;
using System.Collections.Generic;

namespace laba5._1
{
    class Program
    {
        /* Вариант 1
           Отдел кадров
           Фамилия      Должность  Год рожд   Оклад(грн)
           Иванов И.И.    П          1975     4170.50
           Петренко П.П.  С          1996     790.10
           Сидоревич М.С. А          1990     2200.00
           Перечисляемый тип: П - преподаватель, С - студент, А - аспирант
         */
         /* Модифицировать код индивидуального задания 1 лабораторной работы №1.
            Организовать хранение данных в виде массива структур с полями, которые
            соответствуют столбцам таблицы.Консольное приложение должно быть
            интерактивным и постоянно предлагать на выбор одно из следующих
            действий, пока пользователь не введет 7, т.е.выберет пункт «7 – Выход»:
                        1 – Просмотр таблицы
                        2 – Добавить запись
                        3 – Удалить запись
                        4 – Обновить запись
                        5 – Поиск записей
                        6 – Просмотреть лог
                        7 - Выход
            При выборе пункта «Просмотр таблицы» программа должна отобразить
            таблицу со всеми записями, по аналогии с лабораторной работой №1.
            При выборе пункта «Добавить запись» программа должна последовательно
            предложить заполнить все поля новой записи и добавить ее в конец набора.
            При выборе пункта «Удалить запись» программа должна предложить
            пользователю ввести номер записи, которую необходимо удалить.Удаление
            из массива подразумевает уменьшение числа элементов на 1 и смещение
            всех записей, находящихся после удаляемой, на 1 влево в массиве.
            При выборе пункта «Обновить запись» программа должна предложить
            пользователю ввести номер записи, которую необходимо обновить; затем
            предложить ввести новые значения всех полей этой записи и обновить ее.
            При выборе пункта «Поиск записей» программа должна предложить ввести
            пользователю фильтр для поиска (выберите любой фильтр или спросите у
            проработчика. Например, найти всех сотрудников с годом рождения больше
            1985) и вывести результаты, соответствующие фильтру внутри таблицы
            того же вида.
            При выборе пункта «Просмотреть лог» должен быть отображен лог
            действий пользователя(см.следующий пункт).
         */

        enum Post
        {
            П,
            С,
            А
        }
        struct Worker
        {
            public string surname;
            public Post position;
            public int year;
            public decimal salary;

            public void showTable()
            {
                Console.WriteLine("{0, -20} {1, -5} {2, -10} {3, -10}", surname, position, year, salary);
                Console.WriteLine();
            }
        }
        struct Log
        {
            public DateTime time;
            public string operation;
            public string name;

            public void logOutput()
            {
                Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
            }
        }
        static void Main(string[] args)
        {

            var logOfSession = new List<Log>(50);
            DateTime firstTime = DateTime.Now;
            DateTime secondTime = DateTime.Now;
            TimeSpan downtime = secondTime - firstTime;

            Worker Иванов;
            Иванов.surname = "Иванов И.И.";
            Иванов.position = Post.П;
            Иванов.year = 1975;
            Иванов.salary = 4170.50M;

            Worker Петренко;
            Петренко.surname = "Петренко П.П.";
            Петренко.position = Post.С;
            Петренко.year = 1996;
            Петренко.salary = 790.10M;

            Worker Сидоревич;
            Сидоревич.surname = "Сидоревич М.С.";
            Сидоревич.position = Post.А;
            Сидоревич.year = 1990;
            Сидоревич.salary = 2200.00M;

            var table = new List<Worker>();
            table.Add(Иванов);
            table.Add(Петренко);
            table.Add(Сидоревич);

            bool error = true;
            bool working = true;

            do
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Просмотр таблицы");
                Console.WriteLine("2 - Добавить запись");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Обновить запись");
                Console.WriteLine("5 - Поиск записей");
                Console.WriteLine("6 - Просмотреть лог");
                Console.WriteLine("7 - Выход");
                int selector = int.Parse(Console.ReadLine());
                if (selector == 1)
                {
                    for (int i = 0; i < table.Count; i++)
                    {
                        table[i].showTable();
                    }
                    Console.WriteLine();
                }
                if (selector == 2)
                {
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    var position = Post.А;
                    int year = 0;
                    decimal salary = 0;
                    do
                    {
                        Console.Write("Введите должность(П/С/А): ");
                        string pos = Console.ReadLine();
                        if (pos == "П")
                        {
                            position = Post.П;
                            error = false;
                        }
                        else if (pos == "С")
                        {
                            position = Post.С;
                            error = false;
                        }
                        else if (pos == "А")
                        {
                            position = Post.А;
                            error = false;
                        }
                        else
                        {
                            Console.WriteLine("Введите правильно!");
                            Console.WriteLine();
                        }
                    }
                    while (error);
                    error = true;
                    do
                    {
                        Console.Write("Введите год рождения: ");
                        try
                        {
                            year = int.Parse(Console.ReadLine());
                            error = false;
                        }
                        catch (FormatException)
                        {
                            year = 0;
                            Console.WriteLine("Введите правильно!");
                        }
                    }
                    while (error);
                    error = true;
                    do
                    {
                        Console.Write("Введите зарплату: ");
                        try
                        {
                            salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                            error = false;
                        }
                        catch (FormatException)
                        {
                            salary = 0;
                            Console.WriteLine("Введите правильно!");
                        }
                    }
                    while (error);
                    error = true;

                    Worker newWorker;
                    newWorker.surname = surname;
                    newWorker.position = position;
                    newWorker.year = year;
                    newWorker.salary = salary;
                    table.Add(newWorker);

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Запись добавлена.";
                    newLog.name = surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                    {
                        downtime = secondDowntime;
                    }
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                if (selector == 3)
                {
                    int number = 0;
                    string surname = string.Empty;
                    do
                    {
                        Console.WriteLine("Выберите номер строки для удаления: ");
                        number = int.Parse(Console.ReadLine());
                        if (number > 0 && number <= table.Count)
                        {
                            surname = table[number - 1].surname;
                            table.RemoveAt(number - 1);
                            error = false;
                        }
                        else
                        {
                            Console.WriteLine("Введите правильно!");
                        }
                    }
                    while (error);
                    error = true;

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Запись удалена.";
                    newLog.name = surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                    {
                        downtime = secondDowntime;
                    }
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                if (selector == 4)
                {
                    string oldSurname = string.Empty;
                    string surname = string.Empty;
                    var position = Post.А;
                    int year = 0;
                    decimal salary = 0;
                    int number = 0;
                    do
                    {
                        Console.WriteLine("Выберите номер строки для обновления: ");
                        number = int.Parse(Console.ReadLine());
                        if (number > 0 && number <= table.Count)
                        {
                            oldSurname = table[number - 1].surname;
                            Console.Write("Введите фамилию: ");
                            surname = Console.ReadLine();
                            do
                            {
                                Console.Write("Введите должность(П/С/А): ");
                                string pos = Console.ReadLine();
                                if (pos == "П")
                                {
                                    position = Post.П;
                                    error = false;
                                }
                                else if (pos == "С")
                                {
                                    position = Post.С;
                                    error = false;
                                }
                                else if (pos == "А")
                                {
                                    position = Post.А;
                                    error = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите правильно!");
                                    Console.WriteLine();
                                }
                            }
                            while (error);
                            error = true;
                            do
                            {
                                Console.Write("Введите год рождения: ");
                                try
                                {
                                    year = int.Parse(Console.ReadLine());
                                    error = false;
                                }
                                catch (FormatException)
                                {
                                    year = 0;
                                    Console.WriteLine("Введите правильно!");
                                }
                            }
                            while (error);
                            error = true;
                            do
                            {
                                Console.Write("Введите зарплату: ");
                                try
                                {
                                    salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                                    error = false;
                                }
                                catch (FormatException)
                                {
                                    salary = 0;
                                    Console.WriteLine("Введите правильно!");
                                }
                            }
                            while (error);
                        }
                        else
                        {
                            Console.WriteLine("Введите правильно!");
                        }
                    }
                    while (error);
                    error = true;

                    Worker editWorker;
                    editWorker.surname = surname;
                    editWorker.position = position;
                    editWorker.year = year;
                    editWorker.salary = salary;
                    table.Insert(number - 1, editWorker);
                    table.Remove(table[number]);

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Запись обновлена";
                    newLog.name = oldSurname + " ==> " + surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                    {
                        downtime = secondDowntime;
                    }
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                if (selector == 5)
                {
                    var pos = Post.П;
                    do
                    {
                        Console.WriteLine("П - Преподаватель");
                        Console.WriteLine("С - Студент");
                        Console.WriteLine("А - Аспирант");
                        Console.WriteLine("Введите кого вы хотите найти: ");
                        string select = Console.ReadLine();
                        Console.WriteLine();
                        if (select == "П" || select == "С" || select == "А")
                        {
                            if (select == "П")
                                pos = Post.П;
                            if (select == "С")
                                pos = Post.С;
                            if (select == "А")
                                pos = Post.А;
                            for (int i = 0; i < table.Count; i++)
                            {
                                if (table[i].position == pos)
                                {
                                    table[i].showTable();
                                }
                            }
                            error = false;
                        }
                        else
                        {
                            Console.WriteLine("Введите правильно!");
                        }
                    }
                    while (error);
                    error = true;
                    Console.WriteLine();
                }
                if (selector == 6)
                {
                    for (int i = 0; i < logOfSession.Count; i++)
                    {
                        logOfSession[i].logOutput();
                    }
                    Console.WriteLine();
                    Console.WriteLine(downtime + " - Самый долгий период бездействия пользователя");
                    Console.WriteLine();
                }
                if (selector == 7)
                {
                    working = false;
                }
                if (selector < 1 || selector > 7)
                {
                    Console.WriteLine("Выберите правильно!");
                    Console.WriteLine();
                }
            }
            while (working);
            Console.WriteLine();
        }
    }
}


