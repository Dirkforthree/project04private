using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace Effektive_Präsentation.Extension
{
    public interface IFileHandler
    {
        void HandleSelectedFile(string filePath);
    }
    public class FilePickerBehaviorExtension
    {
        public static readonly DependencyProperty IsEnabled =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(FilePickerBehaviorExtension), new PropertyMetadata(false, OnIsEnabledChanged));



        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabled, value);
        }

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as Button;
            if (button != null)
            {
                if ((bool)e.NewValue)
                {
                    button.Click += OnButtonClick;
                }
                else
                {
                    button.Click -= OnButtonClick;
                }
            }
        }

        private static void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "All Files (*.*)|*.*",
                Title = "Select a File"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                var button = sender as Button;
                var fileHandler = button?.GetValue(FileHandlerProperty) as IFileHandler;

                if (fileHandler != null)
                {
                    fileHandler.HandleSelectedFile(openFileDialog.FileName);
                }
            }
        }

        public static readonly DependencyProperty FileHandlerProperty =
            DependencyProperty.RegisterAttached("FileHandler", typeof(IFileHandler), typeof(FilePickerBehaviorExtension), new PropertyMetadata(null));

        public static void SetFileHandler(DependencyObject obj, IFileHandler value)
        {
            obj.SetValue(FileHandlerProperty, value);
        }

        public static IFileHandler GetFileHandler(DependencyObject obj)
        {
            return (IFileHandler)obj.GetValue(FileHandlerProperty);
        }
    }
}
