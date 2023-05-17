namespace ArithmeticConstraints.Boxes;

public class ConstantBox : IBox
{
    private readonly decimal value;
    private readonly Connector a;

    public ConstantBox(decimal value, Connector a)
    {
        this.value = value;
        this.a = a;

        a.Connect(this);
        a.SetValue(value, this);
    }

    public void SetValue()
    {
        throw new ConstraintException($"Cannot set the value of constant {value}");
    }

    public void UnsetValue()
    {
        throw new ConstraintException($"Cannot unset the value of constant {value}");
    }
}
