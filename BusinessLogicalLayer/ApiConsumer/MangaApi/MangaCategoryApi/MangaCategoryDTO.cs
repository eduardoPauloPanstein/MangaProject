// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AnimeMA
{
    public LinksMA links { get; set; }
}

public class AttributesMA
{
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int totalMediaCount { get; set; }
    public string slug { get; set; }
    public bool nsfw { get; set; }
    public int childCount { get; set; }
}

public class DatumMA
{
    public string id { get; set; }
    public string type { get; set; }
    public LinksMA links { get; set; }
    public AttributesMA attributes { get; set; }
    public RelationshipsMA relationships { get; set; }
}

public class DramaMA
{
    public LinksMA links { get; set; }
}

public class LinksMA
{
    public string self { get; set; }
    public string related { get; set; }
    public string first { get; set; }
    public string last { get; set; }
}

public class MangaMA
{
    public LinksMA links { get; set; }
}

public class MetaMA
{
    public int count { get; set; }
}

public class ParentMA
{
    public LinksMA links { get; set; }
}

public class RelationshipsMA
{
    public ParentMA parent { get; set; }
    public AnimeMA anime { get; set; }
    public DramaMA drama { get; set; }
    public MangaMA manga { get; set; }
}

public class RootMA
{
    public List<DatumMA> data { get; set; }
    public MetaMA meta { get; set; }
    public LinksMA links { get; set; }
}

