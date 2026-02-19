namespace DesignPatternChallenge_Prototype.Prototypes;

internal class DocumentStyle : IPrototype
{
    public string FontFamily { get; set; }
    public int FontSize { get; set; }
    public string HeaderColor { get; set; }
    public string LogoUrl { get; set; }
    public Margins PageMargins { get; set; }

    public IPrototype Clone()
    {
        return new DocumentStyle
        {
            FontFamily = this.FontFamily,
            FontSize = this.FontSize,
            HeaderColor = this.HeaderColor,
            LogoUrl = this.LogoUrl,
            PageMargins = (Margins)this.PageMargins.Clone()
        };
    }
}