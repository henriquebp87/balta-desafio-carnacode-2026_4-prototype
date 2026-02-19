namespace DesignPatternChallenge_Prototype.Prototypes;

internal class ApprovalWorkflow : IPrototype
{
    public List<string> Approvers { get; set; }
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow()
    {
        Approvers = new List<string>();
    }

    public IPrototype Clone()
    {
        var newApprovalWorkflow = new ApprovalWorkflow
        {
            RequiredApprovals = this.RequiredApprovals,
            TimeoutDays = this.TimeoutDays
        };

        newApprovalWorkflow.Approvers.AddRange(this.Approvers);

        return newApprovalWorkflow;
    }
}