// <copyright file="EnumMapper.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;

    public class EnumMapper : IEnumMapper
    {
        private readonly IReadOnlyDictionary<Enum, Enum> forward;

        private readonly IDictionary<Enum, Enum> reverse;

        public EnumMapper(IReadOnlyDictionary<Enum, Enum> forward)
        {
            this.forward = forward ?? throw new ArgumentNullException(nameof(forward));
            this.reverse = new Dictionary<Enum, Enum>();

            foreach (Enum? key in forward.Keys)
            {
                if (key == null)
                {
                    throw new ArgumentException($"The specified {nameof(forward)} parameter cannot contain null keys.");
                }

                Enum? value = forward[key];

                if (value == null)
                {
                    throw new ArgumentException($"The specified {nameof(forward)} parameter cannot contain null values.");
                }

                this.reverse.Add(value, key);
            }
        }

        public TResult Forward<TResult>(Enum enumeration)
            where TResult : Enum
        {
            if (!this.forward.TryGetValue(enumeration, out Enum? result))
            {
                throw new Exception();
            }

            return (TResult)result;
        }

        public TResult Reverse<TResult>(Enum enumeration)
            where TResult : Enum
        {
            if (!this.reverse.TryGetValue(enumeration, out Enum? result))
            {
                throw new Exception();
            }

            return (TResult)result;
        }
    }
}