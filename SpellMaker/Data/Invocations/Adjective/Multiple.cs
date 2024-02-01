using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Adjective;

public class Multiple : IInvocation
{
    public string Name { get; set; } = "Multiple";

    public object Addition { get; set; } = new List<object>
    {
        new AddsCasts(1),
        new MultipliesDamage(0.75f),
        new MultipliesSize(0.75f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}