using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Additives;

public class With : IInvocation
{
    public string Name { get; set; } = "With";
    public object Addition { get; set; } = new MultipliesCastTime(1.25f);
    public InvocationType InvocationType { get; set; } = InvocationType.Additive;
    public List<InvocationType> InvocationOrder { get; set; } = 
    [
        InvocationType.Self,
        InvocationType.Noun
    ];
}