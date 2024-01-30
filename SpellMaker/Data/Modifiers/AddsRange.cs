namespace SpellMaker.Data.Modifiers;

public class AddsRange(int range)
{
    public int Range { get; set; } = range;
}