using System.Collections;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Task3
{
    class Program
    {


        static void Main(string[] args)
        {
            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Input error, all arguments must be varied");
                return;
            }
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Input error, please enter an odd number of arguments greater than 3");
                return;
            }
            Cryptography security = new Cryptography();
            Table table = new Table(args);
            Referee referee = new Referee(args.Length);

            while (true)
            {
                var key = security.Key();
                var StepOfComputer = RandomNumberGenerator.GetInt32(args.Length);


                Console.WriteLine("HMAC: " + security.HMAC(key, args[StepOfComputer]));
                Console.WriteLine("MENU:");
                Console.WriteLine("0 - exit");
                Console.WriteLine("! - help");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + args[i]);
                }

                Console.WriteLine("Please select: ");
                string select = Console.ReadLine();

                if (select == "0")
                {
                    Console.WriteLine("Exit the game");
                    break;
                }

                if (select == "!")
                {
                    table.Help();
                    continue;
                }

                int StepOfPlayer = int.Parse(select);
                Console.WriteLine("Your move: " + args[StepOfPlayer - 1]);
                Console.WriteLine("Computer move: " + args[StepOfComputer]);

                if (StepOfPlayer < 0 || StepOfComputer > args.Length)
                {
                    Console.WriteLine("Error, please select of " + args);
                }

                switch (referee.Solution(StepOfPlayer - 1, StepOfComputer))
                {
                    case Result.WON:
                        Console.WriteLine("You WON =)");
                        break;

                    case Result.LOSE:
                        Console.WriteLine("You LOSE =(");
                        break;

                    default:
                        Console.WriteLine("DRAW =|");
                        break;
                }

                Console.WriteLine("HMAC KEY: " + key);
                return;


            }



        }

    }
}