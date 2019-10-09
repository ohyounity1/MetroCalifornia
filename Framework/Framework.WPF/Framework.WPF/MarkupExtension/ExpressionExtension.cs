using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Framework.Patterns.Exception;

namespace Framework.WPF.MarkupExtension
{
    /// <summary>
    /// <see cref="System.Windows.Markup.MarkupExtension"/> which acts as an expression
    /// </summary>
    public abstract class ExpressionExtension : System.Windows.Markup.MarkupExtension
    {
        /// <summary>
        /// Original expression
        /// </summary>
        private readonly string _expression;

        /// <summary>
        /// Some keywords (used for logical && and ||)
        /// </summary>
        private static readonly IList<string> ReservedWords = new List<string> { "AND", "OR" };

        /// <summary>
        /// Initializes a new instance of <see cref="ExpressionValueConverter"/>
        /// </summary>
        /// <param name="expression">Original expression</param>
        public ExpressionExtension(string expression)
        {
            _expression = expression;
        }

        /// <summary>
        /// Method to call in order to evaluate our expression with the given values
        /// </summary>
        /// <param name="values">List of values</param>
        /// <returns>Expression result</returns>
        protected object ComputeExpression(params object[] values)
        {
            // Convert an expression like {0} OP {1} where {0} and {1} will be replaced with value and parameter
            var expression = Regex.Replace(_expression, @"\{[\d]+\}", match =>
            {
                // Keep certain keywords
                if (ReservedWords.Contains(match.Value))
                    return match.Value;
                // Remove the {}
                var indexAsString = match.Value.Substring(1, match.Value.Length - 2);
                // Convert to integer index
                var index = Convert.ToInt32(indexAsString);
                // Validate, throw exception if not valid index
                if (index >= values.Length)
                    throw new Exception<InvalidExpressionIndex>(new InvalidExpressionIndex(index, _expression));
                return Convert.ToString(values[index], CultureInfo.InvariantCulture);
                throw new Exception<ExpressionError>(new ExpressionError($"Invalid string found {match.Value}", _expression));
            }, RegexOptions.CultureInvariant);

            // use an empty data table to compute the result
            var result = new DataTable().Compute(expression, null);
            var doubleResult = result as double?;

            // Compute() may return a double value despite all integer math
            // check for this condition and return an integer if so
            if (doubleResult.HasValue && ((doubleResult.Value - (int)doubleResult) < double.Epsilon))
                return (int)doubleResult;

            return result;
        }

        /// <summary>
        /// <see cref="System.Windows.Markup.MarkupExtension.ProvideValue(IServiceProvider)"/>
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        /// <returns>This object instance</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
