using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;

namespace SpellMaker.Data.Invocations.Verbs;

public class Throw : IInvocation
{
    public string Name { get; set; } = "Throw";
    public object Addition { get; set; } = new List<object>
    {
        new TargetModifier("NonSelf", Target.NonSelf), 
        new AddsRange(6),
        new AddsSpeed(1)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Verb;

    public List<InvocationType> InvocationOrder { get; set; } =
    [
        InvocationType.Self,
        InvocationType.Noun,
        InvocationType.Target
    ];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.Medium;
}