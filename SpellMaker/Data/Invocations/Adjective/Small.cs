using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Adjective;

public class Small : IInvocation
{
    public string Name { get; set; } = "Small";

    public object Addition { get; set; } = new List<object>
    {
        new MultipliesSize(0.5f),
        new MultipliesSpeed(2.0f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}