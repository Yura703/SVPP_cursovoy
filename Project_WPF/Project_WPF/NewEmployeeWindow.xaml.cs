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

namespace Project_WPF
{
    /// <summary>
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        Employee employee;
        public NewEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            grid.DataContext = employee;

        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }
    }
}
