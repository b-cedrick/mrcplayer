using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.IO;

namespace mrcplayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var button = this.FindControl<Button>("CloseWindowButton");
            button.Click += Button_Click;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Button_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public void Scan_mp3_Click(object sender, RoutedEventArgs e)
        {

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.ScanMp3Files(docPath);
        }

        private void  ScanMp3Files(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        var extension = Path.GetExtension(f).ToUpper();
                        if(extension == ".MP3") {
                            Console.WriteLine(f);
                        }
                    }
                    ScanMp3Files(d);
                }
            }
            catch
            { }
        //     catch (System.Exception excpt)
        //     {
        //         Console.WriteLine(excpt.Message);
        //     }
        }
        
    }
}