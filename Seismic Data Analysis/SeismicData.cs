using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Needed for text file I/O
using System.Text.RegularExpressions; //Needed for Regex (when removing whitespace)

namespace Seismic_Data_Analysis
{
    //This class contains all necessary data stored in string arrays
    class SeismicData
    {
        //Siesmic Data Area 1
        public static string[] Year_1 = File.ReadAllLines("../../Seismic_Data/Year_1.txt");
        public static string[] Month_1 = File.ReadAllLines("../../Seismic_Data/Month_1.txt");
        public static string[] Day_1 = File.ReadAllLines("../../Seismic_Data/Day_1.txt");
        public static string[] Time_1 = File.ReadAllLines("../../Seismic_Data/Time_1.txt");
        public static string[] Magnitude_1 = File.ReadAllLines("../../Seismic_Data/Magnitude_1.txt");
        public static string[] Latitude_1 = File.ReadAllLines("../../Seismic_Data/Latitude_1.txt");
        public static string[] Longitude_1 = File.ReadAllLines("../../Seismic_Data/Longitude_1.txt");
        public static string[] Depth_1 = File.ReadAllLines("../../Seismic_Data/Depth_1.txt");
        public static string[] Region_1 = File.ReadAllLines("../../Seismic_Data/Region_1.txt");
        public static string[] IRIS_ID_1 = File.ReadAllLines("../../Seismic_Data/IRIS_ID_1.txt");
        public static string[] Timestamp_1 = File.ReadAllLines("../../Seismic_Data/Timestamp_1.txt");


        //Siesmic Data Area 2
        public static string[] Year_2 = File.ReadAllLines("../../Seismic_Data/Year_2.txt");
        public static string[] Month_2 = File.ReadAllLines("../../Seismic_Data/Month_2.txt");
        public static string[] Day_2 = File.ReadAllLines("../../Seismic_Data/Day_2.txt");
        public static string[] Time_2 = File.ReadAllLines("../../Seismic_Data/Time_2.txt");
        public static string[] Magnitude_2 = File.ReadAllLines("../../Seismic_Data/Magnitude_2.txt");
        public static string[] Latitude_2 = File.ReadAllLines("../../Seismic_Data/Latitude_2.txt");
        public static string[] Longitude_2 = File.ReadAllLines("../../Seismic_Data/Longitude_2.txt");
        public static string[] Depth_2 = File.ReadAllLines("../../Seismic_Data/Depth_2.txt");
        public static string[] Region_2 = File.ReadAllLines("../../Seismic_Data/Region_2.txt");
        public static string[] IRIS_ID_2 = File.ReadAllLines("../../Seismic_Data/IRIS_ID_2.txt");
        public static string[] Timestamp_2 = File.ReadAllLines("../../Seismic_Data/Timestamp_2.txt");

        //Concat string arrays
        public static string[] allYears = Year_1.Concat(Year_2).ToArray();
        public static string[] allMonths = Month_1.Concat(Month_2).ToArray();
        public static string[] allDays = Day_1.Concat(Day_2).ToArray();
        public static string[] allTimes = Time_1.Concat(Time_2).ToArray();
        public static string[] allMagnitudes = Magnitude_1.Concat(Magnitude_2).ToArray();
        public static string[] allLatitudes = Latitude_1.Concat(Latitude_2).ToArray();
        public static string[] allLongitudes = Longitude_1.Concat(Longitude_2).ToArray();
        public static string[] allDepths = Depth_1.Concat(Depth_2).ToArray();
        public static string[] allRegions = Region_1.Concat(Region_2).ToArray();
        public static string[] allIRIS = IRIS_ID_1.Concat(IRIS_ID_2).ToArray();
        public static string[] allTimestamps = Timestamp_1.Concat(Timestamp_2).ToArray();


        //All concat string arrays are added to a Jagged array
        public static string[][] allSeismicData = new string[][] { allYears, allMonths, allDays, allTimes, allMagnitudes, allLatitudes, allLongitudes, allDepths, allRegions, allIRIS, allTimestamps }; 


        //This method assigns months with numbers
        //This string array holds the numbers
        public static string[] allMonthsInNumbers = new string[allMonths.Length];
        public static void MonthsToNumbers(string[] c)
        {
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].Contains("January"))
                    allMonthsInNumbers[i] = "01";
                if (c[i].Contains("February"))
                    allMonthsInNumbers[i] = "02";
                if (c[i].Contains("March"))
                    allMonthsInNumbers[i] = "03";
                if (c[i].Contains("April"))
                    allMonthsInNumbers[i] = "04";
                if (c[i].Contains("May"))
                    allMonthsInNumbers[i] = "05";
                if (c[i].Contains("June"))
                    allMonthsInNumbers[i] = "06";
                if (c[i].Contains("July"))
                    allMonthsInNumbers[i] = "07";
                if (c[i].Contains("August"))
                    allMonthsInNumbers[i] = "08";
                if (c[i].Contains("September"))
                    allMonthsInNumbers[i] = "09";
                if (c[i].Contains("October"))
                    allMonthsInNumbers[i] = "10";
                if (c[i].Contains("November"))
                    allMonthsInNumbers[i] = "11";
                if (c[i].Contains("December"))
                    allMonthsInNumbers[i] = "12";
            }
        }


        //This method changes numbers to months
        public static void NumbersToMonths(string[] c, string[] o)
        {
            for (int i = 0; i < allMonthsInNumbers.Length; i++)
            {
                if (c[i].Contains("01"))
                    o[i] = "January";
                if (c[i].Contains("02"))
                    o[i] = "February";
                if (c[i].Contains("03"))
                    o[i] = "March";
                if (c[i].Contains("04"))
                    o[i] = "April";
                if (c[i].Contains("05"))
                    o[i] = "May";
                if (c[i].Contains("06"))
                    o[i] = "June";
                if (c[i].Contains("07"))
                    o[i] = "July";
                if (c[i].Contains("08"))
                    o[i] = "August";
                if (c[i].Contains("09"))
                    o[i] = "September";
                if (c[i].Contains("10"))
                    o[i] = "October";
                if (c[i].Contains ("11"))
                    o[i] = "November";
                if (c[i].Contains("12"))
                    o[i] = "December";
            }
        }


        //This method adds "0" to the beginning of the respective string to make all elements of the chosen string array the same length
        //Having each element the same length without changing the actual value overcomes the issue of 'natural order sorting' when using the .CompareTo function
        public static string[] modified = new string[allDepths.Length];
        public static void MakeStringSameLength(string[] c, int pad)
        {
            for (int i = 0; i < c.Length; i++)
            {
                if(c[i].Length != pad) /* The paramater 'pad' will be used to decided how many 0's will be added to the left of the string to make all elements the same length' */
                {
                    //PadLeft method adds chosen char to the left of the string until length 'pad' is achieved
                    modified[i] = c[i].PadLeft(pad, '0');
                }
                else
                {
                    //If the selected element is already length 'pad' it is just added to the modified array
                    modified[i] = c[i];
                }
            }
        }


        //This method removes whitespace from the input string
        public static void RemoveStringWhiteSpace(string[] c)
        {
            for(int i = 0; i < c.Length; i ++)
            {
                Regex.Replace(c[i], @"\s+", "");
            }
        }
        
    }
}
