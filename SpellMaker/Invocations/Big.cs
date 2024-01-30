namespace SpellMaker.Invocations;

public class Big : IInvocation
{
    public string Name { get; set; } = "Big";
    public object Addition { get; set; }
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}