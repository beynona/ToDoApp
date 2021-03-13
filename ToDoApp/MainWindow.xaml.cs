using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Пусть с exe
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";

        private BindingList<ToDoModels> ToDoList;
        private FileIOService fileIOService;
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);

            try
            {
                ToDoList = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            
            dgToDo.ItemsSource = ToDoList;
            ToDoList.ListChanged += ToDoList_ListChanged;
        }

        private void ToDoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == null)
            {
                try
                {
                    fileIOService.SaveData(sender);
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
