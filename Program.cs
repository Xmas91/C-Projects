using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TriviaProjectChris
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuestionSupplier qs = null;
            try
            {
                qs = new QuestionSupplier("..\\..\\Questions");
                if (qs.GetCategories().Length == 0)
                    throw new Exception("No Categories found in Directory Folder!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string answer = CategoryPicker.Prompt("Select an Option", "Please choose a category", qs.GetCategories());
            Console.WriteLine("{0}", answer == null ? "Program failed" : "[" + answer + "]");
            
            if(answer != null)
                Application.Run(new Form1(qs, answer));

        }
    }
}
