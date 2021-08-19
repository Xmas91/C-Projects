using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace TriviaProjectRemakeChris
{
    //Question Object
    public class Question
    {
        public enum Letter { NONE = -1, A, B, C, D, E }

        //Question object constructor
        public Question()
        {
            Answers = new List<string>();
            CorrectAnswer = Letter.NONE;
        }

        //Getters and setters for the 3 variables that make up the Question object
        public string Prompt { get; set; }
        public Letter CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }

        //An improtu toString for testing purposes
        public void dump()
        {
            Console.WriteLine($"prompt: {Prompt}");
            Console.WriteLine($"correct answer: {CorrectAnswer}");
            var s = String.Join("\nanswers: ", Answers);
            Console.WriteLine($"answers: {s}");
        }
    }
    //Object that will get the questions and set them up properly with my system
    public class QuestionSupplier
    {
        private Dictionary<string, List<Question>> ListCategories = new Dictionary<string, List<Question>>();

        //QuestionSupplier constructor, needs a string with info on where the Database file is to be built
        public QuestionSupplier(string DB)
        {
            //The exact string/location of the database put into an easy to call variable
            const string connectString = @"URI=file:C:\Users\User\source\repos\QuestionLoader\QuestionLoader\bin\Debug\client.db";
            //Creates the connection to the Database
            var theConnection = new SQLiteConnection(connectString);
            theConnection.Open();

            //The three different variable commands I used to add the 3 different variables that make up the questions into the database
            var cmd = new SQLiteCommand(theConnection);
            var cmd2 = new SQLiteCommand(theConnection);
            var cmd3 = new SQLiteCommand(theConnection);

            cmd.CommandText = "select id, name from categories";
            SQLiteDataReader SQLquestionsReader = cmd.ExecuteReader();
            
            //Run a while loop that keeps going while there is still stuff to read and input into the database
            //This first while loop SQLquestionsReader is for gathering the questions and correct answer and establishing the ID for them
            while (SQLquestionsReader.Read())
            {
                //Setting the variables needed to use the SQL commands
                int id = 0;
                string name = SQLquestionsReader["name"].ToString();
                int.TryParse(SQLquestionsReader["id"].ToString(), out id);
                //Create the list for holding the questions
                var questions = new List<Question>();
                string sql = string.Format("select id, prompt, correct_answer from questions where category_id = {0}", id);
                cmd2.CommandText = sql;
                SQLiteDataReader SQLanswersReader = cmd2.ExecuteReader();

                //The second while loop SQLanswersReader is for going into that question and displaying the Prompt and the Correct answer while feeding the ID into the next loop
                while (SQLanswersReader.Read())
                {
                    //Setting the variables needed to output them with the console writeline function
                    int id2 = 0;
                    int.TryParse(SQLanswersReader["id"].ToString(), out id2);
                    string prompt = SQLanswersReader["prompt"].ToString();
                    int correct = 0;
                    int.TryParse(SQLanswersReader["correct_answer"].ToString(), out correct);
                    Console.WriteLine(id2 + " " + prompt + " " + correct);

                    //Create the list for the answers and set the command to grab them for the right question in the right order
                    var aList = new List<string>();
                    string sql2 = string.Format("select answer from answers where question_id = {0} order by number", id2);
                    cmd3.CommandText = sql2;
                    SQLiteDataReader SQLanswersWriter = cmd3.ExecuteReader();
                    while (SQLanswersWriter.Read())
                    {
                        //As we output the answers in the right order, add them to the list we made
                        string answer = SQLanswersWriter["answer"].ToString();
                        Console.WriteLine(answer);
                        aList.Add(answer);
                    }
                    SQLanswersWriter.Close();

                    //Make the Question object that will have all the data in it we made from the Database
                    Question theQuestion = new Question();
                    theQuestion.Answers = aList;
                    theQuestion.Prompt = prompt;
                    theQuestion.CorrectAnswer = (Question.Letter)correct;

                    questions.Add(theQuestion);
                }
                SQLanswersReader.Close();
                Console.WriteLine(id + " " + name);

                ListCategories[name] = questions;
            }
            SQLquestionsReader.Close();
        }
       
        
        public string[] GetCategories()
        {
            return (ListCategories.Keys.ToArray());
        }
        public List<Question> GetQuestions(string category)
        {
            return (ListCategories[category]);
        }
    }
}
