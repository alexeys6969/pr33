using ChatStudentsShashin.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.IO;

namespace ChatStudentsShashin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public string srcUserImage = "";
        UserContext userContext = new UserContext();
        public Login()
        {
            InitializeComponent();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фотографию:";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if(ofd.ShowDialog() == true)
            {
                imgUser.Source = new BitmapImage(new Uri(ofd.FileName));
                srcUserImage = ofd.FileName;
            }
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            if(!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Lastname.Text))
            {
                MessageBox.Show("Укажите фамилию.");
                return;
            }
            if (!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Firstname.Text))
            {
                MessageBox.Show("Укажите имя.");
                return;
            }
            if (!CheckEmpty("^[А-ЯёЁ][а-яА-ЯёЁ]*$", Surname.Text))
            {
                MessageBox.Show("Укажите отчество.");
                return;
            }
            if (String.IsNullOrEmpty(srcUserImage))
            {
                MessageBox.Show("Выберите изображение.");
                return;
            }
            if(userContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                            x.Lastname == Lastname.Text &&
                                            x.Surname == Surname.Text).Count() > 0)
            {
                MainWindow.Instanse.LoginUser.Photo = File.ReadAllBytes(srcUserImage);
                userContext.SaveChanges();
            }
            else
            {
                userContext.Users.Add(new Models.User(Lastname.Text, Firstname.Text, Surname.Text, File.ReadAllBytes(srcUserImage)));
                userContext.SaveChanges();
                MainWindow.Instanse.LoginUser = userContext.Users.Where(x => x.Firstname == Firstname.Text &&
                                            x.Lastname == Lastname.Text &&
                                            x.Surname == Surname.Text).First();
            }
            MainWindow.Instanse.OpenPages(new Pages.Main());
        }
        public bool CheckEmpty(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }
    }
}
