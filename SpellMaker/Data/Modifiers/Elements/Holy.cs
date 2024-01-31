using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers.Elements;

public class Holy : IElement
{
    public string ElementName { get; set; } = "Holy";
    public ElementType ElementType { get; set; } = ElementType.Holy;
    public float WeightModifier { get; set; } = 0.0f;
}