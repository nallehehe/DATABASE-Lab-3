using Labb3_NET22.Data;
using Labb3_NET22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Labb3_NET22;

/// <summary>
/// Interaction logic for StartQuiz.xaml
/// </summary>
public partial class StartQuiz : Window
{

    private List<Question> shuffledQuestions;
    private Question currentQuestion;
    private int loadNextQuestion = 0;
    private int totalQuestions;
    private double checkedAnswer = 0;
    private double correctCheckedQuestion = 0;
    private MongoCRUD mongoCRUD;

    public StartQuiz()
    {
        InitializeComponent();

        mongoCRUD = new MongoCRUD("QuizDB");

        var questions = mongoCRUD.GetAllQuestions("Question");
        shuffledQuestions = ShuffleQuestions(questions);
        totalQuestions = shuffledQuestions.Count;

        LoadRandomQuestion();
    }

        private void LoadRandomQuestion()
        {
        
             currentQuestion = shuffledQuestions[loadNextQuestion];

             QuizQuestion.Text = currentQuestion.Text;

             Answer1.Content = currentQuestion.Options[0];
             Answer2.Content = currentQuestion.Options[1];
             Answer3.Content = currentQuestion.Options[2];

             loadNextQuestion++;
        
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {

            if (checkedAnswer < totalQuestions)
            {
                checkedAnswer++;

                if (Answer1.IsChecked == true && Answer1.Content.ToString() == currentQuestion.CorrectAnswer)
                {
                    correctCheckedQuestion++;
                    double percentage = questionPercentage();
                    MessageBox.Show($"Correct! ({percentage}% / 100%)");
                }
                else if (Answer2.IsChecked == true && Answer2.Content.ToString() == currentQuestion.CorrectAnswer)
                {
                    correctCheckedQuestion++;
                    double percentage = questionPercentage();
                    MessageBox.Show($"Correct! ({percentage}% / 100%)");
                }
                else if (Answer3.IsChecked == true && Answer3.Content.ToString() == currentQuestion.CorrectAnswer)
                {
                    correctCheckedQuestion++;
                    double percentage = questionPercentage();
                    MessageBox.Show($"Correct! ({percentage}% / 100%)");
                }
                else
                {
                    double currentPrecentage = questionPercentage();
                    MessageBox.Show($"Incorrect.. ({currentPrecentage}% / 100%)");
                }

            }
        
            if (checkedAnswer < totalQuestions)
            {
                LoadRandomQuestion();
            }

            else
            {
                double finishedPercentage = questionPercentage();
                MessageBox.Show($"You have answered all questions! \n You got {correctCheckedQuestion}/{checkedAnswer}! ({finishedPercentage}% / 100%)");
            }
        }

        private void NextQuestion()
        {
            loadNextQuestion++;
            LoadRandomQuestion();
        }

        private double questionPercentage()
        {
            return Math.Round(correctCheckedQuestion / checkedAnswer * 100, 1);
        }

        private void Answer1_Checked(object sender, RoutedEventArgs e)
        {

        }

    private void ExitQuiz_Click(object sender, RoutedEventArgs e)
    {
        MainWindow win2 = new MainWindow();
        win2.Show();
        this.Close();
    }

    public static List<T> ShuffleQuestions<T>(List<T> shuffle)
    {
        Random random = new Random();
        int n = shuffle.Count;

        for (int i = 0; i < n - 1; i++)
        {
            int j = random.Next(i, n);
            T temp = shuffle[i];
            shuffle[i] = shuffle[j];
            shuffle[j] = temp;
        }

        return shuffle;
    }
}
