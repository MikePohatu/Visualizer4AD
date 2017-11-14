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
using common;
using Visualizer4AD.Auth;
using ADConnector;
using Visualizer4AD.Panes;

namespace Visualizer4AD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAuthenticator _authenticator;
        private BasePane _groupspane;

        public MainWindow()
        {
            InitializeComponent(); this.Login();
        }

        private void Login()
        {
            this._authenticator = new DCConnector();
            LoginWindow loginwindow = new LoginWindow();
            LoginViewModel loginviewmodel = new LoginViewModel();

            loginwindow.DataContext = loginviewmodel;

            loginwindow.cancelbtn.Click += (sender, e) => {
                loginwindow.Close();
                this.Close();
            };

            loginwindow.okbtn.Click += (sender, e) => {
                if (loginviewmodel.TryConnect(this._authenticator, loginwindow.pwdbx.Password) == true) { this.Startup(loginwindow, loginviewmodel); }
            };

            loginwindow.pwdbx.KeyUp += (sender, e) => {
                if (e.Key == Key.Enter)
                { if (loginviewmodel.TryConnect(this._authenticator, loginwindow.pwdbx.Password) == true) { this.Startup(loginwindow, loginviewmodel); } }
            };

            loginwindow.usertb.KeyUp += (sender, e) => {
                if (e.Key == Key.Enter)
                { if (loginviewmodel.TryConnect(this._authenticator, loginwindow.pwdbx.Password) == true) { this.Startup(loginwindow, loginviewmodel); } }
            };

            loginwindow.domaintb.KeyUp += (sender, e) => {
                if (e.Key == Key.Enter)
                { if (loginviewmodel.TryConnect(this._authenticator, loginwindow.pwdbx.Password) == true) { this.Startup(loginwindow, loginviewmodel); } }
            };

            loginwindow.ShowDialog();
        }

        private void Startup(LoginWindow loginwindow, LoginViewModel loginviewmodel)
        {
            loginwindow.Close();
            this._groupspane = new GroupsPane();
            //this.devtab.DataContext = this._devicepane;
        }
    }
}
