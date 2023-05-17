using ArithmeticConstraints.Boxes;

namespace ArithmeticConstraints;

public static class Constraints
{
    private static IBox me = new MeBox();

    public static Connector Variable() => new Connector();

    public static Connector Variable(string name) => new Connector(name);

    public static void Probe(string name, Connector variable) => new ProbeBox(name, variable);

    public static void Set(Connector variable, decimal value) => variable.SetValue(value, me);

    public static void Unset(Connector variable) => variable.UnsetValue(me);

    public static void Equal(Connector l, Connector r) => new EqualityBox(l, r);

    private class MeBox : IBox
    {
        public void SetValue() { throw new ConstraintException("setValue -- MeBox"); }

        public void UnsetValue() { throw new ConstraintException("unsetValue -- MeBox"); }
    }
}
