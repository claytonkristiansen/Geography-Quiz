using System;
using System.Collections;
using Windows.Storage;
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
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GeographyApplication_v1._4
{
    public enum CONTINENT { AFRICA, EUROPE, AUSTRAILIA, ANTARCTICA, NORTH_AMERICA, SOUTH_AMERICA, ASIA };
    public enum QUIZ_ORDER { CAPITAL_TO_COUNTRY, COUNTRY_TO_CAPITAL, LOCATION_TO_COUNTRY_AND_CAPITAL };
    public sealed partial class MainPage : Page
    {
        static public QUIZ_ORDER quizOrder;
        public Dictionary<string, object> ActiveCountries;
        static public CONTINENT ActiveContinent;
        Random m_Random = new Random();
        public int m_NumCorrect = 0, m_NumIncorrect = 0;
        public int m_NumAnswered = 0;

        //void CreateFile(string name)
        //{
        //    // Create sample file; replace if exists.
        //    Windows.Storage.StorageFolder storageFolder =
        //        Windows.Storage.ApplicationData.Current.LocalFolder;
        //    Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);
        //}

        /// <summary>
        /// First function called
        /// </summary>
        public MainPage()
        {
            quizFinished = false;
            this.InitializeComponent();
            switch (ActiveContinent)
            {
                case CONTINENT.AFRICA:
                    ActiveCountries = InitializeAfrica();
                    break;
                case CONTINENT.NORTH_AMERICA:
                    ActiveCountries = InitializeNorthAmerica();
                    break;
                case CONTINENT.SOUTH_AMERICA:
                    ActiveCountries = InitializeSouthAmerica();
                    break;
                case CONTINENT.EUROPE:
                    ActiveCountries = InitializeEurope();
                    break;
                case CONTINENT.ASIA:
                    ActiveCountries = InitializeAsia();
                    break;
                case CONTINENT.AUSTRAILIA:
                    ActiveCountries = InitializeAustralia();
                    break;
                case CONTINENT.ANTARCTICA:
                    ActiveCountries = InitializeAntarctica();
                    break;
            }
            //.Source = new BitmapImage(new Uri(@"ms-appx//\Assets\Maps\AngolaMap.jpg", UriKind.Relative));
            NextQuizItem(quizOrder);
            //currentCountry = Africa.m_Countries[m_Random.Next(0, Africa.m_Countries.Length - 1)];
            switch (quizOrder)
            {
                case QUIZ_ORDER.COUNTRY_TO_CAPITAL:
                    if (PromptText != null)
                    {
                        PromptText.Text = currentCountry.m_Name;
                    }
                    break;
                case QUIZ_ORDER.CAPITAL_TO_COUNTRY:
                    if (PromptText != null)
                    {
                        PromptText.Text = currentCountry.m_Capital.m_Name;
                    }
                    break;
                case QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL:
                    if (CountryPromptText != null && CapitalPromptText != null)
                    {
                        CountryPromptText.Text = "";
                        CapitalPromptText.Text = "";
                    }
                    if (PromptText != null)
                    {
                        PromptText.Text = "";
                        PromptText.Text = "";
                    }
                    break;
            }
        }
        //-------------------------------------------------------------------------------------------------------------//
        CContinent Africa = new CContinent("Afica");
        Dictionary<string, object> InitializeAfrica()
        {
            Africa.m_Countries.Add("Mauritania",                      new CCountry("Mauritania", "Nouakchott"));
            Africa.m_Countries.Add("Senegal",                         new CCountry("Senegal", "Dakar"));
            Africa.m_Countries.Add("Gambia",                          new CCountry("Gambia", "Banjul"));
            Africa.m_Countries.Add("GuineaBissau",                    new CCountry("Guinea Bissau", "Bissau"));
            Africa.m_Countries.Add("Guinea",                          new CCountry("Guinea", "Conakry"));
            Africa.m_Countries.Add("SierraLeone",                     new CCountry("Sierra Leone", "Freetown"));
            Africa.m_Countries.Add("Liberia",                         new CCountry("Liberia", "Monrovia"));
            Africa.m_Countries.Add("CotedIvoire",                     new CCountry("Cote d' Ivoire", "Abidjan"));
            Africa.m_Countries.Add("Mali",                            new CCountry("Mali", "Bamako"));
            Africa.m_Countries.Add("BurkinaFaso",                     new CCountry("Burkina Faso", "Ouagadougou"));
            Africa.m_Countries.Add("Ghana",                           new CCountry("Ghana", "Accra"));
            Africa.m_Countries.Add("Togo",                            new CCountry("Togo", "Lome"));
            Africa.m_Countries.Add("Benin",                           new CCountry("Benin", "Porto Novo"));
            Africa.m_Countries.Add("Niger",                           new CCountry("Niger", "Niamey"));
            Africa.m_Countries.Add("Nigeria",                         new CCountry("Nigeria", "Abuja"));
            Africa.m_Countries.Add("Cameroon",                        new CCountry("Cameroon", "Yaounde"));
            Africa.m_Countries.Add("SaoTomeandPrincipe",              new CCountry("Sao Tome and Principe", "Sao Tome"));
            Africa.m_Countries.Add("EquatorialGuinea",                new CCountry("Equatorial Guinea", "Malabo"));
            Africa.m_Countries.Add("Gabon",                           new CCountry("Gabon", "Libreville"));
            Africa.m_Countries.Add("Congo",                           new CCountry("Congo", "Brazzaville"));
            Africa.m_Countries.Add("DemocraticRepublicoftheCongo",    new CCountry("Democratic Republic of the Congo", "Kinshasa"));
            Africa.m_Countries.Add("Angola",                          new CCountry("Angola", "Luanda"));
            Africa.m_Countries.Add("Namibia",                         new CCountry("Namibia", "Windhoek"));
            Africa.m_Countries.Add("SouthAfrica",                     new CCountry("South Africa", "Pretoria, Cape Town, Bloemfontein"));
            Africa.m_Countries.Add("Lesotho",                         new CCountry("Lesotho", "Maseru"));
            Africa.m_Countries.Add("Swaziland",                       new CCountry("Swaziland", "Mbabane"));
            Africa.m_Countries.Add("Botswana",                        new CCountry("Botswana", "Gaborone"));
            Africa.m_Countries.Add("Zimbabwe",                        new CCountry("Zimbabwe", "Harare"));
            Africa.m_Countries.Add("Mozambique",                      new CCountry("Mozambique", "Maputo"));
            Africa.m_Countries.Add("Madagascar",                      new CCountry("Madagascar", "Antananarivo"));
            Africa.m_Countries.Add("Zambia",                          new CCountry("Zambia", "Lusaka"));
            Africa.m_Countries.Add("Malawi",                          new CCountry("Malawi", "Lilongwe"));
            Africa.m_Countries.Add("Tanzania",                        new CCountry("Tanzania", "Dar es Salaam"));
            Africa.m_Countries.Add("Burundi",                         new CCountry("Burundi", "Bujumbura"));
            Africa.m_Countries.Add("Rwanda",                          new CCountry("Rwanda", "Kigali"));
            Africa.m_Countries.Add("Uganda",                          new CCountry("Uganda", "Kampala"));
            Africa.m_Countries.Add("Kenya",                           new CCountry("Kenya", "Nairobi"));
            Africa.m_Countries.Add("Somalia",                         new CCountry("Somalia", "Mogadishu"));
            Africa.m_Countries.Add("Ethiopia",                        new CCountry("Ethiopia", "Addis Ababa"));
            Africa.m_Countries.Add("Djibouti",                        new CCountry("Djibouti", "Djibouti"));
            Africa.m_Countries.Add("Eritrea",                         new CCountry("Eritrea", "Asmara"));
            Africa.m_Countries.Add("Sudan",                           new CCountry("Sudan", "Khartoum"));
            Africa.m_Countries.Add("Chad",                            new CCountry("Chad", "N'Djamena"));
            Africa.m_Countries.Add("CentralAfricanRepublic",          new CCountry("Central African Republic", "Bangui"));
            Africa.m_Countries.Add("Mauritius",                       new CCountry("Mauritius", "Port Louis"));
            Africa.m_Countries.Add("Comoros",                         new CCountry("Comoros", "Moroni"));
            Africa.m_Countries.Add("Seychelles",                      new CCountry("Seychelles", "Victoria"));
            Africa.m_Countries.Add("SouthSudan",                      new CCountry("South Sudan", "Juba"));
            Africa.m_Countries.Add("CapeVerde",                       new CCountry("Cape Verde", "Praia"));
            return Africa.m_Countries;
        }
        //-------------------------------------------------------------------------------------------------------------//
        CContinent NorthAmerica = new CContinent("North America");
        Dictionary<string, object> InitializeNorthAmerica()
        {
            return NorthAmerica.m_Countries;
        }
        ////-------------------------------------------------------------------------------------------------------------//
        CContinent SouthAmerica = new CContinent("South America");
        Dictionary<string, object> InitializeSouthAmerica()
        {
            SouthAmerica.m_Countries.Add("Mexico",              new CCountry("Mexico", "Mexico City"));
            SouthAmerica.m_Countries.Add("Guatemala",           new CCountry("Guatemala", "Guatemala City"));
            SouthAmerica.m_Countries.Add("Belize",              new CCountry("Belize", "Belmopan"));
            SouthAmerica.m_Countries.Add("ElSalvador",          new CCountry("El Salvador", "San Salvador"));
            SouthAmerica.m_Countries.Add("Honduras",            new CCountry("Honduras", "Tegucigalpa"));
            SouthAmerica.m_Countries.Add("CostaRica",           new CCountry("Costa Rica", "San Jose"));
            SouthAmerica.m_Countries.Add("Nicaragua",           new CCountry("Nicaragua", "Managua"));
            SouthAmerica.m_Countries.Add("Panama",              new CCountry("Panama", "Panama City"));
            SouthAmerica.m_Countries.Add("Cuba",                new CCountry("Cuba", "Havana"));
            SouthAmerica.m_Countries.Add("Jamaica",             new CCountry("Jamaica", "Kingston"));
            SouthAmerica.m_Countries.Add("Haiti",               new CCountry("Haiti", "Port-au-Prince"));
            SouthAmerica.m_Countries.Add("DominicanRepublic",   new CCountry("Dominican Republic", "Santo Domingo"));
            SouthAmerica.m_Countries.Add("Bahamas",             new CCountry("Bahamas", "Nassasu"));
            SouthAmerica.m_Countries.Add("Argentina",           new CCountry("Argentina", "Buenos Aires"));
            SouthAmerica.m_Countries.Add("Bolivia",             new CCountry("Bolivia", "La Paz and Sucre"));
            SouthAmerica.m_Countries.Add("Brazil",              new CCountry("Brazil", "Brasilia"));
            SouthAmerica.m_Countries.Add("Chile",               new CCountry("Chile", "Santiago"));
            SouthAmerica.m_Countries.Add("Colombia",            new CCountry("Colombia", "Bogota"));
            SouthAmerica.m_Countries.Add("Ecuador",             new CCountry("Ecuador", "Quito"));
            SouthAmerica.m_Countries.Add("FrenchGuiana",        new CCountry("French Guiana", "Cayenne"));
            SouthAmerica.m_Countries.Add("Guyana",              new CCountry("Guyana", "Georgetown"));
            SouthAmerica.m_Countries.Add("Paraguay",            new CCountry("Paraguay", "Asuncion"));
            SouthAmerica.m_Countries.Add("Peru",                new CCountry("Peru", "Lima"));
            SouthAmerica.m_Countries.Add("Suriname",            new CCountry("Suriname", "Paramaribo"));
            SouthAmerica.m_Countries.Add("Uruguay",             new CCountry("Uruguay", "Montevideo"));
            SouthAmerica.m_Countries.Add("Venezuela",           new CCountry("Venezuela", "Caracas"));
            return SouthAmerica.m_Countries;
        }
        ////-------------------------------------------------------------------------------------------------------------//
        CContinent Europe = new CContinent("Europe");
        Dictionary<string, object> InitializeEurope()
        {
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Spain", new CCountry("Spain", "Madrid"));
            Europe.m_Countries.Add("France", new CCountry("France", "Paris"));
            Europe.m_Countries.Add("UnitedKingdom", new CCountry("UnitedKingdom", "London"));
            Europe.m_Countries.Add("Italy", new CCountry("Italy", "Rome"));
            Europe.m_Countries.Add("Switzerland", new CCountry("Switzerland", "Bern"));
            Europe.m_Countries.Add("Luxembourg", new CCountry("Luxembourg", "Luxembourg"));
            Europe.m_Countries.Add("Belgium", new CCountry("Belgium", "Brussels"));
            Europe.m_Countries.Add("Netherlands", new CCountry("Netherlands", "Amsterdam"));
            Europe.m_Countries.Add("Germany", new CCountry("Germany", "Berlin"));
            Europe.m_Countries.Add("Denmark", new CCountry("Denmark", "Copenhagen"));
            Europe.m_Countries.Add("Poland", new CCountry("Poland", "Warsaw"));
            Europe.m_Countries.Add("CzechRepublic", new CCountry("Czech Republic", "Prague"));
            Europe.m_Countries.Add("Slovakia", new CCountry("Slovakia", "Bratislava"));
            Europe.m_Countries.Add("Austria", new CCountry("Austria", "Vienna"));
            Europe.m_Countries.Add("Hungary", new CCountry("Hungary", "Budapest"));
            Europe.m_Countries.Add("Slovenia", new CCountry("Slovenia", "Ljublijana"));
            Europe.m_Countries.Add("Croatia", new CCountry("Croatia", "Zagreb"));
            Europe.m_Countries.Add("BosniaandHerzegovina", new CCountry("Bosnia and Herzegovina", "Sarajevo"));
            Europe.m_Countries.Add("Serbia", new CCountry("Serbia", "Belgrade"));
            Europe.m_Countries.Add("Montenegro", new CCountry("Montenegro", "Podgorica"));
            Europe.m_Countries.Add("Albania", new CCountry("Albania", "Tirana"));
            Europe.m_Countries.Add("Macedonia", new CCountry("Macedonia", "Skopje"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            Europe.m_Countries.Add("Portugal", new CCountry("Portugal", "Libson"));
            return Europe.m_Countries;
        }
        ////-------------------------------------------------------------------------------------------------------------//
        CContinent Asia = new CContinent("Asia");
        Dictionary<string, object> InitializeAsia()
        {
            return Asia.m_Countries;
        }
        ////-------------------------------------------------------------------------------------------------------------//
        CContinent Australia = new CContinent("Australia");
        Dictionary<string, object> InitializeAustralia()
        {
            return Australia.m_Countries;
        }
        ////-------------------------------------------------------------------------------------------------------------//
        CContinent Antarctica = new CContinent("Antarctica");
        Dictionary<string, object> InitializeAntarctica()
        {
            return Antarctica.m_Countries;
        }

        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainMenu));
        }

        private void ScoreNowButton_Click(object sender, RoutedEventArgs e)
        {
            EndQuiz();
        }

        private void Title_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        //-------------------------------------------------------------------------------------------------------------//
        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            if ((!(currentCountry == null)) && !quizFinished)
            {
                switch (quizOrder)
                {
                    case QUIZ_ORDER.COUNTRY_TO_CAPITAL:
                        if (CapitalAnswerText.Text == currentCountry.m_Capital.m_Name)
                        {
                            AddressAnswer(true);
                            NextQuizItem(QUIZ_ORDER.COUNTRY_TO_CAPITAL);
                        }
                        else
                        {
                            AddressAnswer(false, currentCountry.m_Capital.m_Name);
                            NextQuizItem(QUIZ_ORDER.COUNTRY_TO_CAPITAL);
                        }

                        break;
                    case QUIZ_ORDER.CAPITAL_TO_COUNTRY:
                        if (CountryAnswerText.Text == currentCountry.m_Name)
                        {
                            AddressAnswer(true);
                            NextQuizItem(QUIZ_ORDER.CAPITAL_TO_COUNTRY);
                        }
                        else
                        {
                            AddressAnswer(false, currentCountry.m_Name);
                            NextQuizItem(QUIZ_ORDER.CAPITAL_TO_COUNTRY);
                        }
                        break;
                    case QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL:
                        if(CountryAnswerText.Text == currentCountry.m_Name && CapitalAnswerText.Text == currentCountry.m_Capital.m_Name)
                        {
                            AddressAnswer(true);
                            NextQuizItem(QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL);
                        }
                        else
                        {
                            AddressAnswer(false, currentCountry.m_Name, currentCountry.m_Capital.m_Name);
                            NextQuizItem(QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL);
                        }
                        break;
                }
            }
        }
    }
}
