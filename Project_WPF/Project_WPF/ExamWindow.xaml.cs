using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Project_WPF
{
    /// <summary>
    /// Логика взаимодействия для ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window//сделать выбор билета для экзамена
    {     
        List<Questionn> list = new List<Questionn>();
        int tabelN;
        int variant = 1;//сделать получение варианта из базы
        int answer;
        int _count = 1;
        int countTicket;

        public ExamWindow()
        {
            InitializeComponent();
            tbNtic.DataContext = _count;
            //List<Questionn> list = new List<Questionn>();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            if(_count <= 4)
            {
                if ((answer == 1 && radBut1.IsChecked == true) || (answer == 2 && radBut2.IsChecked == true) || (answer == 3 && radBut3.IsChecked == true))
                {
                    Random random = new Random();
                    int _ticketN = random.Next(0, countTicket);

                    tb_quest.Text = list[_ticketN].Question;
                    tb_answer1.Text = list[_ticketN].Variant1;
                    tb_answer2.Text = list[_ticketN].Variant2;
                    tb_answer3.Text = list[_ticketN].Variant3;
                    answer = list[_ticketN].Answer;
                    _count++;
                    tbNtic.Text = _count.ToString();
                }
                else
                {
                    MessageBox.Show("Экзамен не сдан");
                    Clear();
                    _count = 10;                   
                } 
            }           
            if (_count == 5)
            {
                MessageBox.Show("Экзамен сдан");
                Clear();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }    

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (tbTabel.Text.Length == 0) MessageBox.Show("Введите табельный номер");
            bool result = int.TryParse(tbTabel.Text, out tabelN);
            if (!result) MessageBox.Show("Введите корректный табельный номер");
            else
            {
                using (ModelEDM db = new ModelEDM())
                {
                    //    // var command = db.Database.SqlQuery<Title>("SELECT var_id FROM Titles WHERE Var = '" + Nticket + "'");
                    //    //var command = db.Database.SqlQuery<Title>("SELECT Titles.var_id FROM Titles in Titles.AsEnumerable() JOIN Employee in Employee.AsEnumerable() ON Titles.title_id EQUALS Employee.title_id WHERE Employee.Tabel_id == 'tabelN' ");
                    //    var command = db.Database.SqlQuery<Title>("SELECT Titles.var_id FROM Titles ");
                    //    //доделать запрос на получение номера варианта из таблицы Titles по табельному номеру из таблицы Emplyee

                    //    //foreach (var aa in command)
                    //    //{                       
                    //    //    variant = (int)aa.var_id;                        
                    //    //}
                }
                using (ModelEDM db = new ModelEDM())
                {
                    var command = db.Database.SqlQuery<Questionn>("SELECT * FROM Questions WHERE Var = '" + variant + "'");

                    foreach (var aa in command)
                    {
                        list.Add(aa);
                    }
                }
                countTicket = list.Count();
                Random random = new Random();
                int _ticketN = random.Next(0, countTicket);
                tb_quest.Text = list[_ticketN].Question;
                tb_answer1.Text = list[_ticketN].Variant1;
                tb_answer2.Text = list[_ticketN].Variant2;
                tb_answer3.Text = list[_ticketN].Variant3;
                answer = list[_ticketN].Answer;                
            }   
        }
        private void Clear()
        {
            list.Clear();
            tb_quest.Text = "";
            tb_answer1.Text = "";
            tb_answer2.Text = "";
            tb_answer3.Text = "";
            _count = 1;
            tbNtic.Text = _count.ToString();
        }
    }
}
