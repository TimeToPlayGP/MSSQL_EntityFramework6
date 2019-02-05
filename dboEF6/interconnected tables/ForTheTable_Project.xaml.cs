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

namespace dboEF6.interconnected_tables
{
    /// <summary>
    /// Логика взаимодействия для ForTheTable_Project.xaml
    /// </summary>
    public partial class ForTheTable_Project : Window
    {
        public ForTheTable_Project
            (IEnumerable<projectManagerViewTable> list1, 
            IEnumerable<companyCustomerViewTable> list2,
            IEnumerable<companyPerformerViewTable> list3,
            IEnumerable<employeeViewTable> list4)
        {
            InitializeComponent();

            dataGrid.ItemsSource = list1;
            dataGrid1.ItemsSource = list2;
            dataGrid2.ItemsSource = list3;
            dataGrid3.ItemsSource = list4;
        }
    }
}
