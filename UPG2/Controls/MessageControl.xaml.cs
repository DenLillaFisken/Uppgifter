using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UPG2.Controls
{
    /// <summary>
    /// Interaction logic for MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }
        public string ContactName
        {
            get { return contactName.Text; }
            set { contactName.Text = value; }
        }
        public string Message
        {
            get { return message.Text; }
            set { message.Text = value; }
        }
        public string Date
        {
            get { return date.Text; }
            set { date.Text = value; }
        }
        public string Time
        {
            get { return time.Text; }
            set { time.Text = value; }
        }
    }
}
