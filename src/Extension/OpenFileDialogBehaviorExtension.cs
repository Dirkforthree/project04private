using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace Effektive_Präsentation.Extension
{
    /// <summary>
    /// Open File Dialog Behavior
    /// </summary>
    public class OpenFileDialogBehaviorExtension
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled", typeof(bool), typeof(OpenFileDialogBehaviorExtension), new FrameworkPropertyMetadata(default(bool), OnPropChanged)
            {
                BindsTwoWayByDefault = false,
            });

        private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement fe))
                throw new InvalidOperationException();

            if ((bool)e.NewValue)
            {
                fe.PreviewMouseDown += OnPreviewMouseDown;
            }
            else
            {
                fe.PreviewMouseDown -= OnPreviewMouseDown;
            }
        }

        private static void OnPreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
                var dataContext = ((FrameworkElement)sender).DataContext;

                if (!(dataContext is IOpenFileDialog filesSelected))
                {
                    if (dataContext != null)
                        Trace.TraceError($"Binding error, '{dataContext.GetType().Name}' doesn't implement '{nameof(IOpenFileDialog)}'.");
                    return;
                }


                filesSelected.OnFileSelected(openFileDialog.FileNames);
            }
        }

        public static void SetIsEnabled(DependencyObject element, bool value)
        {
            element.SetValue(IsEnabledProperty, value);
        }

        public static bool GetIsEnabled(DependencyObject element)
        {
            return (bool)element.GetValue(IsEnabledProperty);
        }
    }
}
