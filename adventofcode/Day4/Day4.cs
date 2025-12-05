string[] lines = File.ReadAllLines("Day4/input.txt");

// Part Two.: 
int nb = 0;
bool canContinue = true;
bool updated;

int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

List<(int line, int column)> toMark = new();
while (canContinue)
{
    updated = false;
    for (int line = 0; line < lines.Length; line++)
    {
        for (int column = 0; column < lines[line].Length; column++)
        {
            if (lines[line][column] == '@')
            {
                int adjacent = 0;

                for (int i = 0; i < dx.Length; i++)
                {
                    int newLine = line + dx[i];
                    int newCol = column + dy[i];

                    if (newLine >= 0 && newLine < lines.Length && newCol >= 0 && newCol < lines[newLine].Length)
                    {
                        if (lines[newLine][newCol] == '@')
                        {
                            adjacent++;
                        }
                    }
                }

                if (adjacent < 4)
                {
                    nb++;
                    updated = true;
                    toMark.Add((line, column));
                }
            }
        }
    }

    foreach(var pos in toMark)
    {
        int l = pos.line;
        int c = pos.column;

        char[] temp = lines[l].ToCharArray();
        temp[c] = '.';
        lines[l] = new string(temp);
        
    }
    if(!updated) canContinue = false;
}

Console.WriteLine(nb);
