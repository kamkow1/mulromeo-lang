using System;
using System.Xml;
using System.Xml.Linq;

namespace mri;

public class HtmlCreator
{
    private static XmlDocument _template = new();

    public HtmlCreator()
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
            <div id='images'><ul></ul></div>
            <div id='audios'><ul></ul></div>
            <script src='index.js'></script>
        </body>
        </html>
        ");
    }
    
    public string Make() => _template.OuterXml;

    public void AddImgElement(string src, int width, int height)
    {
        var imageList = _template.SelectSingleNode("/html/body/div[@id='images']/ul");
        imageList.InnerXml += @$"
        <li>
            <img src='{src}' 
                id='{Guid.NewGuid()}' 
                width='{width}' 
                height='{height}' 
            />
        </li>";
    }

    public void AddAudioElement(string src, int width, int height)
    {
        var audioList = _template.SelectSingleNode("/html/body/div[@id='audios']/ul");
        audioList.InnerXml += $@"
        <li>
            <audio controls='true' style='width: {width}; height: {height}'>
                <source src='{src}' type='audio/mpeg' />
            </audio>
        </li>";
    }
}