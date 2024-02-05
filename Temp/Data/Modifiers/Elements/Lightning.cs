using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Lightning : IElement
{
    public string ElementName { get; set; } = "Lightning";
    public ElementType ElementType { get; set; } = ElementType.Lightning;
    public float WeightModifier { get; set; } = 0.0f;
}