using Xunit.Abstractions;

namespace WindowCalculator.Tests
{
    public class InjectionTests
    {
        private readonly ITestOutputHelper _output;
        private const string FileLocation = "../../../../";
        private const string FileName = "MeaningOfLife.txt";
        private readonly string _filePath;
        private const string MeaningOfLife = "The meaning of life is 42";

        public InjectionTests(ITestOutputHelper output)
        {
            _output= output;
            _filePath = $"{FileLocation}{FileName}";
        }

        [Fact]
        public void StartTheBuiltInCalculatorInWindows()
        {
            var number1 = "1";
            var injection = "1 & calc";

            Calculator.Calculate(number1, injection);

            _output.WriteLine("The calculator in Windows should have started");
        }

        [Fact]
        public void ReadFromFile()
        {
            var injection = $"0 & cd {FileLocation} & type {FileName}";
            var expected = $"0{MeaningOfLife}";

            _output.WriteLine($"Injecting: {injection}");
            _output.WriteLine("0 so the calculation will succeed (we could let it fail)");
            _output.WriteLine("& to also run another command");
            _output.WriteLine($"cd {FileLocation} to move to the directory where the file is located");
            _output.WriteLine("& to run yet another command");
            _output.WriteLine($"type {FileName} to display the content of the textfile");

            string actual = Calculator.Calculate("0", injection);

            _output.WriteLine("");
            _output.WriteLine($"The expected output is: \"{expected}\"");
            _output.WriteLine("The leading 0 is the result from the calculation, the rest is the content of the file.");
            _output.WriteLine("");
            _output.WriteLine($"The actual result is: \"{actual}\"");
            _output.WriteLine("(If the test fails due to wrong content of the file, run the RestoreTheMeaningOfLife test)");

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void WriteToleFile()
        {
            //Write to file
            var newMeaningOfLife = "Sex drugs and rock n roll";
            var injection = $"0 & echo {newMeaningOfLife} > {_filePath}";

            _output.WriteLine($"Injecting: {injection}");
            _output.WriteLine("0 so the calculation will succeed (we could let it fail)");
            _output.WriteLine("& to also run another command");
            _output.WriteLine("echo so whats comming next will be written to the output and can be used as input in the next command, instead of interpreted as the name of a command");
            _output.WriteLine($"\"{newMeaningOfLife}\" the value we echoed");
            _output.WriteLine($"> take the thing we echoed and write it to {_filePath}");
            _output.WriteLine("");

            Calculator.Calculate("0", injection);

            //Read from the file and assert if the file was updated
            var actual = "";
            using (var sr = new StreamReader(_filePath))
            {
                actual = sr.ReadToEnd();
            }

            var expected = $"{newMeaningOfLife} \r\n"; //For some reason a space and linebreak is added

            _output.WriteLine("Reading from file");
            _output.WriteLine($"The expected output is: \"{expected}\"");
            _output.WriteLine($"The actual output is: \"{actual}\"");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RestoreTheMeaningOfLife()
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.Write(MeaningOfLife);
            }
            
            _output.WriteLine("The meaning of life has been restored");
        }
    }
}
