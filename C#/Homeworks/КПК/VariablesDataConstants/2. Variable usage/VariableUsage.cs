using System;

namespace _2.Variable_usage
{
    class VariableUsage
    {
        static void Main(string[] args)
        {

        }
        public static void PrintStatistics(double[] stats)
        {
            FindAndPrintMaximalStats(stats);

            FindAndPrintMinimalStats(stats);

            FindAndPrintAvrgStats(stats);
        }


        private static void FindAndPrintMaximalStats(double[] stats)
        {
            double maxStats = 0;
            int statsLenght = stats.Length;

            for (int i = 0; i < statsLenght; i++)
            {
                if (stats[i] > maxStats)
                {
                    maxStats = stats[i];
                }
            }
            Console.WriteLine(maxStats);
        }
        private static void FindAndPrintMinimalStats(double[] stats)
        {
            double minStats = double.MaxValue;
            int statsLenght = stats.Length;

            for (int i = 0; i < statsLenght; i++)
            {
                if (stats[i] < minStats)
                {
                    minStats = stats[i];
                }
            }
            Console.WriteLine(minStats);
        }
        private static void FindAndPrintAvrgStats(double[] stats)
        {
            double statsValue = 0;
            int statsLenght = stats.Length;
            for (int i = 0; i < statsLenght; i++)
            {
                statsValue += stats[i];
            }
            double averageStats = statsValue / statsLenght;
            Console.WriteLine(averageStats);
        }
    }
}
