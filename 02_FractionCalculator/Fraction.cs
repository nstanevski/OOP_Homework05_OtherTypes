using System;

struct Fraction
{
    private long numerator;
    private long denominator;

    public Fraction(long numerator, long denominator):this()
    {
        this.Numerator = numerator;
        this.Denominator = denominator;

    }

    public long Numerator
    {
        get{ return this.numerator; }
        set { this.numerator = value; }
    }

    public long Denominator
    {
        get { return this.denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero");
            }
            this.denominator = value;
        }
    }

    public override string ToString()
    {
        // decimal type applied because of the increased precision in the homework example. 
        decimal numDecimal = (decimal) this.Numerator;
        decimal denDecimal = (decimal) this.Denominator;
        decimal result = numDecimal/denDecimal;
        return string.Format("{0:F27}", result).ToString();
        
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        try
        {
            long newNumerator = checked((f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator));
            long newDenominator = checked(f1.Denominator * f2.Denominator);
            return new Fraction(newNumerator, newDenominator);
        }
        catch (OverflowException)
        {
            throw new InvalidOperationException("Fraction sum is out of range");
        }
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        try
        {
            long newNumerator = checked((f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator));
            long newDenominator = checked(f1.Denominator * f2.Denominator);
            return new Fraction(newNumerator, newDenominator);
        }
        catch (OverflowException)
        {
            throw new InvalidOperationException("Fraction subtraction is out of range");
        }
    }
} 