// <copyright file="FileInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    [ExcludeFromCodeCoverage]
    public class FileInvoker : IFileInvoker
    {
        public Stream Create(string path)
        {
            return File.Create(path);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public Stream Open(string path, FileMode mode, FileAccess access)
        {
            return File.Open(path, mode, access);
        }
    }
}