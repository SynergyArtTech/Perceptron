using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Perceptron; 

namespace Perceptron
{
    public partial class TestPerceptron : Form
    {
        private List<double[]> _inputTrainingData = new List<double[]>();
        private List<double> _outputTrainingData = new List<double>();
        private int _inputDimension;
        private Perceptron _perceptron = new Perceptron();

        public TestPerceptron()
        {
            InitializeComponent();
            InitEventHandlers();
            InitSampleTrainingData();
        }

        public void InitEventHandlers()
        {
            _perceptron.TrainingLoopEventHandler += TrainingLoopEventHandler;
            _perceptron.TrainingFinishedEventHandler += TrainingFinishEventHandler;
            _perceptron.TrainingFailedEventHandler += TrainingFailedHandler;

            trainingDataGridView.ColumnAdded += InputDimensionChangedEventHandler;
            trainingDataGridView.ColumnRemoved += InputDimensionChangedEventHandler;

            testDataGridView.RowsAdded += (sender, e) => TestDataGridViewRowAddedEventHandler(sender, e, "y");
        }

        public void Train(List<double[]> inputTrainingData, List<double> outputTrainingData)
        {
            _perceptron.Train(inputTrainingData, outputTrainingData);
        }

        private void InitPerceptronParametersDataGridView()
        {
            // Clear weightsAndBiasGridView
            perceptronParametersGridView.Columns.Clear();
            perceptronParametersGridView.Rows.Clear();

            // Add epoch column
            perceptronParametersGridView.Columns.Add(new DataGridViewColumn() { Name = "epoch", HeaderText = "epoch", CellTemplate = new DataGridViewTextBoxCell() });

            // Add weight columns
            for (int i = 0; i < _inputDimension; i++)
            {
                perceptronParametersGridView.Columns.Add(
                    new DataGridViewColumn()
                    {
                        Name = "w" + i.ToString(),
                        HeaderText = "w" + i.ToString(),
                        CellTemplate = new DataGridViewTextBoxCell()
                    }
                );
            }

            // Add bias
            perceptronParametersGridView.Columns.Add(new DataGridViewColumn() { Name = "bias", HeaderText = "bias", CellTemplate = new DataGridViewTextBoxCell() });
        }

        private void AddInputColumn()
        {
            int numberOfColumns = trainingDataGridView.ColumnCount;
            string columnName = "x" + (numberOfColumns - 1).ToString();

            trainingDataGridView.Columns.Insert(numberOfColumns - 1, new DataGridViewColumn()
            {
                Name = columnName,
                HeaderText = columnName,
                CellTemplate = new DataGridViewTextBoxCell()
            });
        }

        private void InitSampleTrainingData()
        {
            trainingDataGridView.Rows.Add(0.3, 0.3, 0);
            trainingDataGridView.Rows.Add(0.5, 0.8, 0);
            trainingDataGridView.Rows.Add(3, 6, 1);
        }

        private void TrainBtn_Click(object sender, EventArgs e)
        {
            Tuple<List<double[]>, List<double>> trainingData = ReadTrainingDataFromGridView();
            InitPerceptronParametersDataGridView();
            Train(trainingData.Item1, trainingData.Item2);
        }

        private void TrainingLoopEventHandler(object sender, TrainingLoopEventArgs args)
        {
            // add epoch
            int index = perceptronParametersGridView.Rows.Add();
            perceptronParametersGridView.Rows[index].Cells["epoch"].Value = args.Epoch.ToString();

            // add weights
            DataGridViewCell[] weights = new DataGridViewCell[_inputDimension];
            for (int i = 0; i < _inputDimension; i++)
            {
                perceptronParametersGridView.Rows[index].Cells["w" + i].Value = args.Weights[i].ToString();
            }

            // add bias
            perceptronParametersGridView.Rows[index].Cells["bias"].Value = args.Bias;
        }

        private void TrainingFinishEventHandler(object sender, TrainingFinishedEventArgs args)
        {
            testBtn.Enabled = true;
            InitTestDataGridView();
        }

        private void TrainingFailedHandler(object sender, EventArgs args)
        {
            MessageBox.Show("Unable to converge, training failed");
        }

        private Tuple<List<double[]>, List<double>> ReadTrainingDataFromGridView()
        {
            UpdateInputDimension();

            List<double[]> inputTrainingData = new List<double[]>();
            List<double> outputTrainingData = new List<double>();

            foreach (DataGridViewRow row in trainingDataGridView.Rows)
            {
                // The last column is y value or the classification target 
                double[] dataRow = new double[_inputDimension];

                for (int i = 0; i < _inputDimension; i++)
                {
                    dataRow[i] = Convert.ToDouble(row.Cells[i].Value);
                }

                // X data
                inputTrainingData.Add(dataRow);

                // add the last column of the data row to Y or target data
                outputTrainingData.Add(Convert.ToDouble(row.Cells[_inputDimension].Value));
            }

            return new Tuple<List<double[]>, List<double>>(inputTrainingData, outputTrainingData);
        }

        private List<double[]> ReadTestDataFromGridView()
        {
            List<double[]> testData = new List<double[]>();

            for (int i = 0; i < testDataGridView.Rows.Count - 1; i++)
            {
                double[] testRow = new double[_inputDimension];

                for (int j = 0; j < _inputDimension; j++)
                {
                    testRow[j] = Convert.ToDouble(testDataGridView.Rows[i].Cells[j].Value);
                }

                testData.Add(testRow);
            }

            return testData;
        }

        private void InitTestDataGridView()
        {
            string columnName;

            testDataGridView.Columns.Clear();
            testDataGridView.Rows.Clear();

            // Add x columns
            for (int i = 0; i < _inputDimension; i++)
            {
                columnName = "x" + i;
                testDataGridView.Columns.Insert(i, new DataGridViewColumn() 
                {
                    Name = columnName,
                    HeaderText = columnName,
                    CellTemplate = new DataGridViewTextBoxCell()
                });
            }

            // Add y column and set it read only
            columnName = "y";
            testDataGridView.Columns.Add(columnName, columnName);
            SetDataGridViewColumnReadOnly(testDataGridView, columnName);        
        }

        private void TestDataGridViewRowAddedEventHandler(object sender, EventArgs e, string columnName)
        {
            SetDataGridViewColumnReadOnly((DataGridView)sender, columnName);
        }

        private void SetDataGridViewColumnReadOnly(DataGridView dataGridView, string columnName)
        {
            if (!(dataGridView.Columns.Contains(columnName)))
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell y = row.Cells[columnName];
                y.ReadOnly = true;
                y.Style.BackColor = Color.Azure;
            }

            dataGridView.Refresh();
        }

        private void RemoveInputColumnBtn_Click(object sender, EventArgs e)
        {
            RemoveInputColumn();
        }

        private void RemoveInputColumn()
        {
            int numberOfColumns = trainingDataGridView.Columns.Count;

            if (numberOfColumns == 2)
            {
                return;
            }

            trainingDataGridView.Columns.RemoveAt(numberOfColumns - 2);
        }

        private void AddDataBtn_Click(object sender, EventArgs e)
        {
            trainingDataGridView.Rows.Add(new DataGridViewRow());
        }

        private void DeleteDataBtn_Click(object sender, EventArgs e)
        {
            int index = trainingDataGridView.CurrentCell.RowIndex;
            trainingDataGridView.Rows.RemoveAt(index);
        }

        private void AddInputColumnBtn_Click(object sender, EventArgs e)
        {
            AddInputColumn();
        }

        private void InputDimensionChangedEventHandler(object sender, EventArgs e)
        {
            UpdateInputDimension();
        }

        private void UpdateInputDimension()
        {
            _inputDimension = trainingDataGridView.ColumnCount - 1;
            Console.WriteLine("Input Dimension:" + _inputDimension);
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            List<double[]> testData = ReadTestDataFromGridView();
            double[] results = _perceptron.Predict(testData);

            for (int i = 0; i < results.Length; i++)
            {
                testDataGridView.Rows[i].Cells["y"].Value = results[i];
            }
        }
    }
}
