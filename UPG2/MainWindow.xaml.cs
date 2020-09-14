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
using UPG2.Models;

namespace UPG2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var messages = new List<Message>(){
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48"},
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48"},
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48"}
            };

            foreach(var message in messages)
            {
                messageList.Children.Add(new Controls.MessageControl() { 
                    ContactName = message.FullName,
                    Message = message.EmailMessage,
                    Date = message.EmailDate,
                    Time = message.EmailTime
                });
            }

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ContactModel();
        } 

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MessageModel();
        }
    }
}
