namespace Framework.Patterns.Exception
{
    /// <summary>
    /// Generic exception class allowing user to throw any type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Type of data to throw</typeparam>
    public class Exception<T> : System.Exception
    {
        /// <summary>
        /// The details
        /// </summary>
        private readonly T _details;

        /// <summary>
        /// Initializes a new instance of <see cref="Exception{T}"/>
        /// </summary>
        /// <param name="details"></param>
        public Exception(T details)
        {
            _details = details;
        }

        /// <summary>
        /// Access to the details
        /// </summary>
        public T Details => _details;

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>Display details of the exception</returns>
        public override string ToString()
        {
            return _details.ToString();
        }
    }
}
