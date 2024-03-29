﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WinForms = System.Windows.Forms;

namespace SORTER
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SORTED_Click(object sender, RoutedEventArgs e)
        {
            new SOURCE(DirectoryList.Items, TEXT_2.Text, TypeList.Text, false);
        }

        private void Constantly_sort_Checked(object sender, RoutedEventArgs e)
        {
            SORTED.IsEnabled = false;
            Deletor.IsEnabled = false;
            Creator.IsEnabled = false;
            Clean.IsEnabled = false;
            Replace.IsEnabled = false;
            TypeList.IsEnabled = false;
            Browser_1_Output.IsEnabled = false;
            new SOURCE(DirectoryList.Items, TEXT_2.Text, TypeList.Text, true);
        }

        private void Constantly_sort_Unchecked(object sender, RoutedEventArgs e)
        {
            SORTED.IsEnabled = true;
            Clean.IsEnabled = true;
            TypeList.IsEnabled = true;
            Browser_1_Output.IsEnabled = true;
            Creator.IsEnabled = true;
            if (DirectoryList.SelectedItem != null)
            {
                Deletor.IsEnabled = true;
            }
        }

        private void Browser_1_Input_Click(object sender, RoutedEventArgs e)
        {
            Method_class.Browser_window(DirectoryList.GetType());
        }

        private void Browser_1_Output_Click(object sender, RoutedEventArgs e)
        {
            Method_class.Browser_window(TEXT_2.GetType());
        }

        private void TypeList_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (e.Changes.Count <= 2)
            {
                Method_class.BUTTON_SORT_IS_ENABLE();
            }
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            string temp;
            temp = TEXT_2.Text;
            TEXT_2.Text = DirectoryList.SelectedItem.ToString();
            DirectoryList.Items.Remove(DirectoryList.SelectedItem);
            DirectoryList.Items.Add(temp);
        }

        private void Creator_Click(object sender, RoutedEventArgs e)
        {
            Method_class.Browser_window(DirectoryList.GetType());
        }

        readonly NotifyIcon notifiIcon = new NotifyIcon();

        async private void SHADOW_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu notifyIconContextMenu = new ContextMenu();
            notifiIcon.ContextMenu = notifyIconContextMenu;
            Visibility = Visibility.Hidden;
            notifiIcon.Icon = Properties.Resources.output__1_;
            notifiIcon.Visible = true;
            notifiIcon.ShowBalloonTip(1000, "The application runs in the background", "Click 'Open' to deploy application", ToolTipIcon.Info);
            notifyIconContextMenu.MenuItems.Add("Open", new EventHandler(Open));
            notifyIconContextMenu.MenuItems.Add("Stop sorting", new EventHandler(StopSort));
            notifyIconContextMenu.MenuItems.Add("Close", new EventHandler(Close));
            while (notifiIcon.Visible == true)
            {
                if (Constantly_sort.IsChecked == false)
                {
                    notifyIconContextMenu.MenuItems[1].Enabled = false;
                    notifyIconContextMenu.MenuItems[1].Checked = true;
                }
                else if (Constantly_sort.IsChecked == true)
                {
                    notifyIconContextMenu.MenuItems[1].Enabled = true;
                }
                await Task.Delay(500);
            }
        }
        private void Open(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
            notifiIcon.Visible = false;
        }
        private void StopSort(object sender, EventArgs e)
        {
            Constantly_sort.IsChecked = false;
        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }

        private void Deletor_Click(object sender, RoutedEventArgs e)
        {
            DirectoryList.Items.Remove(DirectoryList.SelectedItem);
            Replace.IsEnabled = false;
            if (DirectoryList.Items.Count == 0)
            {
                Creator.IsEnabled = false;
                Browser_1_Input.IsEnabled = true;
                Clean.IsEnabled = false;
            }
        }

        private void ProfilEditor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DirectoryList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //deletorCheck
            if (DirectoryList.SelectedItem == null)
            {
                Deletor.IsEnabled = false;
            }
            else
            {
                if (Constantly_sort.IsChecked == false)
                {
                    Deletor.IsEnabled = true;
                }
            }
            //deletorCheck

            //BUTTON_REPLACE_IS_ENABLE
            if (DirectoryList.SelectedItem != null && TEXT_2.Text != "")
            {
                if (Constantly_sort.IsChecked == false)
                {
                    Replace.IsEnabled = true;
                }
            }
            else
            {
                Replace.IsEnabled = false;
            }
            //BUTTON_REPLACE_IS_ENABLE
        }

        private void Button_Suport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            Clean.IsEnabled = false;
            DirectoryList.Items.Clear();
            Browser_1_Input.IsEnabled = true;
            Creator.IsEnabled = false;
            Method_class.BUTTON_SORT_IS_ENABLE();
        }

        private void Min_Button1_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
