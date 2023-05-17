using ArithmeticConstraints.Boxes;

namespace ArithmeticConstraints.Extensions;

public static class IEnumerableExtensions
{
    public static void ConnectAll(
        this IEnumerable<Connector> connectors,
        IBox box)
    {
        foreach (var connector in connectors)
        {
            connector.Connect(box);
        }
    }

    public static void UnsetAllValues(
        this IEnumerable<Connector> connectors,
        IBox box)
    {
        foreach (var connector in connectors)
        {
            connector.UnsetValue(box);
        }
    }

    public static IEnumerable<decimal?> GetValues(
        this IEnumerable<Connector> connectors)
    {
        return connectors.Select(c => c.GetValue());
    }

    public static bool AllHaveValues(
        this IEnumerable<Connector> connectors)
    {
        return connectors.All(c => c.HasValue);
    }

    public static IEnumerable<Connector> ConnectorsWithValue(
        this IEnumerable<Connector> connectors)
    {
        return connectors.Where(c => c.HasValue);
    }

    public static IEnumerable<Connector> ConnectorsWithoutValue(
        this IEnumerable<Connector> connectors)
    {
        return connectors.Where(c => c.HasNoValue);
    }
}
