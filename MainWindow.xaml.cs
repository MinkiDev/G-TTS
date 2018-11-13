using System;
using System.Net;
using System.Windows;

namespace G_TTS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += delegate { DragMove(); };
            langSelectionBox.Items.Add("Korean");
            langSelectionBox.Items.Add("English");
            langSelectionBox.Items.Add("Japanese");
        }

        private void btnTerminate_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnGetVoiceMp3_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                // Set filter for file extension and default file extension
                FileName = "TV_" + DateTime.Now.ToString("yyMMdd_HHmmss"),
                DefaultExt = ".mp3",
                Filter = "TTS Voice File|*.mp3"
            };

            if (langSelectionBox.SelectedItem == null)
            {
                MessageBox.Show("언어를 먼저 설정해주세요");
                return;
            }

            if (textInputBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("TTS로 변환할 내용을 입력해주세요");
                return;
            }

            // Display OpenFileDialog by calling ShowDialog method
            var result = dlg.ShowDialog();

            switch (langSelectionBox.SelectedItem)
            {
                case "Korean":
                    // Get the selected file name and display in a TextBox
                    if (result == true)
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile("https://translate.google.com/translate_tts?ie=UTF-8&q="
                            + textInputBox.Text + "&tl=ko&client=tw-ob", dlg.FileName);
                    }
                    break;

                case "English":
                    // Get the selected file name and display in a TextBox
                    if (result == true)
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile("https://translate.google.com/translate_tts?ie=UTF-8&q="
                            + textInputBox.Text + "&tl=en&client=tw-ob", dlg.FileName);
                    }
                    break;

                case "Japanese":
                    // Get the selected file name and display in a TextBox
                    if (result == true)
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile("https://translate.google.com/translate_tts?ie=UTF-8&q="
                            + textInputBox.Text + "&tl=ja&client=tw-ob", dlg.FileName);
                    }
                    break;
            }

            MessageBox.Show("다운로드 완료");
        }
    }
}