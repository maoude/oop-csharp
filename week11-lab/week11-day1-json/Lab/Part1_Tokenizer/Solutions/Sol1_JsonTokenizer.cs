/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_JsonTokenizer. [INSTRUCTOR ONLY]
 *           Do not open until after submitting your own implementation.
 */

using System.Text;

namespace OopCsharp.Week11.Part1_Tokenizer.Solutions;

public enum SolTokenKind
{
    LeftBrace, RightBrace,
    LeftBracket, RightBracket,
    Colon, Comma,
    StringLiteral, NumberLiteral, BooleanLiteral, Null
}

/// <summary>Immutable token produced by the solution tokenizer.</summary>
public record SolToken(SolTokenKind Kind, string Value);

/// <summary>Reference implementation of the JSON tokenizer.</summary>
public class Sol1_JsonTokenizer
{
    /// <summary>Scans input and returns all tokens in order.</summary>
    public IReadOnlyList<SolToken> Tokenize(string input)
    {
        var tokens = new List<SolToken>();
        int i = 0;
        while (i < input.Length)
        {
            char c = input[i];
            if (char.IsWhiteSpace(c)) { i++; continue; }

            switch (c)
            {
                case '{': tokens.Add(new(SolTokenKind.LeftBrace,    "{")); i++; break;
                case '}': tokens.Add(new(SolTokenKind.RightBrace,   "}")); i++; break;
                case '[': tokens.Add(new(SolTokenKind.LeftBracket,  "[")); i++; break;
                case ']': tokens.Add(new(SolTokenKind.RightBracket, "]")); i++; break;
                case ':': tokens.Add(new(SolTokenKind.Colon,        ":")); i++; break;
                case ',': tokens.Add(new(SolTokenKind.Comma,        ",")); i++; break;
                case '"': tokens.Add(ReadString(input, ref i));             break;
                case 't':
                case 'f':
                case 'n': tokens.Add(ReadKeyword(input, ref i));            break;
                default:
                    if (c == '-' || char.IsDigit(c))
                        tokens.Add(ReadNumber(input, ref i));
                    else
                        throw new InvalidOperationException(
                            $"Unexpected character '{c}' at position {i}");
                    break;
            }
        }
        return tokens;
    }

    private SolToken ReadString(string input, ref int i)
    {
        i++; // skip opening "
        var sb = new StringBuilder();
        while (i < input.Length)
        {
            char c = input[i];
            if (c == '\\' && i + 1 < input.Length)
            {
                char next = input[i + 1];
                sb.Append(next switch
                {
                    '"'  => '"',
                    '\\' => '\\',
                    'n'  => '\n',
                    't'  => '\t',
                    'r'  => '\r',
                    _    => next
                });
                i += 2;
            }
            else if (c == '"')
            {
                i++; // skip closing "
                break;
            }
            else
            {
                sb.Append(c);
                i++;
            }
        }
        return new(SolTokenKind.StringLiteral, sb.ToString());
    }

    private SolToken ReadNumber(string input, ref int i)
    {
        int start = i;
        if (input[i] == '-') i++;
        while (i < input.Length &&
               (char.IsDigit(input[i]) || input[i] == '.' ||
                input[i] == 'e' || input[i] == 'E' ||
                input[i] == '+' || input[i] == '-'))
            i++;
        return new(SolTokenKind.NumberLiteral, input[start..i]);
    }

    private SolToken ReadKeyword(string input, ref int i)
    {
        string rest = input[i..];
        if (rest.StartsWith("true"))  { i += 4; return new(SolTokenKind.BooleanLiteral, "true");  }
        if (rest.StartsWith("false")) { i += 5; return new(SolTokenKind.BooleanLiteral, "false"); }
        if (rest.StartsWith("null"))  { i += 4; return new(SolTokenKind.Null,           "null");  }
        throw new InvalidOperationException(
            $"Unknown keyword starting at position {i}: '{rest[..Math.Min(5, rest.Length)]}'");
    }
}
