using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search {
    class Program {
        static void Main(string[] args) {
            List<int> list = new List<int>{1,5,0,5,22,66,76,232,57574,32,41241347,5865865,34423,43,534,54,654,7,54,753,5,5345,23,4};
            for (int i = 0; i < list.Count; i++) {
                for (int j = 0; j < list.Count - 1; j++) {
                    if (list[j] > list[j + 1]) {
                        int temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }//bubble sort 
                }
            }
            int cont = 1;
            while (cont == 1) {
                Console.WriteLine("Please input the num ur looking for");

                int Searchvalue = UserEntry(Console.ReadLine());
                BinarySearch(list, Searchvalue);

                Console.WriteLine("Continue? y/n");
                if (Console.ReadLine() == "n")
                    cont = 2;
            }
        }
        public static void BinarySearch(List<int> list, int SearchTerm) {
            if (list.Count == 1 && list[0] == SearchTerm)
                Console.WriteLine($"{list[0]} Was found btw!");
            else if (list.Count == 1) 
                Console.WriteLine($"{SearchTerm} Was not found btw!");
            else if (list.Count % 2 == 0) {
                double Midpoint = (double)(list[(list.Count / 2) - 1 ] + (double)(list[(list.Count / 2)])) / 2;
                if (Midpoint % 1 == 0 && (list.Count == 2) ? (list[0] == list[1]) : (list[(list.Count / 2) + 1] == list[(list.Count / 2)] && Midpoint == SearchTerm))
                    Console.WriteLine($"{Midpoint} Was found btw!");
                else if (SearchTerm > Midpoint)
                    BinarySearch(list.GetRange((list.Count / 2), list.Count / 2), SearchTerm);
                else
                    BinarySearch(list.GetRange(0, list.Count / 2), SearchTerm);
            }
            else {
                int Midpoint = list[(int)(list.Count / 2)];
                if ((int)(Midpoint) == SearchTerm)
                    Console.WriteLine($"{Midpoint} Was found btw!");
                else if (SearchTerm > Midpoint) 
                    BinarySearch(list.GetRange((((list.Count + 1) / 2)), ((list.Count - 1) / 2)), SearchTerm);
                else 
                    BinarySearch(list.GetRange(0, ((list.Count - 1) / 2)), SearchTerm);
            }    
        }

        public static int UserEntry(string Userstring) {
            int num = 0;
            while (string.IsNullOrWhiteSpace(Userstring) || !int.TryParse(Userstring, out num)) {
                Console.WriteLine("Please enter a number.!!.");
                Userstring = Console.ReadLine();
            }
            return num;
        }
    }
}
