PartOne();
PartTwo();

static void PartOne() {
    string[] input = File.ReadAllLines("../../../input.txt");
    List<int> first = new List<int>();
    List<int> second = new List<int>();
    foreach (var row in input) {
        first.Add(int.Parse(row.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]));
        second.Add(int.Parse(row.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
    }
    first = first.OrderBy(x => x).ToList();
    second = second.OrderBy(x => x).ToList();
    int sum = 0;
    for (int i = 0; i < first.Count; i++) {
        sum += Math.Abs(first[i] - second[i]);
    }
    Console.WriteLine(sum);
}

static void PartTwo() {
    string[] input = File.ReadAllLines("../../../input.txt");
    List<int> first = new List<int>();
    List<int> second = new List<int>();
    foreach (var row in input) {
        first.Add(int.Parse(row.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]));
        second.Add(int.Parse(row.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
    }
    first = first.Where(second.Contains).ToList();
    second = second.Where(first.Contains).ToList();
    int sum = 0;
    foreach (var group in second.GroupBy(x => x)) {
        sum += group.Key * group.Count();
    }
    Console.WriteLine(sum);
}
