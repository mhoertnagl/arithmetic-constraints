namespace ArithmeticConstraints.Boxes;

public class AdderBox : IBox
{
    private readonly Connector a;
    private readonly Connector b;
    private readonly Connector s;

    public AdderBox(Connector a, Connector b, Connector s)
    {
        this.a = a;
        this.b = b;
        this.s = s;

        a.Connect(this);
        b.Connect(this);
        s.Connect(this);
    }

    public void SetValue()
    {
        var va = a.GetValue();
        var vb = b.GetValue();
        var vs = s.GetValue();

        if (a.HasValue && b.HasValue)
        {
            s.SetValue(va.Value + vb.Value, this);
        }
        else if (a.HasValue && s.HasValue)
        {
            b.SetValue(vs.Value - va.Value, this);
        }
        else if (b.HasValue && s.HasValue)
        {
            a.SetValue(vs.Value - vb.Value, this);
        }
    }

    public void UnsetValue()
    {
        a.UnsetValue(this);
        b.UnsetValue(this);
        s.UnsetValue(this);

        SetValue();
    }
}
