using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Water : IElement
{
    public string ElementName { get; set; } = "Water";
    public ElementType ElementType { get; set; } = ElementType.Water;
    public float WeightModifier { get; set; } = 1.0f;
}