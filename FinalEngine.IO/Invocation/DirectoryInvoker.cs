// <copyright file="DirectoryInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.IO.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    ///   Provides an implementation of an <see cref="IDirectoryInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.IO.Invocation.IDirectoryInvoker"/>
    [ExcludeFromCodeCoverage]
    public class DirectoryInvoker : IDirectoryInvoker
    {
        /// <summary>
        ///   Creates all directories and subdirectories in the specified path unless they already exist.
        /// </summary>
        /// <param name="path">
        ///   The directory to create.
        /// </param>
        /// <returns>
        ///   An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.
        /// </returns>
        public DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }

        /// <summary>
        ///   Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
        /// </summary>
        /// <param name="path">
        ///   The name of the directory to remove.
        /// </param>
        /// <param name="recurse">
        ///   <c>true</c> to remove directories, subdirectories, and files in <paramref name="path"/>; otherwise, <c>false</c>.
        /// </param>
        public void Delete(string path, bool recurse)
        {
            Directory.Delete(path, recurse);
        }

        /// <summary>
        ///   Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">
        ///   The path to test.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="path"/> refers to an existing directory; <c>false</c> if the directory does not exist or an error occurs when trying to determine if the specified directory exists.
        /// </returns>
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}