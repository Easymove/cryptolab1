using System.Collections.Generic;
using System.Linq;

namespace cryptolab1
{
    public class NameGenerator
    {
        public List<string> GenerateNames(string nameBase, int len)
        {
            var counter = 1;
            return new List<string>(new string[len]).Select(x =>
            {
                counter++;
                return string.Concat(nameBase, counter - 1);
            }).ToList();
        }
    }
}