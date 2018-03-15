using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seismic_Data_Analysis
{
    //This class will hold variables and methods associated with the analysis of the data
    class DataAnalysis
    {
        // -------------------- ¬¬SORTING ALGORITHMS¬¬ -------------------- //


        // ----- INSERTION SORT ----- //     
        public static void InsertionSort(string[] data, string[][] allData, ref int count)
        {
            // pre: 0 <= n <= data.length
            // post: values in data[0 … n-1] are in ascending order

            //Operation count starts at 0
            count = 0;

            int numSorted = 1; // number of values in place
            int index; // general index

            while (numSorted < data.Length)
            {
                // take the first unsorted value
                string temp = data[numSorted];

                // A tempArray is made to store the unsorted values in each respective column
                string[] tempArray = new string[allData.Length];
                //Then a for loop assigns each first unsorted value into the tempArray
                for (int i = 0; i < allData.Length; i++)
                {
                    tempArray[i] = allData[i][numSorted];
                }
                // … and insert it among the sorted
                // … and insert it among the sorted
                for (index = numSorted; index > 0; index--)
                {
                    if (temp.CompareTo(data[index - 1]) < 0) /* Method 'CompareTo' is used for comparison - if the outcome is less than 0, This instance precedes other in the sort order */
                    {
                        //Swap selected content
                        data[index] = data[index - 1];

                        //Operation count increment
                        count++;

                        //Swap respective content
                        //For loop iterates through each array and swaps the appropriate elements
                        for(int i = 0; i < allData.Length; i++)
                        {
                            allData[i][index] = allData[i][index - 1];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                // reinsert value
                data[index] = temp;
                // reinsert values stored in tempArray back into the data array
                for (int i = 0; i < allData.Length; i++)
                    allData[i][index] = tempArray[i];
                numSorted++;
            }
        }


        // ----- BUBBLE SORT ----- //
        public static void BubbleSort(string[][] allData, int length, int column, ref int count)
        {
            string[] reposArray = new string[allData.Length];
            string repos;

            //Operation count starts at 0
            count = 0;

            // i determines the number of steps for sorting 
            for (int i = 0; i < length - 1; i++)
            {

                // j determines the number of comparisons in each step and the indices to be 
                // studied for comparison 
                for (int j = 0; j < length - (i + 1); j++)
                {
                    if (allData[column][j + 1].CompareTo(allData[column][j]) < 0)
                    {
                        //Swap of selected content
                        repos = allData[column][j];
                        allData[column][j] = allData[column][j + 1];
                        allData[column][j + 1] = repos;

                        //Operation count is incremented
                        count++;

                        for (int x = 0; x < reposArray.Length; x++)
                        {
                            if (x == column)
                                continue;
                            //Swap of respective content
                            reposArray[x] = allData[x][j];
                            allData[x][j] = allData[x][j + 1];
                            allData[x][j + 1] = reposArray[x];

                        }
                    }
                }
            }
        }


        // ----- HEAP SORT ----- //
        private static int heapSize;
        private static void BuildHeap(string[] data, string[][] allData, int column, ref int count)
        {
            heapSize = allData[column].Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(data, allData, i, column, ref count);
            }
        }
        private static void Swap(string[] data, string[][] allData, int x, int y, int column, ref int count) //function to swap elements
        {
            //Swap the selected content
            string temp = data[x];
            data[x] = data[y];
            data[y] = temp;

            //Operation Counter Increment
            count++;

            // A tempArray is made to store the unsorted values in each respective column
            string[] tempArray = new string[allData.Length];
            for(int i = 0; i < allData.Length; i++)
            {
                if (i == column)
                    continue;
                tempArray[i] = allData[i][x];
                allData[i][x] = allData[i][y];
                allData[i][y] = tempArray[i];

            }
        }
        private static void Heapify(string[] data, string[][] allData, int index, int column, ref int count)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;
            if (left <= heapSize && allData[column][index].CompareTo(allData[column][left]) < 0) /* Method 'CompareTo' is used for comparison - if the outcome is less than 0, This instance precedes other in the sort order */
            {
                largest = left;
            }

            if (right <= heapSize && allData[column][largest].CompareTo(allData[column][right]) < 0) /* Method 'CompareTo' is used for comparison - if the outcome is less than 0, This instance precedes other in the sort order */
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(data, allData, index, largest, column, ref count);
                Heapify(data, allData, largest, column, ref count);
            }
        }
        public static void HeapSort(string[] data, string[][] allData, int column, ref int count)
        {
            //Operation count starts at 0
            count = 0;

            BuildHeap(data, allData, column, ref count);
            for (int i = allData[column].Length - 1; i >= 0; i--)
            {
                Swap(data, allData, 0, i, column, ref count);
                heapSize--;
                Heapify(data, allData, 0, column, ref count);
            }
        }


        // -------------------- ¬¬ASCENDING AND DESCENDING ORDER¬¬ -------------------- //


        // ----- DESCENDING ORDER ----- //  
        public static void DescendingOrder(string[][] data)
        {
            Console.WriteLine("\n");
            //This for loop increments along the rows
            for (int i = 0; i < data[0].Length; i++) 
            {
                //This for loop increments along the columns
                for (int j = 0; j < data.Length; j++)
                {
                    Console.Write("{0}, ",data[j][i]);
                }
                Console.WriteLine("\n");
            }
        }


        // ----- ASCENDING ORDER ----- // 
        public static void AscendingOrder(string[][] data)
        {
            //This for loop increments along the rows
            for (int i = data[0].Length - 1; i > 0; i--)
            {
                //This for loop increments along the columns
                for (int j = 0; j < data.Length; j++)
                {
                    Console.Write("{0}, ", data[j][i]);
                }
                Console.WriteLine("\n");
            }
        }


        // -------------------- ¬¬SEARCHING ALGORITHMS¬¬ -------------------- //


        // ----- Linear Search ----- // 
        public static void LinearSearch(string[] data, string[][] allData, string key, int contentSelection, ref int count)
        {
            //Operation counter
            count = 0;

            //If statement checks whether Days has been selected - if so, Key is padded left to 2 so that searching the days array works correctly
            if (contentSelection == 3)
            {
                key = key.PadLeft(2, '0');
            }

            //If statement checks whether depth has been selected - if so, Key is padded left to 7 so that searching the days array works correctly
            if (contentSelection == 8)
            {
                key = key.PadLeft(7, '0');
            }

            //If statement checks whether month has been selection
            //The key is changed to a number and then all numbers are converted towards the end of the method
            if (contentSelection == 2)
            {
                if (key == "JANUARY")
                    key = "01";
                if (key == "FEBRUARY")
                    key = "02";
                if (key == "MARCH")
                    key = "03";
                if (key == "APRIL")
                    key = "04";
                if (key == "MAY")
                    key = "05";
                if (key == "JUNE")
                    key = "06";
                if (key == "JULY")
                    key = "07";
                if (key == "AUGUST")
                    key = "08";
                if (key == "SEPTEMBER")
                    key = "09";
                if (key == "OCTOBER")
                    key = "10";
                if (key == "NOVEMBER")
                    key = "11";
                if (key == "DECEMBER")
                    key = "12";
            }

            //Converting elements to Upper case to avoid error because of case
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].ToUpper();
            }

            //For loop increments through the length of the array 
            for (int elementNum = 0; elementNum <= data.Length; elementNum++)
            {
                //Key was not found
                //Once elementNum reaches the end of the array and hasn't found key it breaks out of for loop
                if(elementNum == data.Length)
                {
                    Console.WriteLine("Key was not found");
                    break;
                }

                //Operation counter
                count++;

                if (data[elementNum] == key)
                {
                    //mid is assigned to each bound as a starting point
                    //No lowerBound loop is needed as linear search will always find the lowestbound first
                    int lowerBound = elementNum, upperBound = elementNum;


                    //UpperBound for loop
                    //this for loop increments up data until key is no longer found
                    for (int i = elementNum + 1; i < data.Length; i++)
                    {
                        //Operation counter
                        count++;

                        if (data[i] == key)
                            upperBound = i; /* once the bound is found it is assigned to a variable */
                        else
                            break;
                    }

                    //If statement checks whether 'month' option was selected
                    if (contentSelection == 2)
                    {
                        //If 'month' is selected The sorted numbers are changed back into their respective months using method in the 'SeismicData' class
                        SeismicData.NumbersToMonths(data, allData[1]);

                    }

                    //Once the upper and lower bounds are found all the data is printed
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        for (int x = 0; x < allData.Length; x++)
                        {
                            Console.Write("{0}, ", allData[x][i]);
                        }
                        Console.WriteLine("\n");
                    }

                    //Once printing has finished break out of if statement
                    break;
                }
            }
        }


        // ----- Binary Search Recursive ----- // 
        public static void BinarySearchRecursive(string[] data, string[][] allData, string key, int min, int max, int contentSelection, ref int count)
        {
            //If statement checks whether Days has been selected - if so, Key is padded left to 2 so that searching the days array works correctly
            if (contentSelection == 3)
            {
                key = key.PadLeft(2, '0');
            }

            //If statement checks whether depth has been selected - if so, Key is padded left to 7 so that searching the days array works correctly
            if (contentSelection == 8)
            {
                key = key.PadLeft(7, '0');
            }

            //If statement checks whether month has been selection
            //The key is changed to a number and then all numbers are converted towards the end of the method
            if (contentSelection == 2)
            {
                if (key == "JANUARY")
                    key = "01";
                if (key == "FEBRUARY")
                    key = "02";
                if (key == "MARCH")
                    key = "03";
                if (key == "APRIL")
                    key = "04";
                if (key == "MAY")
                    key = "05";
                if (key == "JUNE")
                    key = "06";
                if (key == "JULY")
                    key = "07";
                if (key == "AUGUST")
                    key = "08";
                if (key == "SEPTEMBER")
                    key = "09";
                if (key == "OCTOBER")
                    key = "10";
                if (key == "NOVEMBER")
                    key = "11";
                if (key == "DECEMBER")
                    key = "12";
            }

            //Converting elements to Upper case to avoid error because of case
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].ToUpper();
            }

            if (min > max) /* if min > max the value is not present in the array */
            {
                Console.WriteLine("Error: this value does not exist");
            }
            else
            {
                int mid = (min + max) / 2;

                //operation increment
                count++;

                if (key == data[mid])
                {
                    //mid is assigned to each bound as a starting point
                    int lowerBound = mid, upperBound = mid;

                    //LowerBound for loop
                    //this for loop decrements down data until key is no longer found
                    for (int i = mid - 1; i >= 0; i-- )
                    {
                        //operation increment
                        count++;
                        if (data[i] == key)
                            lowerBound = i; /* once the bound is found it is assigned to a variable */
                        else
                            break;
                    }

                    //UpperBound for loop
                    //this for loop increments up data until key is no longer found
                    for (int i = mid + 1; i < data.Length; i++)
                    {
                        //operation increment
                        count++;
                        if (data[i] == key) 
                            upperBound = i; /* once the bound is found it is assigned to a variable */
                        else
                            break;
                    }

                    //If statement checks whether 'month' option was selected
                    if (contentSelection == 2)
                    {
                        //If 'month' is selected The sorted numbers are changed back into their respective months using method in the 'SeismicData' class
                        SeismicData.NumbersToMonths(data, allData[1]);

                    }

                    //Once the upper and lower bounds are found all the data is printed
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        for(int x = 0; x < allData.Length; x++)
                        {
                            Console.Write("{0}, ", allData[x][i]);
                        }
                        Console.WriteLine("\n");
                    }

                }
                else if (key.CompareTo(data[mid]) < 0)
                {
                    BinarySearchRecursive(data, allData, key, min, mid - 1, contentSelection, ref count);
                }
                else
                {
                    BinarySearchRecursive(data, allData, key, mid + 1, max, contentSelection, ref count);
                }
            }
        }


        // -------------------- ¬¬MINIMUM AND MAXIMUM¬¬ -------------------- //


        // ----- MIN\MAX ----- // 
        public static void FindMinMax(string[] data, string[][] allData, int contentSelection)
        {
            //String min and max both are assigned the first value in data
            string minStringValue = data[0];
            string maxStringValue = data[0];

            //Int variables store the element number of min and max
            int minStringElement = 0;
            int maxStringElement = 0;

            //For statement runs through data - does a check - then assigns if check is true
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CompareTo(minStringValue) < 0)
                    minStringElement = i;
                if (data[i].CompareTo(maxStringValue) > 0)
                    maxStringElement = i;
            }

            //If statement checks whether 'month' option was selected
            if (contentSelection == 2)
            {
                //If 'month' is selected The sorted numbers are changed back into their respective months using method in the 'SeismicData' class
                SeismicData.NumbersToMonths(data, allData[1]);

            }

            //Once the min and max values are found a for loop prints out the entries

            //For loop for min value
            Console.WriteLine("\n");
            Console.Write("Minimum Value: ");
            for (int i = 0; i < allData.Length; i++)
            {
                Console.Write("{0}, ", allData[i][minStringElement]);
            }

            //For loop for max value
            Console.WriteLine("\n");
            Console.Write("Maximum Value: ");
            for (int i = 0; i < allData.Length; i++)
            {
                Console.Write("{0}, ", allData[i][maxStringElement]);
            }
        }

    }

}
