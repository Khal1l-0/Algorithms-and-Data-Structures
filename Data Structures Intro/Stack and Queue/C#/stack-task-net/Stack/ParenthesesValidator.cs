using System;
using System.Collections.Generic;

namespace Stack;

/// <summary>
/// Provides methods for validating parentheses in strings.
/// </summary>
public static class ParenthesesValidator
{
    private static readonly Dictionary<char, char> _brackets = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    /// <summary>
    /// Validates if the input string has properly matched and nested parentheses.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <returns>true if the input has valid parentheses; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    /// <remarks>
    /// Valid parentheses are:
    /// - Empty string
    /// - Properly matched and nested pairs of (), [], and {}
    /// - Any other characters are allowed and ignored
    /// </remarks>
    public static bool Validate(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        var stack = new Stack<char>();

        foreach (char ch in input)
        {
            // Если открывающая скобка — кладём её в стек
            if (_brackets.ContainsKey(ch))
            {
                stack.Push(ch);
            }
            // Если закрывающая скобка — проверяем соответствие
            else if (_brackets.ContainsValue(ch))
            {
                if (stack.Count == 0)
                    return false;

                char lastOpen = stack.Pop();

                if (_brackets[lastOpen] != ch)
                    return false;
            }
            // Любые другие символы просто игнорируем
        }

        // Если стек пуст — все скобки корректно закрыты
        return stack.Count == 0;
    }
}