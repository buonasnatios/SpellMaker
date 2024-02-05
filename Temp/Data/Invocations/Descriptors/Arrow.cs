using System.Collections.Generic;
using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Descriptors;

public class Arrow : IInvocation
{
    public string Name { get; set; } = "Arrow";

    public object Addition { get; set; } = new List<object>
    {
        new ChangesShape(SpellShape.Arrow),
        new MultipliesSpeed(1.5f),
        new MultipliesRange(1.5f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Descriptor;
    public List<InvocationType> InvocationOrder { get; set; } = new();
}