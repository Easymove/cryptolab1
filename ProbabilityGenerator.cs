using System;
using System.Collections.Generic;
using System.Linq;

namespace cryptolab1
{
    public class ProbabilityGenerator
    {
        private readonly Random _random = new Random();

        public List<double> GenerateProbabilities(int len, int type)
        {
            switch (type)
            {
                case 1:
                    return GenerateRandomProbabilities(len);
                case 0:
                    return GenerateEqualProbabilities(len);
                default:
                    throw new Exception("Not valid probability generator mode!");
            }
        }

        public List<double> GenerateRandomProbabilities(int len)
        {
            var tmp = new List<int>(new int[len]).Select(x => _random.Next(10, 100)).ToList();
            var total = tmp.Sum();
            return tmp.Select(x => Math.Round((double) x/total, 3)).ToList();
        }

        public List<double> GenerateEqualProbabilities(int len)
        {
            return new List<double>(new double[len]).Select(x => Math.Round(1.0/len, 3)).ToList();
        }
    }
}