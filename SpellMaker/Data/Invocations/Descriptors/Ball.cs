using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;

namespace SpellMaker.Data.Invocations.Descriptors;

public class Ball : IInvocation
{
    public string Name { get; set; } = "Ball";
    public object Addition { get; set; } = new List<object>
    {
        new ChangesShape(SpellShape.Ball),
        new MultipliesWeight(1.2f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Descriptor;
    public List<InvocationType> InvocationOrder { get; set; } = [];
    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.None;
    //
}