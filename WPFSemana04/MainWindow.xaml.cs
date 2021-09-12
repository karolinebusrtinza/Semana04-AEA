using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFSemana04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    public class Person
    {
        public string PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HireDate { get; set; }
        public string EnrollmentDate { get; set; }



    }
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-Q7Q9A06\\SQLEXPRESS2017; Initial Catalog=db_lab04;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            List<Person> people = new List<Person>();

            SqlCommand command = new SqlCommand("BuscarPersonaNombre", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter1.Size = 50;
            //parameter1.Value = txtNombre.Text.Trim();
            parameter1.Value = "";
            parameter1.ParameterName = "@FirstName";

            command.Parameters.Add(parameter1);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonId = dataReader[0].ToString(),
                    LastName = dataReader[1].ToString(),
                    FirstName = dataReader[2].ToString(),
                    HireDate = dataReader[3].ToString(),
                    EnrollmentDate = dataReader[4].ToString(),
                });

            }

            conn.Close();
            dgvUsers.ItemsSource = people;
        }
    }
}
    
