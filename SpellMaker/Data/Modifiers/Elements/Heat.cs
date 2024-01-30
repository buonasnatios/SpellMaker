using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Heat : IElement
{
    public string ElementName { get; set; } = "Heat";
    public ElementType ElementType { get; set; } = ElementType.Heat;
    public float WeightModifier { get; set; } = 0.0f;
}