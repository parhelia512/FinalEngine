// <copyright file="FileSystem.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    [ExcludeFromCodeCoverage]
    public class FileSystem : IFileSystem
    {
        public void CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(path);
            }

            Directory.CreateDirectory(path);
        }

        public Stream CreateFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return File.Create(path);
        }

        public void DeleteDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Directory.Delete(path, true);
        }

        public void DeleteFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            File.Delete(path);
        }

        public bool DirectoryExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return File.Exists(path);
        }

        public Stream OpenFile(string path, FileAccessMode mode)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            FileAccess access = FileAccess.Read;

            switch (mode)
            {
                case FileAccessMode.Read:
                    access = FileAccess.Read;
                    break;

                case FileAccessMode.Write:
                    access = FileAccess.Write;
                    break;

                case FileAccessMode.ReadAndWrite:
                    access = FileAccess.ReadWrite;
                    break;
            }

            return File.Open(path, FileMode.Open, access);
        }
    }
}