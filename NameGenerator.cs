using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cryptolab1
{
    public class NameGenerator
    {
        public List<String> GenerateNames(String nameBase, int len)
        {
            int counter = 0;
            return new List<string>(new String[len]).Select(x =>
            {
                counter++;
                return String.Concat(nameBase, (counter - 1));
            }).ToList();
        }
    }
}