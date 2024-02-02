using SpellMaker.Data.Invocations;
using SpellMaker.Data.Invocations.Additives;
using SpellMaker.Data.Invocations.Adjective;
using SpellMaker.Data.Invocations.Descriptors;
using SpellMaker.Data.Invocations.Nouns;
using SpellMaker.Data.Invocations.Verbs;

namespace SpellMaker;

internal static class Program
{
    /*private static void Main()
    {
        List<IInvocation> invocations = [];
        invocations.RegisterInvocations();
        var temp = new Spell("");
        while (true)
        {
            Console.WriteLine("Write an invocation:");
            var input = Console.ReadLine();
            if (input == "")
            {
                temp = new Spell("");
                continue;
            }
            try
            {
                temp.AddInvocation(invocations.Find(invocation => invocation.Name == input));
            }
            catch
            {
                // ignored
            }

            Console.WriteLine(new SpellSentenceGenerator(temp).GenerateSentence());
            Console.WriteLine("Invocations: " + temp.Invocations);
            Console.WriteLine("CastTime: " + temp.CastTime);
            Console.WriteLine("Damage: " + temp.Damage);
            Console.WriteLine("Casts: " + temp.Casts);
            Console.WriteLine("Duration: " + temp.Duration);
            Console.WriteLine("Piercing: " + temp.Piercing);
            Console.WriteLine("Range: " + temp.Range);
            Console.WriteLine("Size: " + temp.Size);
            Console.WriteLine("Speed: " + temp.Speed);
            Console.WriteLine("Stun: " + temp.Stun);
            Console.WriteLine("Target: " + temp.Target);
            Console.WriteLine("Weight: " + temp.Weight);
            Console.WriteLine("ElementType: " + temp.ElementType);
            Console.WriteLine("SpellName: " + temp.SpellName);
            Console.WriteLine("SpellShape: " + temp.SpellShape);
            Console.WriteLine("SpellOrder: " + temp.SpellOrder.Count);
        }
    }*/

    private static void RegisterInvocations(this ICollection<IInvocation> invocations)
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
    }
}