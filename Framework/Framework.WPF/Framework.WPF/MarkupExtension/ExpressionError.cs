namespace Framework.WPF.MarkupExtension
{
    /// <summary>
    /// Error about a given expression
    /// </summary>
    public class ExpressionError
    {
        /// <summary>
        /// More specific error information
        /// </summary>
        private readonly string _errorInformation;

        /// <summary>
        /// Expression value
        /// </summary>
        public string Expression { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ExpressionError"/>
        /// </summary>
        /// <param name="errorInformation">Error string</param>
        /// <param name="expression">Original expression with the error</param>
        public ExpressionError(string errorInformation, string expression)
        {
            _errorInformation = errorInformation;
            Expression = expression;
        }

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        /// <returns>Error in string format</returns>
        public override string ToString()
        {
            return $"Expression {Expression} is invalid for reason {_errorInformation}";
        }
    }
}
