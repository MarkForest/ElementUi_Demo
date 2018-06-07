using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String connectionString = @"Data Source = COMP200\SQLEXPRESS; Initial Catalog=comboboxDemoDb; Integrated Security = true;";
        SqlConnection conn = null;
        SqlCommand sqlCommand = null;
        SqlDataReader sqlReader = null;
        List<string> users = new List<string>();

        
        public MainWindow()
        {
            InitializeComponent();
            conn = new System.Data.SqlClient.SqlConnection(connectionString);
            conn.Open();
            sqlCommand = new SqlCommand("Select * from [user]", conn);
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                users.Add($"{sqlReader.GetInt32(0)} {sqlReader["firstname"].ToString() } {sqlReader["lastname"].ToString() }");
            }
            conn.Close();
            cb.ItemsSource = users;


            BitmapImage btm = new BitmapImage();
            btm.BeginInit();
            btm.UriSource = new Uri(@"../images/10.jpeg", UriKind.Relative);
            btm.EndInit();
            image9.Source = btm;
            //db

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Че то пошло не так!");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (sender as Slider).SelectionEnd = e.NewValue;
        }
    }
}
