namespace ArithmeticConstraints.Boxes;

public class MultiplierBox : IBox
{
    private readonly Connector a;
    private readonly Connector b;
    private readonly Connector p;

    public MultiplierBox(Connector a, Connector b, Connector p)
    {
        this.a = a;
        this.b = b;
        this.p = p;

        a.Connect(this);
        b.Connect(this);
        p.Connect(this);
    }

    public void SetValue()
    {
        var va = a.GetValue();
        var vb = b.GetValue();
        var vp = p.GetValue();

        if (va.HasValue && va.Value == 0)
        {
            p.SetValue(0, this);
        }
        else if (vb.HasValue && vb.Value == 0)
        {
            p.SetValue(0, this);
        }
        else if (va.HasValue && vb.HasValue)
        {
            p.SetValue(va.Value * vb.Value, this);
        }
        else if (va.HasValue && vp.HasValue)
        {
            b.SetValue(vp.Value / va.Value, this);
        }
        else if (vb.HasValue && vp.HasValue)
        {
            a.SetValue(vp.Value / vb.Value, this);
        }
    }

    public void UnsetValue()
    {
        a.UnsetValue(this);
        b.UnsetValue(this);
        p.UnsetValue(this);

        SetValue();
    }
}
