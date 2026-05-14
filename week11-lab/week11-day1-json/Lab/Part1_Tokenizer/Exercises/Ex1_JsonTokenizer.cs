using System.Text;

namespace OopCsharp.Week11.Part1_Tokenizer.Exercises;

// ── Provided types — do not modify ─────────────────────────────────────────

public enum TokenKind
{
    LeftBrace, RightBrace,
    LeftBracket, RightBracket,
    Colon, Comma,
    StringLiteral, NumberLiteral, BooleanLiteral, Null
}

/// <summary>Immutable token produced by JsonTokenizer.</summary>
public record Token(TokenKind Kind, string Value);

// ── Your implementation ─────────────────────────────────────────────────────

/// <summary>Hand-rolled JSON tokenizer.</summary>
public class JsonTokenizer
{
    /// <summary>
    /// Scans <paramref name="input"/> left to right and returns all tokens in order.
    /// Whitespace is skipped silently. Returns an empty list for whitespace-only or empty input.
    /// </summary>
    public IReadOnlyList<Token> Tokenize(string input)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Called when the current character is <c>"</c>.
    /// Advances <paramref name="i"/> past the closing quote.
    /// Handles <c>\"</c> and <c>\\</c> escape sequences.
    /// Returns a <see cref="TokenKind.StringLiteral"/> token whose Value has no surrounding quotes.
    /// </summary>
    private Token ReadString(string input, ref int i)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Called when the current character is <c>-</c> or a digit.
    /// Reads the full number (integer or floating-point).
    /// Returns a <see cref="TokenKind.NumberLiteral"/> token.
    /// </summary>
    private Token ReadNumber(string input, ref int i)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Called when the current character is <c>t</c>, <c>f</c>, or <c>n</c>.
    /// Matches <c>true</c>, <c>false</c>, or <c>null</c>.
    /// Returns a <see cref="TokenKind.BooleanLiteral"/> or <see cref="TokenKind.Null"/> token.
    /// Throws <see cref="InvalidOperationException"/> for unrecognised keywords.
    /// </summary>
    private Token ReadKeyword(string input, ref int i)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}
