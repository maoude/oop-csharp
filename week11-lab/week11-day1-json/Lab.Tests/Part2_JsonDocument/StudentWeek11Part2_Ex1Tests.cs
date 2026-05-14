using System.Text.Json;
using Xunit;
using OopCsharp.Week11.Part2_JsonDocument.Exercises;

namespace OopCsharp.Week11.Tests.Part2_JsonDocument;

public class StudentWeek11Part2_Ex1Tests
{
    private readonly JsonDocumentReader _reader = new();

    private const string SampleJson = """
        {
            "name": "Alice",
            "age": 30,
            "score": 9.5,
            "active": true,
            "inactive": false,
            "nickname": null,
            "tags": ["admin", "user", "viewer"],
            "empty": []
        }
        """;

    // ── ReadStringProperty ──────────────────────────────────────────────────

    [Fact]
    public void ReadStringProperty_ExistingKey_ReturnsValue()
    {
        string? result = _reader.ReadStringProperty(SampleJson, "name");
        Assert.Equal("Alice", result);
    }

    [Fact]
    public void ReadStringProperty_MissingKey_ReturnsNull()
    {
        string? result = _reader.ReadStringProperty(SampleJson, "missing");
        Assert.Null(result);
    }

    [Fact]
    public void ReadStringProperty_JsonNullValue_ReturnsNull()
    {
        string? result = _reader.ReadStringProperty(SampleJson, "nickname");
        Assert.Null(result);
    }

    // ── ReadNumberProperty ──────────────────────────────────────────────────

    [Fact]
    public void ReadNumberProperty_ExistingKey_ReturnsDouble()
    {
        double? result = _reader.ReadNumberProperty(SampleJson, "score");
        Assert.Equal(9.5, result);
    }

    [Fact]
    public void ReadNumberProperty_MissingKey_ReturnsNull()
    {
        double? result = _reader.ReadNumberProperty(SampleJson, "missing");
        Assert.Null(result);
    }

    // ── ReadBoolProperty ────────────────────────────────────────────────────

    [Fact]
    public void ReadBoolProperty_TrueValue_ReturnsTrue()
    {
        bool? result = _reader.ReadBoolProperty(SampleJson, "active");
        Assert.True(result);
    }

    [Fact]
    public void ReadBoolProperty_FalseValue_ReturnsFalse()
    {
        bool? result = _reader.ReadBoolProperty(SampleJson, "inactive");
        Assert.False(result);
    }

    // ── ReadStringArray ─────────────────────────────────────────────────────

    [Fact]
    public void ReadStringArray_ExistingKey_ReturnsAllElements()
    {
        string[] result = _reader.ReadStringArray(SampleJson, "tags");
        Assert.Equal(new[] { "admin", "user", "viewer" }, result);
    }

    [Fact]
    public void ReadStringArray_MissingKey_ReturnsEmptyArray()
    {
        string[] result = _reader.ReadStringArray(SampleJson, "missing");
        Assert.Empty(result);
    }

    // ── GetArrayLength ──────────────────────────────────────────────────────

    [Fact]
    public void GetArrayLength_ExistingArray_ReturnsCount()
    {
        int result = _reader.GetArrayLength(SampleJson, "tags");
        Assert.Equal(3, result);
    }

    // ── GetObjectKeys ───────────────────────────────────────────────────────

    [Fact]
    public void GetObjectKeys_ReturnsAllTopLevelKeys()
    {
        string[] keys = _reader.GetObjectKeys(SampleJson);
        Assert.Contains("name",     keys);
        Assert.Contains("age",      keys);
        Assert.Contains("score",    keys);
        Assert.Contains("active",   keys);
        Assert.Contains("inactive", keys);
        Assert.Contains("nickname", keys);
        Assert.Contains("tags",     keys);
        Assert.Contains("empty",    keys);
        Assert.Equal(8, keys.Length);
    }

    [Fact]
    public void GetObjectKeys_EmptyObject_ReturnsEmptyArray()
    {
        string[] keys = _reader.GetObjectKeys("{}");
        Assert.Empty(keys);
    }

    // ── Invalid JSON ────────────────────────────────────────────────────────

    [Fact]
    public void ReadStringProperty_InvalidJson_ThrowsJsonException()
    {
        Assert.Throws<JsonException>(() =>
            _reader.ReadStringProperty("NOT_JSON", "name"));
    }
}
