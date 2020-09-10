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
        
        ObservableCollection<Questionn> Questions;
        
        int ticketTrue = 0;//сделать мнгновенное обновление связи после изменения, (NotifyPropertyChanged) не работает
        int ticketFalse = 0;
        int ticket = 1;
        int answer;
        string Nticket;
        




        public TestWindow()
        {
            InitializeComponent();
            Questions = new ObservableCollection<Questionn>();            
            tbNTicket.DataContext = ticket;
            tbTr.DataContext = ticketTrue;
            tbFls.DataContext = ticketFalse;
            grid.DataContext = Questions;          
                      
           
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            using (ModelEDM db = new ModelEDM())
            {
                var command = db.Database.SqlQuery<Questionn>("SELECT * FROM Questions WHERE Var = '" + Nticket + "'");

                foreach (var aa in command)
                {
                    tb_quest.Text = aa.Question;
                    tb_answer1.Text = aa.Variant1;
                    tb_answer2.Text = aa.Variant2;
                    tb_answer3.Text = aa.Variant3;
                    answer = aa.Answer;
                    //while(true)
                    //{
                    //    if (test.IsPressed) break;
                    //}

                    //пауза пока не отработает событие нажатия кнопки
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

                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            cbVar.Text = selectedItem.Content.ToString();// все равно выбор не виден на комбобоксе
            Nticket = selectedItem.Content.ToString();


            //using (ModelEDM db = new ModelEDM())
            //{   
            //    var command = db.Database.SqlQuery<Questionn>("SELECT * FROM Questions WHERE Var = '" + selectedItem.Content.ToString() + "'");
            //    //foreach (var aa in command)   
            //    //{
            //    //    tb_quest.Text = aa.Question;
            //    //    tb_answer1.Text = aa.Variant1;
            //    //    tb_answer2.Text = aa.Variant2;
            //    //    tb_answer3.Text = aa.Variant3;
            //    //    answer = aa.Answer;
            //    //    //while(true)
            //    //    //{
            //    //    //    if (test.IsPressed) break;
            //    //    //}

            //    //    //пауза пока не отработает событие нажатия кнопки
            //    //    if ((answer == 1 && radBut1.IsChecked == true) || (answer == 2 && radBut2.IsChecked == true) || (answer == 3 && radBut3.IsChecked == true))
            //    //    {
            //    //        MessageBox.Show("Правильный ответ");
            //    //        ticketTrue++;
            //    //        this.OnPropertyChanged("ticketTrue");
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Неправильный ответ");
            //    //        ticketFalse++;
            //    //        this.OnPropertyChanged("ticketFalse");
            //    //    }
            //    //    ticket++;
            //    //    this.OnPropertyChanged("ticket");
            //        //this test_Click();

            //        //MessageBox.Show("");





            //    //}
            //}

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
