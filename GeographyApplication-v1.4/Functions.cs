using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
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
    public static class Functions
    {
        static public CCountry GetMemberOfArrayByName(CCountry[] Array, string name)
        {
            CCountry[] tempArray = Array;
            for (int i = 0; i < Array.Length - 1; i++)
            {
                if (Array[i].m_Name == name)
                {
                    return Array[i];
                }
            }
            return null;
        }

        static public Dictionary<T, T2> RemoveObjectFromDictionary<T, T2>(Dictionary<T, T2> dictionaryReference, T keyOfObjectToRemove)
        {
            dictionaryReference.Remove(keyOfObjectToRemove);
            return dictionaryReference;
        }

        static public FileStream ConvertStringArrayToCode(string[] array)
        {
            FileStream file = File.OpenWrite(Directory.GetCurrentDirectory() + "/Assets");
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string CodePiece1)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string CodePiece1, string CodePiece2)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string CodePiece1, string CodePiece2, string CodePiece3)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string CodePiece1, string CodePiece2, string CodePiece3, string CodePiece4)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string[] array1, string CodePiece1)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string[] array1, string[] array2, string CodePiece1, string CodePiece2)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string[] array1, string[] array2, string[] array3, string CodePiece1, string CodePiece2, string CodePiece3)
        {
            return null;
        }
        static public FileStream ConvertStringArrayToCode(string[] array, string[] array1, string[] array2, string[] array3, string[] array4, string CodePiece1, string CodePiece2, string CodePiece3, string CodePiece4)
        {
            return null;
        }

    }
}
