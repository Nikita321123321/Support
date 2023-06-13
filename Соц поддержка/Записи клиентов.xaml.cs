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
            var add = new Client();
            support.Client.Add(add);
            var add1 = new Добавление(support, add);
            add1.ShowDialog();
            update();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var del = clientTable.SelectedItem as Client;
            if (del == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            support.Client.Remove(del);
            support.SaveChanges();
            update();
        }
        private void btn_edd_Click(object sender, RoutedEventArgs e)
        {
            Button edd1 = sender as Button;
            var edd2 = edd1.DataContext as Client;
            var edd3 = new Редактирование(support, edd2);
            edd3.ShowDialog();
            clientTable.ItemsSource = support.Client.ToList();
        }
        private void update()
        {
            clientTable.ItemsSource = support.Client.ToList();
            clientTable.Items.Refresh();
        }
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == null)
            {
                return;
            }
            List<Client> clients = support.Client.ToList();
            clients = clients.Where(x => x.Surename.ToLower().Contains(search.Text.ToLower())).ToList();
            clientTable.ItemsSource = clients.OrderBy(x => x.id).ToList();
        }
    }
}
