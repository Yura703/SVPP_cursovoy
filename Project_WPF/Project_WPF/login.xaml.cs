using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        //public MainWindow mainWindow;
        public login()
            //(MainWindow _mainWindow)
        {
            InitializeComponent();
            //mainWindow = _mainWindow;
        }

        private void Regin_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {     
             
        if (_login.Text.Length > 0)
            {
                if (password.Password.Length > 0)
                {


                    // DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + _login.Text + "' AND [password] = '" + password.Password + "'");
                    //if (dt_user.Rows.Count > 0)
                    //{
                    //    MessageBox.Show("Пользователь авторизовался");
                    //}


                    using (ModelEDM db = new ModelEDM())
                    {
                        //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%admin%");
                        var autoriz = db.Database.SqlQuery<Autorisation>("SELECT * FROM Autorisation WHERE login = _login.Text  AND password = password.Password");

                        if (autoriz == null) MessageBox.Show("Пользователь не найден");
                        else MessageBox.Show("Пользователь авторизовался");
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");

        }
                   
        
    }
}
