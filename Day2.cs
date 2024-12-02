
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args) {
        PartOne();
        PartTwo();
    }

    private static void PartOne() {
        string[] input = File.ReadAllLines("../../../input.txt");
        int counter = 0;
        foreach (string line in input) {
            List<int> nums = line.Split(" ").Select(int.Parse).ToList();
            if (IsLineSafe(nums)) { counter++; }
        }
        Console.WriteLine(counter);
    }

    private static void PartTwo() {
        string[] input = File.ReadAllLines("../../../input.txt");
        int counter = 0;
        foreach (string line in input) {
            List<int> nums = line.Split(" ").Select(int.Parse).ToList();
            if (IsLineSafe(nums)) counter++;
            else if (ProblemDampener(nums)) counter++;
        }
        Console.WriteLine(counter);
    }

    private static bool IsLineSafe(List<int> list) {
        bool ascending = true;
        bool descending = true;

        for (int i = 0; i < list.Count - 1; i++) {
            if (list[i] >= list[i + 1]) ascending = false;
            if (list[i] <= list[i + 1]) descending = false;
            if (Math.Abs(list[i] - list[i + 1]) < 1 || Math.Abs(list[i] - list[i + 1]) > 3) {
                return false;
            }
        }

        return ascending || descending;
    }

    private static bool ProblemDampener(List<int> list) {
        for (int i = 0; i < list.Count; i++) {
            var temp = list.Where((val, index) => index != i).ToList();
            if (IsLineSafe(temp)) return true;
        }
        return false;
    }
}