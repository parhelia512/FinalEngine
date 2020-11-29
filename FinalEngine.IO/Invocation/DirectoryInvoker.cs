// <copyright file="DirectoryInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    [ExcludeFromCodeCoverage]
    public class DirectoryInvoker : IDirectoryInvoker
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void Delete(string path, bool recurse)
        {
            Directory.Delete(path, recurse);
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}