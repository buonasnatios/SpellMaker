using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Earth : IElement
{
    public string ElementName { get; set; } = "Earth";
    public ElementType ElementType { get; set; } = ElementType.Earth;
    public float WeightModifier { get; set; } = 2.0f;
}