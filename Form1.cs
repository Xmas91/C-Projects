using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TriviaProjectRemakeChris
{
    public partial class Form1 : Form
    {
        private List<Control> mControls = new List<Control>();
        private QuestionSupplier qs = null;
        private int mCurrentQuestionNum = 0;
        private int mNumTotalQuestions = 0;
        private int mCorrectAnswers = 0;
        private int mIncorrectAnswers = 0;
        private bool mWrongOrRight = true;
        private string mCurrentCategory = null;
        private bool mFinishedCategory = false;

        public Form1(QuestionSupplier supplier, string answer)
        {
            CenterToScreen();
            mCurrentCategory = answer;
            qs = supplier;
            mNumTotalQuestions = qs.GetQuestions(mCurrentCategory).Count;
            InitializeComponent();
            button2.Enabled = false;
            ShowQuestion();
        }
        private bool GetSelected(out char selectedLetter, out string selectedText)
        {
            selectedLetter = ' ';
            selectedText = "";
            char letter = 'A';

            foreach (Control c in mControls)
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
        private void Continue_Click(object sender, EventArgs e)
        {
            if (mControls.Count > 0)
            {
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
                    mCurrentQuestionNum++;
                }
                else
                {
                    MessageBox.Show("No answer selected, please pick one!");
                }
                //After getting the selected choice, we clear the controls added from our list
                foreach (Control c in mControls)
                    Controls.Remove(c);
                mControls.Clear();
            }
            //If we are not at the end of the Current Category, show the next question
            if (mCurrentQuestionNum < qs.GetQuestions(mCurrentCategory).Count)
                ShowQuestion();
            else
            {
                //Display a message box showing how many the user got right and wrong
                MessageBox.Show("Number of correct answers: " + mCorrectAnswers +
                                "\nNumber of incorrect answers: " + mIncorrectAnswers);
                //Tell the user what they can do next after finishing a category and respond accordingly
                string answer = CategoryPicker.Prompt("Pick a category", "Choose a category or cancel to exit", qs.GetCategories());
                if (answer == null)
                    Application.Exit();
                else
                {
                    //Reset all the member variables to be the state they need to be to run from start since I am not remaking the whole form
                    mFinishedCategory = false;
                    mCurrentCategory = answer;
                    mCurrentQuestionNum = 0;
                    mCorrectAnswers = 0;
                    mIncorrectAnswers = 0;
                    mWrongOrRight = true;
                    //Start from the top and show a question with the new category
                    ShowQuestion();
                }
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            if (mFinishedCategory == true)
                Application.ExitThread();
            else
            {
                //Clear all the controls when the user goes back a question
                foreach (Control c in mControls)
                    Controls.Remove(c);
                mControls.Clear();
                //Make sure the right variables are adjusted when the user goes backwards
                if (mCurrentQuestionNum > 0)
                {
                    mCurrentQuestionNum--;

                    if (mWrongOrRight == true)
                        mCorrectAnswers--;
                    else
                        mIncorrectAnswers--;

                    ShowQuestion();
                }
            }
        }
        private Question GetCurrentQuestion()
        {
            return (qs.GetQuestions(mCurrentCategory)[mCurrentQuestionNum]);
        }
        private void ShowQuestion()
        {
            //Set the title of the program at the top
            string title = "Question: " + (mCurrentQuestionNum + 1) + " of " + qs.GetQuestions(mCurrentCategory).Count;
            Text = title;
            //Setup where the question and answers show up and resize them to fit
            Label prompt = new Label();
            prompt.Text = GetCurrentQuestion().Prompt;
            prompt.AutoSize = true;
            prompt.Location = new Point(40, 40);
            //Clear out any left over controls before adding in the new Question object
            mControls.Clear();
            mControls.Add(prompt);
            Controls.Add(prompt);
            //Make sure you can't go back when on the first question
            button2.Enabled = (mCurrentQuestionNum != 0);
            //Now add in and position the radio buttons accordingly
            char x = 'A';
            for (int i = 0; i < GetCurrentQuestion().Answers.Count; i++)
            {
                var r = new RadioButton();
                r.Text = x++ + ") " + GetCurrentQuestion().Answers[i];
                r.AutoSize = true;
                r.Location = new Point(40, 60 + 20 * i);
                mControls.Add(r);
                Controls.Add(r);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;

            DialogResult result = MessageBox.Show(
              "Are you sure you want to quit?",
              "Quit - Confirm",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
