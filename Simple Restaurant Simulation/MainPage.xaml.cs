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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        static object order;

        private void SubmitNewRequest_Click(object sender, RoutedEventArgs e)
        {
            EggQuality.Text = "";
            Results.Text = "";

            try
            {
                bool? isChicken = chickenOpt.IsChecked;
                order = Employee.NewRequest(isChicken, int.Parse(OrderQuantity.Text));
                EggQuality.Text = Employee.Inspect(order);
            }
            catch (Exception)
            {
                Results.Text = "Please enter a number.";
            }
        }

        private void CopyPreviousRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order = Employee.CopyRequest();
                EggQuality.Text = Employee.Inspect(order);
            }
            catch (NullReferenceException)
            {
                Results.Text = "There is no previous request.";
            }
        }

        private void PrepareFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Results.Text = Employee.PrepareFood(order);
                order = null;
                OrderQuantity.Text = "";
            }
            catch (InvalidOperationException error)
            {
                Results.Text = error.Message;
            }
            catch (NullReferenceException error)
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
