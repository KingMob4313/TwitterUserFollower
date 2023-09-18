using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace TwitterUserAddor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentIndex = 0;
        int maxRecordCount = 0;
        TwitterFollowingRecord currentRecord = null;
        List<TwitterFollowingRecord> thisTFR = null;


        public MainWindow()
        {
            InitializeComponent();
            //List<TwitterFollowingRecord> twitterFollowingRecordList = new List<TwitterFollowingRecord>();
            //TwitterFollowingRecord twitterFollowingRecord = new TwitterFollowingRecord();

            thisTFR = readJsonFile("following.js");
            currentRecord = thisTFR[currentIndex];
            this.IndexTextBox.Text = currentIndex.ToString();
        }

        private List<TwitterFollowingRecord> readJsonFile(string fileName)
        {
            string text = File.ReadAllText(fileName);

            List<TestClass> recordsX = JsonConvert.DeserializeObject<List<TestClass>>(text);
            List<TwitterFollowingRecord> twitterFollowingRecordList = new List<TwitterFollowingRecord>();
            for (int i = 0; i < recordsX.Count; i++)
            {
                twitterFollowingRecordList.Add(new TwitterFollowingRecord(i, recordsX[i].accountId, recordsX[i].userLink));
            }
            maxRecordCount = twitterFollowingRecordList.Count - 1;
            return twitterFollowingRecordList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(thisTFR[currentIndex].UserLink);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                currentRecord = thisTFR[currentIndex];
                this.IndexTextBox.Text = currentIndex.ToString();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < maxRecordCount)
            {
                currentIndex++;
                currentRecord = thisTFR[currentIndex];
                this.IndexTextBox.Text = currentIndex.ToString();
            }
        }
    }
}
