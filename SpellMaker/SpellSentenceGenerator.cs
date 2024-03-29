﻿using SpellMaker.Data.Enums;

namespace SpellMaker;

public class SpellSentenceGenerator(Spell spell)
{
    private Spell Spell { get; set; } = spell;

    public string GenerateSentence()
    {
        return string.Join(", ", Spell.Invocations);
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

    private static string EndSentence(string sentence)
    {
        return sentence.Remove(sentence.Length - 1, 1) + ".";
    }

    private string AggregateInvocations()
    {
        return Spell.Invocations.Aggregate("", (current, invocation) =>
        {
            return current + invocation.InvocationType switch
            {
                InvocationType.Noun => $"{invocation.Name} ",
                InvocationType.Verb => $"{invocation.Name} ",
                InvocationType.Adjective => $"{invocation.Name} ",
                InvocationType.Self => $"{invocation.Name} ",
                InvocationType.Descriptor => $"{invocation.Name} ",
                _ => throw new ArgumentOutOfRangeException()
            };
        });
    }

    private string AddTarget(string sentence)
    {
        switch (Spell.Target)
        {
            case Target.Self:
                return sentence + "yourself ";
            case Target.Ally:
                return sentence + "an ally ";
            case Target.Enemy:
                return sentence + "an enemy ";
            case Target.NonSelf:
                return sentence + "anyone excluding yourself ";
            case Target.Any:
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
        return Spell.Damage switch
        {
            0 => sentence,
            > 0 => sentence + $"dealing {Spell.Damage} damage ",
            < 0 => sentence + $"healing {Spell.Damage * -1} health ",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string AddSizeText(string sentence)
    {
        return Spell.Size switch
        {
            0 => sentence,
            > 0 => sentence + $"with a radius of {Spell.Size} meters ",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string AddRangeText(string sentence)
    {
        return Spell.Range switch
        {
            0 => sentence,
            > 0 => sentence + $"and a range of {Spell.Range} meters ",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}