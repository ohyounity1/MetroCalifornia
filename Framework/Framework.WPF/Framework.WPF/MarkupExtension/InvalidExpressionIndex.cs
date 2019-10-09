namespace Framework.WPF.MarkupExtension
{
    /// <summary>
    /// Error when the placeholder index is out of range
    /// </summary>
    public class InvalidExpressionIndex
    {
        /// <summary>
        /// The out of range index
        /// </summary>
        public int InvalidIndex { get; }

        /// <summary>
        /// Original expression
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="InvalidExpressionIndex"/>
        /// </summary>
        /// <param name="invalidIndex">Invalid index</param>
        /// <param name="expression">Original expression</param>
        public InvalidExpressionIndex(int invalidIndex, string expression)
        {
            InvalidIndex = invalidIndex;
            Expression = expression;
        }

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>The error as a printable string</returns>
        public override string ToString()
        {
            return $"In expression {Expression}, the index {InvalidIndex} is not valid";
        }
    }
}
