using System.Reflection;
using SpellMaker.Modifiers;

namespace SpellMaker.Invocations;

public class Throw : IInvocation
{
    public string Name { get; set; } = "Throw";
    public object Addition { get; set; } = new List<object>{new TargetModifier("NonSelf", Target.NonSelf), new AddsRange(6)};
    public InvocationType InvocationType { get; set; } = InvocationType.Verb;

    public List<InvocationType> InvocationOrder { get; set; } =
    [
        InvocationType.Self,
        InvocationType.Noun,
        InvocationType.Target
    ];
}