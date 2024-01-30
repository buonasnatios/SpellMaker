using SpellMaker.Modifiers;
using SpellMaker.Modifiers.Elements;

namespace SpellMaker.Invocations;

public class Flame : IInvocation
{
    public string Name { get; set; } = "Flame";
    public object Addition { get; set; } = new List<object> { new Fire(), new AddsDamage(4) };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}