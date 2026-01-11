using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiAI.Common.Entities;

namespace webapiAI.Common;
public class ServiceBalancer
{
    private readonly List<ModelService> _services;

    private int _currentIndex = -1;

    public ServiceBalancer(List<ModelService> services)
    {
        _services = services;
    }

    public ModelService GetNext()
    {
        var nextIndex = (_currentIndex + 1) % _services.Count;
        _currentIndex = nextIndex;
        return _services[nextIndex];
    }
}