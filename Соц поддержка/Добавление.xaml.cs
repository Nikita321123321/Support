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
        SupportEntities db;
        public Добавление()
        {
            InitializeComponent();
            db = new SupportEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Записи_клиентов записи = new Записи_клиентов();
            записи.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Surename = surenameadd.Text;
            client.Name = nameadd.Text;
            client.Lastname = lastnameadd.Text;
            client.Birthday = birthdayadd.Text;
            client.Phone = phoneadd.Text;
            client.Adress = adressadd.Text;
            client.Recording_date = dateadd.Text;
            client.Recording_time = timeadd.Text;
            int a = Convert.ToInt32(departamentadd.Text);
            client.id_Departament = a;
            MessageBox.Show("Запись добавлена");
            try
            {
                db.Client.Add(client);
                db.SaveChanges();
                Записи_клиентов записи = new Записи_клиентов();
                записи.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
