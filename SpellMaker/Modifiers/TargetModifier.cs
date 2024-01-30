namespace SpellMaker.Modifiers;

public class TargetModifier(string targetName, Target target)
{
    public string TargetName { get; set; } = targetName;
    public Target Target { get; set; } = target;
}