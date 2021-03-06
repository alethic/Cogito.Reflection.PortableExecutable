﻿using System;
using System.Reflection.PortableExecutable;

namespace Cogito.Reflection.PortableExecutable.Extensions
{

    /// <summary>
    /// Provides extension methods for working with a <see cref="PEReader"/>.
    /// </summary>
    static class PEReaderExtensions
    {

        /// <summary>
        /// Gets a <see cref="ReadOnlySpan{T}"/> covering the entire PE image.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static unsafe ReadOnlySpan<byte> ToSpan(this PEReader self)
        {
            var mb = self.GetEntireImage();
            return new ReadOnlySpan<byte>(mb.Pointer, mb.Length);
        }

        /// <summary>
        /// Gets a <see cref="ReadOnlySpan{T}"/> covering the entire PE image.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static ReadOnlySpan<byte> ToSpan(this PEReader self, int start, int count)
        {
            return ToSpan(self).Slice(start, count);
        }

        /// <summary>
        /// Gets a <see cref="ReadOnlySpan{T}"/> covering the entire PE image.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static ReadOnlySpan<byte> ToSpan(this PEReader self, int start)
        {
            return ToSpan(self).Slice(start);
        }

    }

}
