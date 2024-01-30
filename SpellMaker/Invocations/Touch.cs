namespace SpellMaker.Invocations;

public class Touch : IInvocation
{
    public string Name { get; set; } = "Touch";
    public object Addition { get; set; }
    public InvocationType InvocationType { get; set; } = InvocationType.Verb;

    public List<InvocationType> InvocationOrder { get; set; } =
    [
        InvocationType.Self,
        InvocationType.Target,
        InvocationType.Noun
    ];
}