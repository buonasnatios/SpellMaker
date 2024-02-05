using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers;

public class ChangesShape
{
	public ChangesShape(SpellShape shape)
	{
		Shape = shape;
	}
	public SpellShape Shape { get; set; }
}
