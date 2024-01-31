using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Elements;

namespace SpellMaker.Data.Invocations.Nouns;

public class Rock : IInvocation
{
    public string Name { get; set; } = "Rock";
    public object Addition { get; set; } = new List<object> { new Earth(), new AddsDamage(6) };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = 
    [
        InvocationType.Adjective,
        InvocationType.Self,
        InvocationType.Descriptor
    ];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.MediumAvailable;
}