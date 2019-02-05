using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using dboEF6.interconnected_tables;

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

    enum DilterData
    {
        dateMore = 0,
        dateLess = 1,
        dateEqually = 2,
        priorityMore = 3,
        priorityLess = 4,
        priorityEqually = 5
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

            comboBox1.ItemsSource= Enum.GetValues(typeof(DilterData)).Cast<DilterData>();
        }

        /// <summary>
        /// Событие нажатия на кнопку показа таблиц
        /// Таблица выбирается по позиции comboBox, где индекс 
        /// сравнивается со значением перечисления TableView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Открытие новой формы по двойному щелчку 
        /// для показа доп.информации о таблице ПРОЕКТ,
        /// щелчок производится по строке в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDoubleClick(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != (int)TableView.Project) return;

            BusinessLogicClass bus = new BusinessLogicClass();

            var row = (DataGridRow)sender;
            int a = row.GetIndex();

            ForTheTable_Project table =
                new ForTheTable_Project(bus.GetProject_Manager(a), bus.GetCompany_Customer(a),
                bus.GetCompany_Performer(a), bus.GetEmployee(a));
            table.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            BusinessLogicClass bus = new BusinessLogicClass();

            dataGrid.ItemsSource = bus.GetProjectFiltr(comboBox1.SelectedIndex, int.Parse(textBox.Text), (DateTime)calendar.SelectedDate);
        }
    }
}
