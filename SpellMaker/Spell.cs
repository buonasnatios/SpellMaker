using SpellMaker.Data.Enums;
using SpellMaker.Data.Invocations;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker;

public class Spell(List<IInvocation> invocations, string spellName)
{
    public Spell(string spellName) : this([], spellName)
    {
    }
    

    public List<IInvocation> Invocations { get; set; } = invocations;
    public string SpellName { get; set; } = spellName;
    
    public float Size { get; set; } = 1.0f;
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float Weight { get; set; }
    public float Duration { get; set; } = 1.0f;
    public float Range { get; set; } = 1;
    public float CastTime { get; set; } = 0;
    public int Casts { get; set; } = 1;
    public float StunMultiplier = 1.0f;

    public float Stun => Piercing * StunMultiplier;
    public float Piercing  => (Weight+Speed)/2;
    public SpellShape SpellShape { get; set; }
    public ElementType? ElementType { get; set; }
    public Target? Target { get; set; }
    public string SpellSentence => new SpellSentenceGenerator(this).GenerateSentence();
    public List<InvocationType> SpellOrder { get; set; } = [];

    private InvocationType CurrentSpellType()
    {
        return SpellOrder.Count == Invocations.Count ? InvocationType.None : SpellOrder[Invocations.Count];
    } 

    public bool AddInvocation(IInvocation? invocation)
    {
        if (invocation is null)
        {
            throw new NullReferenceException("Invocation that you are trying to add is not valid.");
        }

        if (Invocations.Contains(invocation)) return false;
        if (!AddToSpellOrder(invocation)) return false;
        
        Invocations.Add(invocation);
        ImplementAdditionEffects(invocation.Addition);
        return true;
    }

    private bool AddToSpellOrder(IInvocation invocation)
    {
        if (SpellOrder.Count == 0 && invocation.InvocationOrder.Count > 0)
        {
            SpellOrder.AddRange(invocation.InvocationOrder);
            SpellOrder[^invocation.InvocationOrder.Count] = invocation.InvocationType;
            return true;
        }

        if (invocation.InvocationType == CurrentSpellType())
        {
            if (invocation.InvocationOrder.Count > 0)
            {
                
            }
            return true;
        }
        
        var isNotAdjectiveNounPairing = invocation.InvocationType != InvocationType.Adjective || CurrentSpellType() != InvocationType.Noun;
        if (isNotAdjectiveNounPairing) return false;
        if (invocation.InvocationOrder.Count != 0)
        {
            SpellOrder.AddRange(invocation.InvocationOrder);
            SpellOrder[^invocation.InvocationOrder.Count] = invocation.InvocationType;
            return true;
        }
        
        SpellOrder.Insert(Invocations.Count, invocation.InvocationType);
        return true;
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