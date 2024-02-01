using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Cold : IElement
{
    public string ElementName { get; set; } = "Cold";
    public ElementType ElementType { get; set; } = ElementType.Cold;
    public float WeightModifier { get; set; } = 0.0f;
}