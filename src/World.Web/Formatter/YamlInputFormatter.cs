﻿
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using YamlDotNet.Serialization;

public class YamlInputFormatter : TextInputFormatter
{
    private readonly Deserializer _deserializer;

    public YamlInputFormatter(Deserializer deserializer)
    {
        _deserializer = deserializer;

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
        //SupportedMediaTypes.Add(MediaTypeHeaderValues.ApplicationYaml);
        //SupportedMediaTypes.Add(MediaTypeHeaderValues.TextYaml);
    }

    public Deserializer Deserializer => _deserializer;

    public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }

        var request = context.HttpContext.Request;

        using (var streamReader = context.ReaderFactory(request.Body, encoding))
        {
            var type = context.ModelType;

            try
            {
                var model = Deserializer.Deserialize(streamReader, type);
                return InputFormatterResult.SuccessAsync(model);
            }
            catch (Exception)
            {
                return InputFormatterResult.FailureAsync();
            }
        }
    }
}