using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Console;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Simple_Restaurant_Simulation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public enum MenuItem
    {
        Chicken = 0,
        Egg = 1,
        Coffee = 2,
        Tea = 3,
        Water = 4,
        ChocolateMilk = 5,
        JockoFuel = 6,
        NoDrink = 7
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
                server.TakeOrder(ChickenQuantity.Text, EggQuantity.Text, ((ComboBoxItem)DrinkOption.SelectedValue).Name);
                ChickenQuantity.Text = "";
                EggQuantity.Text = "";
                DrinkOption.SelectedItem = NoDrink;
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
