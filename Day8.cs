string[] input = File.ReadAllLines("../../../input.txt");
int size = input.Length;
char[,] antinodes = new char[size, size];

PartOne();
PartTwo();

void PartOne() {
    char[,] grid = new char[size, size];
    Dictionary<char, List<Tuple<int, int>>> antennas = new Dictionary<char, List<Tuple<int, int>>>();
    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            grid[i, j] = input[i][j];
            antinodes[i, j] = '.';
            if (grid[i, j] != '.') {
                if (antennas.ContainsKey(grid[i, j])) {
                    antennas[grid[i, j]].Add(Tuple.Create(i, j));
                }
                else {
                    antennas[grid[i, j]] = new List<Tuple<int, int>> { Tuple.Create(i, j) };
                }
            }
        }
    }
    foreach (var antenna in antennas) {
        for (int i = 0; i < antenna.Value.Count; i++) {
            for (int j = 1 + i; j < antenna.Value.Count; j++) {
                AddAntinodes(antenna.Value[i].Item1, antenna.Value[i].Item2, antenna.Value[j].Item1, antenna.Value[j].Item2, false);
            }
        }
    }
    int count = 0;
    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            Console.Write(antinodes[i, j]);
            if (antinodes[i, j] == '#') count++;
        }
        Console.WriteLine();
    }
    Console.WriteLine(count);
}
void AddAntinodes(int x1, int y1, int x2, int y2, bool repeat) {
    int dx = x1 - x2;
    int dy = y1 - y2;
    if (!repeat) {
        int newy = y1 + dy;
        int newx = x1 + dx;
        if (newy >= 0 && newx >= 0 && newy < size && newx < size) {
            antinodes[newy, newx] = '#';
        }
        newy = y2 - dy;
        newx = x2 - dx;
        if (newy >= 0 && newx >= 0 && newy < size && newx < size) {
            antinodes[newy, newx] = '#';
        }
    }
    else {
        antinodes[y1, x1] = '#';
        antinodes[y2, x2] = '#';
        for (int newy = y1 + dy, newx = x1 + dx; newy < size && newy >= 0 && newx < size && newx >= 0; newy += dy, newx += dx) {
            antinodes[newy, newx] = '#';
        }
        for (int newy = y2 - dy, newx = x2 - dx; newy < size && newy >= 0 && newx < size && newx >= 0; newy -= dy, newx -= dx) {
            antinodes[newy, newx] = '#';
        }
    }
}

void PartTwo() {
    char[,] grid = new char[size, size];
    Dictionary<char, List<Tuple<int, int>>> antennas = new Dictionary<char, List<Tuple<int, int>>>();
    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            grid[i, j] = input[i][j];
            antinodes[i, j] = '.';
            if (grid[i, j] != '.') {
                if (antennas.ContainsKey(grid[i, j])) {
                    antennas[grid[i, j]].Add(Tuple.Create(i, j));
                }
                else {
                    antennas[grid[i, j]] = new List<Tuple<int, int>> { Tuple.Create(i, j) };
                }
            }
        }
    }
    foreach (var antenna in antennas) {
        for (int i = 0; i < antenna.Value.Count; i++) {
            for (int j = 1 + i; j < antenna.Value.Count; j++) {
                AddAntinodes(antenna.Value[i].Item1, antenna.Value[i].Item2, antenna.Value[j].Item1, antenna.Value[j].Item2, true);
            }
        }
    }
    int count = 0;
    for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
            if (antinodes[i, j] == '#') count++;
        }
    }
    Console.WriteLine(count);
}
