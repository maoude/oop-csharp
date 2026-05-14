using System.Text;
using System.Text.Json;

namespace OopCsharp.Week11.Part1_Tokenizer.Demo;

// ── TokenKind ──────────────────────────────────────────────────────────────
public enum DemoTokenKind
{
    LeftBrace, RightBrace,
    LeftBracket, RightBracket,
    Colon, Comma,
    StringLiteral, NumberLiteral, BooleanLiteral, Null
}

public record DemoToken(DemoTokenKind Kind, string Value);

// ── Demo tokenizer (read-only reference — students implement their own) ───
public static class Demo01_Tokenizer
{
    public static void Run()
    {
        Console.WriteLine("=== Demo 01 — Hand-rolled JSON Tokenizer ===\n");

        string json = """{"name":"Alice","age":30,"active":true,"scores":[1,2,3],"extra":null}""";
        Console.WriteLine($"Input: {json}\n");

        var tokens = Tokenize(json);
        foreach (var t in tokens)
            Console.WriteLine($"  {t.Kind,-16} | {t.Value}");

        Console.WriteLine($"\nTotal tokens: {tokens.Count}");

        // Demonstrate escape handling
        Console.WriteLine("\n--- Escape sequence demo ---");
        string escaped = """{"msg":"say \"hello\" to me"}""";
        Console.WriteLine($"Input: {escaped}");
        var escaped_tokens = Tokenize(escaped);
        foreach (var t in escaped_tokens)
            Console.WriteLine($"  {t.Kind,-16} | {t.Value}");
    }

    // ── Public entry point ──────────────────────────────────────────────────
    public static IReadOnlyList<DemoToken> Tokenize(string input)
    {
        var tokens = new List<DemoToken>();
        int i = 0;
        while (i < input.Length)
        {
            char c = input[i];
            if (char.IsWhiteSpace(c)) { i++; continue; }

            switch (c)
            {
                case '{': tokens.Add(new(DemoTokenKind.LeftBrace,    "{")); i++; break;
                case '}': tokens.Add(new(DemoTokenKind.RightBrace,   "}")); i++; break;
                case '[': tokens.Add(new(DemoTokenKind.LeftBracket,  "[")); i++; break;
                case ']': tokens.Add(new(DemoTokenKind.RightBracket, "]")); i++; break;
                case ':': tokens.Add(new(DemoTokenKind.Colon,        ":")); i++; break;
                case ',': tokens.Add(new(DemoTokenKind.Comma,        ",")); i++; break;
                case '"': tokens.Add(ReadString(input, ref i));             break;
                case 't':
                case 'f':
                case 'n': tokens.Add(ReadKeyword(input, ref i));            break;
                default:
                    if (c == '-' || char.IsDigit(c))
                        tokens.Add(ReadNumber(input, ref i));
                    else
                        throw new InvalidOperationException($"Unexpected character '{c}' at position {i}");
                    break;
            }
        }
        return tokens;
    }

    // ── Private helpers ─────────────────────────────────────────────────────
    private static DemoToken ReadString(string input, ref int i)
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
        return new(DemoTokenKind.StringLiteral, sb.ToString());
    }

    private static DemoToken ReadNumber(string input, ref int i)
    {
        int start = i;
        if (input[i] == '-') i++;
        while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.' ||
               input[i] == 'e' || input[i] == 'E' || input[i] == '+' || input[i] == '-'))
            i++;
        return new(DemoTokenKind.NumberLiteral, input[start..i]);
    }

    private static DemoToken ReadKeyword(string input, ref int i)
    {
        string rest = input[i..];
        if (rest.StartsWith("true"))  { i += 4; return new(DemoTokenKind.BooleanLiteral, "true");  }
        if (rest.StartsWith("false")) { i += 5; return new(DemoTokenKind.BooleanLiteral, "false"); }
        if (rest.StartsWith("null"))  { i += 4; return new(DemoTokenKind.Null,           "null");  }
        throw new InvalidOperationException($"Unknown keyword starting at position {i}: '{rest[..Math.Min(5,rest.Length)]}'");
    }
}
