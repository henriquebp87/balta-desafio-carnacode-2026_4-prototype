namespace DesignPatternChallenge_Prototype.Prototypes;

internal class Section : IPrototype
{
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; }

    public Section()
    {
        Placeholders = new List<string>();
    }

    public IPrototype Clone()
    {
        var newSection = new Section
        {
            Name = this.Name,
            Content = this.Content,
            IsEditable = this.IsEditable
        };

        newSection.Placeholders.AddRange(this.Placeholders);

        return newSection;
    }
}