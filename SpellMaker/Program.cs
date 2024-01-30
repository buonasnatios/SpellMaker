
using SpellMaker;
using SpellMaker.Invocations;

static void Main()
{
    List<IInvocation?> invocations = [];
    RegisterInvocations(invocations);
    var fireBall = new Spell("Fireball");
    fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Throw"));
    fireBall.AddInvocation(invocations.Find(invocation => invocation?.Name == "Flame"));
    Console.WriteLine(fireBall.SpellSentence);
}

static void RegisterInvocations(ICollection<IInvocation?> invocations)
{
    invocations.Add(new Flame());
    invocations.Add(new Throw());
    invocations.Add(new Heal());
    invocations.Add(new Touch());
}
Main();