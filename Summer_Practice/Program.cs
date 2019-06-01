using Summer_Practice.Entities;
using System;
using System.Collections.Generic;

namespace Summer_Practice
{
    class Program
    {
        static List<Transport> transports;

        static void Main(string[] args)
        {
            transports = new List<Transport>();

            while (Dialog())
            {
            }

        }

        static bool Dialog()
        {
            bool check, isCorrect;
            string answer;
            int choose;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
###############################
##Welcome to Summer_Practice!##
###############################
");
            Console.ResetColor();

            Console.WriteLine("\tItems in list: {0}\n", transports.Count);

            Console.WriteLine(
                "Choose your next action:\n\n1 - automatic list filling;\n2 - add item manually;\n" +
                "3 - delete item;\n4 - edit item;\n5 - show list;\n6 - clear list;\n\n\tstop - exit program."
                );

            isCorrect = false;
            do
            {
                answer = Console.ReadLine();

                if (answer.ToLower() == "stop")
                {
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return false;
                }

                if (answer.ToLower() == "help")
                {
                    Console.WriteLine(
                        "\tCommands available:\n1 - automatic list filling;\n2 - add item manually;\n" +
                        "3 - delete item;\n4 - edit item;\n5 - show list;\nstop - exit program."
                        );
                    continue;
                }

                check = int.TryParse(answer, out choose);
                if (!check)
                {
                    Console.WriteLine("Invalid command. Type \"help\" to see commands.");
                }
                else
                {
                    switch (choose)
                    {
                        case 1:
                            {
                                Autofill();
                                isCorrect = true;
                                break;
                            }
                        case 2:
                            {
                                AddDialog();
                                isCorrect = true;
                                break;
                            }
                        case 3:
                            {
                                DeleteDialog();
                                isCorrect = true;
                                break;
                            }
                        case 4:
                            {
                                UpdateDialog();
                                isCorrect = true;
                                break;
                            }
                        case 5:
                            {
                                ShowPage();
                                isCorrect = true;
                                break;
                            }
                        case 6:
                            {
                                ClearList();
                                isCorrect = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid command. Type \"help\" to see commands.");
                                break;
                            }
                    }
                }
            } while (!isCorrect);


            Console.Write("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        static void Autofill()
        {
            try
            {
                transports.Add(new Airplane("Elitar-202", 240, 0.008, 2, 0));
                transports.Add(new Helicopter("MI-8", 250, 4, 3, 24));
                transports.Add(new CruiseLiner("Queen Mary", 55.5, 19189, 1254, 2620));
                transports.Add(new Tanker("Esso Atlantic", 17, 516891, 60, 0));
                transports.Add(new Car("Honda CR-V", 184, 480, 1, 4));
                transports.Add(new Train("Sapsan X", 250, 5, 20, 640));
                Console.WriteLine("6 items added");
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAn error occured by creating:\n\t{0}", e.Message);
                Console.ResetColor();
            }
        }

        static void AddDialog()
        {
            bool check, isCorrect;
            string answer;
            int type;

            Console.Clear();

            Console.Clear();
            Console.WriteLine(@"
#####
#Add#
#####
");

            Console.WriteLine(@"Choose type of new item:
1 - airplane;
2 - helicopter;
3 - cruise liner
4 - tanker
5 - car;
6 - train;
    0 - cancel.");

            isCorrect = false;
            do
            {
                answer = Console.ReadLine();

                check = int.TryParse(answer, out type);
                if (!check)
                {
                    Console.WriteLine("Invalid command. Enter a single number from 0 to 6.");
                }
                else
                {
                    if (type == 0)
                    {
                        Console.WriteLine("Cancelled");
                        return;
                    }
                    else if (1 <= type && type <= 6)
                    {
                        isCorrect = true;
                    }
                    else Console.WriteLine("Invalid command. Enter a single number from 0 to 6.");
                }
            } while (!isCorrect);

            Console.WriteLine("\tEnter parameters:");

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Speed: ");
            double speed = EnterDouble();

            Console.Write("Maxixum load: ");
            double maxLoad = EnterDouble();

            Console.WriteLine("Type \"end\" to skip filling non-required parameters or anything else to continue.");
            string decision = Console.ReadLine();

            if (decision.ToLower() == "end")
            {
                Create(type, model, speed, maxLoad);
            }
            else
            {
                Console.WriteLine("Enter the rest of parameters:");

                Console.Write("Staff: ");
                int staff = EnterInt();

                Console.Write("Passengers: ");
                int passengers = EnterInt();

                Create(type, model, speed, maxLoad, staff, passengers);
            }
        }

        static int EnterInt()
        {
            bool check;
            int result;
            do
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if (!check) Console.WriteLine("Enter an integer number.");
            } while (!check);
            return result;
        }

        static double EnterDouble()
        {
            bool check;
            double result;
            do
            {
                check = double.TryParse(Console.ReadLine(), out result);
                if (!check) Console.WriteLine("Enter a real number.");
            } while (!check);
            return result;
        }

        static void Create(int type, string model, double speed, double maxLoad)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        {
                            transports.Add(new Airplane(model, speed, maxLoad));
                            break;
                        }
                    case 2:
                        {
                            transports.Add(new Helicopter(model, speed, maxLoad));
                            break;
                        }
                    case 3:
                        {
                            transports.Add(new CruiseLiner(model, speed, maxLoad));
                            break;
                        }
                    case 4:
                        {
                            transports.Add(new Tanker(model, speed, maxLoad));
                            break;
                        }
                    case 5:
                        {
                            transports.Add(new Car(model, speed, maxLoad));
                            break;
                        }
                    case 6:
                        {
                            transports.Add(new Train(model, speed, maxLoad));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Out of type range, nothing was created");
                            break;
                        }
                }
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAn error occured by creating:\n\t{0}", e.Message);
                Console.ResetColor();
            }
        }

        static void Create(int type, string model, double speed, double maxLoad, int staff, int passengers)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        {
                            transports.Add(new Airplane(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    case 2:
                        {
                            transports.Add(new Helicopter(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    case 3:
                        {
                            transports.Add(new CruiseLiner(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    case 4:
                        {
                            transports.Add(new Tanker(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    case 5:
                        {
                            transports.Add(new Car(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    case 6:
                        {
                            transports.Add(new Train(model, speed, maxLoad, staff, passengers));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Out of types range, nothing was created");
                            break;
                        }
                }
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAn error occured by creating:\n\t{0}", e.Message);
                Console.ResetColor();
            }
        }

        static void DeleteDialog()
        {
            bool isCorrect, check;
            string answer;
            int number;

            if (transports.Count == 0)
            {
                Console.WriteLine("No items yet, nothing to delete");
                return;
            }

            Console.Clear();
            Console.WriteLine(@"
########
#Delete#
########
");

            Console.WriteLine("Would you like to see the list first?\nType \"y\" to see or anything else to skip.");
            answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                ShowList();
            }

            Console.WriteLine("Enter the number of item you want to delete (1-{0}) or type \"end\" to cancel", transports.Count);

            isCorrect = false;
            do
            {
                answer = Console.ReadLine();

                if (answer.ToLower() == "end")
                {
                    Console.WriteLine("Cancelled.");
                    return;
                }

                check = int.TryParse(answer, out number);

                if (!check || number < 1 || number > transports.Count)
                {
                    Console.WriteLine("Incorrect input. An integer number 1-{0} was expected", transports.Count);
                }
                else isCorrect = true;

            } while (!isCorrect);

            try
            {
                number--;
                transports.RemoveAt(number);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAn error occured by deleting:\n\t{0}", e.Message);
                Console.ResetColor();
            }
        }

        static void UpdateDialog()
        {
            bool isCorrect, check;
            string answer;
            int number;

            if (transports.Count == 0)
            {
                Console.WriteLine("No items yet, nothing to edit");
                return;
            }

            Console.Clear();
            Console.WriteLine(@"
######
#Edit#
######
");

            Console.WriteLine("Would you like to see the list first?\nType \"y\" to see or anything else to skip.");
            answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                ShowList();
            }

            Console.WriteLine("Enter the number of item you want to edit (1-{0}) or type \"end\" to cancel", transports.Count);

            isCorrect = false;
            do
            {
                answer = Console.ReadLine();

                if (answer.ToLower() == "end")
                {
                    Console.WriteLine("Cancelled.");
                    return;
                }

                check = int.TryParse(answer, out number);

                if (!check || number < 1 || number > transports.Count)
                {
                    Console.WriteLine("Incorrect input. An integer number 1-{0} was expected", transports.Count);
                }
                else isCorrect = true;

            } while (!isCorrect);

            number--;
            var item = transports[number];

            Console.WriteLine("\n\tChosen item:\n\n{0}\n", item.FullInfo());

            Console.WriteLine("\tEnter new parameters:");

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Speed: ");
            double speed = EnterDouble();

            Console.Write("Maxixum load: ");
            double maxLoad = EnterDouble();

            Console.WriteLine("Type \"end\" to skip filling non-required parameters or anything else to continue.");
            string decision = Console.ReadLine();

            if (decision.ToLower() == "end")
            {
                try
                {
                    item.Model = model;
                    item.Speed = speed;
                    item.MaxLoad = maxLoad;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tAn error occured by editing:\n\t{0}", e.Message);
                    Console.ResetColor();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Enter the rest of parameters:");

                Console.Write("Staff: ");
                int staff = EnterInt();

                Console.Write("Passengers: ");
                int passengers = EnterInt();

                try
                {
                    item.Model = model;
                    item.Speed = speed;
                    item.MaxLoad = maxLoad;
                    item.Staff = staff;
                    item.Passengers = passengers;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tAn error occured by editing:\n\t{0}", e.Message);
                    Console.ResetColor();
                    return;
                }
            }

            try
            {
                transports[number] = item;
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAn error occured by replacing:\n\t{0}", e.Message);
                Console.ResetColor();
            }
        }

        static void ShowPage()
        {
            if (transports.Count == 0)
            {
                Console.WriteLine("No items yet");
                return;
            }

            Console.Clear();

            Console.WriteLine(@"
############
#Items list#
############
");
            int i = 1;
            foreach (var item in transports)
            {
                Console.WriteLine("{0}: {1}\n", i, item.FullInfo());
                i++;
            }
        }

        static void ShowList()
        {
            if (transports.Count == 0)
            {
                Console.WriteLine("No items yet");
                return;
            }

            Console.WriteLine("\n\tItems list:\n");

            int i = 1;
            foreach (var item in transports)
            {
                Console.WriteLine("{0}: {1}\n", i, item.FullInfo());
                i++;
            }
        }

        static void ClearList()
        {
            transports.Clear();
            Console.WriteLine("List cleared");
        }

    }
}
