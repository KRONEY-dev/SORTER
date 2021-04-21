using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SORTER
{
    internal static class Method_class
    {
        static readonly Inter inter = new Inter();
        public static void Browser_window(Type control_type)
        {
            using (CommonOpenFileDialog pass = new CommonOpenFileDialog())
            {
                pass.IsFolderPicker = true;
                string Title_for_InputDialog = "Enter input directory files";
                string Title_for_OutputDialog = "Enter output directory files";
                if (control_type == typeof(ListBox))
                {
                    pass.Title = Title_for_InputDialog;
                    if (pass.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        inter.Browser_window(pass.FileName);
                    }
                }
                else if (control_type == typeof(TextBlock))
                {
                    pass.Title = Title_for_OutputDialog;
                    if (pass.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        inter.Browser_window_output(pass.FileName);
                    }
                }
            }
                
        }

        public static void BUTTON_SORT_IS_ENABLE() { inter.BUTTON_SORT_IS_ENABLE(); }
    }

    internal class Inter
    {
        private readonly MainWindow MW = (MainWindow)System.Windows.Application.Current.MainWindow;
        private readonly string Exist_Message = "This directory is already exist!";

        public void Browser_window(string File_pass)
        {
            if (MW.DirectoryList.Items.Contains(File_pass) || MW.TEXT_2.Text == File_pass)
            {
                MessageBox.Show(Exist_Message);
            }
            else
            {
                MW.DirectoryList.Items.Add(File_pass);
                MW.Browser_1_Input.IsEnabled = false;
                MW.Creator.IsEnabled = true;
                MW.Clean.IsEnabled = true;
                BUTTON_SORT_IS_ENABLE();
            }
        }

        public void Browser_window_output(string File_pass)
        {
            if (MW.DirectoryList.Items.Contains(File_pass))
            {
                MessageBox.Show(Exist_Message);
            }
            else
            {
                MW.TEXT_2.Text = File_pass;
                BUTTON_SORT_IS_ENABLE();
            }
        }

        public void BUTTON_SORT_IS_ENABLE()
        {
            if (MW.Constantly_sort.IsChecked == false)
            {
                //sortClickCheck
                if (MW.DirectoryList.Items.Count != 0 && MW.TEXT_2.Text != "" && MW.TypeList.Text != "")
                {
                    MW.SORTED.IsEnabled = true;
                    MW.Constantly_sort.IsEnabled = true;
                }
                else
                {
                    MW.SORTED.IsEnabled = false;
                    MW.Constantly_sort.IsEnabled = false;
                }
                //sortClickCheck
            }
            else
            {
                MW.SORTED.IsEnabled = false;
            }
        }
    }
}
