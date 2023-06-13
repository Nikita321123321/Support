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
    /// Логика взаимодействия для Сотрудники.xaml
    /// </summary>
    public partial class Сотрудники : Window
    {
        SupportEntities support;
        public Сотрудники()
        {
            support = new SupportEntities();
            InitializeComponent();
            workerTable.ItemsSource = support.Worker.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == null)
            {
                return;
            }
            List<Worker> clients = support.Worker.ToList();
            clients = clients.Where(x => x.Surename.ToLower().Contains(search.Text.ToLower())).ToList();
            workerTable.ItemsSource = clients.OrderBy(x => x.id).ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var del = workerTable.SelectedItem as Worker;
            if (del == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            support.Worker.Remove(del);
            support.SaveChanges();
            update();
        }
        private void btn_edd_Click(object sender, RoutedEventArgs e)
        {
            Button edd1 = sender as Button;
            var edd2 = edd1.DataContext as Worker;
            var edd3 = new Редактирование1(support, edd2);
            edd3.ShowDialog();
            workerTable.ItemsSource = support.Worker.ToList();
        }
        private void update()
        {
            workerTable.ItemsSource = support.Worker.ToList();
            workerTable.Items.Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var add = new Worker();
            support.Worker.Add(add);
            var add1 = new Добавление1(support, add);
            add1.ShowDialog();
            update();
        }
    }
}
