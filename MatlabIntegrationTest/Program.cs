using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matlabtest;
using MatlabIntegrationTest.Managers;
using MatlabIntegrationTest.DTO;

namespace MatlabIntegrationTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            new ExcelManager(@"C:\Users\xtadanai\Downloads\testovanie-monitoringu (1).xlsx").ParseSourceData();
            var inMatrix = NeuronData.GetInputMatrix();
            var outMatrix = NeuronData.GetOutputMatrix();
            //var i = 0;

            try
            {
                var matlabClient = new Class1();
                var lenght = inMatrix.GetLength(0);

                for (int i = 0; i < lenght; i++)
                {
                    var inputMatrix = new MathWorks.MATLAB.NET.Arrays.MWNumericArray(1, 3, new double[] { inMatrix[i][0], inMatrix[i][1], inMatrix[i][2] });
                    var result = matlabClient.myNeuralNetworkFunction(inputMatrix);

                    Console.WriteLine($"{inMatrix[i][0]}-{inMatrix[i][1]}-{inMatrix[i][2]}={outMatrix[i][0]} - {result}");
                }
                

                



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
