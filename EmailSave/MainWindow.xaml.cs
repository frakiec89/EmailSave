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

namespace EmailSave
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EMailList eMail;

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            eMail = new EMailList();
           dgEmail.ItemsSource = eMail.EMails;
        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                eMail.Add(tbMail.Text);
                Start();
            }
            catch
            {
                MessageBox.Show("Неверный  емай");
                return;
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            eMail.ClearAll();
            Start();
        }
    }
}
