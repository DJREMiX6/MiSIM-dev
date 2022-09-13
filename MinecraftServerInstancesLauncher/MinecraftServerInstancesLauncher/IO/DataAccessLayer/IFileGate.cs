namespace MinecraftServerInstancesLauncher.IO.DataAccessLayer
{
    /// <summary>
    /// File DataAccessLayer abstraction
    /// </summary>
    public interface IFileGate
    {
        /// <summary>
        /// Creates the file.
        /// </summary>
        public void CreateFile();
        /// <summary>
        /// Deletes the file.
        /// </summary>
        public void DeleteFile();
        /// <summary>
        /// Erases the content of the file.
        /// </summary>
        public void ClearFile();
        /// <summary>
        /// Writes a text into the file. If the file doesn't exists then throws a <c>FileNotFoundException</c> or creates it if <c>createFileIfNotExists</c> is true.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void Write(string text, bool createFileIfNotExists);
        /// <summary>
        /// Writes a text into the file. If the file doesn't exists then throws a <c>FileNotFoundException</c>.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void Write(string text);
        /// <summary>
        /// Writes a text into the file adding a <c>NewLine</c> character at the end. If the file doesn't exists then throws a <c>FileNotFoundException</c> or creates it if <c>createFileIfNotExists</c> is true.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteLine(string text, bool createFileIfNotExists);
        /// <summary>
        /// Writes a text into the file adding a <c>NewLine</c> character at the end. If the file doesn't exists then throws a <c>FileNotFoundException</c>.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteLine(string text);
        /// <summary>
        /// Asynchronously enqueues a text to write it into the file.
        /// </summary>
        public void WriteAsync(string text, bool createFileIfNotExists);
        /// <summary>
        /// Asynchronously enqueues a text to write it into the file adding a <c>NewLine</c> character at the end.
        /// </summary>
        public void WriteLineAsync(string log, bool createFileIfNotExists);
        /// <summary>
        /// Reads a line of characters from the file.
        /// </summary>
        /// <returns>The next line in the file stream or <c>null</c> if the end of the file is reached.</returns>
        public string? ReadLine();
        /// <summary>
        /// Reads all the characters from the file.
        /// </summary>
        /// <returns>The file content. Returns null if the file doesn't exists.</returns>
        public string? ReadToEnd();
    }
}
