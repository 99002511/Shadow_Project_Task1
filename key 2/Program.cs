using System;
using System.Collections;
using System.IO;


namespace MyApplication
{
    interface IKeyGenerator
    {
        public int RandomKey(int min, int max);
    }

    interface Idigits_twister
    {
        public int rand_digits(int size);
    }

    interface Irand_reverse
    {
        public ArrayList reverse_digiter(int inputnum);
    }

    interface Icomparator_value
    {
        public ArrayList comparors(ArrayList dval, ArrayList dresult, int switcher);
    }
    interface ICounts_Digits
    {
        public void Digi_Counter(ArrayList digis);
    }

    class KeyGenerator : IKeyGenerator
    {
        /// <summary>
        /// Random Key  Generator
        /// it gets min and max value as parameter and return a Random number
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>

        public int RandomKey(int min, int max)
        {
            Random ran = new Random();
            int a = ran.Next(min, max);
            return a;
        }


    };
    
   public static class Globals
    {
        
        public static int flag_g = 0;
        public static int flag1 = 0;
        public static int flag2 = 0;
    }

    class digits_twister : Idigits_twister
    {
        /// <summary>
        /// Random Digits
        /// based on the size of user input it will generate random number
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public int rand_digits(int size)
        {
            int r_d = 0;
            var key = new KeyGenerator();
            switch (size)
            {
                case 1:
                    r_d = key.RandomKey(1, 10);
                    break;
                case 2:
                    r_d = key.RandomKey(10, 100);
                    break;
                case 3:
                    r_d = key.RandomKey(100, 1000);
                    break;
                case 4:
                    r_d = key.RandomKey(1000, 9999);
                    break;
                case 5:
                    r_d = key.RandomKey(10000, 99999);
                    break;
                case 6:
                    r_d = key.RandomKey(100000, 999999);
                    break;
                case 7:
                    r_d = key.RandomKey(1000000, 9999999);
                    break;
                case 8:
                    r_d = key.RandomKey(10000000, 99999999);
                    break;
                case 9:
                    r_d = key.RandomKey(10000000, 999999999);
                    break;
                default:
                    Console.WriteLine("Maximum 9 size is allowed");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                    break;


            }

            return r_d;

        }
    };

    class rand_reverse : Irand_reverse
    {
        /// <summary>
        /// This function will parse the interger data into array list. the data will be in reverse manner. 
        /// </summary>
        /// <param name="inputnum"></param>
        /// <returns></returns>
        public ArrayList reverse_digiter(int inputnum)
        {
            int i = 0, m;
            ArrayList reverse_array = new ArrayList();
            while (inputnum > 0)
            {
                m = inputnum % 10;
                reverse_array.Add(m);
                inputnum = inputnum / 10;
                i++;
            }
            return reverse_array;
        }
    };
    class comparator_value : Icomparator_value
    {
        
        /// <summary>
        /// DigitComparor:
        /// this function will compare the digits whether they are same are not.
        /// </summary>
        /// <param name="dval"></param>
        /// <param name="dresult"></param>
        /// <param name="switcher"></param>
        /// <returns></returns>
        public ArrayList comparors(ArrayList dval, ArrayList dresult, int switcher)
        {
            int dval_len = dval.Count;
            int dresult_len = dresult.Count;
            ArrayList array_temp = new ArrayList();
            switch (switcher)
            {
                case 1:
                    int j = dval_len - 1;
                    for (int i = dresult_len - 1; i >= dresult_len - dval_len; i--)
                    {
                        array_temp.Add(dresult[i]);

                    }

                    int count = 0;
                    for (int i = 0; i < dval_len; i++)
                    {
                        if (Object.Equals(array_temp[i], dval[j]))
                        {
                            count++;
                            if (count == dval_len)
                            {
                                Globals.flag1=1;
                                return array_temp;
                                
                            }
                        }
                        j--;
                    }

                    break;
                case 2:
                    for (int i = 0; i < dval_len; i++)
                    {
                        array_temp.Add(dresult[i]);

                    }

                    int counts = 0;
                    for (int i = 0; i < dval_len; i++)
                    {
                        if (Object.Equals(array_temp[i], dval[i]))
                        {
                            counts++;
                            if (counts == dval_len)
                            {
                                Globals.flag2=1;
                                return array_temp;
                            }
                        }
                    }

                    break;
            }
            return array_temp;
        }
    };
    class Counts_Digits : ICounts_Digits
    {
        /// <summary>
        /// DigitConter:
        /// this function will count the digits.if it is more than 3 digits program will show an error message and exit.
        /// </summary>
        /// <param name="digis"></param>
        public void Digi_Counter(ArrayList digis)
        {
            if(digis.Count>3)
            {
                Console.WriteLine("Maximum three digits are accepted");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
        }
        public void Digi_special(string temp_data)
        {
            uint i;
            if(uint.TryParse(temp_data, out i)==false)
            {
                Console.WriteLine("Invalid File Input");
                System.Environment.Exit(0);
            }
        }
    }
    class Emptychecker
    {
        public void digitsEmpty(string s_digit)
        {
            if(string.IsNullOrEmpty(s_digit)==true)
            {
                Console.WriteLine("Empty File");
                System.Environment.Exit(0);
            }
        }
    }
    /// <summary>
    /// This proram will generate a random number with given number of size.and with given conditions.
    /// </summary>
    class MyApplication
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\CTEA\\Documents\\inputs.txt");//Reading input from the file
            var empty_digi_check = new Emptychecker();
            var digi_check = new Counts_Digits();//instance of Counts_Digit
            var key = new KeyGenerator();//instance of KeyGenerator()
            Console.WriteLine("The Size is: ");
            string str = sr.ReadLine();//Reading first line
            empty_digi_check.digitsEmpty(str);
            int sizes = int.Parse(str);
            Console.WriteLine(sizes);
            var digi_r = new digits_twister();//instance of digits_twister
            int ran_first = digi_r.rand_digits(sizes);//generating random number
            
            //Reading the second line for "digit should not start with"

                ArrayList array_one_rever = new ArrayList();
                var digi_one_rever = new rand_reverse();
                Console.WriteLine("Digits 1 shouldn't start with: ");
                str = sr.ReadLine();
                empty_digi_check.digitsEmpty(str);
                digi_check.Digi_special(str);
                int digi_1 = int.Parse(str);
                Console.WriteLine(digi_1);
                array_one_rever = digi_one_rever.reverse_digiter(digi_1);//converting interger to ArrayList
                digi_check.Digi_Counter(array_one_rever);

            //Reading the second line for "digit should not end with"
                var digi_two_rever = new rand_reverse();
                ArrayList array_two_rever = new ArrayList();
                Console.WriteLine("Digits 2 shouldn't end with: ");
                str = sr.ReadLine();
                empty_digi_check.digitsEmpty(str);
                digi_check.Digi_special(str);
                int digi_2 = int.Parse(str);
                Console.WriteLine(digi_2);
                array_two_rever = digi_two_rever.reverse_digiter(digi_2);//converting interger to ArrayList
                digi_check.Digi_Counter(array_two_rever);

            //comparing generated random number with the digits given by user.
            while (Globals.flag_g == 0)
            {

                var digi_rever = new rand_reverse();
                ArrayList array_reverse = new ArrayList();
                array_reverse = digi_rever.reverse_digiter(ran_first);
               // Console.WriteLine("size" + array_reverse.Count);

                var compar_oper = new comparator_value();
                var compar_oper1 = new comparator_value();

                ArrayList array_compareval = new ArrayList();
                array_compareval = compar_oper.comparors(array_one_rever, array_reverse, 1);//comparing digit 1 with the generated random number.
                ArrayList array_compareval1 = compar_oper1.comparors(array_two_rever, array_reverse, 2);//comparing digit 2 with the generated random number.

                if (Globals.flag1 == 1 )//checking if digit1 matches with generated random number 
                {
                    ran_first = digi_r.rand_digits(sizes);
                    Globals.flag1 = 0;
                }
                else if(Globals.flag2 == 1)//checking if digit2 matches with generated random number 
                {
                    ran_first = digi_r.rand_digits(sizes);
                    Globals.flag2 = 0;
                }
                else//exiting the loop
                {
                    Globals.flag_g = 1;
                }

            }
            Console.WriteLine("finished key generation: " + ran_first);//Printig the final genrated random number.
        }
    };

}
