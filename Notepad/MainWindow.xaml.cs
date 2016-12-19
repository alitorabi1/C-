using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasUnsavedChanges;

        string currentFilePath = "New File";

        public MainWindow()
        {
            InitializeComponent();
            tbDocument.Focus();
            lblCursorPosition.Text = currentFilePath;
            menuNew.IsEnabled = false;
            menuClose.IsEnabled = false;
        }

        void FileChanged(object sender, RoutedEventArgs e)
        {
            if (!hasUnsavedChanges)
            {
                tbDocument.Text = "";
                currentFilePath = "New File";
                lblCursorPosition.Text = currentFilePath;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("File has been changed, do you want to save it?", "Save changed file?", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    if (currentFilePath != "New File")
                    {
                        using (StreamWriter newTask = new StreamWriter("test.txt", false))
                        {
                            try
                            {
                                string text = tbDocument.Text;
                                File.WriteAllText(currentFilePath, text);
                                lblCursorPosition.Text = currentFilePath;
                                tbDocument.Text = "";
                                hasUnsavedChanges = false;
                                currentFilePath = "New File";
                                lblCursorPosition.Text = currentFilePath;
                            }
                            catch (IOException ex)
                            {
                                // FIXME: show a dialog box here
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        MenuFileSaveAs_Click(sender, e);
                    }

                }
                else
                {
                    return;
                }
            }
        }

        private void MenuFileNew_Click(object sender, RoutedEventArgs e)
        {
            FileChanged(sender, e);
        }

        private void MenuFileClose_Click(object sender, RoutedEventArgs e)
        {
            FileChanged(sender, e);
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File (*.txt, *.text)|*.txt;*.text|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                currentFilePath = ofd.FileName;
                try
                {
                    string text = File.ReadAllText(currentFilePath);
                    tbDocument.Text = text;
                    lblCursorPosition.Text = currentFilePath;
                }
                catch (IOException ex)
                {
                    // FIXME: show a dialog box here
                    throw ex;
                }
            }
        }
        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt, *.text)|*.txt;*.text|All Files (*.*)|*.*";
            sfd.AddExtension = true;
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == true)
            {
                currentFilePath = sfd.FileName;
                try
                {
                    string text = tbDocument.Text;
                    File.WriteAllText(currentFilePath, text);
                    lblCursorPosition.Text = currentFilePath;
                }
                catch (IOException ex)
                {
                    // FIXME: show a dialog box here
                    throw ex;
                }
            }

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            FileChanged(sender, e);
            Close();
        }

        private void tbDocument_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hasUnsavedChanges = true;
            menuNew.IsEnabled = true;
            menuClose.IsEnabled = true;
            int row = tbDocument.GetLineIndexFromCharacterIndex(tbDocument.CaretIndex);
            int col = tbDocument.CaretIndex - tbDocument.GetCharacterIndexFromLineIndex(row);
            lblCursorPosition.Text = "Line " + (row + 1) + ", Char " + (col + 1) + "  |  "
                + currentFilePath + "  |  File has been modified . . .";
        }
    }
}