using ShoesDE.DataBase;
using ShoesDE.Helpers;
using ShoesDE.Statics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ShoesDE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DBSamShoess31Entities _db =new DBSamShoess31Entities();
        private MessageHelper _mh = new MessageHelper();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string logins = LoginEnter.Text;
            string passwords = PasswordEnter.Password;

            var user = _db.User.Where(u=> u.login == logins && u.password== passwords).FirstOrDefault();
            
            if (user == null)
            {
                _mh.ShowError("ты далбаеб");
                return;
            }
            else 
            {
                CurrentSession.CurrentUser = user;
                new ProductWindow(user).Show();
                Close();


            }
        }
        private void Gosti_Click(object sender, RoutedEventArgs e) 
        {

            new ProductWindow().Show();
            Close();
         
        }
    }
}
