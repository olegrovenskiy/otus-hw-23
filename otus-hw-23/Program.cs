// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var dir = "C:\\Users\\o.rovenskiy\\source\\repos\\otus-hw-23\\otus-hw-23\\Files";

var (file1, file2, file3) = ("file1.txt", "file2.txt", "file3.txt");

CreateFiles();

Task task1 = Task.Run(() =>
{
    CountSpacesInFile(file1);
});
Task task2 = Task.Run(() =>
{
    CountSpacesInFile(file2);
});
Task task3 = Task.Run(() =>
{
    CountSpacesInFile(file3);
});

Task.WaitAll(task1, task2, task3);

Console.WriteLine("Finished");

Console.WriteLine("Find File");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
ReadFile(dir);
stopwatch.Stop();
Console.WriteLine("Время выполнения  " + stopwatch.ElapsedMilliseconds + "  мсек");


Console.WriteLine("End Find File");




void CountSpacesInFile(string s)
{
    var file1Text = File.ReadAllText(s);
    var spaceCount = file1Text.Count(it => it == ' ');
    Console.WriteLine($"File {s} contains {spaceCount} spaces");
}

void CreateFiles()
{
    var file1Content = "hello world";
    var file2Content = "hello great world";
    var file3Content = "hello funny great world";

    File.WriteAllText(file1, file1Content);
    File.WriteAllText(file2, file2Content);
    File.WriteAllText(file3, file3Content);
}


// Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.

void ReadFile (string path)
{
    Console.WriteLine("Hi");
    string[] files = Directory.GetFiles(path);
    var i = 0;
    Task[] tasks = new Task[files.Length];

    foreach (string s in files)
    {
      //  CountSpacesInFile(s);
        Console.WriteLine(s);
        tasks[i] = Task.Run(() =>
        {
            CountSpacesInFile(s);
        });
        i++;
    }
    Task.WaitAll(tasks);

}











Console.ReadKey();
