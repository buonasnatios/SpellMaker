using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Ice : IElement
{
    public string ElementName { get; set; } = "Ice";
    public ElementType ElementType { get; set; } = ElementType.Ice;
    public float WeightModifier { get; set; } = 1.0f;
}