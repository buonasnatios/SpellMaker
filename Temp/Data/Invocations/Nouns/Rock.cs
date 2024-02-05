using System.Collections.Generic;
using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Elements;

namespace SpellMaker.Data.Invocations.Nouns;

public class Rock : IInvocation
{
    public string Name { get; set; } = "Rock";
    public object Addition { get; set; } = new List<object>
    {
        new Earth(), 
        new AddsDamage(6),
        new AddsDuration(1),
        new AddsSize(2)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = new()
    {
        InvocationType.Self,
        InvocationType.Descriptor
    };
}