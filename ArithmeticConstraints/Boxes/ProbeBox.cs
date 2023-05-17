namespace ArithmeticConstraints.Boxes;

public class ProbeBox : IBox
{
    private readonly string name;
    private readonly Connector a;

    public ProbeBox(string name, Connector a)
    {
        this.name = name;
        this.a = a;

        a.Connect(this);
    }

    public void SetValue() => Print(a.GetValue());

    public void UnsetValue() => Print(a.GetValue());

    private void Print(decimal? value)
    {
        if (value.HasValue)
        {
            Console.WriteLine($"Probe: {name} = {value}");
        }
        else
        {
            Console.WriteLine($"Probe: {name} = ?");
        }
    }
}
