using System.IO;
using System.Text;

namespace Digbyswift.Core.IO;

public class UTF8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}