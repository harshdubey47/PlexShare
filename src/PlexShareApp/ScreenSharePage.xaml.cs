using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
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
using PlexShareScreenshare.Client;
using PlexShareScreenshare.Server;

namespace PlexShareApp


{
    /// <summary>
    /// Interaction logic for ScreenSharePage.xaml
    /// </summary>
    public partial class ScreenSharePage : Page
    {
        public ObservableCollection<SharedClient> ImageList = new();
        public string Color = "Green";
        ScreenShareViewModel viewModel;
        public static int id = 1;
        public static int name = 100;
        public ScreenSharePage()
        {
            InitializeComponent();
            string directory = @"C:\Users\HARSH\OneDrive\Documents\SE\PlexShare\src\PlexShareApp\Icons\";

            Debug.WriteLine("Inside ScreenSharePage");

            foreach (string myFile in Directory.GetFiles(directory, "*.jpg", SearchOption.AllDirectories))
            {
                Debug.WriteLine(myFile);
                Image image = new();
                BitmapImage Source = new(new Uri(myFile, UriKind.RelativeOrAbsolute));
                //Debug.WriteLine(Source.GetHashCode());
                //Source.EndInit();
                //image.Source = Source;
                if (ImageList.Count == 6)
                    break;
                Debug.WriteLine(image);
                ImageList.Add(new SharedClient(id, name.ToString(), Source));
                id++;
                name--;
            }

            if (ImageList.Count == 0)
            {
                EmptyScreen.Visibility = Visibility.Visible;
                EmptyText.Visibility = Visibility.Visible;
                NextPage.Visibility = Visibility.Collapsed;
                PreviousPage.Visibility = Visibility.Collapsed;
            }

            viewModel = new(ImageList, Color);
            this.DataContext = viewModel;

            Debug.WriteLine(ImageList.Count);
        }

        private void OnPinButtonClicked(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(PinButton.Path))
            //{
            //    Debug.WriteLine(this.SendButton.Path);
            //    string text = this.SendTextBox.Text;
            //    this.SendTextBox.Text = string.Empty;

            //    MessengerViewModel viewModel = this.DataContext as MessengerViewModel;
            //    viewModel.OutboundMessage = text;
            //}
        }

        private void OnNextPageButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Next Button Clicked\n");
        }

        private void OnPreviousPageButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(viewModel.ImageList.Count);
            viewModel.AddImage(ImageList[0]);
        }
    }
}
