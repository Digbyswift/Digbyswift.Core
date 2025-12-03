using System.Text;

namespace Digbyswift.Core.IO;

public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}
