namespace DesignPatternChallenge_Prototype.Prototypes;

internal class DocumentTemplate : IPrototype
{
    public string Title { get; set; }
    public string Category { get; set; }
    public List<Section> Sections { get; set; }
    public DocumentStyle Style { get; set; }
    public List<string> RequiredFields { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public ApprovalWorkflow Workflow { get; set; }
    public List<string> Tags { get; set; }

    public DocumentTemplate()
    {
        Sections = new List<Section>();
        RequiredFields = new List<string>();
        Metadata = new Dictionary<string, string>();
        Tags = new List<string>();
    }

    public IPrototype Clone()
    {
        var newDocumentTemplate = new DocumentTemplate
        {
            Title = this.Title,
            Category = this.Category,
            Style = (DocumentStyle)this.Style.Clone(),
            Workflow = (ApprovalWorkflow)this.Workflow.Clone()
        };

        newDocumentTemplate.RequiredFields.AddRange(this.RequiredFields);
        newDocumentTemplate.Tags.AddRange(this.Tags);

        foreach (var section in this.Sections)
        {
            newDocumentTemplate.Sections.Add((Section)section.Clone());
        }

        foreach (var kvp in this.Metadata)
        {
            newDocumentTemplate.Metadata[kvp.Key] = kvp.Value;
        }

        return newDocumentTemplate;
    }
}