using System;
using System.Collections.Generic;
using System.Linq;

namespace cryptolab1
{
    public class ProbabilityGenerator
    {
        private Random _random = new Random();
        public List<Double> GenerateProbabilities(int len, int type)
        {
            switch (type)
            {
                case 0:
                    return GenerateRandomProbabilities(len);
                case 1:
                    return GenerateEqualProbabilities(len);
                default:
                    throw new Exception("Not valid probability generator mode!");
            }
        } 

        public List<Double> GenerateRandomProbabilities(int len)
        {
            var tmp = new List<int>(new int[len]).Select(x => _random.Next(1, 100)).ToList();
            int total = tmp.Sum();
            return tmp.Select(x => (double)x / total).ToList();
        }

        public List<Double> GenerateEqualProbabilities(int len)
        {
            return new List<double>(new Double[len]).Select(x => 1.0/len).ToList();
        }
    }
}