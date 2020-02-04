
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RunPythonScriptFromCS
{
    class Program
    {
        static void Main(string[] args)
        {

            // On créé la grille de Sudoku à résoudre
            int[] initial_grid = new int[] { 0, 6, 0, 0, 5, 0, 0, 2, 0,

                                             0, 0, 0, 3, 0, 0, 0, 9, 0,

                                             7, 0, 0, 6, 0, 0, 0, 1, 0,

                                             0, 0, 6, 0, 3, 0, 4, 0, 0,

                                             0, 0, 4, 0, 7, 0, 1, 0, 0,

                                             0, 0, 5, 0, 9, 0, 8, 0, 0,

                                             0, 4, 0, 0, 0, 1, 0, 0, 6,

                                             0, 3, 0, 0, 0, 8, 0, 0, 0,

                                             0, 2, 0, 0, 4, 0, 0, 5, 0 };

            int[] solved_grid = initial_grid;

            string grid = "";

            foreach(int i in initial_grid)
            {
                grid += i.ToString();
            }

            DateTime T_init = DateTime.Now;

            //Option1_ExecProcess();

            DateTime T_final = DateTime.Now;

            TimeSpan t_exec = T_final - T_init;

            Console.WriteLine("La solution a été trouvé en " + (double)t_exec.TotalSeconds + " secondes");
            Console.WriteLine(grid);

            int indice = 0;

            foreach(char x in solved_grid)
            {
                solved_grid[indice] = x;
                Console.WriteLine(solved_grid[indice]);
                indice++; 
            }  

        }

        static void Option1_ExecProcess()
        {
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\thoma\AppData\Local\Programs\Python\Python38-32\python.exe";

            // 2) Provide script and arguments
            var script = @"C:\Users\thoma\Desktop\Cours ING4\IA\TP-Sudoku-master\Sudoku-Solver-CNN-master\model.py";
            var game = "080032001703080002500007030050001970600709008047200050020600009800090305300820010";

            psi.Arguments = $"\"{script}\" \"{game}\"";

            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);

        }


    }
}

