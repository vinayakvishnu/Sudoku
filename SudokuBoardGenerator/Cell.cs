using System;

public class Cell
{
	private int col;
	private int row;
	private int reg;
	private int number;
	private int guess;
	private bool preFilled;

	public Cell(int col, int row, int number = 0, int guess = 0, bool preFilled = false)
	{
		this.col = col;
		this.row = row;				
		this.number = number;
		this.guess = guess;
		this.preFilled = preFilled;
	}

	public int GetCol()
	{
		return col;
	}

	public void SetCol(int c)
	{
		this.row = c;
	}

	public int GetRow()
    {
		return row;
    }

	public void SetRow(int r)
	{
		this.row = r;
	}

	public int GetRegNum()
	{
		return reg;
	}

	public void SetRegNum(int r)
	{
		this.reg = r;
	}

	public int GetNumber()
    {
		return number;
    }

	public void SetNumber(int n)
    {
		this.number = n;
    }

	public int GetGuess()
	{
		return guess;
	}

	public void SetGuess(int g)
	{
		this.guess = g;
	}

	public bool CheckIfGuessed()
    {
		if (this.guess == 0)
        {
			return false;
        }
		return true;
    }

	public void ResetGuess()
    {
		this.guess = 0;
    }

	public bool CheckIfPreFilled()
    {
		return preFilled;
    }

	public void TogglePreFilled(bool p)
    {
		this.preFilled = p;
    }
}
