using SpellMaker.Modifiers;

namespace SpellMaker.Invocations;

public class Big : IInvocation
{
    public string Name { get; set; } = "Big";
    public object Addition { get; set; } = new List<object>{
        new MultipliesDamage(1.5f),
        new MultipliesSize(1.5f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}