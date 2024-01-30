namespace SpellMaker.Modifiers.Elements;

public class Holy : IElement
{
    public string ElementName { get; set; } = "Holy";
    public ElementType ElementType { get; set; } = ElementType.Holy;
}