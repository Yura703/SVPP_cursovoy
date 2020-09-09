using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class TestWindow : Window
    {
        ObservableCollection<Question> Questions;
        
        int ticketTrue = 0;
        int ticketFalse = 0;
        int ticket = 1;
        

        public TestWindow()
        {
            InitializeComponent();
            Questions = new ObservableCollection<Question>();            
            tbNTicket.DataContext = ticket;
            tbTr.DataContext = ticketTrue;
            tbFls.DataContext = ticketFalse;
            grid.DataContext = Questions;          
                      
            cbVar.Items.Add("1");
            cbVar.Items.Add("2");
            cbVar.Items.Add("3");

        }
        
        private void testirorovanie()
        {
            using (ModelEDM db = new ModelEDM())
            {
                var command = db.Database.SqlQuery<Question>("SELECT * FROM Question");
                foreach (var aa in command)
                {
                    Questions.Add(aa);
                    
                }                
            }
        }

        

        private void test_Click(object sender, RoutedEventArgs e)
        {

            using (ModelEDM db = new ModelEDM())
            {

                var command = db.Database.SqlQuery<Question>("SELECT * FROM Questions WHERE Questions_id = 1");
                foreach (var aa in command)
                {
                    //lb_answer1.Text = aa.Variant1;
                    MessageBox.Show("1111");

                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
                      
            using (ModelEDM db = new ModelEDM())
            {
                var command = db.Database.SqlQuery<Question>("SELECT * FROM Questions WHERE Var = '" + cbVar.Text + "'");
                foreach (var aa in command)
                {
                    //lb_answer1.Text = aa.Variant1;
                    //MessageBox.Show(aa.Variant1);

                }
            }

        }

    }
}
