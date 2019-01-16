using System.Collections.Generic;
using Interfaces;

namespace PageService
{
    public interface IRandom
    {
        Language NextLanguage();
        T NextEntry<T>(IReadOnlyList<T> collection);
    }
}