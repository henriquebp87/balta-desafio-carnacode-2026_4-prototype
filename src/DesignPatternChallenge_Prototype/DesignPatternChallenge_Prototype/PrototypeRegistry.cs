using DesignPatternChallenge_Prototype.Prototypes;

namespace DesignPatternChallenge_Prototype
{
    internal class PrototypeRegistry
    {
        private readonly Dictionary<string, IPrototype> _prototypes = new();

        public void Register(string key, IPrototype prototype)
            => _prototypes[key] = prototype;

        public IPrototype Get(string key)
            => _prototypes[key].Clone();
    }
}
