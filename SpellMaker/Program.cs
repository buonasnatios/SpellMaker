using SpellMaker;
using SpellMaker.Invocations;

namespace SpellMaker;

internal static class Program
{
    private static void Main()
    {
        List<IInvocation> invocations = [];
        invocations.RegisterInvocations();
        var fireBall = new Spell("Fireball");
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Flame"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Throw"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Big"));
        Console.WriteLine(fireBall.SpellSentence);
        var healingTouch = new Spell("Fireball");
        healingTouch.AddInvocation(invocations.Find(invocation => invocation?.Name == "Heal"));
        healingTouch.AddInvocation(invocations.Find(invocation => invocation?.Name == "Touch"));
        Console.WriteLine(healingTouch.SpellSentence);
    }

    private static void RegisterInvocations(this ICollection<IInvocation> invocations)
    {
        ArgumentNullException.ThrowIfNull(invocations);
        //Verbs
        invocations.Add(new Throw());
        invocations.Add(new Touch());
    
        //Nouns
        invocations.Add(new Flame());
        invocations.Add(new Heal());
        invocations.Add(new Rock());
    
        //Adjective
        invocations.Add(new Big());
        invocations.Add(new Lasting());
        invocations.Add(new Multiple());
        invocations.Add(new Small());
        invocations.Add(new Stunning());
    }
}