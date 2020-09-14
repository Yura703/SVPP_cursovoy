using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        ObservableCollection<EmployeeTwin> empl = new ObservableCollection<EmployeeTwin>();
        ObservableCollection<EmployeeTwin> _empl = new ObservableCollection<EmployeeTwin>();

        public EmployeeWindow()
        {
            List <string> list = new List <string>();
            using (ModelEDM db = new ModelEDM())//как добавить в датагрид цех и специальность, в классе они int (FK)?
            {
                var command = db.Employees.ToList();
                foreach (var aa in command)
                {
                    EmployeeTwin employeeTwin = new EmployeeTwin();
                    employeeTwin.Tabel_id = aa.Tabel_id;
                    employeeTwin.FIO = aa.FIO;
                    employeeTwin.department = aa.Department.dep_name;
                    employeeTwin.title = aa.Title.title_name;
                    employeeTwin.Notes = aa.Notes;
                    employeeTwin.NamberComission = (int)aa.NamberComission;
                    employeeTwin.NamberVariant = (int)aa.Title.var_id;
                    empl.Add(employeeTwin);                   
                }
                
                var comm = db.Departments.ToList();
                foreach (var aaa in comm)
                {
                    list.Add(aaa.dep_name);
                }
            }
            _empl = empl;
            InitializeComponent();
            dGrid.DataContext = empl;
            foreach (var a in list)
            {
                cbDep.Items.Add(a);
            }     
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            empl = _empl;
        }
        
        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            //comboBox.SelectedItem.ToString;
            string dep = comboBox.SelectedItem.ToString();
            //ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            //string dep = selectedItem.Content.ToString();
            //BindingOperations.ClearAllBindings(dGrid);
            ObservableCollection<EmployeeTwin> __empl = new ObservableCollection<EmployeeTwin>();
            foreach (var item in empl)
            {
                if (item.department == dep) __empl.Add(item);
            }
            empl = __empl;


            dGrid.Items.Refresh();
        }

        private void addEmpl_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow(employee);
            var result = newEmployeeWindow.ShowDialog();
            
        }

        private void delEmpl_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Employee empl = dGrid.SelectedItem as Employee;
                context.Employees.Remove(empl);
                context.SaveChanges();
            }
            
        }

        private void editEmpl_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow();
            newEmployeeWindow.ShowDialog();
        }
    }
}
