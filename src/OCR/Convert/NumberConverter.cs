namespace OCR.Convert {
    using System.Collections.Generic;
    using System.Linq;
    public class NumberConverter : IConvert {
        public static int INVALID = -1;

        public int Convert(IEnumerable<string> number) {
            return mappings.Where((kvp) => kvp.Key.SequenceEqual(number)).Select(kvp => kvp.Value).DefaultIfEmpty(INVALID).FirstOrDefault();
        }

        public static Dictionary<IEnumerable<string>, int> mappings = new Dictionary<IEnumerable<string>, int>() {
            {new List<string> {"   ",
                               "  |",
                               "  |"}, 1},

            {new List<string> {" _ ",
                               " _|",
                               "|_ "}, 2},

            {new List<string> {" _ ",
                               " _|",
                               " _|"}, 3},

            {new List<string> {"   ",
                               "|_|",
                               "  |"}, 4},

            {new List<string> {" _ ",
                               "|_ ",
                               " _|"}, 5},

            {new List<string> {" _ ",
                               "|_ ",
                               "|_|"}, 6},

            {new List<string> {" _ ",
                               "  |",
                               "  |"}, 7},

            {new List<string> {" _ ",
                               "|_|",
                               "|_|"}, 8},

            {new List<string> {" _ ",
                               "|_|",
                               " _|"}, 9},

            {new List<string> {" _ ",
                               "| |",
                               "|_|"}, 0},
        };
    }
}