using System.Diagnostics;

public class Git
{

    const string FILE_NAME = "run_git.bat";

    public string Branch => _branch;

    string _branch;

    public Git(string branch)
    {
        _branch = branch;
    }

    public void Checkout()
    {
        string cmd = @"
        @echo off
        @git checkout " +
        _branch;

        WriteBat(cmd);
    }

    public void FetchAll()
    {
        string cmd = @"git fetch --all";
        WriteBat(cmd);
    }

    void WriteBat(string cmd)
    {
        string root = AppDomain.CurrentDomain.BaseDirectory;
        string path = Path.Combine(root, FILE_NAME);

        File.WriteAllText(path, cmd);

        Run();
    }

    void Run()
    {
        string bat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME);

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = bat,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = false
        };

        Process process = new Process { StartInfo = startInfo };

        try
        {
            Console.WriteLine("Starting porcess");

            process.Start();
            process.StandardInput.WriteLine($".\\{bat}");
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();

            Console.WriteLine(output);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}