using System.Collections.Generic;
using SpellMaker.Data.Enums;

namespace SpellMaker.Data.Invocations;

public interface IInvocation
{
    public string Name { get; set; }
    public object Addition { get; set; }
    public InvocationType InvocationType { get; set; }
    public List<InvocationType> InvocationOrder { get; set; }
}