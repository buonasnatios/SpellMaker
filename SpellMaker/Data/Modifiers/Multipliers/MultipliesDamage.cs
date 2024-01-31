namespace SpellMaker.Data.Modifiers;

public class MultipliesDamage(float multiplier)
{
    public float Multiplier { get; } = multiplier;
}