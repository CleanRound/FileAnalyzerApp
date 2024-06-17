class FileAnalyzerApp
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the path to the file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            List<int> numbers = lines.Select(int.Parse).ToList();

            var positiveNumbers = numbers.Where(n => n > 0).ToList();
            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            var twoDigitNumbers = numbers.Where(n => n >= 10 && n < 100 || n <= -10 && n > -100).ToList();
            var fiveDigitNumbers = numbers.Where(n => n >= 10000 && n < 100000 || n <= -10000 && n > -100000).ToList();

            Console.WriteLine($"Number of positive numbers: {positiveNumbers.Count}");
            Console.WriteLine($"Number of negative numbers: {negativeNumbers.Count}");
            Console.WriteLine($"Number of two-digit numbers: {twoDigitNumbers.Count}");
            Console.WriteLine($"Number of five-digit numbers: {fiveDigitNumbers.Count}");

            string directory = Path.GetDirectoryName(filePath);
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            File.WriteAllLines(Path.Combine(directory, $"{filename}_positive{extension}"), positiveNumbers.Select(n => n.ToString()));
            File.WriteAllLines(Path.Combine(directory, $"{filename}_negative{extension}"), negativeNumbers.Select(n => n.ToString()));
            File.WriteAllLines(Path.Combine(directory, $"{filename}_twoDigit{extension}"), twoDigitNumbers.Select(n => n.ToString()));
            File.WriteAllLines(Path.Combine(directory, $"{filename}_fiveDigit{extension}"), fiveDigitNumbers.Select(n => n.ToString()));

            Console.WriteLine("Analysis complete. Files with categorized numbers have been created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
