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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MongoCRUD db = new MongoCRUD("QuizDB");
        static List<Question> questions = new List<Question>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            StartQuiz win2 = new StartQuiz();
            win2.Show();
            this.Close();
        }
        
        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            aEditQuiz win2 = new aEditQuiz();
            win2.Show();
            this.Close();
        }

        private void ExitQuiz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
