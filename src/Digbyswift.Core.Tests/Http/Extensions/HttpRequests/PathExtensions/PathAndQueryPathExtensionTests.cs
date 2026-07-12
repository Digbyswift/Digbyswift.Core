using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Digbyswift.Extensions.Http.Tests.Extensions.HttpRequests.PathExtensions;

[TestFixture]
public class PathAndQueryPathExtensionTests
{
    private HttpRequest _sut = null!;

    [SetUp]
    public void Setup()
    {
        var context = Substitute.For<HttpContext>();

        _sut = context.Request;
        _sut.Method = HttpMethod.Get.Method;
        _sut.Scheme = "http";
        _sut.Host = new HostString("localhost");
    }

    #region PathAndQueryReplaceValueOfKey

    [TestCase(100, "/testing/?test=100")]
    [TestCase(100.00d, "/testing/?test=100")]
    [TestCase(100.01d, "/testing/?test=100.01")]
    [TestCase(true, "/testing/?test=True")]
    public void PathAndQueryReplaceValueOfKey_ReturnsQuerystringWithStringifiedValue_WhenValueObjectIsNotString(object value, string expectedResult)
    {
        // Arrange
        const string originalPath = "/testing/";
        const string key = "test";

        _sut.Path = new PathString(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(key, "initial-value"));

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(key, value);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("/testing", null)]
    [TestCase("/testing/", null)]
    [TestCase("/testing-again/", null)]
    [TestCase("/testing-again/", "?test=true")]
    public void PathAndQueryReplaceValueOfKey_ReturnsOriginalPathAndQuery_WhenKeyParamIsEmpty(string path, string querystring)
    {
        // Arrange
        _sut.Path = new PathString(path);
        _sut.QueryString = QueryString.FromUriComponent(querystring);

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(String.Empty, String.Empty);

        // Assert
        Assert.That(result, Is.EqualTo(path + querystring));
    }

    [TestCase("/testing", null)]
    [TestCase("/testing/", null)]
    [TestCase("/testing-again/", null)]
    [TestCase("/testing-again/", "?test=true")]
    public void PathAndQueryReplaceValueOfKey_ReturnsOriginalPathAndQuery_WhenKeyIsNotPresent(string path, string querystring)
    {
        // Arrange
        const string nonMatchedKey = "mismatch";

        _sut.Path = new PathString(path);
        _sut.QueryString = QueryString.FromUriComponent(querystring);

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(nonMatchedKey, String.Empty);

        // Assert
        Assert.That(result, Is.EqualTo(path + querystring));
    }

    [Test]
    public void PathAndQueryReplaceValueOfKey_ReturnsOriginalPathAndQuery_WhenKeyIsNotPresent()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/?test=testquery";

        const string keyToReplaceValueFor = "test";
        const string replacementValue = "testquery";
        const string nonMatchedKey = "mismatch";

        _sut.Path = new PathString(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, replacementValue));

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(nonMatchedKey, String.Empty);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    [Test]
    public void PathAndQueryReplaceValueOfKey_AddsQueryString_WhenKeyParamIsMatched()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string keyToReplaceValueFor = "test";
        const string replacementValue = "replaced";
        const string expectedPath = $"{originalPath}?{keyToReplaceValueFor}={replacementValue}";

        _sut.Path = PathString.FromUriComponent(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, "testquery"));

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(keyToReplaceValueFor, replacementValue);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    [Test]
    public void PathAndQueryReplaceValueOfKey_ReturnsPathAndQuery_WithMultipleValuesOfSameKeyReplaced()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/?test=replaced";

        const string keyToReplaceValueFor = "test";
        const string replacementValue = "replaced";

        _sut.Path = new PathString(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, "testquery"));
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, "testagain"));

        // Act
        var result = _sut.PathAndQueryReplaceValueOfKey(keyToReplaceValueFor, replacementValue);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    #endregion

    #region PathAndQueryWithoutKey

    [Test]
    public void PathAndQueryWithoutKey_ReturnsOriginalPath_WhenKeyIsNotPresent_AndRequestHasQueryString()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/?test=testquery";
        const string keyToReplaceValueFor = "test";
        const string mismatchedKey = "mismatch";

        _sut.Path = new PathString(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, "testquery"));

        // Act
        var result = _sut.PathAndQueryWithoutKey(mismatchedKey);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    [Test]
    public void PathAndQueryWithoutKey_ReturnsOriginalPath_WhenKeyIsNotPresent_AndRequestDoesNotHaveQueryString()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/";
        const string mismatchedKey = "mismatch";

        _sut.Path = new PathString(originalPath);

        // Act
        var result = _sut.PathAndQueryWithoutKey(mismatchedKey);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    #endregion

    #region PathAndQueryWithoutKeys

    [Test]
    public void PathAndQueryWithoutKeys_ReturnsOriginalPath_WhenKeysAreNotPresent_AndRequestHasQueryString()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/?test=testquery";
        const string keyToReplaceValueFor = "test";
        const string mismatchedKey = "mismatch";
        const string mismatchedKeyTwo = "mismatch2";

        _sut.Path = new PathString(originalPath);
        _sut.QueryString = _sut.QueryString.Add(QueryString.Create(keyToReplaceValueFor, "testquery"));

        // Act
        var result = _sut.PathAndQueryWithoutKeys(mismatchedKey, mismatchedKeyTwo);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    [Test]
    public void PathAndQueryWithoutKeys_ReturnsOriginalPath_WhenKeysAreNotPresent_AndRequestDoesNotHaveQueryString()
    {
        // Arrange
        const string originalPath = "/testing/";
        const string expectedPath = "/testing/";
        const string mismatchedKey = "mismatch";

        _sut.Path = new PathString(originalPath);

        // Act
        var result = _sut.PathAndQueryWithoutKeys(mismatchedKey);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }

    #endregion
}
