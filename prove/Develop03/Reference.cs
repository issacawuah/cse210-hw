public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public List<int> Verses { get; private set; }

    public Reference(string book, int chapter, List<int> verses)
    {
        Book = book;
        Chapter = chapter;
        Verses = verses;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{string.Join("-", Verses)}";
    }
}
