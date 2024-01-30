using SpellMaker.Modifiers.Elements;

namespace SpellMaker.Modifiers;

public interface IElement
{
    public string ElementName { get; set; }
    public ElementType ElementType { get; set; }
}