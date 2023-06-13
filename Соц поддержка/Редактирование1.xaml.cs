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
    /// Логика взаимодействия для Редактирование1.xaml
    /// </summary>
    public partial class Редактирование1 : Window
    {
        SupportEntities support;
        public Редактирование1(SupportEntities support1, Worker worker)
        {
            InitializeComponent();
            this.support = support1;
            this.DataContext = worker;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Сотрудники сотрудники = new Сотрудники();
            сотрудники.Show();
            Close();
        }

        private void btnEdd_Click(object sender, RoutedEventArgs e)
        {
            support.SaveChanges();
            Close();
        }
    }
}
