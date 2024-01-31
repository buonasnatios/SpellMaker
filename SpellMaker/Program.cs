using SpellMaker.Data.Invocations;
using SpellMaker.Data.Invocations.Adjective;
using SpellMaker.Data.Invocations.Descriptors;
using SpellMaker.Data.Invocations.Nouns;
using SpellMaker.Data.Invocations.Verbs;

namespace SpellMaker;

internal static class Program
{
    private static void Main()
    {
        List<IInvocation> invocations = [];
        invocations.RegisterInvocations();
        var fireBall = new Spell("Fireball");
        fireBall.AddInvocation(invocations.Find(invocation => invocation.Name == "Throw"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation.Name == "Big"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation.Name == "Flame"));
        Console.WriteLine(fireBall.SpellSentence);
        var healingTouch = new Spell("Fireball");
        healingTouch.AddInvocation(invocations.Find(invocation => invocation.Name == "Touch"));
        healingTouch.AddInvocation(invocations.Find(invocation => invocation.Name == "Heal"));
        Console.WriteLine(healingTouch.SpellSentence);
    }

    private static void RegisterInvocations(this ICollection<IInvocation> invocations)
    {
        //Adjective
        invocations.Add(new Big());
        invocations.Add(new Lasting());
        invocations.Add(new Multiple());
        invocations.Add(new Small());
        invocations.Add(new Stunning());
        
        //Descriptors
        invocations.Add(new Arrow());
        invocations.Add(new Ball());
        invocations.Add(new Bolt());
    
        //Nouns
        invocations.Add(new Flame());
        invocations.Add(new Heal());
        invocations.Add(new Rock());
        invocations.Add(new Water());

        //Verbs
        invocations.Add(new Throw());
        invocations.Add(new Touch());
    }
}