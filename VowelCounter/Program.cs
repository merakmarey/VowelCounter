namespace VowelCounter
{
    internal class Program
    {
       
        public static int VowelsFor(string line, HashSet<char> vowels)
        {
            int count = 0;
            foreach (char _char in line)
            {
                if (vowels.Contains(_char))
                    count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            bool weirdMode = false;
            int totalVowels = 0;

            char[] _charVowels = { 'a', 'e', 'i', 'o', 'u' };

            HashSet<char> vowels = new HashSet<char>(_charVowels);

            string inputFile = args[0];
            string filename;

            if (args.Length > 1 && args[1].StartsWith("-d="))
            {
                filename = args[1].Substring(3);

                var subsetVowels = new HashSet<char>();

                foreach (var ch in filename)
                {
                    if (vowels.Contains(ch))
                    {
                        subsetVowels.Add(ch);
                    }
                }

                vowels =  subsetVowels;
                
                weirdMode = true;
            }

            var lines = File.ReadAllLines(inputFile);
            if (weirdMode)
            {
                foreach (var line in lines)
                {
                    int vowelCount = VowelsFor(line.ToLowerInvariant(), vowels);
                    if (vowelCount > 0)
                    {
                        Console.WriteLine($"Line: {line} - Vowels: {vowelCount}");
                    }
                    totalVowels += vowelCount;
                }
            } else
            {
                foreach (var line in lines)
                {
                    int vowelCount = VowelsFor(line.ToLowerInvariant(), vowels);
                    Console.WriteLine($"Line: {line} - Vowels: {vowelCount}");
                    totalVowels += vowelCount;
                }
            }
            
            Console.WriteLine($"Total Vowels: {totalVowels}");
        }
    }
}
