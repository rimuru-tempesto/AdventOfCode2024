Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
List<string> prints = new List<string>();

MakeMap();
PartOne();
PartTwo();


void MakeMap() {
    bool state = true;
    string[] input = File.ReadAllLines("../../../input.txt");
    foreach (var row in input) {
        if (row == "") { state = false; continue; }
        if (state) {
            int[] args = row.Split("|").Select(int.Parse).ToArray();
            if (!map.ContainsKey(args[0]))
                map[args[0]] = new List<int>();
            map[args[0]].Add(args[1]);
        }
        else {
            prints.Add(row);
        }
    }
}

void PartOne() {
    int sum = 0;
    foreach (var item in prints) {
        List<int> pagesToPrint = item.Split(",").Select(int.Parse).ToList();
        if (CheckRow(pagesToPrint)) sum += pagesToPrint[pagesToPrint.Count / 2];
    }


    Console.WriteLine(sum);
}

void PartTwo() {
    int sum = 0;
    foreach (var item in prints) {
        List<int> pagesToPrint = item.Split(",").Select(int.Parse).ToList();
        if (!CheckRow(pagesToPrint)) {
            SortRow(pagesToPrint);
            sum += pagesToPrint[pagesToPrint.Count / 2]; 
        }
    }
    Console.WriteLine(sum);
}

bool CheckRow(List<int> pages) {
    for (int i = 0; i < pages.Count; i++) {
        if (map.ContainsKey(pages[i]) && map[pages[i]].Intersect(pages.Take(i)).Count() > 0) {
            return false;
        }
    }
    return true;
}

void SortRow(List<int> pages) {
    while (!CheckRow(pages)) {
        for (int i = 0; i < pages.Count; i++) {
            if(map.ContainsKey(pages[i]) && map[pages[i]].Intersect(pages.Take(i)).Count() > 0) {
                int temp = pages[i];
                int index = pages.IndexOf(map[pages[i]].Intersect(pages.Take(i)).First());
                pages.RemoveAt(i);
                pages.Insert(index, temp);
                break;
            }
        }
    }
}