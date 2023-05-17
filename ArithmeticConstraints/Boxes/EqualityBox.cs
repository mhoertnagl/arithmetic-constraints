namespace ArithmeticConstraints.Boxes;

public class EqualityBox : IBox
{
    private readonly Connector l;
    private readonly Connector r;

    public EqualityBox(Connector l, Connector r)
    {
        this.l = l;
        this.r = r;

        l.Connect(this);
        r.Connect(this);
    }

    public void SetValue()
    {
        var vl = l.GetValue();
        var vr = r.GetValue();

        if (vl.HasValue)
        {
            r.SetValue(vl.Value, this);
        }
        else if (vr.HasValue)
        {
            l.SetValue(vr.Value, this);
        }
    }

    public void UnsetValue()
    {
        l.UnsetValue(this);
        r.UnsetValue(this);
        SetValue();
    }
}
