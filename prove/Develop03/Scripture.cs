public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> Words { get; set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(Reference);
        foreach (var word in Words)
        {
            Console.Write(word.IsHidden ? "___ " : word.Text + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            var unhiddenWords = Words.Where(w => !w.IsHidden).ToList();
            if (unhiddenWords.Count == 0) break; // No more words to hide

            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }
}
