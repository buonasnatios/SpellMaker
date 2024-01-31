using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;

namespace SpellMaker.Data.Invocations.Adjective;

public class Multiple : IInvocation
{
    public string Name { get; set; } = "Multiple";
    public object Addition { get; set; } = new AddsCasts(1);
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}