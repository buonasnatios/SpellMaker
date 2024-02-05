using System.Collections.Generic;
using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Elements;

namespace SpellMaker.Data.Invocations.Nouns;

public class Flame : IInvocation
{
    public string Name { get; set; } = "Flame";
    public object Addition { get; set; } = new List<object>
    {
        new Heat(), 
        new AddsDamage(4),
        new AddsDuration(1),
        new AddsSize(1)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;

    public List<InvocationType> InvocationOrder { get; set; } = new()
    {
        InvocationType.Self,
        InvocationType.Descriptor
    };
}