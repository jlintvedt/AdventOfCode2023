using System;
using System.IO;

namespace AdventOfCodeTests.InputHelpers
{
    public static class InputProvider
    {
        private const string RootDirectoryFormat = "AdventOfCode{0}";
        private const string TestDirectoryName = "AdventOfCodeTests";
        private const string InputDirectoryName = "InputPuzzle";
        private const string FilenameFormat = "D{0:00}_Input.txt";
        private const string ExampleInputDirectoryName = "InputExample";
        private const string ExampleFilenameFormat = "D{0:00}_Example_{1}.txt";

        public static string GetInput(int year, int day)
        {
            var path = GetAbsolutePath(year, day);

            // Try getting cached file.
            if (TryReadFile(path, out string content))
            {
                return content;
            }

            // Fetch from web
            try
            {
                content = AocClient.GetInput(year, day);
                WriteFile(path, content);
                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetExample(int year, int day, int exampleNum)
        {
            var path = GetAbsolutePath(year, day, exampleNum);

            // Try getting cached file.
            if (TryReadFile(path, out string content))
            {
                if (content.Length == 0)
                {
                    throw new IOException($"Example file empty: {path}");
                }

                return content;
            }

            throw new FileNotFoundException($"File not found / file is empty: {path}");
        }

        private static bool TryReadFile(string filepath, out string content)
        {
            content = null;
            try
            {
                content = File.ReadAllText(filepath);
                return !string.IsNullOrEmpty(content);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void WriteFile(string filepath, string content)
        {
            File.WriteAllText(filepath, content);
        }

        private static string GetAbsolutePath(int year, int day, int exampleNum = 0)
        {
            var binPath = Directory.GetCurrentDirectory();
            var rootDirName = string.Format(RootDirectoryFormat, year);
            var filename = exampleNum == 0 ? string.Format(FilenameFormat, day) : string.Format(ExampleFilenameFormat, day, exampleNum);
            return Path.Combine(
                binPath[..binPath.IndexOf(rootDirName)],
                rootDirName,
                TestDirectoryName,
                exampleNum == 0 ? InputDirectoryName : ExampleInputDirectoryName,
                filename);
        }
    }
}
