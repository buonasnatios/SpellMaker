using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Invocations.Adjective;

public class Stunning : IInvocation
{
    public string Name { get; set; }
    public object Addition { get; set; }
    public InvocationType InvocationType { get; set; }
    public List<InvocationType> InvocationOrder { get; set; }

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}