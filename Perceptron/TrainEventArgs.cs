using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class TrainingLoopEventArgs : EventArgs
    {
        public int Epoch { get; set; }
        public double[] Weights { get; set; }
        public double Bias { get; set; }
    }

    class TrainingFinishedEventArgs : EventArgs
    {
        public int TotalEpochs { get; set; }
    }
}
