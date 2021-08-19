using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaProjectRemakeChris
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            QuestionSupplier qs = null;
            try
            {
                string DB = @"C:\Users\User\source\repos\QuestionLoader\QuestionLoader\bin\Debug\client.db";
                qs = new QuestionSupplier(DB);
                if (qs.GetCategories().Length == 0)
                    throw new Exception("No Categories found in Directory Folder!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }
            foreach (string category in qs.GetCategories())
            {
                Console.WriteLine(category);
                foreach (Question q in qs.GetQuestions(category))
                {
                    q.dump();
                }
            }

            Console.ReadKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string answer = CategoryPicker.Prompt("Select an Option", "Please choose a category", qs.GetCategories());
            Console.WriteLine("{0}", answer == null ? "Program failed" : "[" + answer + "]");

            if (answer != null)
                Application.Run(new Form1(qs, answer));
        }
    }
}
