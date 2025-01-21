using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace old_phone_pad_coding_challenge
{
    class Program
    {
        public static String OldPhonePad(string input)
        {
            input = input.Trim();
            
            if(input.Length == 0)
            {
                return "";
            }

            Dictionary<char, char[]> phonePadMap = new Dictionary<char, char[]> {
                { '2', new char[] { 'A', 'B', 'C' } },
                { '3', new char[] { 'D', 'E', 'F' } },
                { '4', new char[] { 'G', 'H', 'I' } },
                { '5', new char[] { 'J', 'K', 'L' } },
                { '6', new char[] { 'M', 'N', 'O' } },
                { '7', new char[] { 'P', 'Q', 'R', 'S' } },
                { '8', new char[] { 'T', 'U', 'V' } },
                { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
            };
            string output = "";
            char firstWord = input[0]; // To mark first word to compare
            int counter = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (firstWord != input[i] || counter == 2)
                {
                    if (firstWord == '*')
                    {
                        output = output.Substring(0, output.Length - 1);
                    }

                    if (!phonePadMap.ContainsKey(firstWord))
                    {
                        firstWord = input[i];
                        counter = 0;
                        continue;
                    }

                    output += phonePadMap[firstWord][counter];
                    counter = 0;
                    firstWord = input[i];
                    continue;
                }

                counter++;
            }

            return output;
        }

        static void Main(string[] args)
        {
            int passTotal = 0;
            int testTotal = 5;
            passTotal += Test("222 2 22#", "CAB") == "Pass" ? 1 : 0;
            passTotal += Test("33#", "E") == "Pass" ? 1 : 0;
            passTotal += Test("227*#", "B") == "Pass" ? 1 : 0;
            passTotal += Test("4433555 555666#", "HELLO") == "Pass" ? 1 : 0;
            passTotal += Test("8 88777444666*664#”)", "TURING") == "Pass" ? 1 : 0;
            Console.WriteLine($"Passed : {passTotal} Failed : {testTotal - passTotal}");
            Console.ReadLine();
        }

        private static string Test(string input, string expected)
        {
            string result = OldPhonePad(input);
            string isPass = expected != result ? "Fail" : "Pass";
            Console.WriteLine($"{input} => {result} - {isPass} - Expected : {expected}");
            return isPass;
        }
    }
}
