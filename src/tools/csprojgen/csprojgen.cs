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
            
            for(int i = (shift ? 1 : 0); i < args.Length; i += 2)
            {
                try
                {
                    switches[args[i].Remove(0, 1)] = args[i + 1];
                    Console.WriteLine($"Added {args[i].Remove(0, 1)}");
                }
                catch(IndexOutOfRangeException)
                {
                    Console.Error.WriteLine($"Switch {args[i]} ignored.");
                }
            }

            if(switches.ContainsKey("out") && !(new List<string>() { "Library", "Exe", "Module", "WinExe" }).Contains(switches["out"]))
            {
                Console.Error.WriteLine("Unknown output type: " + switches["out"] + ". Using default 'Exe'.");
                switches["out"] = "Exe";
            }

            File.WriteAllText(outfile, $"<Project Sdk=\"{ (switches.ContainsKey("sdk") ? switches["sdk"] : "Microsoft.Net.Sdk") }\">\n" +
                $"\t<PropertyGroup>\n" +
                $"\t\t<OutputType>{ (switches.ContainsKey("out") ? switches["out"] : "Exe") }</OutputType>\n" +
                $"\t\t<TargetFramework>{ (switches.ContainsKey("frame") ? switches["frame"] : "netcoreapp3.1") }</TargetFramework>\n" +
                $"\t\t<AssemblyName>{ (switches.ContainsKey("name") ? switches["name"] : Directory.GetCurrentDirectory().Split('/').Last()) }</AssemblyName>\n" +
                "\t</PropertyGroup>\n</Project>");
        }
    }
}

/*
csprojgen [outfile] [switches]
    -out: output type, one of { Library, Exe, Module, WinExe } (default: Exe)
    -frame: framework version, no checking done (default: netcoreapp3.1)
    -name: assembly name, (default: directory name)
    -sdk: sdk (default: Microsoft.Net.Sdk)
*/
