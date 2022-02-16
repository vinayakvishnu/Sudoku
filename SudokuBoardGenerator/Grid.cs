using System;
using System.Linq;

public class Grid
{
    private Cell[,] grid;
    private Group[] groups;

    public Grid()
    {
        this.grid = new Cell[9, 9];

        for (int col = 0; col < 9; col++)
        {
            for (int row = 0; row < 9; row++)
            {
                this.grid[col, row] = new Cell(col, row);
            }
        }

        this.groups = new Group[9];

        for (int i = 0; i < 9; i++)
        {
            this.groups[i] = new Group();
        }
    }

    public void SetGrid(Cell[,] g)
    {
        this.grid = g;
    }
    
    public void SetCellNumber(int c, int r, int n)
    {
        this.grid[c, r].SetNumber(n);
    }

    public Cell GetCell(int c, int r)
    {
        return this.grid[c, r];
    }
    public Cell[,] GetGrid()
    {
        return this.grid;
    }

    public void SetGroups(Group[] g)
    {
        this.groups = g;
    }

    public Group[] GetGroups()
    {
        return this.groups;
    }

    public int GetNumber(int c, int r)
    {
        return this.grid[c, r].GetNumber();
    }

    public void SetNumber(int c, int r, int n)
    {
        this.grid[c, r].SetNumber(n);
    }
    public void AddNumbers()
    {
        int[] potentialNumbers;
        int potentialNumber, reg;
        Cell[] relevantColumn, relevantRow, relevantRegion;

        for (int col = 0; col < 9; col++)
        {
            for (int row = 0; row < 9; row++)
            {
                reg = whichRegion(col, row);
                relevantColumn = groups[col].GetColumn();
                relevantRow = groups[row].GetRow();
                relevantRegion = groups[reg].GetRegion();
                potentialNumbers = resetPotentialNumbers();
                potentialNumber = randomNumber(potentialNumbers);
                while (potentialNumbers.Length > 0 && checkDivisions(relevantColumn, relevantRow, relevantRegion, potentialNumber))
                {                    
                    potentialNumbers = potentialNumbers.Where(potentialNumbers => potentialNumbers != potentialNumber).ToArray();
                    if (potentialNumbers.Length == 0)
                    {
                        potentialNumber = 0;
                    }
                    else
                    {
                        potentialNumber = randomNumber(potentialNumbers);
                    }                         
                }
                SetCellNumber(col, row, potentialNumber);
                groups[col].AddCellToColumn(groups[col].AdvanceColumnCounter(), GetCell(col,row));
                groups[row].AddCellToRow(groups[row].AdvanceRowCounter(), GetCell(col, row));
                groups[reg].AddCellToRegion(groups[reg].AdvanceRegionCounter(), GetCell(col, row));
            }
        }
    }

    public int randomNumber(int[] numbers)
    {
        int index, number;
        Random random = new Random();
        index = random.Next(0, numbers.Length);
        number = numbers[index];
        return number;
    }

    public bool checkDivisions(Cell[] column, Cell[] row, Cell[] region, int number)
    {

        if ((Array.Exists(column, cell => cell != null && cell.GetNumber() == number)) || (Array.Exists(row, cell => cell != null && cell.GetNumber() == number)) || (Array.Exists(region, cell => cell != null && cell.GetNumber() == number)))
        {
            return true;
        }
        return false;
    }

    public int[] resetPotentialNumbers()
    {
        int[] possibleNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        return possibleNumbers;
    }

    public int whichRegion(int col, int row)
    {
        int reg = -1;
        
        if ((0 <= col && col <=2) && (0<= row && row <= 2))
        {
            reg = 0;
        }

        else if ((3 <= col && col <= 5) && (0 <= row && row <= 2))
        {
            reg = 1;
        }

        else if ((6 <= col && col <= 8) && (0 <= row && row <= 2))
        {
            reg = 2;
        }

        else if ((0 <= col && col <= 2) && (3 <= row && row <= 5))
        {
            reg = 3;
        }

        else if ((3 <= col && col <= 5) && (3 <= row && row <= 5))
        {
            reg = 4;
        }

        else if ((6 <= col && col <= 8) && (3 <= row && row <= 5))
        {
            reg = 5;
        }

        else if ((0 <= col && col <= 2) && (6 <= row && row <= 8))
        {
            reg = 6;
        }

        else if ((3 <= col && col <= 5) && (6 <= row && row <= 8))
        {
            reg = 7;
        }

        else if ((6 <= col && col <= 8) && (6 <= row && row <= 8))
        {
            reg = 8;
        }

        return reg;
    }

    public bool CheckIfGuessed(int c, int r)
    {
        return this.grid[c, r].CheckIfGuessed();
    }

    public bool CheckIfPreFilled(int c, int r)
    {
        return this.grid[c, r].CheckIfPreFilled();
    }

    public void display()
    {
        string output = "\n  ";
        string square = " ";
        for (int collabel = 0; collabel < 9; collabel++)
        {
            output += " " + collabel + " ";
        }
        output += "\n";
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (CheckIfPreFilled(col, row) || CheckIfGuessed(col, row))
                {
                    square = $"{GetNumber(col, row)}";
                }
                else
                {
                    square = " ";
                }
                if (col == 0)
                {
                    output += row + " [" + square + "]";
                }
                else
                {
                    output += "[" + square + "]";
                }
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }

    public void print()
    {
        string output = "\n  ";
        string square = " ";
        for (int collabel = 0; collabel < 9; collabel++)
        {
            output += " " + collabel + " ";
        }
        output += "\n";
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                square = $"{GetNumber(col, row)}";
                if (col == 0)
                {
                    output += row + " [" + square + "]";
                }
                else
                {
                    output += "[" + square + "]";
                }
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }

    public void printColumns()
    {
        string output = "\n  ";
        string square = " ";
        for (int collabel = 0; collabel < 9; collabel++)
        {
            output += " " + collabel + " ";
        }
        output += "\n";
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                square = $"{col}";
                if (col == 0)
                {
                    output += row + " [" + square + "]";
                }
                else
                {
                    output += "[" + square + "]";
                }
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }

    public void printRows()
    {
        string output = "\n  ";
        string square = " ";
        for (int collabel = 0; collabel < 9; collabel++)
        {
            output += " " + collabel + " ";
        }
        output += "\n";
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                square = $"{row}";
                if (col == 0)
                {
                    output += row + " [" + square + "]";
                }
                else
                {
                    output += "[" + square + "]";
                }
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }

    public void printRegions()
    {
        string output = "\n  ";
        string square = " ";
        for (int collabel = 0; collabel < 9; collabel++)
        {
            output += " " + collabel + " ";
        }
        output += "\n";
        int reg;
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                reg = whichRegion(col, row);
                square = $"{reg}";
                if (col == 0)
                {
                    output += row + " [" + square + "]";
                }
                else
                {
                    output += "[" + square + "]";
                }
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }
}
