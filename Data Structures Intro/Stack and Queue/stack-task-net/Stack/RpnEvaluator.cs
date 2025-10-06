using System;
using System.Collections.Generic;

namespace Stack;

/// <summary>
/// Provides methods for evaluating arithmetic expressions in Reverse Polish Notation (RPN).
/// </summary>
public static class RpnEvaluator
{
    private static readonly Dictionary<string, Func<int, int, int>> Operators = new()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) =>
            {
                if (b == 0)
                    throw new DivideByZeroException();
                return a / b;
            }
        }
    };

    /// <summary>
    /// Evaluates the value of an arithmetic expression in Reverse Polish Notation (RPN).
    /// </summary>
    /// <param name="rpnTokens">An array of RPN tokens to evaluate.</param>
    /// <returns>The evaluation result of the RPN expression.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="rpnTokens"/> contains invalid tokens or the expression is invalid.
    /// </exception>
    public static int Evaluate(string[] rpnTokens)
    {
        if (rpnTokens == null || rpnTokens.Length == 0)
            throw new ArgumentException("Input cannot be null or empty.", nameof(rpnTokens));

        var stack = new Stack<int>();

        foreach (var token in rpnTokens)
        {
            if (Operators.ContainsKey(token))
            {
                // нужно хотя бы два числа в стеке
                if (stack.Count < 2)
                    throw new ArgumentException("Invalid RPN expression: insufficient operands.");

                int b = stack.Pop();
                int a = stack.Pop();
                int result = Operators[token](a, b);
                stack.Push(result);
            }
            else
            {
                if (!int.TryParse(token, out int value))
                    throw new ArgumentException($"Invalid token: '{token}'", nameof(rpnTokens));

                stack.Push(value);
            }
        }

        if (stack.Count != 1)
            throw new ArgumentException("Invalid RPN expression: leftover operands.");

        return stack.Pop();
    }
}