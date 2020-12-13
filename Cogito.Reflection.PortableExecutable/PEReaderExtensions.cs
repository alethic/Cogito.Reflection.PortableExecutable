using System;
using System.Reflection.PortableExecutable;

using Cogito.Reflection.PortableExecutable.Exports;

namespace Cogito.Reflection.PortableExecutable
{

    /// <summary>
    /// Provides extension methods for working with Portable Executable export tables.
    /// </summary>
    public static class PEReaderExtensions
    {

        /// <summary>
        /// Reads the entries from the export directory.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ExportTableDirectory ReadExportTableDirectory(this PEReader reader)
        {
            if (reader is null)
                throw new ArgumentNullException(nameof(reader));

            // return directory table if possible
            if (reader.PEHeaders.PEHeader.ExportTableDirectory.Size > 0 &&
                reader.PEHeaders.TryGetDirectoryOffset(reader.PEHeaders.PEHeader.ExportTableDirectory, out var offset))
                return new ExportTableDirectory(reader, offset, 1);
            else
                return new ExportTableDirectory(reader, 0, 0);
        }

    }

}
