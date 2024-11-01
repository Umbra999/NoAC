using System.Diagnostics;

namespace NoAnticheat
{
    internal class Entry
    {
        public static void Main(string[] args)
        {
            string exePath = FindUnrealExecutable();
            if (exePath == null) return;

            string arguments = string.Join(" ", args);
            Console.WriteLine($"Launching: {exePath} with arguments: {arguments}");

            ProcessStartInfo startInfo = new()
            {
                FileName = exePath,
                Arguments = arguments
            };

            Process.Start(startInfo);
        }

        private static string FindUnrealExecutable()
        {
            var directories = Directory.GetDirectories(Environment.CurrentDirectory, "*", SearchOption.AllDirectories).Where(d => d.Contains("Binaries") && d.Contains("Win64"));

            foreach (var dir in directories)
            {
                var exeFiles = Directory.GetFiles(dir, "*.exe");
                if (exeFiles.Length > 0)
                {
                    return exeFiles[0];
                }
            }

            return null;
        }

        // TODO: Add Unity Support
    }
}
