using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window, INotifyPropertyChanged
    {
        List<Questionn> list = new List<Questionn>();
        int ticketTrue = 0;//сделать мнгновенное обновление связи после изменения, (NotifyPropertyChanged) не работает
        int ticketFalse = 0;
        int ticket = 0;
        int answer;
        string Nticket;   

        public TestWindow()
        {
            InitializeComponent();
            List<Questionn> list = new List<Questionn>();
            tbNTicket.DataContext = ticket;
            tbTr.DataContext = ticketTrue;
            tbFls.DataContext = ticketFalse;            
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            if ((answer == 1 && radBut1.IsChecked == true) || (answer == 2 && radBut2.IsChecked == true) || (answer == 3 && radBut3.IsChecked == true))
            {
                MessageBox.Show("Правильный ответ");
                ticketTrue++;
                this.OnPropertyChanged("ticketTrue");
            }
            else
            {
                MessageBox.Show("Неправильный ответ");
                ticketFalse++;
                this.OnPropertyChanged("ticketFalse");
            }
            ticket++;
            this.OnPropertyChanged("ticket");

            if (list.Count != 0)
            {
            tb_quest.Text = list[ticket].Question;
            tb_answer1.Text = list[ticket].Variant1;
            tb_answer2.Text = list[ticket].Variant2;
            tb_answer3.Text = list[ticket].Variant3;
            answer = list[ticket].Answer;
            }
            else MessageBox.Show("Выберите существующий вариант");
            tbNTicket.Text = ticket.ToString();
            tbTr.Text = ticketTrue.ToString();
            tbFls.Text = ticketFalse.ToString();

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            if(list!=null)list.Clear();
            ticket = 0;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            cbVar.Text = selectedItem.Content.ToString();// все равно выбор не виден на комбобоксе
            Nticket = selectedItem.Content.ToString();
            using (ModelEDM db = new ModelEDM())
            {
                var command = db.Database.SqlQuery<Questionn>("SELECT * FROM Questions WHERE Var = '" + Nticket + "'");
                                
                foreach (var aa in command)
                {
                    list.Add(aa);     
                }
            }

            if (list.Count != 0)
            {
                tb_quest.Text = list[ticket].Question;
                tb_answer1.Text = list[ticket].Variant1;
                tb_answer2.Text = list[ticket].Variant2;
                tb_answer3.Text = list[ticket].Variant3;
                answer = list[ticket].Answer;
            }
            else MessageBox.Show("Выберите существующий вариант");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
