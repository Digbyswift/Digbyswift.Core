using System.Net.Http;
using Digbyswift.Core.Http.Extensions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Http.Extensions.HttpRequests.PathExtensions;

[TestFixture]
public class IsPngOrJpgPathExtensionTests
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

    [TestCase("/0.jpg")]
    [TestCase("/0.jpeg")]
    [TestCase("/0.JPG")]
    [TestCase("/0.JPEG")]
    [TestCase("/0.Jpg")]
    [TestCase("/0.Jpeg")]
    [TestCase("/a/a.jpg")]
    [TestCase("/a/a.JPG")]
    [TestCase("/a/a.Jpg")]
    [TestCase("/a/a.jpeg")]
    [TestCase("/a/a.JPEG")]
    [TestCase("/a/a.Jpg")]
    [TestCase("/a/a.Jpeg")]
    public void IsPngOrJpeg_ReturnsTrue_WhenPathEndsWithJpgExtension(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.IsPngOrJpeg();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("/0.jpeg")]
    [TestCase("/0.JPEG")]
    [TestCase("/0.Jpeg")]
    [TestCase("/a/a.jpeg")]
    [TestCase("/a/a.JPEG")]
    [TestCase("/a/a.Jpeg")]
#pragma warning disable S4144
    public void IsPngOrJpeg_ReturnsTrue_WhenPathEndsWithJpegExtension(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.IsPngOrJpeg();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("/0.png")]
    [TestCase("/0.PNG")]
    [TestCase("/0.Png")]
    [TestCase("/a/a.png")]
    [TestCase("/a/a.PNG")]
    [TestCase("/a/a.Png")]
    public void IsPngOrJpeg_ReturnsTrue_WhenPathEndsWithPngExtension(string path)
#pragma warning restore S4144
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.IsPngOrJpeg();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("/.png")]
    [TestCase("/.PNG")]
    [TestCase("/0.png")]
    [TestCase("/0.PNG")]
    [TestCase("/0.Png")]
    [TestCase("/a/a.png")]
    [TestCase("/a/a.PNG")]
    [TestCase("/a/a.Png")]
    public void IsPngOrJpeg_ReturnsTrue_WhenRequestHasAQueryString(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);
        _sut.QueryString.Add("test", "true");

        // Act
        var result = _sut.IsPngOrJpeg();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("/.x")]
    [TestCase("/.X")]
    [TestCase("/.pong")]
    [TestCase("/.txt")]
    [TestCase("/.TXT")]
    [TestCase("/a/a.x")]
    [TestCase("/a/a.X")]
    [TestCase("/a/a.pong")]
    [TestCase("/a/a.pong")]
    public void IsPngOrJpeg_ReturnsFalse_WhenPathDoesNotEndWithSomethingOtherThanAJpgOrPngExtension(string path)
    {
        // Arrange
        _sut.Path = new PathString(path);

        // Act
        var result = _sut.IsPngOrJpeg();

        // Assert
        Assert.That(result, Is.False);
    }
}
