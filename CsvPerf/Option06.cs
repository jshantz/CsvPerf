﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvPerf
{
    public static class Option06
    {
        public static void Execute(byte[] bytes)
        {
            var batters = new List<Option06Batter>();
            using (var byteStream = new MemoryStream(bytes))
            {
                using (var reader = new StreamReader(byteStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var batter = new Option06Batter(reader.ReadLine());
                        batters.Add(batter);
                    }
                }
            }

            Console.WriteLine(batters.Count + " batters created.");
        }
    }
}
