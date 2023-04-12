using System;
using System.Collections.Generic;
using AGDevX.IEnumerables;
using Xunit;

namespace AGDevX.Tests.IEnumerables;

public class IEnumerableExtensionsTests
{
    [Fact]
    public void IsNullOrEmpty_Null_ReturnsTrue()
    {
        //-- Arrange
        List<string>? strings = null;

        //-- Act
        var isNullOrEmpty = strings.IsNullOrEmpty();

        //-- Assert
        Assert.True(isNullOrEmpty);
    }

    [Fact]
    public void IsNullOrEmpty_Empty_ReturnsTrue()
    {
        //-- Arrange
        List<string> strings = new();

        //-- Act
        var isNullOrEmpty = strings.IsNullOrEmpty();

        //-- Assert
        Assert.True(isNullOrEmpty);
    }

    [Fact]
    public void IsNullOrEmpty_NotNullOrEmpty_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings = new List<string>
        {
            "Hello"
        };

        //-- Act
        var isNullOrEmpty = strings.IsNullOrEmpty();

        //-- Assert
        Assert.False(isNullOrEmpty);
    }

    [Fact]
    public void HasCommonStringElement_ReturnsTrue()
    {
        //-- Arrange
        List<string> strings1 = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        List<string> strings2 = new List<string>
        {
            "hello"
        };

        //-- Act
        var hasCommonElement = strings1.HasCommonStringElement(strings2);

        //-- Assert
        Assert.True(hasCommonElement);
    }

    [Fact]
    public void HasCommonStringElement_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings1 = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        List<string> strings2 = new List<string>
        {
            "oh", "my", "gosh"
        };

        //-- Act
        var hasCommonElement = strings1.HasCommonStringElement(strings2);

        //-- Assert
        Assert.False(hasCommonElement);
    }

    [Fact]
    public void HasCommonStringElement_Null1_ReturnsFalse()
    {
        //-- Arrange
        List<string>? strings1 = null;

        List<string> strings2 = new List<string>
        {
            "oh", "my", "gosh"
        };

        //-- Act
        var hasCommonElement = strings1.HasCommonStringElement(strings2);

        //-- Assert
        Assert.False(hasCommonElement);
    }

    [Fact]
    public void HasCommonStringElement_Null2_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings1 = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        List<string>? strings2 = null;

        //-- Act
        var hasCommonElement = strings1.HasCommonStringElement(strings2);

        //-- Assert
        Assert.False(hasCommonElement);
    }

    [Fact]
    public void ToDataTable_NullEnumerable_ReturnsEmptyDataTable()
    {
        //-- Arrange
        List<Guid>? ids = null;

        //-- Act
#pragma warning disable CS8604 // Possible null reference argument.
        var dataTable = ids.ToIdDataTable();
#pragma warning restore CS8604 // Possible null reference argument.

        //-- Assert
        Assert.True(dataTable.Rows.Count == 0);
    }

    [Fact]
    public void ToDataTable_EmptyEnumerable_ReturnsEmptyDataTable()
    {
        //-- Arrange
        var ids = new List<Guid>();

        //-- Act
        var dataTable = ids.ToIdDataTable();

        //-- Assert
        Assert.True(dataTable.Rows.Count == 0);
    }

    [Fact]
    public void ToDataTable_OneRecordDefaultColumnName_ReturnsDataTableWithOneRecordAndIdColumn()
    {
        //-- Arrange
        var guid = Guid.NewGuid();
        var ids = new List<Guid>
        {
            guid
        };

        //-- Act
        var dataTable = ids.ToIdDataTable();

        //-- Assert
        Assert.True(dataTable.Rows.Count == 1);
        Assert.True(dataTable.Columns.Count == 1);
        Assert.True(dataTable.Columns.Contains("Id"));
        Assert.True(new Guid(dataTable.Rows[0]["Id"].ToString()!) == guid);
    }

    [Fact]
    public void ToDataTable_MultipleRecordDefaultColumnName_ReturnsDataTableWithOneRecordAndIdColumn()
    {
        //-- Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var ids = new List<Guid>
        {
            guid1,
            guid2
        };

        //-- Act
        var dataTable = ids.ToIdDataTable();

        //-- Assert
        Assert.True(dataTable.Rows.Count == 2);
        Assert.True(dataTable.Columns.Count == 1);
        Assert.True(dataTable.Columns.Contains("Id"));
        Assert.True(new Guid(dataTable.Rows[0]["Id"].ToString()!) == guid1);
        Assert.True(new Guid(dataTable.Rows[1]["Id"].ToString()!) == guid2);
    }

    [Fact]
    public void ToDataTable_MultipleRecordCustomColumnName_ReturnsDataTableWithOneRecordAndCustomColumn()
    {
        //-- Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var ids = new List<Guid>
        {
            guid1,
            guid2
        };

        //-- Act
        var dataTable = ids.ToIdDataTable("TheId");

        //-- Assert
        Assert.True(dataTable.Rows.Count == 2);
        Assert.True(dataTable.Columns.Count == 1);
        Assert.True(dataTable.Columns.Contains("TheId"));
        Assert.True(new Guid(dataTable.Rows[0]["TheId"].ToString()!) == guid1);
        Assert.True(new Guid(dataTable.Rows[1]["TheId"].ToString()!) == guid2);
    }

    [Fact]
    public void ContainsIgnoreCase_ReturnsTrue()
    {
        //-- Arrange
        List<string> strings = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        var str = "hello";

        //-- Act
        var contains = strings.ContainsIgnoreCase(str);

        //-- Assert
        Assert.True(contains);
    }

    [Fact]
    public void ContainsIgnoreCase_Null_ReturnsTrue()
    {
        //-- Arrange
        List<string?> strings = new List<string?>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut", null
        };

        string? str = null;

        //-- Act
        var contains = strings.ContainsIgnoreCase(str);

        //-- Assert
        Assert.True(contains);
    }

    [Fact]
    public void ContainsIgnoreCase_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        var str = "hey";

        //-- Act
        var contains = strings.ContainsIgnoreCase(str);

        //-- Assert
        Assert.False(contains);
    }

    [Fact]
    public void ContainsIgnoreCase_NullStrings_ReturnsFalse()
    {
        //-- Arrange
        List<string>? strings = null;

        var str = "hello";

        //-- Act
        var contains = strings.ContainsIgnoreCase(str);

        //-- Assert
        Assert.False(contains);
    }

    [Fact]
    public void ContainsIgnoreCase_NullString_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        string? str = null;

        //-- Act
        var contains = strings.ContainsIgnoreCase(str);

        //-- Assert
        Assert.False(contains);
    }

    [Fact]
    public void AnySafe_ReturnsTrue()
    {
        //-- Arrange
        List<string> strings = new List<string>
        {
            "hi", "there", "hello", "it's", "me", "I'm", "the", "adstronaut"
        };

        //-- Act
        var contains = strings.AnySafe();

        //-- Assert
        Assert.True(contains);
    }

    [Fact]
    public void AnySafe_Null_ReturnsFalse()
    {
        //-- Arrange
        List<string>? strings = null;

        //-- Act
        var contains = strings.AnySafe();

        //-- Assert
        Assert.False(contains);
    }

    [Fact]
    public void AnySafe_Empty_ReturnsFalse()
    {
        //-- Arrange
        List<string> strings = new();

        //-- Act
        var contains = strings.AnySafe();

        //-- Assert
        Assert.False(contains);
    }
}