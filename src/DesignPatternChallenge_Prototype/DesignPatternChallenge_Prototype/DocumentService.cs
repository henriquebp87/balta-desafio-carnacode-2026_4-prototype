using DesignPatternChallenge_Prototype.Prototypes;

namespace DesignPatternChallenge_Prototype
{
    internal class DocumentService
    {
        private readonly PrototypeRegistry _registry;

        public DocumentService(PrototypeRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        // Problema: Criação manual de templates complexos repetidamente
        public DocumentTemplate CreateServiceContract()
        {
            Console.WriteLine("Criando template de Contrato de Serviço a partir do protótipo armazenado no registry...");

            return GetAndCustomizeTemplateFromRegistry(
                title: "Contrato de Prestação de Serviços",
                sectionContent: "O presente contrato tem por objeto...",
                customTags: "servicos");
        }

        public DocumentTemplate CreateConsultingContract()
        {
            Console.WriteLine("Criando template de Contrato de Consultoria a partir do protótipo armazenado no registry...");

            return GetAndCustomizeTemplateFromRegistry(
                title: "Contrato de Consultoria",
                sectionContent: "O presente contrato de consultoria tem por objeto...",
                customTags: "consultoria");
        }

        public void DisplayTemplate(DocumentTemplate template)
        {
            Console.WriteLine($"\n=== {template.Title} ===");
            Console.WriteLine($"Categoria: {template.Category}");
            Console.WriteLine($"Seções: {template.Sections.Count}");
            Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
            Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
            Console.WriteLine();
        }

        private DocumentTemplate GetAndCustomizeTemplateFromRegistry(
            string title,
            string sectionContent,
            params string[] customTags)
        {
            if (_registry.Get("Contrato") is not DocumentTemplate template) return null;

            template.Title = title;
            template.Sections[0].Content = sectionContent;
            template.Tags.AddRange(customTags);

            return template;
        }
    }
}