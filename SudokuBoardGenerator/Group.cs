using System;

public class Group
{
	private Cell[] column;
	private Cell[] row;
	private Cell[] region;
	private int columnCounter;
	private int rowCounter;
	private int regionCounter;
	public Group()
	{
		this.column = new Cell[9];
		this.row = new Cell[9];
		this.region = new Cell[9];
		this.columnCounter = 0;
		this.rowCounter = 0;
		this.regionCounter = 0;
	}
	
	public void SetColumn(Cell[] column)
	{
		this.column = column;
	}
	public void SetRow(Cell[] row)
	{
		this.row = row;
	}
	public void SetRegion(Cell[] region)
	{
		this.region = region;
	}
	public int CheckColumnCounter()
    {
		return this.columnCounter;
    }
	public int AdvanceColumnCounter()
    {
		return this.columnCounter++;
    }
	public int checkRowCounter()
    {
		return this.rowCounter;
    }
	public int AdvanceRowCounter()
	{
		return this.rowCounter++;
	}
	public int checkRegionCounter()
    {
		return this.regionCounter;
    }
	public int AdvanceRegionCounter()
	{
		return this.regionCounter++;
	}

	public Cell[] GetColumn()
    {
		return this.column;
    }
	public Cell[] GetRow()
	{
		return this.row;
	}
	public Cell[] GetRegion()
	{
		return this.region;
	}

	public void AddCellToColumn(int p, Cell c)
    {
		this.column[p] = c;
    }

	public void AddCellToRow(int p, Cell c)
	{
		this.row[p] = c;
	}

	public void AddCellToRegion(int p, Cell c)
	{
		this.region[p] = c;
	}
}
