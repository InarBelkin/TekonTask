// See https://aka.ms/new-console-template for more information

using TekonTask;

var text = Console.ReadLine() ?? "";

var pencilBox = new List<Pen>();

var leftPenColors = Enumerable.Range(1, 15).Select(i => (ConsoleColor)i).ToList();
leftPenColors.Remove(ConsoleColor.Gray);
leftPenColors.Remove(ConsoleColor.DarkGray);
leftPenColors.Remove(ConsoleColor.White);


for (int i = 0; i < Random.Shared.Next(2, 5); i++)
{
    var color = leftPenColors[Random.Shared.Next(leftPenColors.Count)];
    pencilBox.Add(new Pen()
        { Capacity = Random.Shared.Next(5, 16), InkColor = color });
    leftPenColors.Remove(color);
}

foreach (var c in text)
{
    var pen = pencilBox.FirstOrDefault(p => p.Capacity > 0);
    Console.ForegroundColor = pen?.InkColor ?? ConsoleColor.Gray;
    Console.Write(c);
    if (pen is not null && c != ' ') pen.Capacity--;
}

Console.ReadKey();