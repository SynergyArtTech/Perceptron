using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Perceptron
    {
        int epoch = 0;
        double[] weights;
        double bias;
        public double LearningRate = 0.1;
        private int _inputDim;
        public event EventHandler<TrainingLoopEventArgs> TrainingLoopEventHandler;
        public event EventHandler<TrainingFinishedEventArgs> TrainingFinishedEventHandler;
        public event EventHandler TrainingFailedEventHandler;

        public Perceptron()
        {

        }

        private void InitWeightsAndBias(int inputDim)
        {
            Random random = new Random();
            weights = new double[inputDim];

            for (int i = 0; i < inputDim; i++)
            {
                // random between -1 and 1
                weights[i] = (random.NextDouble() * 2) - 1;
            }

            string txt = "";
            for (int i = 0; i < weights.Length; i++)
            {
                txt += weights[i].ToString() + ", ";
            }

            bias = (random.NextDouble() * 2) - 1;
        }

        public int Predict(double[] inputs)
        {
            double sum = bias;

            for (int i = 0; i < _inputDim; i++)
            {
                sum += inputs[i] * weights[i];
            }

            int output = sum > 0 ? 1 : 0;

            return output;
        }

        public double[] Predict(List<double[]> inputBatch)
        {
            double[] results = new double[inputBatch.Count];

            for (int i = 0; i < inputBatch.Count; i++)
            {
                results[i] = Predict(inputBatch[i]);
            }

            return results;
        }

        public void Train(List<double[]> x, List<double> y, int maxEpoch = 100)
        {
            if (x.Count != y.Count)
            {
                throw new Exception("The number of elements in x and y must be equal");
            }

            _inputDim = x[0].Length;
            InitWeightsAndBias(_inputDim);

            for (epoch = 0; epoch < maxEpoch; epoch++)
            {
                double error_sum = 0;

                // trigger an event after a loop
                TriggerTrainingLoopEvent();

                for (int i = 0; i < x.Count; i++)
                {
                    int prediction = Predict(x[i]);
                    double error = y[i] - prediction;
                    error_sum += Math.Abs(error);

                    // update weights
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += (LearningRate * x[i][j] * error);
                    }

                    // update bias
                    bias += LearningRate * error;
                }

                if (error_sum == 0)
                {
                    TriggerTrainingFinishedEvent();
                    break;
                }

                if (epoch == maxEpoch - 1)
                {
                    TriggerTrainingFailedEvent();
                }
            }
        }

        private void TriggerTrainingLoopEvent()
        {
            TrainingLoopEventHandler?.Invoke(this, new TrainingLoopEventArgs
            {
                Epoch = this.epoch,
                Weights = this.weights,
                Bias = this.bias
            });
        }

        private void TriggerTrainingFinishedEvent()
        {
            TrainingFinishedEventHandler?.Invoke(this, new TrainingFinishedEventArgs
            {
                TotalEpochs = epoch,
            });
        }

        private void TriggerTrainingFailedEvent()
        {
            TrainingFailedEventHandler?.Invoke(this, new EventArgs());
        }

        public void Verify(List<double[]> x, List<double> y)
        {
            Console.WriteLine("\n\nVERIFY:");
            for (int i = 0; i < x.Count; i++)
            {
                string msg = "[";

                for (int j = 0; j < x[i].Length; j++)
                {
                    msg += x[i][j];

                    if (j < x[i].Length - 1)
                    {
                        msg += ",";
                    }
                }

                msg += "], actual:" + y[i] + ", predict:" + Predict(x[i]).ToString();
                Console.WriteLine(msg);
            }
        }

        public double[] GetWeightsAndBias()
        {
            List<double> list = weights.ToList();
            list.Add(bias);

            return list.ToArray();
        }
    }
}
