PartOne();
PartTwo();

void PartOne() {
    List<string> input = File.ReadAllLines("../../../input.txt").ToList();
    int size = input.Count, count = 0, length = 4;

    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            if (input[i][j] == 'X') {
                string[] possibles =
                    [
                        GetSubString(input, j, i, 1, 0, length),
                        GetSubString(input, j, i, -1, 0, length),
                        GetSubString(input, j, i, 0, 1, length),
                        GetSubString(input, j, i, 0, -1, length),
                        GetSubString(input, j, i, 1, 1, length),
                        GetSubString(input, j, i, 1, -1, length),
                        GetSubString(input, j, i, -1, 1, length),
                        GetSubString(input, j, i, -1, -1, length),
                    ];
                count += possibles.Count(x => x == "XMAS");
            }
        }
    }
    Console.WriteLine(count);
}

string GetSubString(List<string> input, int x, int y, int dx, int dy, int length) {
    string text = "";
    if (y + dy * (length - 1) >= input.Count || y + dy * (length - 1) < 0)
        return "";
    for (int i = 0; i < length; ++i) {
        if (x >= input[y].Length || x < 0)
            return "";
        text += input[y][x];
        x += dx;
        y += dy;
    }
    return text;
}

void PartTwo() {
    List<string> input = File.ReadAllLines("../../../input.txt").ToList();
    int size = input.Count, count = 0;

    for (int i = 1; i < size - 1; i++) {
        for (int j = 1; j < size - 1; j++) {
            if (input[i][j] == 'A') {
                string[] possibles =
                    [
                        input[i - 1][j - 1] + " " + input[i][j] + " " + input[i + 1][j + 1],
                        input[i - 1][j + 1] + " " + input[i][j] + " " + input[i + 1][j - 1]
                    ];
                if ((possibles[0] == "M A S" && possibles[1] == "M A S") || (possibles[0] == "S A M" && possibles[1] == "S A M") || (possibles[0] == "M A S" && possibles[1] == "S A M") || (possibles[0] == "S A M" && possibles[1] == "M A S")) count++;
            }
        }
    }
    Console.WriteLine(count);
}