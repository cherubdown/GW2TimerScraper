using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GW2TimerScraper
{
    class Program
    {
        public static int RunInterval = 5000;   // default to 5 seconds

        static void Main(string[] args)
        {
            AcceptArgs();   //ask for time input
            StartTimers();  //start the timers and kickoff Process
            Process();      //first process kickoff at T=0
            Wait();
        }

        /// <summary>
        /// Awaits input for process runtime, with validation
        /// </summary>
        private static void AcceptArgs()
        {
            Console.Write(string.Format("Give interval between process run time (in ms, greater than {0}): ", RunInterval - 1));
            string input = Console.ReadLine();
            Console.WriteLine();
            int value = RunInterval;
            if (input == null || input.Length < 0 || !int.TryParse(input, out value) || value < RunInterval)
            {
                Console.WriteLine(string.Format("Input is not an integer greater than {0}.", RunInterval - 1));
                AcceptArgs();
            }
            else
            {
                RunInterval = value;
            }
        }

        /// <summary>
        /// Creates a timer and runs whatever is in Run
        /// </summary>
        private static void StartTimers()
        {
            Console.WriteLine("Starting scanner.");
            Timer myTimer = new Timer();
            myTimer.Elapsed += Run;
            myTimer.Interval = RunInterval;
            myTimer.Enabled = true;
        }

        /// <summary>
        /// While console is up, you can press ESC to stop
        /// </summary>
        private static void Wait()
        {
            Console.WriteLine("Press ESC to stop.");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // do nothing
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Process logic goes here
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        private static void Run(object src, ElapsedEventArgs e)
        {
            Process();
        }

        private static void Process()
        {
            Console.WriteLine("Process kickoff.");
            Console.WriteLine(GW2TimerScraper.Run());
        }
    }
}
