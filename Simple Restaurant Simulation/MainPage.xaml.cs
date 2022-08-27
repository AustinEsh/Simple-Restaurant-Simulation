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

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Server server = new Server();
        readonly Cook cook = new Cook();

        private void ReceiveRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = "";
                int.TryParse(ChickenQuantity.Text, out int chickenQuantity);
                int.TryParse(EggQuantity.Text, out int eggQuantity);
                server.TakeOrder(name.Text, chickenQuantity, eggQuantity, ((ComboBoxItem)DrinkOption.SelectedValue).Name);
                ChickenQuantity.Text = "";
                EggQuantity.Text = "";
                DrinkOption.SelectedItem = NoDrink;
            }
            catch (IndexOutOfRangeException error)
            {
                Results.Text = error.Message;
            }
            catch (Exception ex)
            {
                Results.Text = "Sorry, something went wrong. " + ex.Message;
            }
        }

        private void SendRequests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = "";
                server.OrdersTaken += () => { server.OnOrdersTaken(server._tableRequests); };
                cook.OrdersPrepared += server.OnOrdersPrepared;
                Results.Text = server.SendOrder();
            }
            catch (InvalidOperationException error)
            {
                Results.Text = error.Message;
            }
            catch (Exception ex)
            {
                Results.Text = "Sorry, something went wrong. " + ex.Message;
            }
        }

        //private void ServeFood_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {

        //        Results.Text = server.ServeFood();
        //    }
        //    catch (InvalidOperationException error)
        //    {
        //        Results.Text = error.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        Results.Text = "Sorry, something went wrong. " + ex.Message;
        //    }
        //}
    }
}
