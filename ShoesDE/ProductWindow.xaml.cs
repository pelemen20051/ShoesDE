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

using ShoesDE.DataBase;
using ShoesDE.Statics;

namespace ShoesDE
{
    public partial class ProductWindow : Window
    {

        public ProductWindow()
        {
            InitializeComponent();
        }

        public ProductWindow(User user)
        {
            InitializeComponent();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentSession.CurrentUser=null;
            new MainWindow().Show();
            Close();
        }
    }
}
