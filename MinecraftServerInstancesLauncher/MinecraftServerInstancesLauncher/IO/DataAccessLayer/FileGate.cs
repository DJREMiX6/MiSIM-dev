namespace MinecraftServerInstancesLauncher.IO.DataAccessLayer
{
    /// <summary>
    /// Manages the Read and WriteAsync access to a file.
    /// </summary>
    public class FileGate : IFileGate
    {

        #region PROTECTED FIELDS

        protected Queue<string> _writeQueue;
        protected FileInfo _fileInfo;
        protected bool _isWriting = false;

        #endregion PROTECTED FIELDS

        #region PROTECTED PROPS

        protected Queue<string> writeQueue => _writeQueue ??= new Queue<string>();
        protected FileInfo fileInfo => _fileInfo;

        #endregion PROTECTED PROPS

        #region CTORS

        public FileGate(string fileName)
        {
            _fileInfo = new FileInfo(fileName);
        }

        #endregion CTORS

        #region PUBLIC VIRTUAL METHODS

        /// <summary>
        /// Creates the file.
        /// </summary>
        public virtual void CreateFile()
        {
            File.Create(fileInfo.FullName);
        }

        /// <summary>
        /// Writes a text into the file. If the file doesn't exists then throws a <c>FileNotFoundException</c> or creates it if <c>createFileIfNotExists</c> is true.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public virtual void Write(string text, bool createFileIfNotExists)
        {

            if (!FileExists())
            {
                if (createFileIfNotExists)
                {
                    CreateFile();
                }
                else
                {
                    throw new FileNotFoundException($"{fileInfo.FullName} does not exists.");
                }
            }

            using (StreamWriter writer = new StreamWriter(fileInfo.FullName))
            {
                writer.Write(text);
            }
        }

        /// <summary>
        /// Writes a text into the file. If the file doesn't exists then throws a <c>FileNotFoundException</c>.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public virtual void Write(string text)
        {
            Write(text, false);
        }

        /// <summary>
        /// Writes a text into the file adding a <c>NewLine</c> character at the end. If the file doesn't exists then throws a <c>FileNotFoundException</c> or creates it if <c>createFileIfNotExists</c> is true.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public virtual void WriteLine(string text, bool createFileIfNotExists)
        {
            Write(text + Environment.NewLine, createFileIfNotExists);
        }

        /// <summary>
        /// Writes a text into the file adding a <c>NewLine</c> character at the end. If the file doesn't exists then throws a <c>FileNotFoundException</c>.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public virtual void WriteLine(string text)
        {
            WriteLine(text);
        }

        /// <summary>
        /// Asynchronously enqueues a text to write it into the file.
        /// </summary>
        public virtual async void WriteAsync(string text, bool createFileIfNotExists)
        {
            lock(writeQueue)
            {
                writeQueue.Enqueue(text);
                OnTextEnqueued(createFileIfNotExists);
            }
        }

        /// <summary>
        /// Asynchronously enqueues a text to write it into the file adding a <c>NewLine</c> character at the end.
        /// </summary>
        public virtual async void WriteLineAsync(string log, bool createFileIfNotExists)
        {
            WriteAsync(log + Environment.NewLine, createFileIfNotExists);
        }

        /// <summary>
        /// Reads a line of characters from the file.
        /// </summary>
        /// <returns>The next line in the file stream or <c>null</c> if the end of the file is reached.</returns>
        public virtual string? ReadLine()
        {
            using(StreamReader reader = new StreamReader(fileInfo.FullName))
            {
                return reader.ReadLine();
            }
        }

        /// <summary>
        /// Reads all the characters from the file.
        /// </summary>
        /// <returns>The file content. Returns null if the file doesn't exists.</returns>
        public virtual string? ReadToEnd()
        {
            if(!FileExists())
            {
                return null;
            }

            using(StreamReader reader = new StreamReader(fileInfo.FullName))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion PUBLIC VIRTUAL METHODS

        #region PROTECTED VIRTUAL METHODS

        /// <summary>
        /// Text enqueued event invoker.
        /// </summary>
        protected virtual void OnTextEnqueued(bool createFileIfNotExists)
        {
            if (!_isWriting)
            {
                WriteQueuedTextsIntoFileAsync(createFileIfNotExists);
            }
        }

        /// <summary>
        /// Checks if the <c>writeQueue</c> is empty by checking its <c>Count</c> property.
        /// </summary>
        protected virtual bool IsWriteQueueEmpty()
        {
            return writeQueue.Count == 0;
        }

        /// <summary>
        /// Asynchronously writes queued texts into the Log file.
        /// </summary>
        protected virtual async void WriteQueuedTextsIntoFileAsync(bool createFileIfNotExists)
        {
            if(!FileExists())
            {
                if (createFileIfNotExists)
                {
                    CreateFile();
                } 
                else
                {
                    throw new FileNotFoundException($"{fileInfo.FullName} does not exists.");
                }
            }

            using (var writer = new StreamWriter(fileInfo.FullName, true))
            {
                while (!IsWriteQueueEmpty())
                {
                    StartedWriting();
                    string text = writeQueue.Dequeue();
                    await writer.WriteAsync(text);
                }
            }
            StoppedWriting();
        }

        /// <summary>
        /// Checks if the file already exists.
        /// </summary>
        /// <returns>True if the file already exists.</returns>
        protected virtual bool FileExists()
        {
            return File.Exists(fileInfo.FullName);
        }

        /// <summary>
        /// Sets all the conditions that needs to change after the <c>FileGate</c> started writing into the file.
        /// </summary>
        protected virtual void StartedWriting()
        {
            _isWriting = true;
        }

        /// <summary>
        /// Sets all the conditions that needs to change after the <c>FileGate</c> stopped writing into the file.
        /// </summary>
        protected virtual void StoppedWriting()
        {
            _isWriting = false;
        }

        #endregion PROTECTED VIRTUAL METHODS

    }
}
