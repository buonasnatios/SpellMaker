using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Invocations.Adjective;

public class Small : IInvocation
{
    public string Name { get; set; }
    public object Addition { get; set; }
    public InvocationType InvocationType { get; set; }
    public List<InvocationType> InvocationOrder { get; set; }
}