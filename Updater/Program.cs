using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Updater
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Argument 1: " + args[0]);
                try
                {
                    if (args[1] != null)
                    {
                        Console.WriteLine("Argument 2: " + args[1]);
                    }
                }
                catch
                {
                    Console.WriteLine("No argument 2...");
                }
                try
                {
                    if (args[2] != null)
                    {
                        Console.WriteLine("Argument 3: " + args[2]);
                        if (args[2].Contains("-relaunch"))
                            relaunch = true;
                    }
                }
                catch
                {
                    Console.WriteLine("No argument 3...");
                }
                if (args[0].Contains("-baseApp.") || args[0].Contains("-mapper."))
                {
                    if (args[0].Contains("-baseApp.") && (args[1].Contains("-newApp.") || args[1].Contains("-fromUrl.")))
                    {
                        baseApp = args[0].Remove(0, 9);
                        if (args[1].Contains("-fromUrl."))
                        {
                            urlMode = true;
                            newApp = args[1].Remove(0, 9);
                        }
                        else
                        {
                            newApp = args[1].Remove(0, 8);
                        }
                    }
                    else if (args[0].Contains("-mapper."))
                    {
                        MessageBox.Show("Disabled for now, sorry!", "Updater");
                        Environment.Exit(0);
                        /*
                        mapmode = true;
                        var file = args[0].Remove(0, 8);
                        if (File.Exists(file))
                        {
                            var lines = File.ReadAllLines(file);
                            for (var i = 0; i < lines.Length; i += 1)
                            {
                                var line = lines[i];
                                if (line.Contains("-base."))
                                { 
                                    baseApps.Add(line.Remove(0, 6));
                                    Console.WriteLine("baseApps count: " + baseApps.ToArray().Length.ToString());
                                }
                                else if (line.Contains("-new."))
                                {
                                    newApps.Add(line.Remove(0, 5));
                                    Console.WriteLine("newApps count: " + newApps.ToArray().Length.ToString());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Map file not found...");
                            Environment.Exit(0);
                        }*/
                    }
                    else
                    {
                        Console.WriteLine("Invaild argument...");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Invaild argument...");
                    Environment.Exit(0);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrm());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error.");
                Console.WriteLine(ex);
                Environment.Exit(0);
            }
        }
        public static string baseApp, newApp;
        public static List<string> baseApps = new List<string>();
        public static List<string> newApps = new List<string>();
        public static bool urlMode, relaunch, mapmode;
    }
}
