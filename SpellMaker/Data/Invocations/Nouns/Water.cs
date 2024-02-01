using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;

namespace SpellMaker.Data.Invocations.Nouns;

public class Water : IInvocation
{
    public string Name { get; set; } = "Water";
    public object Addition { get; set; } = new List<object> { new Modifiers.Elements.Water(), new AddsDamage(4) };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = 
    [
        InvocationType.Self,
        InvocationType.Descriptor
    ];
}