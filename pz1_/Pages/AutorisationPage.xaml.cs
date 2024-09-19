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
using pz1_.Utils;

namespace pz1_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        public AutorisationPage()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string email, password;
            email = tbEmail.Text;
            password = Hash.ComputeSha256Hash(tbPassword.Text);
            


            var context = new Pz1FioContext();
            var user = context.Users.FirstOrDefault(x => x.Email.Trim() == email.Trim() &&
                                                    x.Password.Trim() == password.Trim());
            if (user != null)
            {
                MessageBox.Show("Успешный вход!");
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                MessageBox.Show("Ошибка почты или пароля");
                MessageBox.Show(Hash.ComputeSha256Hash(password));
            }
        }

    }
}
