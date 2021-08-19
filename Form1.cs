using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace TriviaProjectChris
{
    public partial class Form1 : Form
    {
        private List<Control> mAdded = new List<Control>();
        QuestionSupplier qs = null;
        int mNum = 0;
        int mNumQuestions = 0;
        int mCorrectAnswers = 0;
        int mIncorrectAnswers = 0;
        bool mWrongOrRight = true;
        string mCurrentCategory = null;
        bool mFinishedCategory = false;
        

        public Form1(QuestionSupplier supplier, string answer)
        {
            
            mCurrentCategory = answer;

            this.CenterToScreen();
            qs = supplier;
            mNumQuestions = qs.GetQuestions(mCurrentCategory).Count;
            InitializeComponent();
            //disable back button on start up
            this.button2.Enabled = false;
        }
        private bool GetSelected(out char selectedLetter, out string selectedText)
        {
            selectedLetter = ' ';
            selectedText = "";

            char letter = 'A';

            foreach (Control c in mAdded)
            {
                if (c is RadioButton)
                {
                    var r = (RadioButton)c;

                    if (r.Checked)
                    {
                        selectedLetter = letter;
                        selectedText = r.Text;
                        break;
                    }

                    letter++;
                }
            }
            return (selectedText != "");
        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            //if (mFinishedCategory == true)
            //    Application.Restart();

            if (mAdded.Count > 0)
            {
                // See which radio button was checked, if any

                char selectedLetter = ' ';
                string selectedText = "";

                if (GetSelected(out selectedLetter, out selectedText))
                {
                    if ((int)GetCurrentQuestion().CorrectAnswer == selectedLetter - 'A')
                    {
                        mCorrectAnswers++;
                        mWrongOrRight = true;
                    }
                    else
                    {
                        mIncorrectAnswers++;
                        mWrongOrRight = false;
                    }
                    mNum++;
                }
                else
                {
                    MessageBox.Show("No answer selected");
                }

                foreach (Control c in mAdded)
                    Controls.Remove(c);

                mAdded.Clear();
            }

            if (mNum < qs.GetQuestions(mCurrentCategory).Count)
            {
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("Number of correct answers: " + mCorrectAnswers +
                                "\nNumber of incorrect answers: " + mIncorrectAnswers);

                string answer = CategoryPicker.Prompt("Pick a category", "Choose a category or cancel to exit", qs.GetCategories());
                if (answer == null)
                {
                    Application.Exit();
                }
                else
                {
                    mFinishedCategory = false;
                    //RestartProgram();

                    mCurrentCategory = answer;
                    mNum = 0;
                    mCorrectAnswers = 0;
                    mIncorrectAnswers = 0;
                    mWrongOrRight = true;

                    ShowQuestion();
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (mFinishedCategory == true)
            {
                Application.ExitThread();
            }
            else
            {
                foreach (Control c in mAdded)
                    Controls.Remove(c);

                mAdded.Clear();

                if (mNum > 0)
                {
                    mNum--;
                    if (mWrongOrRight == true)
                    {
                        mCorrectAnswers--;
                    }
                    else
                    {
                        mIncorrectAnswers--;
                    }

                    ShowQuestion();
                }
            }
        }
        private Question GetCurrentQuestion()
        {
            return (qs.GetQuestions(mCurrentCategory)[mNum]);
        }
        private void ShowQuestion()
        {
            string title = "Question: " + (mNum + 1) + " of " + qs.GetQuestions(mCurrentCategory).Count;
            this.Text = title;

            
            Label prompt = new Label();
            prompt.Text = GetCurrentQuestion().Prompt;
            prompt.AutoSize = true;

            prompt.Location = new Point(40, 40);

            mAdded.Clear();
            mAdded.Add(prompt);

            Controls.Add(prompt);

            if (mNum == 0)
                this.button2.Enabled = false;
            else
                this.button2.Enabled = true;

            char x = 'A';
            for (int i = 0; i < GetCurrentQuestion().Answers.Count; i++)
            {
                var r = new RadioButton();
                r.Text = x++ + ") " + GetCurrentQuestion().Answers[i];
                r.AutoSize = true;

                r.Location = new Point(40, 60 + 20 * i);

                mAdded.Add(r);
                Controls.Add(r);
            }
        }
    }
}
