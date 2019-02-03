using System;
using System.Linq;
using System.Windows;

namespace dboEF6
{
    enum TableView
    {
        Project = 0,
        Company_Customer = 1,
        Company_Performer = 2,
        Employee = 3,
        Project_Manager = 4
    }



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            comboBox.ItemsSource = Enum.GetValues(typeof(TableView)).Cast<TableView>();
            comboBox.SelectedIndex = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BusinessLogicClass bus = new BusinessLogicClass();

            switch (comboBox.SelectedIndex)
            {
                case (int)TableView.Project: dataGrid.ItemsSource = bus.GetProject(); break;
                case (int)TableView.Company_Customer: dataGrid.ItemsSource = bus.GetCompany_Customer(); break;
                case (int)TableView.Company_Performer: dataGrid.ItemsSource = bus.GetCompany_Performer(); break;
                case (int)TableView.Employee: dataGrid.ItemsSource = bus.GetEmployee(); break;
                case (int)TableView.Project_Manager: dataGrid.ItemsSource = bus.GetProject_Manager(); break;
            }
        }
    }
}
