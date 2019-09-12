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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GeographyApplication_v1._4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        public MainMenu()
        {
            this.InitializeComponent();
        }

        private void AfricaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.AFRICA;
            Frame.Navigate(typeof(MainPage));
        }

        private void EuropeQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.EUROPE;
            Frame.Navigate(typeof(MainPage));
        }

        private void NorthAmericaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.NORTH_AMERICA;
            Frame.Navigate(typeof(MainPage));
        }

        private void SouthAmericaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.SOUTH_AMERICA;
            Frame.Navigate(typeof(MainPage));
        }

        private void AustrailiaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.AUSTRAILIA;
            Frame.Navigate(typeof(MainPage));
        }

        private void AntarcticaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.ANTARCTICA;
            Frame.Navigate(typeof(MainPage));
        }

        private void AsiaQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ActiveContinent = CONTINENT.ASIA;
            Frame.Navigate(typeof(MainPage));
        }

        private void MenuFlyoutCaptoCount_Click(object sender, RoutedEventArgs e)
        {
            MainPage.quizOrder = QUIZ_ORDER.CAPITAL_TO_COUNTRY;
        }

        private void MenuFlyoutCounttoCap_Click(object sender, RoutedEventArgs e)
        {
            MainPage.quizOrder = QUIZ_ORDER.COUNTRY_TO_CAPITAL;
        }

        private void MenuFlyoutMaptoCountCap_Click(object sender, RoutedEventArgs e)
        {
            MainPage.quizOrder = QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
