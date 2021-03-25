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

namespace ToDoApp
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        public Settings(string title)
        {
            InitializeComponent(); //Переопределение конструктора
            Title = title;
        }
        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)slColorR.Value, (byte)slColorG.Value, (byte)slColorB.Value);
                this.Background = new SolidColorBrush(color);
            ((MainWindow)Application.Current.MainWindow).dgToDo.Background = new SolidColorBrush(color);
        }

        private void FontSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MainWindow)Application.Current.MainWindow).dgToDo.FontSize = (double)fontSize.Value;
        }
    }
}
