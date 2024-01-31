using SpellMaker.Data.Enums;
using SpellMaker.Data.Invocations;
using SpellMaker.Data.Modifiers;

namespace SpellMaker;

public class Spell(List<IInvocation> invocations, string spellName)
{
    public Spell(string spellName) : this([], spellName)
    {
    }

    private List<IInvocation> Invocations { get; set; } = invocations;
    public string SpellName { get; set; } = spellName;
    public string SpellSentence => GetSpellSentence();
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
    private Target? Target { get; set; }

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

    private string GetSpellSentence()
    {
        var sentence = AggregateInvocations();
        sentence = AddTarget(sentence);
        sentence = AddSpellStats(sentence);

        return sentence;
    }

    private string AddSpellStats(string sentence)
    {
        sentence = AddDamageText(sentence);
        sentence = AddSizeText(sentence);
        sentence = AddRangeText(sentence);
        sentence = EndSentence(sentence);
        return sentence;
    }

    private IEnumerable<IInvocation> GetOrderedInvocation()
    {
        List<IInvocation> invocations = [];
        foreach (var invocation in Invocations)
        {
            if (invocation is { InvocationOrder.Count: > 0 })
            {
                invocations.Add(invocation);
            }
        }

        return invocations;
    }

    private static string EndSentence(string sentence)
    {
        return sentence.Remove(sentence.Length - 1, 1) + ".";
    }

    private string AggregateInvocations()
    {
        return Invocations.Aggregate("", (current, invocation) =>
        {
            return current + invocation.InvocationType switch
            {
                InvocationType.Noun => $"{invocation.Name} ",
                InvocationType.Verb => $"{invocation.Name} ",
                InvocationType.Adjective => $"{invocation.Name} ",
                InvocationType.Target => "",
                InvocationType.Self => "",
                _ => throw new ArgumentOutOfRangeException()
            };
        });
    }

    private string AddTarget(string sentence)
    {
        switch (Target)
        {
            case Data.Enums.Target.Self:
                return sentence + "yourself ";
            case Data.Enums.Target.Ally:
                return sentence + "an ally ";
            case Data.Enums.Target.Enemy:
                return sentence + "an enemy ";
            case Data.Enums.Target.NonSelf:
                return sentence + "anyone excluding yourself ";
            case Data.Enums.Target.Any:
                return sentence + "anyone ";
            case null:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return sentence;
    }

    private string AddDamageText(string sentence)
    {
        return Damage switch
        {
            0 => sentence,
            > 0 => sentence + $"dealing {Damage} damage ",
            < 0 => sentence + $"healing {Damage * -1} health ",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string AddSizeText(string sentence)
    {
        return Size switch
        {
            0 => sentence,
            > 0 => sentence + $"with a radius of {Size} meters ",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string AddRangeText(string sentence)
    {
        return Range switch
        {
            0 => sentence,
            > 0 => sentence + $"and a range of {Range} meters ",
            _ => throw new ArgumentOutOfRangeException()
        };
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