// <copyright file="IDirectoryInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO.Invocation
{
    public interface IDirectoryInvoker
    {
        void CreateDirectory(string path);

        void Delete(string path, bool recurse);

        bool Exists(string path);
    }
}