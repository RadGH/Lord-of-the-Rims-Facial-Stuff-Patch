﻿using System.Collections.Generic;
using System.Linq;

namespace AlienFace
{
    using UnityEngine;

    using Verse;

    public static class Extensions
    {
        // EdB.PrepareCarefully.ExtensionsColorGenerator
        public static List<Color> GetColorList(this ColorGenerator generator)
        {
            ColorGenerator_Options options = generator as ColorGenerator_Options;
            if (options != null)
            {
                return options.options.Where((ColorOption option) => {
                        return option.only.a > -1.0f;
                    }).Select((ColorOption option) => {
                        return option.only;
                    }).ToList();
            }
            ColorGenerator_Single single = generator as ColorGenerator_Single;
            if (single != null)
            {
                return new List<Color>() { single.color };
            }
            ColorGenerator_White white = generator as ColorGenerator_White;
            if (white != null)
            {
                return new List<Color>() { Color.white };
            }
            return new List<Color>();
        }

    }
}
