﻿using System;
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

namespace MailClient.View.InboxWindow
{
    /// <summary>
    /// Interaction logic for OpenMessage.xaml
    /// </summary>
    public partial class OpenMessage : Page
    {
        public int id = 1;
        public OpenMessage(MailWindow w)
        {
            
            w.frameStatus = 1;
            InitializeComponent();
            if (w.MainFrame.CanGoBack)
            {
                w.Back.IsEnabled = true;
            }
        }
    }
}
