using SpellMaker.Modifiers;

namespace SpellMaker;

public class Spell(List<IInvocation> invocations, string spellName)
{
    public Spell(string spellName) : this([], spellName)
    {
    }

    private List<IInvocation> Invocations { get; set; } = invocations;
    public string SpellName { get; set; } = spellName;
    public string SpellSentence => GetSpellSentence();
    public int Size { get; set; } = 0;
    public int Damage { get; set; } = 0;
    public int Duration { get; set; } = 0;
    public int Range { get; set; } = 0;
    public int CastTime { get; set; } = 0;
    public int? DamageType { get; set; }
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
        var invocationsWithOrder = GetOrderedInvocation().ToList();
        List<IInvocation> OrderedInvocations = [];
        if (invocationsWithOrder.Count == 1)
        {
            OrderedInvocations = CreateOrderedInvocation(invocationsWithOrder.First());
            Invocations = OrderedInvocations.ToList();
        }
        var sentence = AggregateInvocations();
        sentence = AggregateTarget(sentence);
        sentence = AddDamageText(sentence);
        sentence = EndSentence(sentence);

        return sentence;
    }

    private List<IInvocation> CreateOrderedInvocation(IInvocation invocationWithOrder)
    {
        LinkedList<IInvocation> orderedInvocations = [];
        foreach (var invocationType in invocationWithOrder.InvocationOrder)
        {
            switch (invocationType)
            {
                case InvocationType.Noun:
                    orderedInvocations.AddLast(Invocations.Find(invocation => invocation.InvocationType == invocationType) ??
                                               throw new InvalidOperationException());
                    break;
                case InvocationType.Verb:
                    orderedInvocations.AddLast(Invocations.Find(invocation => invocation.InvocationType == invocationType) ??
                                               throw new InvalidOperationException());
                    break;
                case InvocationType.Target:
                    break;
                case InvocationType.Self:
                    orderedInvocations.AddLast(invocationWithOrder);
                    break;
                case InvocationType.Adjective:
                    orderedInvocations.AddLast(Invocations.Find(invocation => invocation.InvocationType == invocationType) ??
                                               throw new InvalidOperationException());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (orderedInvocations.Count < Invocations.Count)
        {
            var extraInvocations = Invocations.Where(invocation => !orderedInvocations.Contains(invocation)).ToList();
            foreach (var invocation in extraInvocations)
            {
                switch (invocation.InvocationType)
                {
                    case InvocationType.Noun:
                        break;
                    case InvocationType.Verb:
                        break;
                    case InvocationType.Target:
                        break;
                    case InvocationType.Self:
                        break;
                    case InvocationType.Adjective:
                        orderedInvocations.AddBefore(
                            orderedInvocations.Find(
                                orderedInvocations.First(
                                    orderedInvocation => orderedInvocation.InvocationType == InvocationType.Noun)) ?? throw new InvalidOperationException(), 
                            invocation);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        return orderedInvocations.ToList();
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

    private string AggregateTarget(string sentence)
    {
        switch (Target)
        {
            case SpellMaker.Target.Self:
                return sentence + "at yourself ";
            case SpellMaker.Target.Ally:
                return sentence + "at an ally ";
            case SpellMaker.Target.Enemy:
                return sentence + "at an enemy ";
            case SpellMaker.Target.NonSelf:
                return sentence + "at anything excluding yourself ";
            case SpellMaker.Target.Any:
                return sentence + "at anything ";
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
            < 0 => sentence + $"healing {Damage} health "
        };
    }

    private void ImplementAdditionEffects(object addition)
    {
        switch (addition)
        {
            case IElement element: DamageType = element.ElementType;
                break;
            case TargetModifier targetModifier: Target = targetModifier.Target;
                break;
            case AddsDamage addsDamage:
                Damage += addsDamage.Damage;
                break;
            case AddsRange addsRange:
                Range += addsRange.Range;
                break;
            case List<object> list:
                foreach (var item in list)
                {
                    ImplementAdditionEffects(item);
                }

                break;
        }
    }
}