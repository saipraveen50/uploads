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

namespace ChangeConnectionStringAtRuntime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", serverBox.Text,databaseName.Text);
            try
            {
                TestConnection testConnection = new TestConnection(connectionString);
                if (testConnection.IsConnection)
                {
                    MessageBox.Show("Connection Successful", "Message", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ServerBox_Loaded(object sender, RoutedEventArgs e)
        {
            serverBox.Items.Add(@".\SQLEXPRESS");
            serverBox.Items.Add(string.Format(@"{0}\SQLEXPRESS",Environment.MachineName));
            serverBox.SelectedIndex = 1;
        }
    }
}
