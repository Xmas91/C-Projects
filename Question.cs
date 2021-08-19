using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaProjectChris
{
    public class Question
    {
        public enum Letter { NONE = -1, A, B, C, D, E }


        public Question()
        {
            Answers = new List<string>();
            CorrectAnswer = Letter.NONE;
        }

        public string Prompt { get; set; }
        public Letter CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }


        //public void Dump()
        //{
        //    Console.WriteLine("Question: {0, -10}", Prompt);
        //    Console.WriteLine("Correct Answer: {0, -5}", CorrectAnswer);

        //    char i = 'A';
        //    foreach (string s in Answers)
        //    {
        //        Console.WriteLine("{0}) {1}", i++, s);
        //    }
        //}
    }
    public class QuestionSupplier
    {
        private Dictionary<string, List<Question>> ListCatagories = new Dictionary<string, List<Question>>();
        
        public static string[] GetQuestionFileNames(string directory)
        {
            var fileNames = new List<string>();

            foreach (var s in Directory.GetFiles(directory, "*.txt"))
            {
                fileNames.Add(s);
            }

            
            return (fileNames.ToArray());
        }
        public QuestionSupplier(string directory)
        {
            //Check for no question.txt files in directory
            
            string[] names = GetQuestionFileNames(directory);
            
            foreach (string fileName in names)
            {
                var Questions = new List<Question>();
                string[] lines = File.ReadAllLines(fileName);
                Question question = new Question();
                foreach (string line in lines)
                {
                    string theLine = line.Trim();

                    if (theLine != "")
                    {

                        int index = theLine.IndexOf(':');

                        if (index < 0)
                            throw new Exception("No ':' found in line: [" + theLine + "]");

                        string left = theLine.Substring(0, index).Trim();
                        string right = theLine.Substring(index + 1).Trim();

                        if (left == "")
                            throw new Exception("Left side of: [" + theLine + "] is empty");
                        if (right == "")
                            throw new Exception("Right side of: [" + theLine + "] is empty");

                        switch (left)
                        {
                            case "prompt":
                                {
                                    if (question.Prompt != null)
                                    {
                                        CheckQuestion(question);
                                        Questions.Add(question);
                                        question = new Question();
                                    }
                                    question.Prompt = right;
                                }
                                break;
                            case "correct-answer":
                                switch (right.ToUpper())
                                {
                                    case "A":
                                        question.CorrectAnswer = Question.Letter.A;
                                        break;
                                    case "B":
                                        question.CorrectAnswer = Question.Letter.B;
                                        break;
                                    case "C":
                                        question.CorrectAnswer = Question.Letter.C;
                                        break;
                                    case "D":
                                        question.CorrectAnswer = Question.Letter.D;
                                        break;
                                    case "E":
                                        question.CorrectAnswer = Question.Letter.E;
                                        break;
                                    default:
                                        throw new Exception("Invalid Correct Answer: " + right + " " + theLine);
                                }
                                break;
                            case "answer":
                                {
                                    question.Answers.Add(right);
                                }
                                break;
                        }
                    }
                }
                if (question.Prompt != null)
                {
                    CheckQuestion(question);
                    Questions.Add(question);
                }
                string key = FileNameToCategory(fileName);
                ListCatagories[key] = Questions;
            }
        }
        public static string FileNameToCategory(string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(
               fileName.Replace("-", " ")
            );
            name = Path.GetFileName(name.ToLower());
            string result = "";

            for (int i = 0; i < name.Length; i++)
            {
                char theChar = name[i];

                if (!char.IsWhiteSpace(theChar))
                {
                    if (i == 0 || char.IsWhiteSpace(name[i - 1]))
                        theChar = char.ToUpper(theChar);
                }

                result += theChar;
            }

            return (result);
        }
        private static void CheckQuestion(Question question)
        {
            int correctIndex = (int)question.CorrectAnswer + 1;
            if (question.Answers.Count < correctIndex)
                throw new Exception("Correct Answer is " + question.CorrectAnswer + " but the total number of answers found is " + question.Answers.Count);
            if (question.CorrectAnswer == Question.Letter.NONE)
                throw new Exception("Correct Answer was never set!");
        }
        //public List<Question> Questions { get; set; }
        public string[] GetCategories()
        {
            return (ListCatagories.Keys.ToArray());
        }
        public List<Question> GetQuestions(string category)
        {
            return (ListCatagories[category]);
        }
    }
}
