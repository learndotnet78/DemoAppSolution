
using Microsoft.Extensions.FileSystemGlobbing;
using System.IO;

namespace DemoCoreAPI.BackgroundWorker
{
    public class BgWorkerService : BackgroundService
    {
        private FileSystemWatcher fileSystemWatcher = new();

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            fileSystemWatcher.Path = @"E:\\FileLocation\\Input\\";
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            fileSystemWatcher.Filter = "*.txt*";
            fileSystemWatcher.Created += new FileSystemEventHandler(OnFileCreated);
            return Task.CompletedTask;
        }

        static FileStream? WaitForFile(string fullPath, FileMode mode, FileAccess access, FileShare share)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                FileStream? fs = null;
                try
                {
                    fs = new FileStream(fullPath, mode, access, share);
                    return fs;
                }
                catch (IOException)
                {
                    fs?.Dispose();
                    Thread.Sleep(50);
                }
            }

            return null;
        }

        private async void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                await CopyAddedFile(e);
            }
        }

        private async Task CopyAddedFile(FileSystemEventArgs e)
        {
            string? strValue = DateTime.Now.ToString("HHmmss");
            try
            {
                var files = new DirectoryInfo(@"E:\\FileLocation\\Input\\").GetFiles("*.txt");
                var outputPath = "E:\\FileLocation\\Output\\OutputFile.txt";
                var archivePath = $"E:\\FileLocation\\Archive\\OutputFile{strValue}.txt";

                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {
                        string[] allData = File.ReadAllLines(file.FullName);
                        File.Open(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        File.AppendAllLines(outputPath, allData);
                        File.Move(file.FullName, archivePath, true);
                        File.Delete(file.FullName);
                    }
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task HandleAddedFile(FileSystemEventArgs e)
        {
            FileStream? fileStream = null;
            string? strValue = DateTime.Now.ToString("HHmmss");
            try
            {
                fileStream = WaitForFile(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await Task.Run(() =>
                {
                    using (var outputfileStream = new FileStream($"E:\\FileLocation\\Output\\OutputFile{strValue}.txt", FileMode.Create, FileAccess.Write))
                    {
                        fileStream.CopyTo(outputfileStream);
                    }
                });

            }
            catch (Exception ex)
            {
                throw ex;   
            }
            fileStream?.Dispose();

        }
    }
}
