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

namespace Соц_поддержка
{
    /// <summary>
    /// Логика взаимодействия для Добавление.xaml
    /// </summary>
    public partial class Добавление : Window
    {
        SupportEntities support;
        public Добавление(SupportEntities support1, Client client)
        {
            InitializeComponent();
            this.support = support1;
            this.DataContext = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Записи_клиентов записи = new Записи_клиентов();
            записи.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            support.SaveChanges();
            Close();
        }
    }
}
