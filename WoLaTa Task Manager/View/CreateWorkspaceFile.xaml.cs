using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for CreateWorkspaceFile.xaml
    /// </summary>
    public partial class CreateWorkspaceFile : Window
    {
        public string Label { get; private set; }
        public string Path { get; private set; }

        public CreateWorkspaceFile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label = LabelTextBox.Text;
            Path = PathTextBox.Text;
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = PathTextBox.Text;
            dialog.Title = Label;
            dialog.Filter += ".json | *.json";
            if (dialog.ShowDialog() == true)
            {
                PathTextBox.Text = dialog.FileName;
            }
        }

        private void LabelTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Button_Ok == null) return;

            if (LabelTextBox.Text.Length > 0)
                Button_Ok.IsEnabled = true;
            else
                Button_Ok.IsEnabled = false;
        }
    }
}
