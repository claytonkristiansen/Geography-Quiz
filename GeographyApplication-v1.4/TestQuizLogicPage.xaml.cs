using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GeographyApplication_v1._4
{
    public struct SCapital
    {
        public string m_Name;
    }

    public class CCountry
    {
        string m_CountryImageSource;
        public string m_Name;
        public string m_Key;
        public SCapital m_Capital;
        public int m_LocationIndex;
        public CCountry(string name, SCapital capital, int locationIndex)
        {
            m_Name = name;
            m_Capital = capital;
            m_LocationIndex = locationIndex;
        }
        public CCountry(string name, string capital)
        {
            m_Name = name;
            m_Capital.m_Name = capital;
        }
        public CCountry(string name, string capital, string countryImageSource)
        {
            m_CountryImageSource = countryImageSource;
            m_Name = name;
            m_Capital.m_Name = capital;
        }
        public CCountry(string name, SCapital capital)
        {
            m_Name = name;
            m_Capital = capital;
        }
        public CCountry()
        {
        }
    }

    public class CContinent
    {
        public Dictionary<string, object> m_Countries;
        public string m_Name;
        int m_NumberOfCountries;

        public CContinent(string name, Dictionary<string, object> countries)
        {
            m_Name = name;
            m_Countries = countries;
        }
        public CContinent(string name)
        {
            m_Countries = new Dictionary<string, object>();
            m_Name = name;
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestQuizLogicPage : Page
    {

        Random m_Random = new Random();
        public TestQuizLogicPage()
        {
            //FileStream countryFile = File.Open("Assets/AfricaCountries.txt", FileMode.Open, FileAccess.Read);
            //byte[] tempByteArray = new  byte[countryFile.Length];
            //countryFile.Read(tempByteArray, 0, (int)countryFile.Length);
            //char[] tempCharArray = Encoding.Unicode.GetChars(tempByteArray);
            //InitializeAfrica();
            InitializeNorthAmerica();
            InitializeSouthAmerica();
            //InitializeEurope();
            InitializeAsia();
            InitializeAustralia();
            InitializeAntarctica();

            this.InitializeComponent();

            currentCountry = (CCountry)Africa.m_Countries.ElementAtOrDefault(m_Random.Next(0, Africa.m_Countries.Count - 1)).Value;
            //switch (quizOrder)
            //{
            //    case QUIZ_ORDER.COUNTRY_TO_CAPITAL:
            //        PromptText.Text = currentCountry.m_Name;
            //        break;
            //    case QUIZ_ORDER.CAPITAL_TO_COUNTRY:
            //        PromptText.Text = currentCountry.m_Capital.m_Name;
            //        break;
            //}

        }


        CContinent Africa = new CContinent("Afica");
        //void InitializeAfrica()
        //{
        //    Africa.m_Countries = new CCountry[]
        //    {
        //        new CCountry("Mauritania", "Nouakchott"),
        //        new CCountry("Senegal", "Dakar"),
        //        new CCountry("Gambia", "Banjul"),
        //        new CCountry("Guinea-Bissau", "Bissau"),
        //        new CCountry("Guinea", "Conakry"),
        //        new CCountry("Sierra Leone", "Freetown"),
        //        new CCountry("Liberia", "Monrovia"),
        //        new CCountry("Cote d' Ivoire", "Abidjan"),
        //        new CCountry("Mali", "Bamako"),
        //        new CCountry("Burkina Faso", "Ouagadougou"),
        //        new CCountry("Ghana", "Accra"),
        //        new CCountry("Togo", "Lome"),
        //        new CCountry("Benin", "Porto Novo"),
        //        new CCountry("Niger", "Niamey"),
        //        new CCountry("Nigeria", "Abuja"),
        //        new CCountry("Cameroon", "Yaounde"),
        //        new CCountry("Sao Tome & Principe", "Sao Tome"),
        //        new CCountry("Equatorial Guinea", "Malabo"),
        //        new CCountry("Gabon", "Libreville"),
        //        new CCountry("Congo", "Brazzaville"),
        //        new CCountry("Democratic Republic of the Congo", "Kinshasa"),
        //        new CCountry("Angola", "Luanda"),
        //        new CCountry("Namibia", "Windhoek"),
        //        new CCountry("South Africa", "Pretoria, Cape Town, Bloemfontein"),
        //        new CCountry("Lesotho", "Maseru"),
        //        new CCountry("Swaziland", "Mbabane"),
        //        new CCountry("Botswana", "Gaborone"),
        //        new CCountry("Zimbabwe", "Harare"),
        //        new CCountry("Mozambique", "Maputo"),
        //        new CCountry("Madagascar", "Antananarivo"),
        //        new CCountry("Zambia", "Lusaka"),
        //        new CCountry("Malawi", "Lilongwe"),
        //        new CCountry("Tanzania", "Dar es Salaam"),
        //        new CCountry("Burundi", "Bujumbura"),
        //        new CCountry("Rwanda", "Kigali"),
        //        new CCountry("Uganda", "Kampala"),
        //        new CCountry("Kenya", "Nairobi"),
        //        new CCountry("Somalia", "Mogadishu"),
        //        new CCountry("Ethiopia", "Addis Ababa"),
        //        new CCountry("Djibouti", "Djibouti"),
        //        new CCountry("Eritrea", "Asmara"),
        //        new CCountry("Sudan", "Khartoum"),
        //        new CCountry("Chad", "N'Djamena"),
        //        new CCountry("Central African Republic", "Bangui"),
        //        new CCountry("Mauritius", "Port Louis"),
        //        new CCountry("Comoros", "Moroni"),
        //        new CCountry("Seychelles", "Victoria"),
        //        new CCountry("South Sudan", "Juba"),
        //        new CCountry("Cape Verde", "Praia")
        //    };
        //}

        CContinent NorthAmerica = new CContinent("North America");
        void InitializeNorthAmerica()
        {

        }

        CContinent SouthAmerica = new CContinent("South America");
        void InitializeSouthAmerica()
        {

        }

        //CContinent Europe = new CContinent("Europe");
        //void InitializeEurope()
        //{
        //    Europe.m_Countries = new CCountry[]
        //    {
        //    new CCountry("Mauritania", "Nouakchott"),
        //    new CCountry("Mauritania", "Nouakchott")
        //    };
        //}

        CContinent Asia = new CContinent("Asia");
        void InitializeAsia()
        {

        }

        CContinent Australia = new CContinent("Australia");
        void InitializeAustralia()
        {

        }

        CContinent Antarctica = new CContinent("Antarctica");
        void InitializeAntarctica()
        {

        }

        public void NextQuizItem()
        {
            int i = Africa.m_Countries.Count;
            int random = m_Random.Next(0, Africa.m_Countries.Count - 1);
            currentCountry = (CCountry)Africa.m_Countries.ElementAtOrDefault(random).Value;
            PromptText.Text = currentCountry.m_Name;
        }

        CCountry currentCountry;
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            //    switch (quizOrder)
            //    {
            //        case QUIZ_ORDER.COUNTRY_TO_CAPITAL:
            //            if (AnswerTextEnter.Text == currentCountry.m_Capital.m_Name)
            //            {
            //                UserGratificationIdentifier.Text = "Correct";
            //                AnswerTextEnter.Text = "";
            //                NextQuizItem();
            //            }
            //            else
            //            {
            //                UserGratificationIdentifier.Text = "Incorrect";
            //                AnswerTextEnter.Text = "";
            //            }

            //            break;
            //        case QUIZ_ORDER.CAPITAL_TO_COUNTRY:
            //            if (AnswerTextEnter.Text == currentCountry.m_Name)
            //            {
            //                UserGratificationIdentifier.Text = "Correct";
            //                int i = Africa.m_Countries.Length;
            //                int random = m_Random.Next(0, Africa.m_Countries.Length - 1);
            //                currentCountry = Africa.m_Countries[random];
            //                PromptText.Text = currentCountry.m_Name;
            //            }
            //            else
            //            {
            //                UserGratificationIdentifier.Text = "Incorrect";
            //            }

            //            break;

            //    }
            //}
        }
    }
}
