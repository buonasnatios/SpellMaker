﻿using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Elements;

namespace SpellMaker.Data.Invocations.Nouns;

public class Water : IInvocation
{
    public string Name { get; set; } = "Water";
    public object Addition { get; set; } = new List<object> { new Modifiers.Elements.Water(), new AddsDamage(4) };
    public InvocationType InvocationType { get; set; } = InvocationType.Noun;
    public List<InvocationType> InvocationOrder { get; set; } = 
    [
        InvocationType.Adjective,
        InvocationType.Self,
        InvocationType.Descriptor
    ];

    public InvocationOrderPriority OrderPriority { get; set; } = InvocationOrderPriority.MediumAvailable;
}