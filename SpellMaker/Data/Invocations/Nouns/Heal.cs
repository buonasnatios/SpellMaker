﻿using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers.Additions;
using SpellMaker.Data.Modifiers.Elements;

namespace SpellMaker.Data.Invocations.Nouns;

public class Heal : IInvocation
{
    public string Name { get; set; } = "Heal";
    public object Addition { get; set; } = new List<object>
    {
        new Holy(), 
        new AddsDamage(-3),
        new AddsDuration(1),
        new AddsSize(1)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = 
    [
        InvocationType.Self,
        InvocationType.Descriptor
    ];
}