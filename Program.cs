using System;


namespace Trainings
{
    class Program
    {
        static void Main(string[] args)

            /*
    We are creating human with name, health, and it will be possible to give a commands to speak, walk, die and to find out alive it or not.
    Human name will be sent to the class during using class constructor. Age and heals status are generating in the constructor automatically.
    Later theyll take a part in next steps related displaying text regarding human during using available methods.
            */
        {
            string user_command = "";
            bool Infinity = true;
            Human SomeHuman = null;
            while (Infinity)
            {
                Console.WriteLine("Waiting for your command... \n");
                user_command = Console.ReadLine();

                switch (user_command)
                {
                    case "exit":
                    {
                        Infinity = false;
                        break;
                    }
                    case "help":
                    {
                        Console.WriteLine("\nList of commands");
                        Console.WriteLine("---");
                        Console.WriteLine("'create_human' : to create a human");
                        Console.WriteLine("'exit' : to close from App");
                        Console.WriteLine("'kill_human' : to kill human");
                        Console.WriteLine("'talk' : function forcing to speak (if person is creahed)");
                        Console.WriteLine("'go' : forcing to walk  (if person is creahed)");
                        Console.WriteLine("---");
                        Console.WriteLine("--- \n");

                        break;
                    }

                    case "create_human":
                    {
                        if (SomeHuman != null)
                        {
                            SomeHuman.Kill();
                        }
                        Console.WriteLine("Please set a name of created human \n");
                        user_command = Console.ReadLine();
                        SomeHuman = new Human(user_command);
                        Console.WriteLine("Human is successfully created \n");
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
                            Console.WriteLine("Human person is not created. You cant complete kill func");
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
                            Console.WriteLine("Human person is not created. Function can't be processed");
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
                            Console.WriteLine("Human person is not created. Function can't be processed");
                        }
                        break;
                    }
                    case "":
                    {
                            Console.WriteLine("We need some command from your side. Dont leave empty field");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("we dont have this function \n");
                        Console.WriteLine("write 'help' function to display the list of the functions");
                        Console.WriteLine("write 'exit' for App finish \n\n");
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
            Age = (uint)rnd.Next(15, 51);
            Health = (uint)rnd.Next(10, 101);
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
                    tmp_str = "Name " + Name + " cheers";
                    break;
                }
                case 2:
                {
                    tmp_str = "Im " + Age + " Not to old?";
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
            Console.WriteLine(tmp_str);
        }

        public void Go()
        {
            if (isAlive == true)
            {
                if (Health > 40)
                {
                    string outString = Name + " walknig in the park and planning evening";
                    Console.WriteLine(outString);
                }
                else
                {
                    string outString = Name + " he's sick and dont thinking about girls or even boys";
                    Console.WriteLine(outString);
                }
            }
            else
            {
                string outString = Name + " im sorry, he is dead :(";
                Console.WriteLine(outString);
            }
        }


        public bool IsAliveOrNot()
        {
            return isAlive;
        }

        public void Kill()
        {
            isAlive = false;
            Console.WriteLine(Name + " is died");
        }
    }
}

