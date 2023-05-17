using ArithmeticConstraints.Boxes;

namespace ArithmeticConstraints;

public class Connector
{
    private string name;
    private ISet<IBox> boxes;
    private IBox? setter;
    private decimal? value;

    public Connector()
    {
        boxes = new HashSet<IBox>();
        setter = null;
        value = null;
    }

    public Connector(string name)
    {
        this.name = name;
        boxes = new HashSet<IBox>();
        setter = null;
        value = null;
    }

    public bool HasValue => setter is not null;

    public bool HasNoValue => !HasValue;

    public decimal? GetValue() => value;

    public void SetValue(decimal value, IBox setter)
    {
        if (HasNoValue)
        {
            this.setter = setter;
            this.value = value;
            //InformAllBut(setter);
            foreach (var box in boxes)
            {
                if (box != setter)
                {
                    box.SetValue();
                }
            }
        } 
        else if (this.value != value)
        {
            throw new ConstraintException($"Value mismatch -- current: {this.value}, new: {value}");
        }
    }

    public void UnsetValue(IBox setter)
    {
        if (this.setter == setter)
        {
            this.setter = null;
            value = null;
            //InformAllBut(setter);
            foreach (var box in boxes)
            {
                if (box != setter)
                {
                    box.UnsetValue();
                }
            }
        }
    }

    public void Connect(IBox box)
    {
        boxes.Add(box);

        if (HasValue)
        {
            box.SetValue();
        }
    }

    //private void InformAllBut(IBox setter)
    //{
    //    foreach (var box in boxes)
    //    {
    //        if (box != setter)
    //        {
    //            box.SetValue();
    //        }
    //    }
    //}

    public static implicit operator Connector(byte value) => Convert.ToDecimal(value);
    public static implicit operator Connector(short value) => Convert.ToDecimal(value);
    public static implicit operator Connector(int value) => Convert.ToDecimal(value);
    public static implicit operator Connector(long value) => Convert.ToDecimal(value);
    public static implicit operator Connector(float value) => Convert.ToDecimal(value);
    public static implicit operator Connector(double value) => Convert.ToDecimal(value);

    public static implicit operator Connector(decimal value)
    {
        var a = new Connector();
        new ConstantBox(value, a);
        return a;
    }

    public static Connector operator +(Connector a, Connector b)
    {
        var s = new Connector();
        new AdderBox(a, b, s);
        return s;
    }

    public static Connector operator -(Connector s, Connector a)
    {
        var b = new Connector();
        new AdderBox(a, b, s);
        return b;
    }

    public static Connector operator *(Connector a, Connector b)
    {
        var s = new Connector();
        new MultiplierBox(a, b, s);
        return s;
    }

    public static Connector operator /(Connector p, Connector a)
    {
        var b = new Connector();
        new MultiplierBox(a, b, p);
        return b;
    }

    public static bool operator ==(Connector l, Connector r)
    {
        new EqualityBox(l, r);
        return true;
    }

    public static bool operator !=(Connector l, Connector r)
    {
        return false;
    }
}
