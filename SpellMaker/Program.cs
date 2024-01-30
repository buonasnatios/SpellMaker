
using SpellMaker;
using SpellMaker.Invocations;

static void Main()
{
    List<IInvocation?> invocations = [];
    RegisterInvocations(invocations);
    var fireBall = new Spell("Fireball");
    fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Flame"));
    fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Throw"));
    fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Big"));
    Console.WriteLine(fireBall.SpellSentence);
}

static void RegisterInvocations(ICollection<IInvocation?> invocations)
{
    invocations.Add(new Flame());
    invocations.Add(new Throw());
    invocations.Add(new Heal());
    invocations.Add(new Touch());
    invocations.Add(new Big());
}
Main();