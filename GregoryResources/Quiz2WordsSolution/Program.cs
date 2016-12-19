using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2WordsSolution
{
    interface ICountVowels
    {
        int GetVowelsCount();
    }
    interface ICountConsonants
    {
        int GetConsonantsCount();
    }

    abstract class Word : ICountConsonants, ICountVowels
    {
        public Word(string term)
        {
            this.term = term;
        }
        private string term;
        public string Term { get { return term; } }

        public int GetConsonantsCount()
        {
            return term.Length - GetVowelsCount();
        }

        public int GetVowelsCount()
        {
            String t = term.ToUpper();
            int count = 0;
            foreach (char c in t) {
                if (c == 'A' || c == 'E' || c == 'I' ||
                    c == 'O'|| c == 'U' || c == 'Y') {
                        count++;
                
                }
            }
            return count;
        }
    }

    class Verb : Word
    {
        public Verb(string verb) : base(verb) { }
        public override string ToString() {
            return string.Format("Verb: {0}, {1} consonants, {2} vowels",
                Term, GetConsonantsCount(), GetVowelsCount());
        }
    }
    class Noun : Word
    {
        public Noun(string noun) : base(noun) { }
        public override string ToString()
        {
            return string.Format("Noun: {0}, {1} consonants, {2} vowels",
                Term, GetConsonantsCount(), GetVowelsCount());
        }
    }
    class Other : Word
    {
        public Other(string other) : base(other) { }
        public override string ToString()
        {
            return string.Format("Other: {0}, {1} consonants, {2} vowels",
                Term, GetConsonantsCount(), GetVowelsCount());
        }
    }

    class WordByWeightComparer : IComparer<Word>
    {
        public int Compare(Word x, Word y)
        {
            int xWeight = 4 * x.GetVowelsCount() + x.GetConsonantsCount();
            int yWeight = 4 * y.GetVowelsCount() + y.GetConsonantsCount();
            return xWeight - yWeight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Word> wordList = new List<Word>();
            wordList.Add(new Noun("cat"));
            wordList.Add(new Verb("walk"));
            wordList.Add(new Other("at"));
            Console.WriteLine("========== ORIGINAL LIST ==========");
            foreach (Word w in wordList)
            {
                Console.WriteLine(w);
            }
            //
            Console.WriteLine("========== SORTED BY WORD WEIGHT ==========");
            wordList.Sort(new WordByWeightComparer());
            foreach (Word w in wordList)
            {
                Console.WriteLine(w);
            }
            //
            Console.ReadKey();
        }
    }
}
