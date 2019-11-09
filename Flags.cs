using System;
using System.Linq;
using System.Collections.Generic;

[Flags]
public enum SampleFlags
{
    None = 0,
    First = 1 << 0,
    Second = 1 << 1,
    Third = 1 << 2,
    Fourth = 1 << 3,

    All = First | Second | Third | Fourth
    //lub All = ~0u ale deklaracja enuma musi wyglądać tak enum SampleFlags: uint
}

static class FlagsUtils
{
    public static void Set(ref SampleFlags aSet, SampleFlags aFlag)
    {
        aSet |= aFlag;
    }

    public static void UnSet(ref SampleFlags aSet, SampleFlags aFlag)
    {
        aSet &= ~aFlag;
    }

    public static bool HasFlag(ref SampleFlags aSet, SampleFlags aFlag)
    {
        return (aSet & aFlag) == aFlag;
    }

    public static void Toogle(ref SampleFlags aSet, SampleFlags aFlag)
    {
        aSet ^= aFlag;
    }

    public static IEnumerable<SampleFlags> Decompose(SampleFlags aSet)
    {
        var i = SampleFlags.First;
        do
        {
            if ((aSet & i) == i)
                yield return i;
        
            i = (SampleFlags)((int)i << 1);
        }
        while (i < SampleFlags.All && i > 0);
    }

    public static SampleFlags Compose(IEnumerable<SampleFlags> aFlags)
    {
        return aFlags.Aggregate((set, flag) => set | flag);
    }
}