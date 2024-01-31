using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Descriptors;

public class Bolt : IInvocation
{
    public string Name { get; set; } = "Bolt";
    public object Addition { get; set; } = new List<object>
    {
        new ChangesShape(SpellShape.Bolt),
        new MultipliesWeight(1.2f)
    };

    public InvocationType InvocationType { get; set; } = InvocationType.Descriptor;
    public List<InvocationType> InvocationOrder { get; set; } = [];
    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}