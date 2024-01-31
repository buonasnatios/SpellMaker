using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;

namespace SpellMaker.Data.Invocations.Verbs;

public class Touch : IInvocation
{
    public string Name { get; set; } = "Touch";
    public object Addition { get; set; } = new List<object>
    {
        new TargetModifier("Any", Target.Any),
        new SetsRange(0)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Verb;

    public List<InvocationType> InvocationOrder { get; set; } =
    [
        InvocationType.Self,
        InvocationType.Target,
        InvocationType.Noun
    ];
}