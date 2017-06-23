using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using YamlDotNet.Serialization;

public class YamlOutputFormatter : TextOutputFormatter
{
    private Serializer serializer;

    public YamlOutputFormatter(Serializer serializer)
    {
        Serializer = serializer;

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    public Serializer Serializer { get => serializer; set => serializer = value; }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (selectedEncoding == null)
        {
            throw new ArgumentNullException(nameof(selectedEncoding));
        }

        var response = context.HttpContext.Response;
        using (var writer = context.WriterFactory(response.Body, selectedEncoding))
        {
            WriteObject(writer, context.Object);

            await writer.FlushAsync();
        }
    }

    private void WriteObject(TextWriter writer, object value)
    {
        if (writer == null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        Serializer.Serialize(writer, value);
    }
}