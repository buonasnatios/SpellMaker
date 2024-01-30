using SpellMaker.Modifiers;
using SpellMaker.Modifiers.Elements;

namespace SpellMaker.Invocations;

public class Heal : IInvocation
{
    public string Name { get; set; } = "Heal";
    public object Addition { get; set; } = new List<object> { new Holy(), new AddsDamage(-3)};
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}