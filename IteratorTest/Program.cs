using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IteratorTest
{
	class Program
	{
        public static void Main()
        {
            var s = File.OpenRead("TextFile1.txt");
            IEnumerable<int> it = new SolutionIter(s);
            int[] arr = it.ToArray();
        }
        public class SolutionIter : IEnumerable<int>
        {
            private TextReader reader;

            public SolutionIter(Stream stream)
            {
                if (stream == null)
                    return;

                reader = new StreamReader(stream);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                string line = "";
                do
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        int temp;
                        if (int.TryParse(line.Trim(), out temp))
                        {
                            yield return temp;
                        }
                    }
                } while (!string.IsNullOrEmpty(line));
            }

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                string line = "";   
                do
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        int temp;
                        if (int.TryParse(line.Trim(), out temp))
                        {
                            yield return temp;
                        }
                    }
                } while (!string.IsNullOrEmpty(line));
            }
        }

        /**
         * Example usage:
         *
         * IEnumerable<int> it = new SolutionIter(stream);
         * int[] arr = it.ToArray();
         */

    }
}
