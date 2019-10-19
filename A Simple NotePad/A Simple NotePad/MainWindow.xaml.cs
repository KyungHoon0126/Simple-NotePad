using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace A_Simple_NotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string file = ""; // File Path

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "WPF Simple NotePad";
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog(); // File Open
            {
                ofdlg.Filter = "txt File | *.txt"; // File Filter Set

                ofdlg.CheckFileExists = true;
                ofdlg.CheckPathExists = true;

                if (ofdlg.ShowDialog().GetValueOrDefault()) // File Open, CheckValueExists
                {
                    file = ofdlg.FileName;
                    this.Title = file;

                    using (StreamReader sw = new StreamReader(file))
                    {
                        tbWrite.Text = sw.ReadToEnd();
                    }
                }
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            tbWrite.Text = string.Empty;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (file == "")
            {
                SaveFileDialog sfdlg = new SaveFileDialog();
                sfdlg.Filter = "Text File | *.txt";  // File Filter Set

                if (sfdlg.ShowDialog().GetValueOrDefault())
                {
                    file = sfdlg.FileName;
                    this.Title = file;
                }
                else return;
            }

            // StreamWriter(FileName, CheckContentAdd(false : All Clear, Encoding))
            using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
            {
                sw.Write(tbWrite.Text);
            }
        }
    }
}