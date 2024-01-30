using SpellMaker;
using SpellMaker.Invocations;

namespace SpellMaker;

static class Program
{
    static void Main()
    {
        List<IInvocation> invocations = [];
        RegisterInvocations(invocations);
        var fireBall = new Spell("Fireball");
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Flame"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Throw"));
        fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Big"));
        Console.WriteLine(fireBall.SpellSentence);
    }

    static void RegisterInvocations(ICollection<IInvocation> invocations)
    {
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