namespace DesignPatternChallenge_Prototype.Prototypes;

internal class Margins : IPrototype
{
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }

    public IPrototype Clone()
    {
        return new Margins
        {
            Top = this.Top,
            Bottom = this.Bottom,
            Left = this.Left,
            Right = this.Right
        };
    }
}