// <copyright file="IFileInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO.Invocation
{
    using System.IO;

    public interface IFileInvoker
    {
        Stream Create(string path);

        void Delete(string path);

        bool Exists(string path);

        Stream Open(string path, FileMode mode, FileAccess access);
    }
}