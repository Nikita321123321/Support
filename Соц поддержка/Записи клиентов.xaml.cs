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
    /// Логика взаимодействия для Записи_клиентов.xaml
    /// </summary>
    public partial class Записи_клиентов : Window
    {
        SupportEntities support;
        public Записи_клиентов()
        {
            support = new SupportEntities();
            InitializeComponent();
            clientTable.ItemsSource = support.Client.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Добавление добавление = new Добавление();
            добавление.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Редактирование редактирование = new Редактирование();
            редактирование.Show();
            Close();
        }
        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            support = new SupportEntities();
            Client item = clientTable.SelectedItem as Client;
            try
            {
                Client client = support.Client.Where(r => r.id == item.id).Single();
                support.Client.Remove(client);
                support.SaveChanges();
                MessageBox.Show("Запись удалена!");
                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void update()
        {
            clientTable.ItemsSource = support.Client.ToList();
            clientTable.Items.Refresh();
        }
    }
}
