using Xunit;
using OopCsharp.Week11.Part1_Tokenizer.Exercises;

namespace OopCsharp.Week11.Tests.Part1_Tokenizer;

public class StudentWeek11Part1_Ex1Tests
{
    private readonly JsonTokenizer _tokenizer = new();

    // ── Single-character punctuation ────────────────────────────────────────

    [Fact]
    public void Tokenize_LeftBrace()
    {
        var tokens = _tokenizer.Tokenize("{");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.LeftBrace, tokens[0].Kind);
    }

    [Fact]
    public void Tokenize_RightBrace()
    {
        var tokens = _tokenizer.Tokenize("}");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.RightBrace, tokens[0].Kind);
    }

    [Fact]
    public void Tokenize_ColonAndComma()
    {
        var tokens = _tokenizer.Tokenize(",:");
        Assert.Equal(2, tokens.Count);
        Assert.Equal(TokenKind.Comma, tokens[0].Kind);
        Assert.Equal(TokenKind.Colon, tokens[1].Kind);
    }

    [Fact]
    public void Tokenize_Brackets()
    {
        var tokens = _tokenizer.Tokenize("[]");
        Assert.Equal(2, tokens.Count);
        Assert.Equal(TokenKind.LeftBracket,  tokens[0].Kind);
        Assert.Equal(TokenKind.RightBracket, tokens[1].Kind);
    }

    // ── String literals ─────────────────────────────────────────────────────

    [Fact]
    public void Tokenize_StringLiteral_ReturnsUnquotedValue()
    {
        var tokens = _tokenizer.Tokenize("\"hello\"");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.StringLiteral, tokens[0].Kind);
        Assert.Equal("hello", tokens[0].Value);
    }

    [Fact]
    public void Tokenize_StringLiteral_EscapedQuote()
    {
        // Input: "say \"hi\""  → value should be: say "hi"
        var tokens = _tokenizer.Tokenize("""
            "say \"hi\""
            """);
        Assert.Single(tokens);
        Assert.Equal(TokenKind.StringLiteral, tokens[0].Kind);
        Assert.Equal("say \"hi\"", tokens[0].Value);
    }

    // ── Number literals ─────────────────────────────────────────────────────

    [Fact]
    public void Tokenize_IntegerNumber()
    {
        var tokens = _tokenizer.Tokenize("42");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.NumberLiteral, tokens[0].Kind);
        Assert.Equal("42", tokens[0].Value);
    }

    [Fact]
    public void Tokenize_FloatingPointNumber()
    {
        var tokens = _tokenizer.Tokenize("3.14");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.NumberLiteral, tokens[0].Kind);
        Assert.Equal("3.14", tokens[0].Value);
    }

    // ── Keywords ────────────────────────────────────────────────────────────

    [Fact]
    public void Tokenize_BooleanLiterals()
    {
        var tokens = _tokenizer.Tokenize("true false");
        Assert.Equal(2, tokens.Count);
        Assert.Equal(TokenKind.BooleanLiteral, tokens[0].Kind);
        Assert.Equal("true",  tokens[0].Value);
        Assert.Equal(TokenKind.BooleanLiteral, tokens[1].Kind);
        Assert.Equal("false", tokens[1].Value);
    }

    [Fact]
    public void Tokenize_NullLiteral()
    {
        var tokens = _tokenizer.Tokenize("null");
        Assert.Single(tokens);
        Assert.Equal(TokenKind.Null, tokens[0].Kind);
        Assert.Equal("null", tokens[0].Value);
    }

    // ── Compound inputs ─────────────────────────────────────────────────────

    [Fact]
    public void Tokenize_SimpleObject_CorrectSequence()
    {
        var tokens = _tokenizer.Tokenize("""{"name":"Alice","age":30}""");
        Assert.Equal(7, tokens.Count);
        Assert.Equal(TokenKind.LeftBrace,     tokens[0].Kind);
        Assert.Equal(TokenKind.StringLiteral, tokens[1].Kind); Assert.Equal("name",  tokens[1].Value);
        Assert.Equal(TokenKind.Colon,         tokens[2].Kind);
        Assert.Equal(TokenKind.StringLiteral, tokens[3].Kind); Assert.Equal("Alice", tokens[3].Value);
        Assert.Equal(TokenKind.Comma,         tokens[4].Kind);
        Assert.Equal(TokenKind.StringLiteral, tokens[5].Kind); Assert.Equal("age",   tokens[5].Value);
        // remaining tokens: colon, 30, }
    }

    [Fact]
    public void Tokenize_Array_CorrectSequence()
    {
        var tokens = _tokenizer.Tokenize("[1,2,3]");
        Assert.Equal(7, tokens.Count);
        Assert.Equal(TokenKind.LeftBracket,  tokens[0].Kind);
        Assert.Equal(TokenKind.NumberLiteral, tokens[1].Kind); Assert.Equal("1", tokens[1].Value);
        Assert.Equal(TokenKind.Comma,         tokens[2].Kind);
        Assert.Equal(TokenKind.NumberLiteral, tokens[3].Kind); Assert.Equal("2", tokens[3].Value);
        Assert.Equal(TokenKind.Comma,         tokens[4].Kind);
        Assert.Equal(TokenKind.NumberLiteral, tokens[5].Kind); Assert.Equal("3", tokens[5].Value);
        Assert.Equal(TokenKind.RightBracket,  tokens[6].Kind);
    }

    [Fact]
    public void Tokenize_WhitespaceOnlyInput_ReturnsEmptyList()
    {
        var tokens = _tokenizer.Tokenize("   \t\n  ");
        Assert.Empty(tokens);
    }
}
