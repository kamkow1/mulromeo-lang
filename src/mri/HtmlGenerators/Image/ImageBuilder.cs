namespace mri.HtmlGenerators;

public class ImageBuilder
{
    private string Name;

    private string Path;

    private byte[] Content;

    public ImageBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public ImageBuilder SetPath(string path)
    {
        Path = path;
        return this;
    }

    public ImageBuilder SetContent(byte[] content)
    {
        Content = content;
        return this;
    }

    public Image Build()
    {
        return new Image
        {
            Path = Path,
            Name = Name,
            Content = Content
        };
    }
}