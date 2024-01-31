using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Adjective;

public class Big : IInvocation
{
    public string Name { get; set; } = "Big";
    public object Addition { get; set; } = new List<object>{
        new MultipliesDamage(1.5f),
        new MultipliesSize(1.5f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;

    public List<InvocationType> InvocationOrder { get; set; } = [];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}