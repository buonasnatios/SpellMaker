using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers;

public class ChangesShape(SpellShape shape)
{
    public SpellShape Shape { get; set; }
}