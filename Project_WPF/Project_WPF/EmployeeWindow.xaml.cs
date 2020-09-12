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

        public EmployeeWindow()
        {
            using (ModelEDM db = new ModelEDM())//как добавить в датагрид цех и специальность, в классе они int (FK)?
            {
                //EmployeeTwin employeeTwin = new EmployeeTwin();
                // var command = db.Database.SqlQuery<Employee>("SELECT * FROM Employee");
                var command = db.Employees.ToList();
                
                foreach (var aa in command)
                {
                    //employeeTwin.Tabel_id = aa.Tabel_id;
                    //employeeTwin.FIO = aa.FIO;
                    //employeeTwin._department = aa.Department.dep_name;
                    //employeeTwin._title = aa.Title.title_name;
                    //empl.Add(employeeTwin);

                    //MessageBox.Show(aa.Title.title_name);
                }
                //db.Employees.Load();
                //dGrid.DataContext = db.Employees.Local;

            }
            InitializeComponent();
            dGrid.DataContext = empl;
            //InitExployeeList();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            using (ModelEDM db = new ModelEDM())
            {
                //var command = db.Database.SqlQuery<Employee>("SELECT * FROM Employee");
                //foreach (var ss in command)
                //{
                //    MessageBox.Show(ss.FIO);
                //}
                db.Employees.Load();
                dGrid.DataContext = db.Employees.Local;

            }


        }

        //private void InitExployeeList()
        //{
        //    db.Employees.Load();
        //    dGrid.DataContext = context.Employees.Local;
        //}

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
