namespace SpellMaker.Data.Modifiers;

public class AddsDamage(int damage)
{
    public int Damage { get; } = damage;
}