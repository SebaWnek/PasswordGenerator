using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PasswordGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        internal string password = "";
        Random rnd = new Random();
        List<string> letters = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            letters.Clear();
            string nextChar;
            password = ((char)rnd.Next(65, 91)).ToString();
            for (int i = 0; i < 11; i++)
            {
                nextChar = ((char)rnd.Next(97, 123)).ToString();
                while (nextChar == password[i].ToString().ToLower())
                {
                    nextChar = ((char)rnd.Next(97, 123)).ToString();
                }
                password += nextChar;
            }
            password += "1!";
            passwordBox.Text = password;
            letters = password.ToList();
            listBox1.ItemsSource = letters;
            listBox1.SelectedIndex = 0;
            listBox1.Focus();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Text.Length != 14)
            {
                System.Windows.MessageBox.Show("First generate password!");
                return;
            }
            Clipboard.SetText(password);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Focus();
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex--;
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Focus();
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex++;
            }
        }
    }

    internal static class PassLetter
    {
        static Dictionary<char, string> baseLetters = new Dictionary<char, string>()
        {
            { 'a', "ALFA" },
            { 'b', "BRAVO" },
            { 'c', "CHARLIE" },
            { 'd', "DELTA" },
            { 'e', "ECHO" },
            { 'f', "FOXTROT" },
            { 'g', "GOLF" },
            { 'h', "HOTEL" },
            { 'i', "INDIA" },
            { 'j', "JULIET" },
            { 'k', "KILO" },
            { 'l', "LIMA" },
            { 'm', "MIKE" },
            { 'n', "NOVEMBER" },
            { 'o', "OSCAR" },
            { 'p', "PAPA" },
            { 'q', "QUEBEC" },
            { 'r', "ROMEO" },
            { 's', "SIERRA" },
            { 't', "TANGO" },
            { 'u', "UNIFORM" },
            { 'v', "VICTOR" },
            { 'w', "WHISKEY" },
            { 'x', "XRAY" },
            { 'y', "YANKEE" },
            { 'z', "ZULU" },
            { '1', "Number ONE" },
            { '!', "Exclamation mark" },
        };

        static Dictionary<char, string> alternateLetters = new Dictionary<char, string>()
        {
            { 'a', "Apple"},
            { 'b', "Banana"},
            { 'c', "Chocolate"},
            { 'd', "Donald"},
            { 'e', "England"},
            { 'f', "Football"},
            { 'g', "Germany"},
            { 'h', "Hong-Kong"},
            { 'i', "Indigo"},
            { 'j', "Japan"},
            { 'k', "Kite"},
            { 'l', "London"},
            { 'm', "Mumbai"},
            { 'n', "New, No"},
            { 'o', "Orange"},
            { 'p', "Pakistan"},
            { 'q', "Queen"},
            { 'r', "Robert"},
            { 's', "Snake, Singapore"},
            { 't', "Television"},
            { 'u', "Umbrella"},
            { 'v', "Value, Virtual"},
            { 'w', "Washington"},
            { 'x', "Xenomorph"},
            { 'y', "Yellow"},
            { 'z', "Zebra"},
            { '1', "Just the number"},
            { '!', "Shift plus key one"},
        };
        
        static string NameFromLetter(this char c)
        {
            string letter = c.ToString();
            string result = letter.ToUpper();
            result += " for ";
            result += baseLetters[letter.ToLower()[0]];
            result += " - or ";
            result += alternateLetters[letter.ToLower()[0]];
            return result;
        }

        public static List<string> ToList(this string password)
        {
            List<string> result = new List<string>();
            foreach (char c in password)
            {
                if(c < 91 && c > 64)
                {
                    result.Add("Capital " + c.NameFromLetter());
                }
                else
                {
                    result.Add(c.NameFromLetter());
                }
            }
            return result;
        }
    }
}
