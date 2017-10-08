using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class DocumentDistance
    {
        public static void Main(string[] args)
        {
            string doc1 = "My name is dilan hewage.";
            string doc2 = doc1;

            Console.WriteLine(FindDocumentDistance(doc1, doc2));

            doc2 = "I am Randi Manawasinghe";
            Console.WriteLine(FindDocumentDistance(doc1, doc2));

            doc2 = "my name is randi Hewage.";
            Console.WriteLine(FindDocumentDistance(doc1, doc2));

        }
        public static double FindDocumentDistance(string document1, string document2)
        {
            double maxDistance = Math.PI / 2;
            if(string.IsNullOrWhiteSpace(document1) || string.IsNullOrWhiteSpace(document2))
            {
                return maxDistance;
            }

            Dictionary<string, int> doc1Frequency = CalculateWordFrequency(document1);
            Dictionary<string, int> doc2Frequency = CalculateWordFrequency(document2);

            double productdoc1_doc2 = CalculateProduct(doc1Frequency, doc2Frequency);
            double productdoc1_doc1 = CalculateProduct(doc1Frequency, doc1Frequency);
            double productdoc2_doc2 = CalculateProduct(doc2Frequency, doc2Frequency);

            return Math.Acos(productdoc1_doc2 / Math.Sqrt(productdoc1_doc1 * productdoc2_doc2));
        }

        private static Dictionary<string, int> CalculateWordFrequency(string document)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] stringArr = document.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string str in stringArr)
            {
                string lower = str.ToLower();
                if(!dict.ContainsKey(lower))
                {
                    dict.Add(lower, 1);
                }
                else
                {
                    dict[lower] = dict[lower]++;
                }
            }

            return dict;
        }

        private static int CalculateProduct(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            int sum = 0;
            foreach(string key in dict1.Keys)
            {
                if(dict2.ContainsKey(key))
                {
                    sum += dict1[key] * dict2[key];
                }
            }

            return sum;
        }

    }
}
