namespace SpellMaker.Modifiers.Elements;

public class Physical : IElement
{
    public string ElementName { get; set; } = "Physical";
    public ElementType ElementType { get; set; } = ElementType.Physical;
}