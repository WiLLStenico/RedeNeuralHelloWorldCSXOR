using System;

namespace Ultron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //double[] input = { 2, 8 };
            //new RedeNeural(2,2,1).FeedForward(input);

            var RN = new RedeNeural(2, 2, 1);//.Train(input, input);

            //XOR Inputs
            double[][] inputs = new double[][]
            {
                new double[] { 1, 1 },
                new double[] { 1, 0 },
                new double[] { 0, 1 },
                new double[] { 0, 0 }
            };

            double[][] outputs = new double[][]
           {
                new double[] { 0 },
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 0 }
           };


            var random = new Random();
            bool train = true;
            while (train)
            {
                for (int i = 0; i < 100000; i++)
                {

                    var index = random.Next(0, 4);
                    //if(index!=2 && index != 1)
//                    Console.WriteLine("############################################################################### Index " + index + " ###############################################################");
                    RN.Train(inputs[index], outputs[index]);
  //                  RN.Train(inputs[3], outputs[3]);
                    //RN.Train(inputs[0], outputs[0]);
                    //RN.Train(inputs[3], outputs[3]);

                }

                var prediction00 = RN.predict(inputs[3]); //0,0 -> 0
                var prediction10 = RN.predict(inputs[1]); //1,0 -> 1
                if (prediction00[0, 0] < 0.04 && prediction10[0, 0] > 0.98)
                {
                    train = false;
                    Console.WriteLine("Terminou");
                }

                Console.WriteLine("QUASE: " + prediction00[0, 0] + " <0.04 E 0.98 <" + prediction10[0, 0]);

                for (int i = 0; i < 4; i++)
                {
                    var prediction = RN.predict(inputs[i]);
                    Console.WriteLine("Index: " + i + " Inputs " + inputs[i][0] + " , " + inputs[i][1] + " Expected " + outputs[i][0] + " Result : " + prediction[0, 0]);
                }

            }

            Console.WriteLine("############################################################################");

            for (int i = 0; i < 4; i++)
            {
                var prediction = RN.predict(inputs[i]);
                //Console.WriteLine("Index: " + i + " Result : " + prediction[0, 0]);
                Console.WriteLine("Index: " + i + " Inputs " + inputs[i][0] + " , " + inputs[i][1] + " Expected " + outputs[i][0] + " Result : " + prediction[0, 0]);
            }

        }
    }
}
