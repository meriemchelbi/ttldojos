using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace LCDKata
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _output = testOutputHelper;
        }
        
        [Fact]
        public void Numbers()
        {
            var digits = new DigitFactory().Create(123);
            new Render(_output).Write(digits);
        }

        [Fact]
        public void Time()
        {
            var digits = new ClockFactory().Create(DateTime.Now);   
            new Render(_output).Write(digits);
        }

        [Fact]
        public void AllInOne()
        {
            new Render(_output).Display("12334");
        }
    }

    public class Digit
    {
        private readonly string _symbol;

        public static IDictionary<string, string[]> _digitLines = new Dictionary<string, string[]>
        {
            ["0"] = new [] {"._.", "|.|", "|_|"},
            ["1"] = new [] {"...", "..|", "..|"},
            ["2"] = new[] { "._.", "._|", "|_." },
            ["3"] = new[] { "._.", "._|", "._|" },
            ["4"] = new[] { "...", "|_|", "..|" },
            ["5"] = new[] { "._.", "|_.", "._|" },
            ["6"] = new[] { "._.", "|_.", "|_|" },
            ["7"] = new[] { "._.", "..|", "..|" },
            ["8"] = new[] { "._.", "|_|", "|_|" },
            ["9"] = new[] { "._.", "|_|", "..|" },
            [":"] = new[] { "   ", " . ", " . " }
        };

        public Digit(string symbol)
        {
            _symbol = symbol;
        }

        public string[] GetLines()
        {
            return _digitLines[_symbol];
        }
    }

    public class DigitFactory
    {
      
        public IEnumerable<Digit> Create(int number)
        {
            return number.ToString().ToList().Select(n => new Digit(n.ToString()));
        }
    }

    public class ClockFactory
    {
        private DigitFactory _digitFactory = new DigitFactory();

        public IEnumerable<Digit> Create(DateTime time)
        {
            return _digitFactory.Create(time.Hour).ToList()
                .Union(new List<Digit> {new Digit(":")})
                .Union(_digitFactory.Create(time.Minute));
        }
    }

    public class Render
    {
        private readonly ITestOutputHelper _output;
        private static IDictionary<string, string[]> _digitLines = new Dictionary<string, string[]>
        {
            ["0"] = new[] { "._.", "|.|", "|_|" },
            ["1"] = new[] { "...", "..|", "..|" },
            ["2"] = new[] { "._.", "._|", "|_." },
            ["3"] = new[] { "._.", "._|", "._|" },
            ["4"] = new[] { "...", "|_|", "..|" },
            ["5"] = new[] { "._.", "|_.", "._|" },
            ["6"] = new[] { "._.", "|_.", "|_|" },
            ["7"] = new[] { "._.", "..|", "..|" },
            ["8"] = new[] { "._.", "|_|", "|_|" },
            ["9"] = new[] { "._.", "|_|", "..|" },
            [":"] = new[] { "   ", " . ", " . " }
        };

        public Render(ITestOutputHelper output)
        {
            _output = output;
        }

        public void _Write(IEnumerable<Digit> digits)
        {
            for (var lineNumber = 0; lineNumber < 3; lineNumber++)
            {
                var line = string.Empty;
                foreach (var digit in digits)
                {
                    line += digit.GetLines()[lineNumber];
                    line += "\t";
                }

                _output.WriteLine(line);
            }
        }

        public void Write(IEnumerable<Digit> digits)
        {
            //var linePerDigit = 3;
            //var reps = digits.SelectMany(d => d.GetLines()).ToList();

            //var one = reps.Where((_, i) => i % linePerDigit == 0);
            //var two = reps.Skip(1).Where((x, i) => i % linePerDigit == 0);
            //var three = reps.Skip(2).Where((x, i) => i % linePerDigit == 0);

            var glypths = new List<string>();

            foreach (var digit in digits)
            {
                var lines = digit.GetLines();
                foreach (var line in lines)
                {
                    glypths.Add(line);
                }
            }

            var lineOne = string.Empty;
            for (var lineOneIndex = 0; lineOneIndex < glypths.Count-2; lineOneIndex+=3)
                lineOne += glypths[lineOneIndex];

            var lineTwo = string.Empty;
            for (var lineOneIndex = 1; lineOneIndex < glypths.Count-1; lineOneIndex += 3)
                lineTwo += glypths[lineOneIndex];

            var lineThree = string.Empty;
            for (var lineOneIndex = 2; lineOneIndex < glypths.Count; lineOneIndex += 3)
                lineThree += glypths[lineOneIndex];

            _output.WriteLine(lineOne);
            _output.WriteLine(lineTwo);
            _output.WriteLine(lineThree);


            //_output.WriteLine(string.Join(" ", one));
            //_output.WriteLine(string.Join(" ", two));
            //_output.WriteLine(string.Join(" ", three));
        }

        public void __Write(IEnumerable<Digit> digits)
        {
            var reps = digits.SelectMany(d => d.GetLines()).ToList();
            
            var lineOne = string.Empty;
            var lineTwo = string.Empty;
            var lineThree = string.Empty;

            for (var i = 0; i < reps.Count; i++)
            {
                if (i % 3 == 0)
                    lineOne += $"{reps[i]} ";
                if (i % 3 == 1)
                    lineTwo += $"{reps[i]} ";
                if (i % 3 == 2)
                    lineThree += $"{reps[i]} ";
            }

            _output.WriteLine(lineOne);
            _output.WriteLine(lineTwo);
            _output.WriteLine(lineThree);
        }

        public void Display(string output)
        {
            var reps = output.ToList().SelectMany(o => _digitLines[o.ToString()]).ToList();

            var lineOne = string.Empty;
            var lineTwo = string.Empty;
            var lineThree = string.Empty;

            for (var i = 0; i < reps.Count; i++)
            {
                if (i % 3 == 0)
                    lineOne += $"{reps[i]} ";
                if (i % 3 == 1)
                    lineTwo += $"{reps[i]} ";
                if (i % 3 == 2)
                    lineThree += $"{reps[i]} ";
            }

            _output.WriteLine(lineOne);
            _output.WriteLine(lineTwo);
            _output.WriteLine(lineThree);
        }
    }
    
}
