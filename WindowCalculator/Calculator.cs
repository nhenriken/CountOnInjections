using System.Diagnostics;

namespace WindowCalculator
{
    public static class Calculator
    {
        public static string Calculate(string number1, string number2)
        {
            var argument = $"/C set /A {number1}+{number2}";
            var result = string.Empty;

            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = argument;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();

                result = myProcess.StandardOutput.ReadToEnd();
            }

            return result;
        }
    }
}
