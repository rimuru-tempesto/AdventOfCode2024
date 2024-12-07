PartOne();
PartTwo();

void PartOne() {
    string[] example = "190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20".Split("\r\n");
    string[] input = File.ReadAllLines("../../../input.txt");
    long res = 0;
    foreach (string row in input) {
        long[] args = row.Split([":", " "], StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        long target = args[0];
        if (TryOperators([Multiply, Sum], target, args.Skip(1).ToArray())) res += target;
    }
    Console.WriteLine(res);
}

long Multiply(long a, long b) => a * b;
long Sum(long a, long b) => a + b;

bool TryOperators(Func<long, long, long>[] operators, long target, long[] nums) => TryOperator(Sum, operators, target, 0, nums, 0);

bool TryOperator(Func<long, long, long> current, Func<long, long, long>[] operators, long target, long a, long[] nums, int index) {
    if (a > target) return false;
    if (index == nums.Length) return a == target;

    long result = current(a, nums[index]);
    return operators.Any(op => TryOperator(op, operators, target, result, nums, index + 1));
}
void PartTwo() {
    string[] input = File.ReadAllLines("../../../input.txt");
    long res = 0;
    foreach (string row in input) {
        long[] args = row.Split([":", " "], StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        long target = args[0];
        if (TryOperators([Multiply, Sum, Concat], target, args.Skip(1).ToArray())) res += target;
    }
    Console.WriteLine(res);
}
long Concat(long a, long b) => long.Parse($"{a}{b}");