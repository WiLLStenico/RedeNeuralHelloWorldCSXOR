using System;

namespace Ultron
{
    public class RedeNeural
    {

        public int i_nodes { get; set; } //input_nodes

        public int h_nodes { get; set; } //hidden_nodes
        public int o_nodes { get; set; } //output_nodes   
        public Matrix bias_ih { get; set; } //bias of input to hidden
        public Matrix bias_ho { get; set; } //bias of hidden to output

        public Matrix weigth_ih { get; set; } //weights of input to hidden
        public Matrix weigth_ho { get; set; } //weights of input to hidden

        public int _learning_rate = 10; // Mudar para 0.1; 10%

        public static double Sigmoid(int x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        //Derivada Sigmoid
        public static double DSigmoid(int x)
        {
            return x * (1 - x);//1 / (1 + Math.Exp(-x));
        }

        public RedeNeural(int i_nodes, int h_nodes, int o_nodes)
        {
            this.i_nodes = i_nodes;
            this.h_nodes = h_nodes;
            this.o_nodes = o_nodes;

            bias_ih = new Matrix(h_nodes, 1);
            bias_ho = new Matrix(o_nodes, 1);

            weigth_ih = new Matrix(h_nodes, i_nodes);
            weigth_ho = new Matrix(o_nodes, h_nodes);

        }

        public void FeedForward(int[] _input)
        {


            //INPUT -> HIDDEN
            var input = Matrix.arrayToMatryx(_input);

            var hidden = Matrix.Multiply(this.weigth_ih.Data, input.Data); //Multiplica Entrada pelos Pesos

            hidden = Matrix.Add(hidden, this.bias_ih.Data);//Adiciona o Bias


            int row = hidden.GetLength(0) - 1;
            int col = hidden.GetLength(1) - 1;

            int[,] result = new int[row, col];


            //Aplica funcao de ativação
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    hidden[i, j] = (int)RedeNeural.Sigmoid(hidden[i, j]);
                }
            }

            //HIDDEN -> OUTPUT
            var output = Matrix.Multiply(this.weigth_ho.Data, hidden); //Multiplica Entrada pelos Pesos

            output = Matrix.Add(output, this.bias_ho.Data);//Adiciona o Bias

            //Aplica funcao de ativação na Saida 
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    output[i, j] = (int)RedeNeural.Sigmoid(output[i, j]);
                }
            }


            Console.WriteLine("RESULTADO: ");
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.WriteLine("Result-> " + output[i, j]);
                }
            }
        }

        public void predict(int[] _input){
             //INPUT -> HIDDEN
            var input = Matrix.arrayToMatryx(_input);

            var hidden = Matrix.Multiply(this.weigth_ih.Data, input.Data); //Multiplica Entrada pelos Pesos

            hidden = Matrix.Add(hidden, this.bias_ih.Data);//Adiciona o Bias


            int row = hidden.GetLength(0) - 1;
            int col = hidden.GetLength(1) - 1;

            int[,] result = new int[row, col];


            //Aplica funcao de ativação
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    hidden[i, j] = (int)RedeNeural.Sigmoid(hidden[i, j]);
                }
            }

            //HIDDEN -> OUTPUT
            var output = Matrix.Multiply(this.weigth_ho.Data, hidden); //Multiplica Entrada pelos Pesos

            output = Matrix.Add(output, this.bias_ho.Data);//Adiciona o Bias

            //Aplica funcao de ativação na Saida 
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    output[i, j] = (int)RedeNeural.Sigmoid(output[i, j]);
                }
            }

            Console.WriteLine("RESULTADO: ");
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.WriteLine("Result-> " + output[i, j]);
                }
            }
        }


        #region TREINO

        public void Train(int[] _input, int[] _target)
        {


            //INPUT -> HIDDEN
            var input = Matrix.arrayToMatryx(_input);

            var hidden = Matrix.Multiply(this.weigth_ih.Data, input.Data); //Multiplica Entrada pelos Pesos

            hidden = Matrix.Add(hidden, this.bias_ih.Data);//Adiciona o Bias


            int row = hidden.GetLength(0) - 1;
            int col = hidden.GetLength(1) - 1;

            int[,] result = new int[row, col];


            //Aplica funcao de ativação
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    hidden[i, j] = (int)RedeNeural.Sigmoid(hidden[i, j]);
                }
            }

            //HIDDEN -> OUTPUT
            var output = Matrix.Multiply(this.weigth_ho.Data, hidden); //Multiplica Entrada pelos Pesos

            output = Matrix.Add(output, this.bias_ho.Data);//Adiciona o Bias

            //Aplica funcao de ativação na Saida 
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    output[i, j] = (int)RedeNeural.Sigmoid(output[i, j]);
                }
            }

            //BACKPROPAGATION
            var expected = Matrix.arrayToMatryx(_target);
            var output_error = Matrix.Subtract(expected.Data, output); 

           

            //OUTPUt -> HIDDEN
            #region DELTA W´s
             var d_output = output;

            //Calcula derivada da Sigmoid do output
            for (int i = 0; i < d_output.GetLength(0); i++)
            {
                for (int j = 0; j < d_output.GetLength(1); j++)
                {
                    d_output[i, j] = (int)RedeNeural.DSigmoid(d_output[i, j]);
                }
            }

            var hidden_T = Matrix.Transpose(hidden);

            var gradient = Matrix.Hadamard(output_error, d_output);
            gradient = Matrix.EscalarMultiply(gradient, _learning_rate);

            //Adjust BIAS
            this.bias_ho = new Matrix(Matrix.Add(bias_ho.Data, gradient));
            
            var weigth_ho_deltas = Matrix.Multiply(gradient, hidden_T);

            #endregion
            //Corrige os pesos
            weigth_ho = new Matrix(Matrix.Add(weigth_ho.Data, weigth_ho_deltas));


            //HIDDEN --> INPUT
            var weigth_ho_T = Matrix.Transpose(this.weigth_ho.Data); //aqui é diferente da camada de saida, pois na saida já temos o valor absoluto que precisamos
            var hidden_error = Matrix.Multiply(weigth_ho_T, output_error);

            var d_hidden = hidden;
             
            //Calcula derivada da Sigmoid da camada oculta
            for (int i = 0; i < d_hidden.GetLength(0); i++)
            {
                for (int j = 0; j < d_hidden.GetLength(1); j++)
                {
                    d_hidden[i, j] = (int)RedeNeural.DSigmoid(hidden[i, j]);
                }
            }

            var input_T= Matrix.Transpose(input.Data);            

            var gradient_h = Matrix.Hadamard(hidden_error, d_hidden);
            gradient_h = Matrix.EscalarMultiply(gradient_h, _learning_rate);
            
            //Adjust BIAS
            this.bias_ih = new Matrix(Matrix.Add(bias_ih.Data, gradient_h)); //TODO: BIAS
            var weigth_ih_deltas = Matrix.Multiply(gradient_h, input_T);

            //Corrige os pesos
            weigth_ih = new Matrix(Matrix.Add(weigth_ih.Data, weigth_ih_deltas));

        }

        #endregion

    }
}