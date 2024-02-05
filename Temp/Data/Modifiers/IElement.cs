using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers;

public interface IElement
{
    public string ElementName { get; set; }
    public ElementType ElementType { get; set; }
    public float WeightModifier { get; set; }
}