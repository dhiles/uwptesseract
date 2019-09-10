using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tesseract;
using Page = Windows.UI.Xaml.Controls.Page;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPtesseract
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("load_system_dawg", 0);
            dict.Add("load_freq_dawg", 0);
            dict.Add("load_unambig_dawg", 0);
            dict.Add("load_punc_dawg", 0);
            dict.Add("load_number_dawg", 0);
            dict.Add("load_fixed_length_dawgs", 0);
            dict.Add("load_bigram_dawg", 0);
            dict.Add("wordrec_enable_assoc", 0);
            dict.Add("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ<");


            var engine = new TesseractEngine(@"C:/Program Files/Tesseract/tessdata", "ocrb", EngineMode.Default, null, dict, false);
            var img = Pix.LoadFromFile(@"C:/Program Files/Tesseract/p1.jpg");
            var page = engine.Process(img);
            var text = page.GetText();
            TextBlock newNote = new TextBlock();
            newNote.Text = text;
            notes.Children.Add(newNote);

        }
    }
}
