using System;
namespace MyApplication
{
    class KeyGenerator
    {
        public void RandomKey(int min, int max)
        {
            Random ran = new Random();
            int a = ran.Next(min,max);
            Console.WriteLine(a);
        }


    };

    class MyApplication
    {

        static void Main(string[] args)
        {
            //int min = 1, max = 1;
            var key = new KeyGenerator();
            int size = int.Parse(Console.ReadLine());
            switch (size)
            {
                case 1:
                    key.RandomKey(1, 10);
                    break;
                case 2:
                    key.RandomKey(10, 100);
                    break;
                case 3:
                    key.RandomKey(100, 1000);
                    break;
                case 4:
                    key.RandomKey(1000, 9999);
                    break;
                case 5:
                    key.RandomKey(10000, 99999);
                    break;
                case 6:
                    key.RandomKey(1000000, 999999);
                    break;
                case 7:
                    key.RandomKey(1000000, 9999999);
                    break;
                case 8:
                    key.RandomKey(10000000, 99999999);
                    break;
                case 9:
                    key.RandomKey(10000000, 999999999);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
                    

            }


        }
    };

}
