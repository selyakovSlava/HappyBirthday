using HappyBDay.Dialogs;
using System.Windows;

namespace HappyBDay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.DataContext = new ViewModel.Persons();

            /* Добавили работу с диалоговомыи окнами */
            this.DataContext = new ViewModel.Persons(new DefaultDialogService(), new JsonFileService());
        }
    }
}
