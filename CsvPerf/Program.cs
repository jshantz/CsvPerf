using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public class Program
    {
        public const string DataFile = @"..\..\..\Batting.csv";

        private static readonly Dictionary<string, Action<byte[]>> _actions = new Dictionary<string, Action<byte[]>>()
        {
          { "01", Option01.Execute },
          { "02", Option02.Execute },
          { "03", Option03.Execute },
          { "04", Option04.Execute },
          { "05", Option05.Execute },
          { "06", Option06.Execute },
          { "07", Option07.Execute },
          { "08", Option08.Execute },
          { "09", Option09.Execute },
          { "10", Option10.Execute }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to begin.");
            Console.ReadLine();

            Action<byte[]> optionToExecute = Option01.Execute;
            if (args.Length > 0)
            {
                _actions.TryGetValue(args[0], out optionToExecute);
            }

            var bytes = File.ReadAllBytes(Program.DataFile);

            int repeatCount = 1;
            if (args.Length > 1)
            {
                repeatCount = Convert.ToInt32(args[1]);
            }

            for (var iter = 0; iter < repeatCount; iter++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Reset();
                sw.Start();
                optionToExecute(bytes);
                sw.Stop();
                Console.WriteLine(sw.Elapsed.TotalSeconds + " second(s) elapsed.");
            }

            Console.WriteLine("Press ENTER to end.");
            Console.ReadLine();
        }
    }
}
