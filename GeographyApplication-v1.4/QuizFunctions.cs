using System;
using System.Collections;
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
namespace GeographyApplication_v1._4
{
    

    partial class MainPage
    {
        static bool quizFinished = false;
        CCountry currentCountry;
        int AddressAnswer(bool isCorrect)
        {
            if (isCorrect == true)
            {
                m_NumCorrect++;
                NumberCorrectText.Text = "Number Correct: " + m_NumCorrect.ToString();
                Title.Text = "Correct";
            }
            else
            {
                m_NumIncorrect++;
                NumberIncorrectText.Text = "Number Incorrect: " + m_NumIncorrect.ToString();
                Title.Text = "Incorrect";
            }
            m_NumAnswered++;
            return m_NumCorrect;
        }
        int AddressAnswer(bool isCorrect, string correctAnswer)
        {
            if (isCorrect == true)
            {
                m_NumCorrect++;
                NumberCorrectText.Text = "Number Correct: " + m_NumCorrect.ToString();
                Title.Text = "Correct";
            }
            else
            {
                m_NumIncorrect++;
                NumberIncorrectText.Text = "Number Incorrect: " + m_NumIncorrect.ToString();
                Title.Text = "Incorrect, answer was: " + correctAnswer.ToString();
            }
            m_NumAnswered++;
            return m_NumCorrect;
        }
        int AddressAnswer(bool isCorrect, string correctAnswer, string secondCorrectAnswer)
        {
            if (isCorrect == true)
            {
                m_NumCorrect++;
                NumberCorrectText.Text = "Number Correct: " + m_NumCorrect.ToString();
                Title.Text = "Correct";
            }
            else
            {
                m_NumIncorrect++;
                NumberIncorrectText.Text = "Number Incorrect: " + m_NumIncorrect.ToString();
                Title.Text = "Incorrect, answer was: " + correctAnswer.ToString() + " and " + secondCorrectAnswer.ToString();
            }
            m_NumAnswered++;
            return m_NumCorrect;
        }

        public void NextQuizItem(QUIZ_ORDER quizOrder)
        {
            if (ActiveCountries.Count > 1)
            {
                if (currentCountry != null)
                {
                    string currentCountryName = currentCountry.m_Name;
                    //RemoveMemberFromArray<CCountry, CCountry>(ActiveCountries, ActiveCountries[6]);
                    for (int index = 0; index < ActiveCountries.Count; index++)
                    {
                        if(((CCountry)ActiveCountries.ElementAtOrDefault(index).Value).m_Name == currentCountry.m_Name)
                        {
                            ActiveCountries.Remove(ActiveCountries.ElementAtOrDefault(index).Key);
                        }
                    }
                    
                }
                int i = ActiveCountries.Count;
                int random = m_Random.Next(0, ActiveCountries.Count - 1);
                string key = ActiveCountries.ElementAtOrDefault(random).Key;
                currentCountry = (CCountry)ActiveCountries[key];
                MainCountryImage.Source = ((Image)this.Resources[key]).Source;
                switch (quizOrder)
                {
                    case QUIZ_ORDER.COUNTRY_TO_CAPITAL:
                        if (PromptText != null)
                        {
                            PromptText.Text = currentCountry.m_Name;
                        }
                        if (CountryPromptText != null)
                        {
                            CountryPromptText.Text = currentCountry.m_Name;
                        }
                        CountryAnswerText.IsEnabled = false;
                        CapitalAnswerText.IsEnabled = true;
                        break;
                    case QUIZ_ORDER.CAPITAL_TO_COUNTRY:
                        if (PromptText != null)
                        {
                            PromptText.Text = currentCountry.m_Capital.m_Name;
                        }
                        if (CapitalPromptText != null)
                        {
                            CapitalPromptText.Text = currentCountry.m_Capital.m_Name;
                        }
                        CountryAnswerText.IsEnabled = true;
                        CapitalAnswerText.IsEnabled = false;
                        break;
                    case QUIZ_ORDER.LOCATION_TO_COUNTRY_AND_CAPITAL:
                        if (CapitalPromptText != null && CountryPromptText != null)
                        {
                            CountryPromptText.Text = "";
                            CapitalPromptText.Text = "";
                        }
                        if (PromptText != null)
                        {
                            PromptText.Text = "";
                        }
                        CountryAnswerText.IsEnabled = true;
                        CapitalAnswerText.IsEnabled = true;
                        break;
                }
                CountryAnswerText.Text = "";
                CapitalAnswerText.Text = "";
            }
            else if (ActiveCountries.Count <= 1)
            {
                EndQuiz();
            }
        }

        bool EndQuiz()
        {
            quizFinished = true;
            Title.Text = "Quiz Over, you got " + m_NumCorrect.ToString() + " out of " + m_NumAnswered.ToString() + " correct";
            if (m_NumCorrect > m_NumIncorrect)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}