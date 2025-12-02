string input = Path.Combine(AppContext.BaseDirectory, "Day1/input.txt");
string[] lines = File.ReadAllLines(input);

int zeroStop = 0;
int zeroPass = 0;
int dial = 50;

foreach (string line in lines)
{
    int number = GetNumber(line);

    if (IsRLine(line))
    {
        zeroPass += (dial + number) / 100;
        dial = (dial + (number % 100)) % 100;
    }
    else
    {
        zeroPass += (number + (99 - dial)) / 100;
        dial = (dial - (number % 100) + 100) % 100;
    }
    
    if (dial == 0) zeroStop++;
}

Console.WriteLine("zeroStop: " + zeroStop); // Part one.
Console.WriteLine("zeroPass: " + zeroPass); // Part two.


bool IsRLine(string line) => line[0] == 'R';

int GetNumber(string line) => int.Parse(line.Substring(1));