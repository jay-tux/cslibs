using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Jay.CSLibs.Tools.CSProjGen
{
    public class Entry
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> switches = new Dictionary<string, string>();
            string outfile = "";
            bool shift = false;
            if(args.Length == 0) outfile = Directory.GetCurrentDirectory() + ".csproj";
            else if(!args[0].StartsWith("-"))
            {
                outfile = (args[0].EndsWith(".csproj") ? args[0] : (args[0] + ".csproj"));
                shift = true;
            }
            else
            {
                for(int i = (shift ? 1 : 0); i < args.Length; i += 2)
                {
                    try
                    {
                        switches[args[i].Remove(0, 1)] = switches[args[i + 1]];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        Console.Error.WriteLine($"Switch {args[i]} ignored.");
                    }
                }
            }
            Console.WriteLine($"Output File: {outfile}");
            Console.WriteLine($"Switches: ");
            foreach(var v in switches) { Console.WriteLine($"\t{v.Key} = {v.Value}"); }
        }
    }
}

/*
csprojgen [outfile] [switches]

*/
