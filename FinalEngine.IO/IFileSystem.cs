// <copyright file="IFileSystem.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO
{
    using System.IO;

    public interface IFileSystem
    {
        void CreateDirectory(string path);

        Stream CreateFile(string path);

        void DeleteDirectory(string path);

        void DeleteFile(string path);

        bool DirectoryExists(string path);

        bool FileExists(string path);

        Stream OpenFile(string path, FileAccessMode mode);
    }
}