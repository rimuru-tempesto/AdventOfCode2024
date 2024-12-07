PartOne();
PartTwo();

void PartOne() {
    string[] input = File.ReadAllLines("../../../input.txt");
    char[,] grid = new char[input.Length, input[0].Length];
    int row = 0, col = 0;
    int count = -1;
    int xmod = 0, ymod = -1;
    for (int i = 0; i < input.Length; i++) {
        for (int j = 0; j < input[i].Length; j++) {
            if (input[i][j] == '^') 
            {
                row = i;
                col = j;
            }
            grid[i, j] = input[i][j];
        }
    }
    while (row + ymod >= 0 && row + ymod < input.Length && col + xmod >= 0 && col + xmod < input[0].Length) {
        if (grid[row + ymod, col + xmod] == '#') {
            count++;
            switch (count%4) {
                case 0:
                    ymod = 0;
                    xmod = 1;
                    break;
                case 1:
                    ymod = 1;
                    xmod = 0;
                    break;
                case 2:
                    ymod = 0;
                    xmod = -1;
                    break;
                case 3:
                    ymod = -1;
                    xmod = 0;
                    break;
            }
        }
        grid[row, col] = 'X';
        row += ymod;
        col += xmod;
    }
    count = 0;
    for (int i = 0; i < input.Length; i++) {
        for (int j = 0; j < input[0].Length; j++) {
            Console.Write(grid[i, j]);
            if (grid[i, j] == 'X') count++;
        }
        Console.WriteLine();
    }
    Console.WriteLine(++count);
}

void PartTwo() {
    string[] input = File.ReadAllLines("../../../input.txt");
    int SZ = input.Length;
    char[,] visited, grid = new char[SZ, SZ];
    int startRow = 0, startCol = 0, row, col, drow, dcol, total = 0, tmp;
    for (int i = 0; i < SZ; i++) {
        for (int j = 0; j < SZ; j++) {
            if (input[i][j] == '^') {
                startRow = i;
                startCol = j;
            }
            grid[i, j] = input[i][j];
        }
    }
    for (int i = 0; i < SZ; i++) 
        for (int j = 0; j < SZ; j++) {
            if (grid[i,j] == '.') {
                grid[i,j] = '#'; 
                drow = -1; 
                dcol = 0; 
                row = startRow; 
                col = startCol;
                visited = new char[SZ, SZ];
                while (true) {
                    if (row + drow < 0 || col + dcol < 0 || row + drow >= SZ || col + dcol >= SZ) break;    /* check for out-of-bounds */
                    if (visited[row + drow,col + dcol] == EncodeDirection(drow, dcol)) { 
                        total++;                                                                            /* check for endless-loop */
                        break; 
                    } 
                    if (grid[row + drow, col + dcol] == '#') { 
                        tmp = drow; 
                        drow = dcol;                                                                        /* turn right */
                        dcol = -tmp; 
                    } 
                    else { 
                        row += drow; 
                        col += dcol;                                                                        /* advance */
                        visited[row, col] = (char)EncodeDirection(drow, dcol); 
                    }   
                }
                grid[i,j] = '.'; /* reset state */
            }
        }
    Console.WriteLine(total);
}

int EncodeDirection(int dr, int dc) {
    return dr * 2 + dc;
}