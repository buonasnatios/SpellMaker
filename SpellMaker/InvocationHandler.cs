using SpellMaker.Data.Invocations;
using SpellMaker.Data.Invocations.Additives;
using SpellMaker.Data.Invocations.Adjective;
using SpellMaker.Data.Invocations.Descriptors;
using SpellMaker.Data.Invocations.Nouns;
using SpellMaker.Data.Invocations.Verbs;

namespace SpellMaker;

public class InvocationHandler
{
    
    public ICollection<IInvocation> RegisterInvocations(ICollection<IInvocation> invocations)
    {
        //Additives
        invocations.Add(new With());
        
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
        
        return invocations;
    }
}