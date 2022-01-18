using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Simple_Restaurant_Simulation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public enum MenuItem
    {
        Chicken,
        Egg,
        Coffee,
        Tea,
        Water,
        ChocolateMilk,
        JockoFuel,
        NoDrink
    }

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Server server = new Server();

        private void ReceiveRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = "";
                int.TryParse(ChickenQuantity.Text, out int chickenQuantity);
                int.TryParse(EggQuantity.Text, out int eggQuantity);
                server.TakeOrder(chickenQuantity, eggQuantity, ((ComboBoxItem)DrinkOption.SelectedValue).Name);
                ChickenQuantity.Text = "";
                EggQuantity.Text = "";
                DrinkOption.SelectedItem = NoDrink;
            }
            catch (IndexOutOfRangeException error)
            {
                Results.Text = error.Message;
            }
            catch (Exception)
            {
                Results.Text = "Sorry, something went wrong.";
            }
        }

        private void SendRequests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = "";
                EggQuality.Text = server.SendOrder();
            }
            catch (InvalidOperationException error)
            {
                Results.Text = error.Message;
            }
            catch (Exception)
            {
                Results.Text = "Sorry, something went wrong.";
            }
        }

        private void ServeFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = server.ServeFood();
                EggQuality.Text = "";
            }
            catch (InvalidOperationException error)
            {
                Results.Text = error.Message;
            }
            catch (Exception)
            {
                Results.Text = "Sorry, something went wrong.";
            }
        }
    }
}
