using System;
using System.Net.Http;
using Digbyswift.Extensions.Http.Tests.MockObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using NSubstitute;
using NUnit.Framework;

namespace Digbyswift.Extensions.Http.Tests.Extensions.HttpRequests;

[TestFixture]
public class RequestExtensionTests
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
        _sut.Headers.Returns(new MockHeaderCollection());
    }

    #region PathHasExtension

    [TestCase("/.x")]
    [TestCase("/.X")]
    [TestCase("/.txt")]
    [TestCase("/.TXT")]
    [TestCase("/0.jpg")]
    [TestCase("/0.JPEG")]
    [TestCase("/a/a.x")]
    [TestCase("/a/a.X")]
    [TestCase("/a/a.jpeg")]
    [TestCase("/a/a.JPEG")]
    public void PathHasExtension_ReturnsTrue_WhenPathHasAnExtension(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.PathHasExtension();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("/")]
    [TestCase("/0")]
    [TestCase("/0/")]
    [TestCase("/a")]
    [TestCase("/a/")]
    [TestCase("/A")]
    [TestCase("/A/")]
    [TestCase("/a/b")]
    [TestCase("/a/b/")]
    [TestCase("/A/B")]
    [TestCase("/A/B/")]
    public void PathHasExtension_ReturnsFalse_WhenPathHasNoExtension(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.PathHasExtension();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region GetRawReferrer

    [Test]
    public void GetRawReferrer_ReturnsNull_WhenNoReferrerHeaderExists()
    {
        // Act
        var referrer = _sut.GetRawReferrer();

        // Assert
        Assert.That(referrer, Is.Null);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void GetRawReferrer_ReturnsNull_WhenReferrerValueIsNullOrWhitespace(string? value)
    {
        // Arrange
        _sut.Headers.Add(HeaderNames.Referer, new StringValues(value));

        // Act
        var referrer = _sut.GetRawReferrer();

        // Assert
        Assert.That(referrer, Is.Null);
    }

    [TestCase("1")]
    [TestCase("#")]
    [TestCase(" # ")]
    [TestCase("/")]
    [TestCase("https://www.digbyswift.com")]
    public void GetRawReferrer_ReturnsValue_WhenReferrerValueIsNotNullOrWhitespace(string value)
    {
        // Arrange
        _sut.Headers.Add(HeaderNames.Referer, new StringValues(value));

        // Act
        var referrer = _sut.GetRawReferrer();

        // Assert
        Assert.That(referrer, Is.EqualTo(value));
    }

    #endregion

    #region GetReferrer

    [Test]
    public void GetReferrer_ReturnsNull_WhenNoReferrerHeaderExists()
    {
        // Act
        var referrer = _sut.GetReferrer();

        // Assert
        Assert.That(referrer, Is.Null);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void GetReferrer_ReturnsNull_WhenReferrerValueIsNullOrWhitespace(string? value)
    {
        // Arrange
        _sut.Headers.Add(HeaderNames.Referer, new StringValues(value));

        // Act
        var referrer = _sut.GetReferrer();

        // Assert
        Assert.That(referrer, Is.Null);
    }

    [TestCase("1")]
    [TestCase("1,2")]
    [TestCase("#")]
    [TestCase(" # ")]
    [TestCase("/")]
    [TestCase("/index.html")]
    [TestCase("/index.html,/default.html")]
    public void GetReferrer_ReturnsNull_WhenReferrerValueIsNotAbsolute(string? value)
    {
        // Arrange
        _sut.Headers.Add(HeaderNames.Referer, new StringValues(value));

        // Act
        var referrer = _sut.GetReferrer();

        // Assert
        Assert.That(referrer, Is.Null);
    }

    [TestCase("//www.digbyswift.com")]
    [TestCase("http://www.digbyswift.com")]
    [TestCase("https://www.digbyswift.com")]
    public void GetReferrer_ReturnsValue_WhenReferrerValueIsValidUrl(string value)
    {
        // Arrange
        _sut.Headers.Add(HeaderNames.Referer, new StringValues(value));
        var expectedResult = new Uri(value, UriKind.Absolute);

        // Act
        var referrer = _sut.GetReferrer();

        // Assert
        Assert.That(referrer, Is.EqualTo(expectedResult));
    }

    #endregion
}
