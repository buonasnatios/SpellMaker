using SpellMaker.Data.Enums;
using SpellMaker.Data.Invocations;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Multipliers;
using SpellMaker.Data.Modifiers.Setters;

namespace SpellMaker;

public class Spell(List<IInvocation> invocations, string spellName)
{
    public Spell(string spellName) : this([], spellName)
    {
    }
    

    public List<IInvocation> Invocations { get; set; } = invocations;
    public string SpellName { get; set; } = spellName;
    
    public int Casts => _baseCasts;

    public float CastTime => _baseCastTime * _castTimeMultiplier;
    public float Damage => _baseDamage * _damageMultiplier;
    public float Duration => _baseDuration * _durationMultiplier;
    public float Size => _baseSize * _sizeMultiplier;
    public float Speed => _baseSpeed * _speedMultiplier;
    public float Weight => _baseWeight * _weightMultiplier;
    public float Range => _baseRange * _rangeMultiplier;
    public float Piercing  => (Weight+Speed)/2;
    public float Stun => Piercing * _stunMultiplier;
    
    public SpellShape SpellShape { get; set; }
    public ElementType? ElementType { get; set; }
    public Target? Target { get; set; }
    public List<InvocationType> SpellOrder { get; set; } = [];

    private int _baseCasts = 1;

    private float _baseCastTime = 0;
    private float _baseDamage = 0;
    private float _baseDuration = 0;
    private float _baseRange = 0;
    private float _baseSize = 0;
    private float _baseSpeed = 0;
    private float _baseWeight = 0;

    private float _castTimeMultiplier = 1;
    private float _damageMultiplier = 1;
    private float _durationMultiplier = 1;
    private float _rangeMultiplier = 1;
    private float _sizeMultiplier = 1;
    private float _speedMultiplier = 1;
    private float _stunMultiplier = 1;
    private float _weightMultiplier = 1;

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

        if (!CanAddInvocationToSpell(invocation)) return false;
        
        Invocations.Add(invocation);
        ImplementAdditionEffects(invocation.Addition);
        return true;
    }

    private bool CanAddInvocationToSpell(IInvocation invocation)
    {
        // Check if Spell doesn't have a SpellOrder.
        if (SpellOrder.Count == 0 && invocation.InvocationOrder.Count > 0)
        {
            InsertInvocationOrderToSpellOrder(0, invocation);
            return true;
        }

        // Check if Invocation is already used in current portion ((Verb - Noun) - Additive - (Verb - Noun))
        for (var index = Invocations.Count-1; index >= 0; index--)
        {
            if (invocation == Invocations[index])
            {
                return false;
            }
            if (Invocations[index].InvocationType == InvocationType.Additive)
            {
                break;
            }
        }
        
        // Check if Invocation is an Additive and if all slots in the SpellOrder are used
        if (invocation.InvocationType == InvocationType.Additive && SpellOrder.Count == Invocations.Count)
        {
            InsertInvocationOrderToSpellOrder(Invocations.Count, invocation);
            return true;
        }


        switch (invocation.InvocationOrder.Count)
        {
            case > 0 when invocation.InvocationType != CurrentSpellType():
                return false;
            case > 0:
                SpellOrder.RemoveAt(Invocations.Count);
                InsertInvocationOrderToSpellOrder(Invocations.Count, invocation);
                return true;
            case 0 when invocation.InvocationType == CurrentSpellType():
                return true;
            // Exception for Adjectives as they have to be before a Noun
            case 0 when invocation.InvocationType == InvocationType.Adjective && CurrentSpellType() == InvocationType.Noun:
                SpellOrder.Insert(Invocations.Count, invocation.InvocationType);
                return true;
            default:
                return false;
        }
    }

    private void InsertInvocationOrderToSpellOrder(int index, IInvocation invocation)
    {
        SpellOrder.InsertRange(index, invocation.InvocationOrder);
        SpellOrder[^invocation.InvocationOrder.Count] = invocation.InvocationType;
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
                ElementType = CombineElements(element.ElementType);
                _baseWeight = element.WeightModifier;
                break;
            case TargetModifier targetModifier: 
                Target = targetModifier.Target;
                break;
            
            case SetsRange setsRange:
                _baseRange = setsRange.Setter;
                break;
            
            //Multipliers
            case MultipliesCastTime multipliesCastTime:
                _castTimeMultiplier += multipliesCastTime.Multiplier;
                break;
            case MultipliesDamage multipliesDamage:
                _damageMultiplier += multipliesDamage.Multiplier;
                break;
            case MultipliesDuration multipliesDuration:
                _durationMultiplier += multipliesDuration.Multiplier;
                break;
            case MultipliesRange multipliesRange:
                _rangeMultiplier += multipliesRange.Multiplier;
                break;
            case MultipliesSize multipliesSize:
                _sizeMultiplier += multipliesSize.Multiplier;
                break;
            case MultipliesSpeed multipliesSpeed:
                _speedMultiplier += multipliesSpeed.Multiplier;
                break;
            case MultipliesStun multipliesStun:
                _stunMultiplier += multipliesStun.Multiplier;
                break;
            case MultipliesWeight multipliesWeight:
                _weightMultiplier += multipliesWeight.Multiplier;
                break;
            
            //Additions
            case AddsCasts addsCasts:
                _baseCasts += addsCasts.Addition;
                break;
            case AddsCastTime addsCastTime:
                _baseCastTime += addsCastTime.Addition;
                break;
            case AddsDamage addsDamage:
                _baseDamage += addsDamage.Addition;
                break;
            case AddsDuration addsDuration:
                _baseDuration += addsDuration.Addition;
                break;
            case AddsRange addsRange:
                _baseRange += addsRange.Addition;
                break;
            case AddsSize addsSize:
                _baseSize += addsSize.Addition;
                break;
            case AddsSpeed addsSpeed:
                _baseSpeed += addsSpeed.Addition;
                break;
            case AddsWeight addsWeight:
                _baseWeight += addsWeight.Addition;
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
        if (ElementType is null) return elementType;
        switch (ElementType)
        {
            case Data.Enums.ElementType.Cold:
                switch (elementType)
                {
                    case Data.Enums.ElementType.Water:
                        break;
                    case Data.Enums.ElementType.Ice:
                        break;
                    case Data.Enums.ElementType.Lava:
                        break;
                    case Data.Enums.ElementType.Plasma:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(elementType), elementType, null);
                }
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