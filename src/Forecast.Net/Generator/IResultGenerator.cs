﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Generator
{
    public interface IResultGenerator<K, V>
    {
        V GetEstimated(K key);
    }
}
