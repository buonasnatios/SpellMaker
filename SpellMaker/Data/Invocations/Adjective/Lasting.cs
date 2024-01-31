using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Adjective;

public class Lasting : IInvocation
{
    public string Name { get; set; } = "Lasting";
    public object Addition { get; set; } = new MultipliesDuration(1.5f);
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}