namespace SpellMaker.Modifiers;

public class AddsDamage
{
    public AddsDamage(int damage)
    {
        Damage = damage;
    }
    public int Damage { get; set; }
}