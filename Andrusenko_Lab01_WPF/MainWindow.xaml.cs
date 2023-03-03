using System;
using System.Globalization;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Windows;
using System.Windows.Controls;

namespace Andrusenko_Lab01_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AgeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ageTextBlock.Text = "";
            wAstroSignTextBlock.Text = "";
            cAstroSignTextBlock.Text = "";
            int yearDifference;
            if (ageDatePicker.SelectedDate == null)
                return;
            else yearDifference = DateTime.Now.Year - ((DateTime)ageDatePicker.SelectedDate).Year;
            if (DateTime.Now.Month < ((DateTime)ageDatePicker.SelectedDate).Month ||
                (DateTime.Now.Month == ((DateTime)ageDatePicker.SelectedDate).Month &&
                DateTime.Now.Day < ((DateTime)ageDatePicker.SelectedDate).Day)) yearDifference--;
            if (yearDifference < 0)
            {
                MessageBox.Show("Are you a timetraveller? \nYou can't be born in the future. \nDate is probably incorrect.", "Something's wrong");
                ageDatePicker.SelectedDate = null;
            }
            else
            {
                if(yearDifference > 135) {
                    MessageBox.Show("You can't be that old! \nDate is probably incorrect.", "Something's wrong");
                    ageDatePicker.SelectedDate = null;
                }
                else {
                    if (DateTime.Now.Month == ((DateTime)ageDatePicker.SelectedDate).Month &&
                    DateTime.Now.Day == ((DateTime)ageDatePicker.SelectedDate).Day) MessageBox.Show("Looks like you've got a birthday, congratulations!", "Congratulation");
                    string wText = "";
                    ageTextBlock.Text = "Your age is " + yearDifference.ToString();
                    switch (((DateTime)ageDatePicker.SelectedDate).Month){
                        case 1: wText = ((DateTime)ageDatePicker.SelectedDate).Day < 20 ? "The Goat" : "The Water-bearer";
                            break;
                        case 2:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 19 ? "The Water-bearer" : "The Fish";
                            break;
                        case 3:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 21 ? "The Fish" : "The Ram";
                            break;
                        case 4:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 20 ? "The Ram" : "The Bull";
                            break;
                        case 5:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 21 ? "The Bull" : "The Twins";
                            break;
                        case 6:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 22 ? "The Twins" : "The Crab";
                            break;
                        case 7:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 23 ? "The Crab" : "The Lion";
                            break;
                        case 8:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 23 ? "The Lion" : "The Maiden";
                            break;
                        case 9:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 23 ? "The Maiden" : "The Scales";
                            break;
                        case 10:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 23 ? "The Scales" : "The Scorpion";
                            break;
                        case 11:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 23 ? "The Scorpion" : "The Archer (Centaur)";
                            break;
                        case 12:
                            wText = ((DateTime)ageDatePicker.SelectedDate).Day < 22 ? "The Archer (Centaur)" : "The Goat";
                            break;
                        default: break;
                    }
                    wAstroSignTextBlock.Text = "Western zodiac: " + wText;
                    if (((DateTime)ageDatePicker.SelectedDate).Year < 1901 || ((DateTime)ageDatePicker.SelectedDate).Year > 2100) return;
                    string cText = "";
                    DateTime chineseNewYearDate = new ChineseLunisolarCalendar().ToDateTime(((DateTime)ageDatePicker.SelectedDate).Year, 1, 1, 0, 0, 0, 0);
                    wAstroSignTextBlock.Text += " ";
                    int chineseYear = ((DateTime)ageDatePicker.SelectedDate).Year - ((((DateTime)ageDatePicker.SelectedDate).Month < chineseNewYearDate.Month ||
                (((DateTime)ageDatePicker.SelectedDate).Month == chineseNewYearDate.Month &&
                ((DateTime)ageDatePicker.SelectedDate).Day < chineseNewYearDate.Day))?1:0);
                    switch (chineseYear % 12)
                    {
                        case 0: cText = "Monkey";
                            break;
                        case 1:
                            cText = "Rooster";
                            break;
                        case 2:
                            cText = "Dog";
                            break;
                        case 3:
                            cText = "Pig";
                            break;
                        case 4:
                            cText = "Rat";
                            break;
                        case 5:
                            cText = "Ox";
                            break;
                        case 6:
                            cText = "Tiger";
                            break;
                        case 7:
                            cText = "Rabbit";
                            break;
                        case 8:
                            cText = "Dragon";
                            break;
                        case 9:
                            cText = "Snake";
                            break;
                        case 10:
                            cText = "Horse";
                            break;
                        case 11:
                            cText = "Goat";
                            break;
                        default:break;
                    }
                    cAstroSignTextBlock.Text = "Chinese zodiac: " + cText;
                }
            }

        }
    }
}
