/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for JsonSerializerHelper exercises (13 tests covering Serialize, SerializeIndented, Deserialize, TryDeserialize, round-trips).
 */

using System.Text.Json;
using Xunit;
using OopCsharp.Week11.Part3_JsonSerializer.Exercises;

namespace OopCsharp.Week11.Tests.Part3_JsonSerializer;

public class StudentWeek11Part3_Ex1Tests
{
    private readonly JsonSerializerHelper _helper = new();

    private static PersonRecord SamplePerson() =>
        new() { Name = "Alice", Age = 30, IsActive = true };

    private static ProductRecord SampleProduct() =>
        new() { Name = "Widget", Price = 9.99, Tags = ["sale", "new"] };

    // ── Serialize ───────────────────────────────────────────────────────────

    [Fact]
    public void Serialize_ContainsPropertyValues()
    {
        string json = _helper.Serialize(SamplePerson());
        Assert.Contains("Alice", json);
        Assert.Contains("30",    json);
    }

    [Fact]
    public void Serialize_ProducesValidJson_RoundTrips()
    {
        string json = _helper.Serialize(SamplePerson());
        var ex = Record.Exception(() => JsonDocument.Parse(json));
        Assert.Null(ex);
    }

    // ── SerializeIndented ───────────────────────────────────────────────────

    [Fact]
    public void SerializeIndented_ContainsNewlines()
    {
        string json = _helper.SerializeIndented(SamplePerson());
        Assert.Contains("\n", json);
    }

    [Fact]
    public void SerializeIndented_RoundTrips()
    {
        var original = SamplePerson();
        string json  = _helper.SerializeIndented(original);
        var result   = _helper.Deserialize<PersonRecord>(json);
        Assert.Equal(original.Name,     result?.Name);
        Assert.Equal(original.Age,      result?.Age);
        Assert.Equal(original.IsActive, result?.IsActive);
    }

    // ── Deserialize ─────────────────────────────────────────────────────────

    [Fact]
    public void Deserialize_ReturnsCorrectStringProperty()
    {
        string json = """{"Name":"Bob","Age":0,"IsActive":false}""";
        var result  = _helper.Deserialize<PersonRecord>(json);
        Assert.Equal("Bob", result?.Name);
    }

    [Fact]
    public void Deserialize_ReturnsCorrectIntProperty()
    {
        string json = """{"Name":"","Age":42,"IsActive":false}""";
        var result  = _helper.Deserialize<PersonRecord>(json);
        Assert.Equal(42, result?.Age);
    }

    [Fact]
    public void Deserialize_RoundTrips_ListOfObjects()
    {
        var people = new List<PersonRecord>
        {
            new() { Name = "Carol", Age = 28 },
            new() { Name = "Dave",  Age = 35 }
        };
        string json  = _helper.Serialize(people);
        var result   = _helper.Deserialize<List<PersonRecord>>(json);
        Assert.Equal(2,       result?.Count);
        Assert.Equal("Carol", result?[0].Name);
        Assert.Equal("Dave",  result?[1].Name);
    }

    [Fact]
    public void Deserialize_JsonPropertyName_MapsSnakeCaseKey()
    {
        // "product_name" in JSON should map to ProductRecord.Name via [JsonPropertyName]
        string json = """{"product_name":"Gadget","Price":4.99,"Tags":[]}""";
        var result  = _helper.Deserialize<ProductRecord>(json);
        Assert.Equal("Gadget", result?.Name);
    }

    // ── TryDeserialize ──────────────────────────────────────────────────────

    [Fact]
    public void TryDeserialize_ValidJson_ReturnsTrueAndResult()
    {
        string json = _helper.Serialize(SamplePerson());
        bool ok = _helper.TryDeserialize<PersonRecord>(json, out var result);
        Assert.True(ok);
        Assert.Equal("Alice", result?.Name);
    }

    [Fact]
    public void TryDeserialize_InvalidJson_ReturnsFalseAndNull()
    {
        bool ok = _helper.TryDeserialize<PersonRecord>("NOT_JSON", out var result);
        Assert.False(ok);
        Assert.Null(result);
    }

    [Fact]
    public void TryDeserialize_NeverThrows()
    {
        var ex = Record.Exception(() =>
            _helper.TryDeserialize<PersonRecord>("NOT_JSON", out _));
        Assert.Null(ex);
    }

    // ── Round-trip ──────────────────────────────────────────────────────────

    [Fact]
    public void Serialize_ThenDeserialize_ValuesMatch()
    {
        var original = SamplePerson();
        string json  = _helper.Serialize(original);
        var result   = _helper.Deserialize<PersonRecord>(json);
        Assert.Equal(original.Name,     result?.Name);
        Assert.Equal(original.Age,      result?.Age);
        Assert.Equal(original.IsActive, result?.IsActive);
    }

    [Fact]
    public void Deserialize_JsonArray_IntoListOfPersonRecord()
    {
        string json  = """[{"Name":"Eve","Age":22,"IsActive":true}]""";
        var result   = _helper.Deserialize<List<PersonRecord>>(json);
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Eve", result[0].Name);
    }
}
