using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

namespace NeoCraftCLI
{
    public class ShellHandler
    {
        public static void ExCmd(string cmd)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                
                // Configure the process based on the operating system
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + cmd;
                }
                else
                {
                    startInfo.FileName = "/bin/bash";
                    startInfo.Arguments = "-c \"" + cmd + "\"";
                }
                
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;
                
                using (Process process = Process.Start(startInfo))
                {
                    // Read output and error streams
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    
                    process.WaitForExit();
                    
                    // Display output
                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        Console.WriteLine("Output:");
                        Console.WriteLine(output);
                    }
                    
                    // Display errors if any
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        Console.WriteLine("Error:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(error);
                        Console.ResetColor();
                    }
                    
                    // Display exit code
                    Console.WriteLine($"Exit Code: {process.ExitCode}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception occurred: {ex.Message}");
                Console.ResetColor();
            }
        }
        
        // Optional: Async version for better performance
        public static async Task ExCmdAsync(string cmd)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + cmd;
                }
                else
                {
                    startInfo.FileName = "/bin/bash";
                    startInfo.Arguments = "-c \"" + cmd + "\"";
                }
                
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;
                
                using (Process process = Process.Start(startInfo))
                {
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    
                    await process.WaitForExitAsync();
                    
                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        Console.WriteLine("Output:");
                        Console.WriteLine(output);
                    }
                    
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        Console.WriteLine("Error:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(error);
                        Console.ResetColor();
                    }
                    
                    Console.WriteLine($"Exit Code: {process.ExitCode}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception occurred: {ex.Message}");
                Console.ResetColor();
            }
        }
        
        // Optional: Version that returns output as string instead of printing
        public static string ExCmdReturnOutput(string cmd)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + cmd;
                }
                else
                {
                    startInfo.FileName = "/bin/bash";
                    startInfo.Arguments = "-c \"" + cmd + "\"";
                }
                
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;
                
                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    
                    process.WaitForExit();
                    
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        throw new Exception($"Command failed with error: {error}");
                    }
                    
                    return output;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to execute command: {ex.Message}");
            }
        }
    }
}