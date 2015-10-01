using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamlet
{
    class Program
    {
        static void Main(string[] args)
        {
            string hamlet = File.ReadAllText(@"C:\Projects\ConsoleApplication1\hamlet.txt").ToLower();
            //Console.WriteLine(hamlet);
            hamlet = hamlet.Replace(",", "");
            hamlet = hamlet.Replace("?", "");
            hamlet = hamlet.Replace(".", "");
            hamlet = hamlet.Replace(Environment.NewLine, "");

            var contents = hamlet.Split(' ');
            var hamletDictionary = new Dictionary<string, int>();
            int value = 0;
            foreach (var word in contents)
            {
                hamletDictionary[word] = hamletDictionary.TryGetValue(word, out value) ? ++value : 1;
            }
            hamletDictionary.Remove("");
            hamletDictionary.Remove(" ");

            foreach (KeyValuePair<string, int> item in hamletDictionary.Where(a => a.Key.Length > 3).OrderBy(key => key.Value))
            {
               Console.WriteLine("{0}, {1}", item.Key, item.Value);
            }
            Console.ReadLine();
        }
    }
}
