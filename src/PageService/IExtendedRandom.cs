using System.Collections.Generic;
using Interfaces;

namespace PageService
{
    public interface IExtendedRandom
    {
        Language NextLanguage();
        T NextEntry<T>(IReadOnlyList<T> collection);
    }
}