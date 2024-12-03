using System.Text.RegularExpressions;

PartOne();
PartTwo();

static void PartOne() {
    string input = File.ReadAllText("../../../input.txt");
    string pattern = "mul\\(\\d{1,3},\\d{1,3}\\)";
    Regex regex = new Regex(pattern);
    var data = regex.Matches(input).ToList();
    long sum = 0;

    foreach ( Match item in data ) {
        long[] a = item.Value.Split( ["(", ",", ")"] , StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
        sum += a[0] * a[1];
    }
    Console.WriteLine(sum);
}

static void PartTwo() {
    string input = File.ReadAllText("../../../input.txt");
    string pattern = "mul\\(\\d{1,3},\\d{1,3}\\)|do\\(\\)|don't\\(\\)";
    Regex regex = new Regex(pattern);
    var data = regex.Matches(input).ToList();
    long sum = 0;
    bool state = true;

    foreach (Match item in data) {
        if (item.Value == "do()") { state = true; continue; }
        if (item.Value == "don't()") { state = false; continue; }
        if (state) {
            long[] a = item.Value.Split(["(", ",", ")"], StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
            sum += a[0] * a[1];
        }
    }
    Console.WriteLine(sum);
}