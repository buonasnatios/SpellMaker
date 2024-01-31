using SpellMaker.Data.Enums;
using SpellMaker.Data.Invocations;
using SpellMaker.Data.Modifiers;

namespace SpellMaker;

public class Spell(List<IInvocation> invocations, string spellName)
{
    public Spell(string spellName) : this([], spellName)
    {
    }
    

    public List<IInvocation> Invocations { get; set; } = invocations;
    public string SpellName { get; set; } = spellName;
    
    public float Size { get; set; } = 1f;
    public float Damage { get; set; } = 0.0f;
    public float Speed { get; set; } = 0.0f;
    public float Weight { get; set; } = 0.0f;
    public float Duration { get; set; } = 1.0f;
    public float Range { get; set; } = 1;
    public float CastTime { get; set; } = 0;
    public int Casts { get; set; } = 1;

    public float Piercing  => (Weight+Speed)/2;
    public SpellShape SpellShape { get; set; }
    public ElementType? ElementType { get; set; }
    public Target? Target { get; set; }
    public string SpellSentence => new SpellSentenceGenerator(this).GenerateSentence();

    public int AddInvocation(IInvocation? invocation)
    {
        if (invocation is null)
        {
            return 1;
        }
        Invocations.Add(invocation);
        ImplementAdditionEffects(invocation.Addition);
        return 0;
    }
    
    private void ImplementAdditionEffects(object addition)
    {
        switch (addition)
        {
            //Setters
            case ChangesShape shape: 
                SpellShape = shape.Shape;
                break;
            case IElement element:
                ElementType = ElementType is null ? element.ElementType : CombineElements(element.ElementType);
                Weight = element.WeightModifier;
                break;
            case TargetModifier targetModifier: 
                Target = targetModifier.Target;
                break;
            
            case SetsRange setsRange:
                Range = setsRange.Range;
                break;
            
            //Multipliers
            case MultipliesDamage multipliesDamage:
                Damage *= multipliesDamage.Multiplier;
                break;
            case MultipliesDuration multipliesDuration:
                Duration *= multipliesDuration.Multiplier;
                break;
            case MultipliesSize multipliesSize:
                Size *= multipliesSize.Multiplier;
                break;
            case MultipliesSpeed multipliesSpeed:
                Speed *= multipliesSpeed.Multiplier;
                break;
            case MultipliesWeight multipliesWeight:
                Weight *= multipliesWeight.Multiplier;
                break;
            
            //Additions
            case AddsCasts addsCasts:
                Casts += addsCasts.Casts;
                break;
            case AddsDamage addsDamage:
                Damage += addsDamage.Damage;
                break;
            case AddsRange addsRange:
                Range += addsRange.Range;
                break;
            case AddsSpeed addsSpeed:
                Speed += addsSpeed.Speed;
                break;
            
            case List<object> list:
                foreach (var item in list)
                {
                    ImplementAdditionEffects(item);
                }

                break;
        }
    }

    private ElementType? CombineElements(ElementType elementType)
    {
        switch (ElementType)
        {
            case Data.Enums.ElementType.Cold:
                break;
            case Data.Enums.ElementType.Earth:
                break;
            case Data.Enums.ElementType.Heat:
                break;
            case Data.Enums.ElementType.Holy:
                break;
            case Data.Enums.ElementType.Lightning:
                break;
            case Data.Enums.ElementType.Water:
                break;
            case Data.Enums.ElementType.Ice:
                break;
            case Data.Enums.ElementType.Demonic:
                break;
            case Data.Enums.ElementType.Air:
                break;
            case Data.Enums.ElementType.Lava:
                break;
            case Data.Enums.ElementType.Plasma:
                break;
            case null:
                throw new ArgumentOutOfRangeException(nameof(elementType), elementType, null);
            default:
                throw new ArgumentOutOfRangeException(nameof(elementType), elementType, null);
        }

        return elementType;
    }
}