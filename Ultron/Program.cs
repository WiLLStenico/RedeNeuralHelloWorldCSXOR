using System;

namespace Ultron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] input = { 2, 8 };
            //new RedeNeural(2,2,1).FeedForward(input);

            var RN = new RedeNeural(2, 3, 1);//.Train(input, input);

            int[][] inputs = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { 0, 0 }
            };   

             int[][] outputs = new int[][]
            {
                new int[] { 0 },
                new int[] { 1 },
                new int[] { 1 },
                new int[] { 0 }
            };            
            

            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {

                var index = random.Next(0, 3);

                RN.Train(inputs[index], outputs[index]);

            }

            RN.predict(inputs[0]);



        }
    }
}
