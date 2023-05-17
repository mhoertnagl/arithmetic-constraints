using ArithmeticConstraints.Extensions;

namespace ArithmeticConstraints.Boxes;

public class AverageBox : IBox
{
    private readonly IEnumerable<Connector> inputs;
    private readonly Connector output;
    private readonly decimal N;

    public AverageBox(Connector output, params Connector[] inputs)
    {
        this.inputs = inputs;
        this.output = output;

        N = inputs.Length;

        inputs.ConnectAll(this);
        output.Connect(this);
    }

    public AverageBox(Connector output, IEnumerable<Connector> inputs)
    {
        this.inputs = inputs;
        this.output = output;

        N = inputs.Count();

        inputs.ConnectAll(this);
        output.Connect(this);
    }

    public void SetValue()
    {
        var sum = inputs.Aggregate((a, b) => a + b);
        Constraints.Equal(output, sum / N);

        //if (inputs.AllHaveValues())
        //{
        //    var sum = inputs
        //        .GetValues()
        //        .Sum() ?? 0m;

        //    output.SetValue(sum / N, this);
        //} 
        //else if (output.HasValue)
        //{
        //    var missing = inputs.ConnectorsWithoutValue();

        //    if (missing.Count() == 1)
        //    {
        //        var avg = output.GetValue();
        //        var sum = inputs
        //            .ConnectorsWithValue()
        //            .GetValues()
        //            .Sum() ?? 0m;

        //        missing.First().SetValue(avg.Value * N - sum, this);
        //    }
        //}
    }

    public void UnsetValue()
    {
        inputs.UnsetAllValues(this);
        output.UnsetValue(this);

        SetValue();
    }
}
