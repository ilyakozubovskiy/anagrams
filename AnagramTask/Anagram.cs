using System;
using System.Collections.Generic;

namespace AnagramTask
{
    public class Anagram
    {
        private readonly string sourceWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException($"{nameof(sourceWord)} cannot be empty.");
            }

            this.sourceWord = sourceWord;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            List<string> result = new List<string>();

            for (int i = 0; i < candidates.Length; i++)
            {
                if (this.sourceWord.ToUpperInvariant() != candidates[i].ToUpperInvariant() && this.sourceWord.Length == candidates[i].Length)
                {
                    var source1 = this.sourceWord.ToUpperInvariant().ToCharArray();
                    var source2 = candidates[i].ToUpperInvariant().ToCharArray();

                    Array.Sort(source1);
                    Array.Sort(source2);

                    bool isMatch = true;
                    for (int j = 0; j < source1.Length; j++)
                    {
                        if (source1[j] != source2[j])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        result.Add(candidates[i]);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
