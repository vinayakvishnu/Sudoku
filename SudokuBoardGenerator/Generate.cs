using System;

class Generate {
  public static void Main(string[] args)
    {
        Grid gameplay = new Grid();
        gameplay.AddNumbers();
        Console.WriteLine();
        Console.WriteLine("COLUMNS:");
        gameplay.printColumns();
        Console.WriteLine("ROWS:");
        gameplay.printRows();
        Console.WriteLine("REGIONS:");
        gameplay.printRegions();
        Console.WriteLine("VALUES:");
        gameplay.print();
    }
}