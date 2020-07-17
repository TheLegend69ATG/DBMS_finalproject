using FinalProjectWP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace FinalProjectWP
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private List<LoginInfo> loginInfo = new LaboratoryContext().LoginInfo.ToList();
        public Login()
        {
            InitializeComponent();

        }
        private void usertxtbox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (usertxtbox.Text != "Username")
                return;
            usertxtbox.Foreground = Brushes.Black;
            usertxtbox.Text = "";

        }
        private void passwordbox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            placeholder.Visibility = Visibility.Hidden;
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginInfo username = loginInfo.First(x => x.Username == usertxtbox.Text && x.Password == passwordbox.Password) as LoginInfo;
                MemberGUI memberGUI = new MemberGUI(username.MemId);
                memberGUI.Show();
                this.Close();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("incorrect");
                return;
            }
        }
        private void passwordbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginbtn_Click(sender, e);
            }
            else return;
        }

        private void passwordbox_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholder.Visibility = Visibility.Hidden;
        }

        private void placeholder_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordbox.Focus();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.CloseWindow(this);

        }
    }
}
