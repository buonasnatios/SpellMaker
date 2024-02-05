using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Modifiers;

public class TargetModifier
{
	public TargetModifier(string targetName, Target target)
	{
		TargetName = targetName;
		Target = target;
	}
	public string TargetName { get; set; }
	public Target Target { get; set; }
}
