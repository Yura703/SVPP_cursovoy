using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
                                             //добавить в БД для авторизации роли пользователя (админ, юзер, студент, тестирование)
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Regin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (_login.Text.Length > 0)
            {
                if (password.Text.Length > 0)
                {
                    using (ModelEDM db = new ModelEDM())
                    {
                        var command = db.Database.SqlQuery<Autorisation>("SELECT * FROM Autorisation WHERE login = '" + _login.Text + "' AND password = '" + password.Text + "'");
                        int i = 0;
                        foreach (var aa in command)
                        {
                            if (aa.login.Length>0)
                            {
                               // MessageBox.Show("Пользователь авторизовался");
                                i++;
                                StartWindow startWindow = new StartWindow();
                                startWindow.Show();                                
                                this.Close();                                
                            }
                        }
                        if(i==0) MessageBox.Show("Пользователь не найден"); 
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }        
    }
}
