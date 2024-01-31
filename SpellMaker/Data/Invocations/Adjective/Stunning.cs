using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;

namespace SpellMaker.Data.Invocations.Adjective;

public class Stunning : IInvocation
{
    public string Name { get; set; } = "Stunning";
    public object Addition { get; set; } = new AddsStunMultiplier(2.0f);
    public InvocationType InvocationType { get; set; } = InvocationType.Adjective;
    public List<InvocationType> InvocationOrder { get; set; } = [];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
}