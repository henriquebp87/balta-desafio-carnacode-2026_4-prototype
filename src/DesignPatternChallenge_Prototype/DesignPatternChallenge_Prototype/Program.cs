// DESAFIO: Sistema de Templates de Documentos
// PROBLEMA: Um sistema de gerenciamento documental precisa criar novos documentos
// baseados em templates pré-configurados complexos (contratos, propostas, relatórios)
// O código atual recria objetos do zero, perdendo muito tempo em inicializações

using DesignPatternChallenge_Prototype;
using DesignPatternChallenge_Prototype.Prototypes;

public class Program
{
    // Contexto: Sistema que gerencia documentos corporativos com muitas configurações
    // Templates são complexos e custosos para criar, mas precisamos gerar muitos documentos similares

    private static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Templates de Documentos ===\n");

        var registry = new PrototypeRegistry();

        registry.Register("Contrato", CreateDocumentTemplate());
        var service = new DocumentService(registry);

        Console.WriteLine("Criando 5 contratos de serviço...");
        var startTime = DateTime.Now;

        for (var i = 1; i <= 5; i++)
        {
            var contract = service.CreateServiceContract();

            // Depois modificamos apenas dados específicos do cliente
            contract.Title = $"Contrato #{i} - Cliente {i}";

            service.DisplayTemplate(contract);
        }

        var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
        Console.WriteLine($"Tempo total: {elapsed}ms\n");

        var consultingContract = service.CreateConsultingContract();
        service.DisplayTemplate(consultingContract);
    }

    private static IPrototype CreateDocumentTemplate()
    {
        var template = new DocumentTemplate
        {
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                LogoUrl = "https://company.com/logo.png",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow
            {
                RequiredApprovals = 2,
                TimeoutDays = 5
            }
        };

        template.Workflow.Approvers.Add("gerente@empresa.com");
        template.Workflow.Approvers.Add("juridico@empresa.com");

        template.Sections.Add(new Section
        {
            Name = "Cláusula 1 - Objeto",
            IsEditable = true
        });
        template.Sections.Add(new Section
        {
            Name = "Cláusula 2 - Prazo",
            Content = "O prazo de vigência será de...",
            IsEditable = true
        });
        template.Sections.Add(new Section
        {
            Name = "Cláusula 3 - Valor",
            Content = "O valor total do contrato é de...",
            IsEditable = true
        });

        template.RequiredFields.Add("NomeCliente");
        template.RequiredFields.Add("CPF");
        template.RequiredFields.Add("Endereco");

        template.Tags.Add("contrato");

        template.Metadata["Versao"] = "1.0";
        template.Metadata["Departamento"] = "Comercial";
        template.Metadata["UltimaRevisao"] = DateTime.Now.ToString();

        return template;
    }
}