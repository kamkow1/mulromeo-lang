using System;
using System.Xml;
using System.Xml.Linq;

namespace mri.HtmlGenerators;

public class IndexCreator
{
    private static XmlDocument _template = new();

    public IndexCreator()
    {
        _template.LoadXml(@$"
        <html lang='en'>
        <head>
            <meta charset='UTF-8' />
            <meta name='viewport' content='width=device-width, initial-scale=1.0' />
            <meta http-equiv='X-UA-Compatible' content='ie=edge' />
            <title>HTML 5 Boilerplate</title>
            <link rel='stylesheet' href='style.css' />
        </head>
        <body>
            <div id='media'>
            </div>
            <script src='index.js'></script>
        </body>
        </html>
        ");
    }
    
    public string Make() => _template.OuterXml;

    public void AddImgElement(string src)
    {
        var mediaDiv =_template.SelectSingleNode("/html/body/div[@id='media']");
        mediaDiv.InnerXml = $"<img src=\"{src}\" />";
    }
}