namespace SpellMaker.Data.Modifiers;

public class MultipliesDamage
{
	public MultipliesDamage(float multiplier)
	{
		Multiplier = multiplier;
	}
	public float Multiplier { get; }
}
