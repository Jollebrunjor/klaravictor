﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace klaravictor.Extensions
{
    public static class BoolExtensions
    {
        public static string ToSwedish(this bool b)
        {
            if (b is false) return "Nej";
            if (b is true) return "Ja";

            return string.Empty;
        }
    }
}