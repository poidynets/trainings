using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Trainings
{
    class Program
    {
        static void Main(string[] args)

        /*

        Имя, возраст, здоровье и состояние жив / мертв будут описывать каждый конкретный экземпляр нашего класса -
        на основе этих параметров так же будет основываться работа функций Talk, Go, Kill и IsAliveOrNot. 
        Имя будет передаваться в класс, во время вызова конструктора класса. Возраст и состояние здоровья будут 
        генерироваться в конструкторе автоматически - в дальнейшем они будут влиять на вывод текста в консоль, при вызове доступных пользователю методов.

        */
        {
            string user_command = "";
            bool Infinity = true;
            Human SomeHuman = null;
            while (Infinity)
            {
                System.Console.WriteLine("Waiting for your command... \n");
                user_command = System.Console.ReadLine();

                switch (user_command)
                {
                    case "exit":
                    {
                        Infinity = false;
                        break;
                    }
                    case "help":
                    {
                        System.Console.WriteLine("\nList of commands");
                        System.Console.WriteLine("---");
                        System.Console.WriteLine("'create_human' : to create a human");
                        System.Console.WriteLine("'exit' : to close from App");
                        System.Console.WriteLine("'kill_human' : to kill human");
                        System.Console.WriteLine("'talk' : function forcing to speak (if person is creahed)");
                        System.Console.WriteLine("'go' : forcing to walk  (if person is creahed)");
                        System.Console.WriteLine("---");
                        System.Console.WriteLine("--- \n");

                        break;
                    }

                    case "create_human":
                    {
                        if (SomeHuman !=null)
                        {
                            SomeHuman.Kill();
                        }
                        System.Console.WriteLine("Please set a name of created human \n");
                        user_command = System.Console.ReadLine();
                        SomeHuman = new Human(user_command);
                        System.Console.WriteLine("Human is successfully created \n");
                        break;
                    }

                    case "kill_human":

                    {
                        if (SomeHuman != null)
                        {
                            SomeHuman.Kill();
                        }
                        else
                        {
                            System.Console.WriteLine("Human person is not created. You cant complete kill func");
                        }
                        break;

                    }
                    case "talk":
                    {
                        if (SomeHuman != null)
                        {
                            SomeHuman.Talk();
                        }
                        else
                        {
                            System.Console.WriteLine("Human person is not created. Function can't be processed");
                        }
                        break;

                    }
                    case "go":
                    {
                        if (SomeHuman != null)
                        {
                            SomeHuman.Go();
                        }
                        else
                        {
                            System.Console.WriteLine("Human person is not created. Function can't be processed");
                        }
                        break;
                    }
                    default:
                    {
                        System.Console.WriteLine("we dont have this function \n");
                        System.Console.WriteLine("write 'help' function to display the list of the functions");
                        System.Console.WriteLine("write 'exit' for App finish \n\n");
                        break;

                    }
                }
            }
        }
    }

    public class Human
        {
            public Human(string _name)
            {
                Name = _name;
                isAlive = true;
                Age = (uint) rnd.Next(15, 51);
                Health = (uint) rnd.Next(10, 101);
            }

            private string Name;
            private uint Age;
            private uint Health;
            private bool isAlive;
            private Random rnd = new Random();

            public void Talk()
            {
                int random_talk = rnd.Next(1, 4);
                string tmp_str = "";

                switch (random_talk)
                {
                    case 1:
                    {
                        tmp_str = "Name" + Name + "cheers";
                        break;
                    }
                    case 2:
                    {
                        tmp_str = "Im" + Age + "Not to old?";
                        break;
                    }
                    case 3:
                    {
                        if (Health > 50)
                            tmp_str = "Im so healthy!";
                        else
                            tmp_str = "My health is so-so. Want to leave at least till" + (Age + 5).ToString();
                        break;
                    }
                }
                System.Console.WriteLine(tmp_str);
            }

            public void Go()
            {
                if (isAlive == true)
                {
                    if (Health > 40)
                    {
                        string outString = Name + "walknig in the park and planning evening";
                        System.Console.WriteLine(outString);
                    }
                    else
                    {
                        string outString = Name + " he's sick and dont thinking about girls or even boys";
                        System.Console.WriteLine(outString);
                    }
                }
                else
                {
                    string outString = Name + "im sorry, he is dead :(";
                    System.Console.WriteLine(outString);
                }
            }


            public bool IsAliveOrNot()
            {
                return isAlive;
            }

            public void Kill()
            {
                isAlive = false;
                System.Console.WriteLine(Name + " is died");
            }
        }
    }

