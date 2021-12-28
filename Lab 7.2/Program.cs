using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
  Разработчик -> Вирус -> CConficker
  Разработчик -> ПО -> Игрушка -> Сапер
  Разработчик -> ПО -> Текстовый редактор -> Word
  Интерфейс: Набор операций
*/

namespace Lab_7._2
{
    class Program
    {
        interface ISetOfOperations
        {
            void info();
        } // Интерфейс



        public class Software : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            public string version { set; get; }

            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }

        } // Абстрактный класс

        // 1st (Developer -> Virus -> CConficker)
        class Virus : Developer//исключение !=0
        {
            private string Naming = "No";
            public string name
            {
                get
                {
                    return Naming;
                }
                set
                {
                    try
                    {
                        if (value == null)
                        {
                            throw new Exceptions.NoVir("Назовите своё ПО!");
                        }
                        if (value == "")
                        {
                            throw new Exceptions.NoVir("Назовите своё ПО!");
                        }
                    }
                    catch (Exceptions.NoVir ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            private int quantity;
            public int Quantity
            {
                get
                { return quantity; }
                set
                {
                    if (value < 0)
                    {
                        throw new Exceptions.Zero("Число не может быть отрицательным!");
                    }
                    else if (value == 0)
                    {
                        throw new Exceptions.Zero("Число не может быть нулём!");
                    }
                    else quantity = value;
                }
            }

            /*public string name;*/
            public string Name
            {
                get { return name; }
                set
                {
                    if (value == "" || value==null)
                        throw new Exceptions.StringException("Название вируса некорректно!", value);
                    else
                        name = value;
                }
            }



            public string type { set; get; }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {type}");
            }
        }
        sealed class CConficker : Virus, ISetOfOperations
        {
            public void info()
            {
                Console.WriteLine($"Description: {developer}");
            }
            public override string ToString()
            {
                return $"CConficker: {name}, {Quantity}";
            }
        }

        // 2nd (Developer -> ПО -> Game -> Saper)
        class Game : Software, ISetOfOperations
        {
            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- Game is Saper ->");
            }
        }

        class Saper : Game
        {
            public void Name()
            {
                Console.WriteLine($"Название сапера: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип сапера: {type}");
            }
            public override string ToString()
            {
                return $"Saper: {name}, {type}, {developer}";
            }




        }

        class Preview
        {
            public string prev;
            public Preview(string p)
            {
                prev = p;
            }
        } // Композиция

        // 3d (Developer -> ПО -> WordProcessor -> Word)
        class WordProcessor : Software, ISetOfOperations
        {
            public string developer { set; get; }
            public void Developer()
            {
                Console.WriteLine($"Разработчик: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- WordProcessor is Word ->");
            }
        }

        class Word : WordProcessor
        {
            public void Name()
            {
                Console.WriteLine($"Название: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип: {type}");
            }
            public override string ToString()
            {
                return $"Word: {name}, {type}, {developer}";
            }
        }

        // Printer
        class Printer : APrinter
        {
            public string IAmPrinting;
        }
        abstract class APrinter
        {
            public void IamPrinting(Developer someobj)
            {
                Console.WriteLine($"Тип этого обьекта: " + someobj.GetType());
                Console.WriteLine(someobj.ToString());
            }
        }
        // <------------------------>
        class Over
        {
            public string name { get; set; } = "Overriding";

            public Over(string fame)
            {
                this.name = fame;
            }

            public override int GetHashCode()
            {
                Console.WriteLine($"\nHash of {this.name} is: {name.GetHashCode()}\n");
                return name.GetHashCode();
            }

            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Over el = obj as Over;
                if (el as Over == null)
                    return false;

                return el.name == this.name;
            }
        }




        // Лабораторная 6


        //перечисление
        enum Enumerable : byte
        {
            Developer,
            Software,
            WordProcessor,
            Word
        } // Перечисление
        //структура
        class Person //18 лет
        {
            private int age;
            public int Age
            {
                get { return age; }
                set
                {
                    if (value < 18)
                        throw new Exceptions.PersonException("В эту игру запрещено играть людям до 18 лет", value);
                    else
                        age = value;
                }
            }
        }
        // Структура
        //partial класс
        public partial class Developer
        {
            public string developer { set; get; }

            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        //partial класс
        //класс-контейнер
        public class Computer
        {
            /*public static int count = 0;
            public static int amount = 0;*/
            public List<Software> container { set; get; }
            public Computer()
            {
                container = new List<Software>();
                return;
            }

            public Software this[int index]
            {
                get { return container[index]; }
                set { container[index] = value; }
            }

            public void AddItem(Software s)
            {
                /*Info.Add(s);
                if(s as Software != null)
                {
                    count++;
                }*/
                container.Add(s);
            }
            public void DeleteItem(Software s)
            {
                /*if (Computer.count == 0)
                {
                    throw new Exceptions.DeleteItemException("Не найдены никакие элементы!");
                }
                else
                {
                    container.Remove(s);
                    if(s as Software != null)
                    {
                        count--;
                    }

                }*/
                container.Remove(s);
            }

            public void Print()
            {
                Console.WriteLine("Элементы контейнера: ");
                for (int i = 0; i < container.Count; i++)
                {
                    Console.WriteLine("   " + container[i].name);
                }
            }
        } // Класс-Контейнер
        //класс-контроллер
        public static class Controller
        {
            public static void FindCurrentGameType(List<Software> g)//вывод игрушки
            {
                string GameType = "Racing";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].type == GameType)
                    {
                        Console.WriteLine("Текущая игра - " + g[i]);
                    }
                }
            }

            public static void FindVersionEditor(List<Software> g)//вывод т редактора заданной версии
            {
                string ver = "1.1";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].version == ver)
                    {
                        Console.WriteLine("Редактор версии " + ver + ": " + g[i]);
                    }
                }

                string version = "1.2";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].version == version)
                    {
                        Console.WriteLine("Редактор версии " + version + ": " + g[i]);
                    }
                }
            }

            public static void SortedSoftware(List<Software> g)//ПО в алфавитном порядке
            {
                Console.WriteLine("\n" + "Сортировка по алфавитному порядку: ");
                var sortedSoftware = g.OrderBy(u => u.name);
                foreach (var softw in sortedSoftware)
                {
                    Console.WriteLine("   " + softw.name);
                }
            }

        } // Класс-контроллер

        static void Main(string[] args)
        {

            Computer PC = new Computer();
            Game game1 = new Game { name = "Forza", type = "Racing", developer = "Turn10" };
            Word word1 = new Word { name = "MSWord", type = "Word", developer = "Microsoft", version = "1.1" };
            Saper game2 = new Saper { name = "Saper", type = "Puzzle", developer = "Microsoft", version = "1.2" };
            Word word2 = new Word { name = "Notepad", type = "Word", developer = "Microsoft", version = "1.1" };
            PC.AddItem(game1);
            PC.AddItem(word1);
            PC.AddItem(game2);
            PC.AddItem(word2);
            PC.Print();
            //попытка удаления несуществующего элемента
            try//проверка на совершеннолетие
            {
                Person p = new Person { Age = 15 };
            }
            catch (Exceptions.PersonException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine($"Текущему юзеру {ex.Value} лет.");
            }

            //проверка на название вируса
            try
            {
                Virus v = new Virus { Name = "" };//намеренно вводим ошибочное значение
            }
            catch (Exceptions.StringException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            CConficker conf = new CConficker();
            //исключение !=0
            try
            {
                Virus q = new Virus { Quantity = 0 };
            }
            catch (Exceptions.Zero ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            //исключение /0
            try
            {
                Console.WriteLine("Введите значение икса: ");
                int x = int.Parse(Console.ReadLine());
                int y = 1 / x;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Делить на ноль нельзя!");
            }
            //Debug.Assert
            Virus sw = new Virus();
            try
            {
                sw.name = "";
            }
            catch (Exceptions.NoVir ex)
            {
                Console.Write("Экземпляр создан неправильно (͡๏̯͡๏): ");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }
            //finally
            finally
            {
                Console.WriteLine("Поздравляю, Вы дошли до конца программы!");
            }

            string str = null;
            Debug.Assert(str != null, "Строка нулевая");
            
            Console.Read();
        }
    }
}
