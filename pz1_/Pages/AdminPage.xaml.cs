using pz1_.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pz1_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new Pz1FioContext())
            {
                // Получаем список пользователей из базы данных
                List<User> users = context.Users.ToList();

                // Привязываем список к DataGrid
                admDg.ItemsSource = users;
            }
        }
    }
}
