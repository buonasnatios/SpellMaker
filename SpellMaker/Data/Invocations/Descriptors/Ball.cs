﻿using SpellMaker.Data.Enums;
using SpellMaker.Data.Modifiers;
using SpellMaker.Data.Modifiers.Multipliers;

namespace SpellMaker.Data.Invocations.Descriptors;

public class Ball : IInvocation
{
    public string Name { get; set; } = "Ball";
    public object Addition { get; set; } = new List<object>
    {
        new ChangesShape(SpellShape.Ball),
        new MultipliesWeight(1.2f),
        new MultipliesSpeed(0.9f)
    };
    public InvocationType InvocationType { get; set; } = InvocationType.Descriptor;
    public List<InvocationType> InvocationOrder { get; set; } = [];
}