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
using Uppgift2.Models;

namespace Uppgift2
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

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MessageModel();
            messageList.Children.Clear();
            var messages = new List<Message>(){
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48", MessageBtn = "test1"},
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48", MessageBtn = "test2"},
                new Message {FirstName="Alex", LastName="Johansson", EmailMessage="Ett meddelande", EmailDate = "2020-20-05", EmailTime = "10:48", MessageBtn = "test3"}
            };

            foreach (var message in messages)
            {
                messageList.Children.Add(new Controls.MessageControl()
                {
                    ContactName = message.FullName,
                    Message = message.EmailMessage,
                    Date = message.EmailDate,
                    Time = message.EmailTime,
                    MessageBtn = message.MessageBtn,
                });

                //generera en knapp-funktion
                
                //knappfunktionen ska skriva ut en textsträng i "message" 
                //nedan är fel syntax?
                // message.Text ="By default, a TextBlock provides no UI beyond simply displaying its contents.";


            }


        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            messageList.Children.Clear();
            DataContext = new ContactModel();
        }
        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            messageList.Children.Clear();
            DataContext = new CalendarModel();
        }
        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            messageList.Children.Clear();
            DataContext = new TaskModel();
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            messageList.Children.Clear();
            DataContext = new SettingModel();
        }

       
    }
}
