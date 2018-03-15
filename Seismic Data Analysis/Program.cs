using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seismic_Data_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t~~~~~~ Seismic Data Analysis-o-matic ~~~~~~");
            Console.WriteLine("\n\t\t\t\t\tWelcome!");
            Console.WriteLine("\t........");
            Console.WriteLine("\t\t................");
            Console.WriteLine("\t\t\t\t........................");
            Console.WriteLine("\t\t\t\t\t\t\t................................");
            Console.WriteLine("\n\t\tArea (1) and Area (2) have been merged into a jagged array\n");

            //Run the menu method
            Menu();
            Console.ReadKey();

            //Ending the program
            Console.WriteLine("\n\n\nThis application will now close...");
            Console.WriteLine("Press any key to close the window");
            Console.ReadKey();
        }

        //Menu method
        public static void Menu()
        {
            //Variables for selection (need to be outside while loops)
            int contentSelection = 0, analysisSelection = 0, sortingSelection = 0, searchingSelection = 0;
            string orderSelection = "";

            //Key variable used in searching
            string key = "";

            //Bools for while loop menus
            bool menuFlag1 = true;
            bool menuFlag2 = true;
            bool menuFlag3 = true;
            bool menuFlag4 = true;

            //Count variable for number of operations (space-time complexity)
            int count = 0;

            //While menu loop
            while (menuFlag1)
            {
                try
                {
                    //Array analysis selection menu
                    Console.WriteLine("\nPlease select the content to be analysed:");
                    Console.WriteLine("1. Year");
                    Console.WriteLine("2. Month");
                    Console.WriteLine("3. Day");
                    Console.WriteLine("4. Time");
                    Console.WriteLine("5. Magnitude");
                    Console.WriteLine("6. Latitude");
                    Console.WriteLine("7. Longitude");
                    Console.WriteLine("8. Depth");
                    Console.WriteLine("9. Region");
                    Console.WriteLine("10. IRIS_ID");
                    Console.WriteLine("11. Timestamp");
                    Console.Write("Selection: ");
                    contentSelection = Convert.ToInt32(Console.ReadLine());

                    //input validation to make sure selection is between 1 and 11
                    if (contentSelection < 1 || contentSelection > 11)
                    {
                        Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                        menuFlag1 = true;
                        continue;
                    }


                    //Analysis selection - How the user wants to analyse the content
                    Console.WriteLine("\nHow would you like to analyse the content?");
                    Console.WriteLine("1. Sort");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Minimum and Maximum Values");
                    Console.Write("Selection: ");
                    analysisSelection = Convert.ToInt32(Console.ReadLine());

                    //input validation to make sure selection is between 1 and 3
                    if (analysisSelection < 1 || analysisSelection > 3)
                    {
                        Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                        menuFlag1 = true;
                        continue;
                    }

                    //stopping the loop
                    menuFlag1 = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nERROR: an exception was caught\nException: {0}", ex.Message);
                    menuFlag1 = true;
                }
            }
            

            //selectedContentArray is used so that original variables are not altered - This array stores the content the user wants to analyse 
            string[] selectedContentArray = new string[1200];

            //This switch calls a method that selects the content the user wants to analyse from the 2D array in 'SeismicData' class
            //The content is then assigned to the temporary array 'selectedContentArray'
            switch (contentSelection)
            {
                case 1:
                    Console.WriteLine("\nYou have selected \"year\"");
                    selectedContentArray = SeismicData.allYears;
                    break;
                case 2:
                    Console.WriteLine("\nYou have selected \"month\"");
                    //Chosen content is cloned to another array so that it can be altered - the modified array is then cloned back into the appropriate column in the 2D array
                    selectedContentArray = SeismicData.allMonths;
                    SeismicData.RemoveStringWhiteSpace(selectedContentArray);
                    SeismicData.MonthsToNumbers(selectedContentArray); /* This method coverts the months to their respective/associated numbers */
                    selectedContentArray = SeismicData.allMonthsInNumbers; /* Chosen content is cloned to another array so that the original content is not altered */
                    SeismicData.allSeismicData[1] = selectedContentArray;
                    break;
                case 3:
                    Console.WriteLine("\nYou have selected \"day\"");
                    // Chosen content is cloned to another array so that it can be altered - the modified array is then cloned back into the appropriate column in the 2D array
                    selectedContentArray = SeismicData.allDays;
                    SeismicData.MakeStringSameLength(selectedContentArray, 2); /* '2' is used because the max length of elements in 'alldays' is 2 */
                    selectedContentArray = SeismicData.modified;
                    SeismicData.allSeismicData[2] = selectedContentArray;
                    break;
                case 4:
                    Console.WriteLine("\nYou have selected \"time\"");
                    selectedContentArray = SeismicData.allTimes;
                    break;
                case 5:
                    Console.WriteLine("\nYou have selected \"magnitude\"");
                    selectedContentArray = SeismicData.allMagnitudes;
                    break;
                case 6:
                    Console.WriteLine("\nYou have selected \"latitude\"");
                    selectedContentArray = SeismicData.allLatitudes;
                    break;
                case 7:
                    Console.WriteLine("\nYou have selected \"longitude\"");
                    selectedContentArray = SeismicData.allLongitudes;
                    break;
                case 8:
                    Console.WriteLine("\nYou have selected \"depth\"");
                    // Chosen content is cloned to another array so that it can be altered - the modified array is then cloned back into the appropriate column in the 2D array
                    selectedContentArray = SeismicData.allDepths;
                    SeismicData.MakeStringSameLength(selectedContentArray, 7); /* '7' is used because the max length of elements in 'alldepths' is 7 */
                    selectedContentArray = SeismicData.modified; /* 'SeismicData.modified' holds the modified array used in 'MakeStringSameLength' */
                    SeismicData.allSeismicData[7] = selectedContentArray;
                    break;
                case 9:
                    Console.WriteLine("\nYou have selected \"region\"");
                    selectedContentArray = SeismicData.allRegions;
                    break;
                case 10:
                    Console.WriteLine("\nYou have selected \"iris_id\"");
                    selectedContentArray = SeismicData.allIRIS;
                    break;
                case 11:
                    Console.WriteLine("\nYou have selected \"timestamp\"");
                    selectedContentArray = SeismicData.allTimestamps;
                    break;
                default:
                    Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                    break;
            }

        
            //SORTING - Individual Array 
            //The sorting menu first allows the user to select the algorithm they want to sort with, then they individual array they want to sort
            if (analysisSelection == 1)
            {
                //While menu loop
                while(menuFlag2)
                {
                    try
                    {
                        //Sorting Slection
                        Console.WriteLine("\nPlease select your chosen sorting algorithm: ");
                        Console.WriteLine("1. Insertion Sort");
                        Console.WriteLine("2. Bubble Sort");
                        Console.WriteLine("3. Heap Sort");
                        Console.Write("Selection: ");
                        sortingSelection = Convert.ToInt32(Console.ReadLine());

                        //input validation to make sure selection is between 1 and 3
                        if (sortingSelection < 1 || sortingSelection > 3)
                        {
                            Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                            menuFlag2 = true;
                            continue;
                        }

                        //stopping the loop
                        menuFlag2 = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nERROR: an exception was caught\nException: {0}", ex.Message);
                        menuFlag2 = true;
                    }
                }




                //This switch statement calls the method containing the algorithm the user selected in the menu above
                switch (sortingSelection)
                {
                    case 1:
                        Console.WriteLine("\nYou have selected Insertion Sort");
                        DataAnalysis.InsertionSort(selectedContentArray, SeismicData.allSeismicData, ref count);
                        Console.WriteLine("\nWorst Case Time Complexity: O(N^2)\tSpace Complexity O(1)\tOperation Counter: {0}", count);
                        break;
                    case 2:
                        Console.WriteLine("\nYou have selected Bubble Sort");
                        DataAnalysis.BubbleSort(SeismicData.allSeismicData, selectedContentArray.Length, contentSelection - 1, ref count);
                        Console.WriteLine("\nWorst Case Time Complexity: O(N^2)\tSpace Complexity O(1)\tOperation Counter: {0}", count);
                        break;
                    case 3:
                        Console.WriteLine("\nYou have selected Heap Sort");
                        DataAnalysis.HeapSort(selectedContentArray, SeismicData.allSeismicData, contentSelection - 1, ref count);
                        Console.WriteLine("\nWorst Case Time Complexity: O(Nlogn)\tSpace Complexity O(1)\tOperation Counter: {0}", count);
                        break;
                    default:
                        Console.WriteLine("\nYou have entered an incorrect choice, please try again...\n");
                        break;
                }
                //If statement checks whether 'month' option was selected
                if (contentSelection == 2)
                {
                    //If 'month' is selected The sorted numbers are changed back into their respective months using method in the 'SeismicData' class
                    SeismicData.NumbersToMonths(selectedContentArray, SeismicData.allSeismicData[1]);
                    
                }

                //Ascending or Descending order selection
                while(menuFlag3)
                {
                    try
                    {
                        Console.WriteLine("\nWould you like to display the sorted content in ascending(a) or descending(d) order?");
                        Console.Write("Selection: ");
                        orderSelection = Console.ReadLine().ToLower();

                        //Input validation to make sure only valid input is a or d
                        if (orderSelection != "a" && orderSelection != "d")
                        {
                            Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                            menuFlag3 = true;
                            continue;
                        }

                        //stopping the loop
                        menuFlag3 = false;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("\nERROR: an exception was caught\nException: {0}", ex.Message);
                        menuFlag3= true;
                    }
                }

                if (orderSelection == "a" || orderSelection == "ascending")
                    DataAnalysis.AscendingOrder(SeismicData.allSeismicData);
                else if (orderSelection == "d" || orderSelection == "descending")
                    DataAnalysis.DescendingOrder(SeismicData.allSeismicData);

            }


            else if (analysisSelection == 2)
            {
                while(menuFlag4)
                {
                    try
                    {
                        //Searching algorithm menu
                        Console.WriteLine("\nWhat searching algorithm would you like to use?");
                        Console.WriteLine("1. Linear Search");
                        Console.WriteLine("2. Binary Search");
                        Console.Write("Selection: ");
                        searchingSelection = Convert.ToInt32(Console.ReadLine());

                        //Input validation make sure that the only int able to select is 1
                        if(searchingSelection != 1 && searchingSelection != 2)
                        {
                            Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                            menuFlag4 = true;
                            continue;
                        }

                        //Key input
                        Console.WriteLine("\nPlease enter the key");
                        Console.Write("Selection: ");
                        key = (Console.ReadLine()).ToUpper();

                        //stopping the loop
                        menuFlag4 = false;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("\nERROR: an exception was caught\nException: {0}", ex.Message);
                        menuFlag4 = true;
                    }
                }


                switch (searchingSelection)
                {
                    case 1:
                        Console.WriteLine("\nYou have selected Linear Search");
                        DataAnalysis.InsertionSort(selectedContentArray, SeismicData.allSeismicData, ref count); /* The array needs to be sorted before the Binary Search can be ran */
                        Console.WriteLine("\nWorst Case Time Complexity: O(N)\tOperation Counter: {0}\n", count);
                        DataAnalysis.LinearSearch(selectedContentArray, SeismicData.allSeismicData, key, contentSelection, ref count);
                        break;
                    case 2:
                        Console.WriteLine("\nYou have selected Binary Search");
                        DataAnalysis.InsertionSort(selectedContentArray, SeismicData.allSeismicData, ref count); /* The array needs to be sorted before the Binary Search can be ran */
                        Console.WriteLine("\nWorst Case Time Complexity: O(Log(n))\tOperation Counter: {0}\n", count);
                        DataAnalysis.BinarySearchRecursive(selectedContentArray, SeismicData.allSeismicData, key, 0, selectedContentArray.Length, contentSelection, ref count);
                        break;
                    default:
                        Console.WriteLine("\nYou have entered an incorrect choice, please try again...");
                        break;
                }
            }
            else if (analysisSelection == 3)
                {
                DataAnalysis.FindMinMax(selectedContentArray, SeismicData.allSeismicData, contentSelection);
                }
            }
        }


    }



