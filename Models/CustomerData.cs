namespace BotBustorDB.Models
{

    public sealed class CustomerData
    {
        public int CustomerId { get; set; }
        public List<Interaction> Interactions { get; set; }
    }

    public sealed class Interaction
    {
        public string InteractionDate { get; set; }
        public string InternalUpdateDate { get; set; }
        public string VerkDKUpdateDate { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int CvrNumber { get; set; }
        public string FormOfCompany { get; set; }
        public string Activity { get; set; }
        public List<BranchCode> BranchCodes { get; set; }
        public Employees Employees { get; set; }
        public Turnover Turnover { get; set; }
        public GeographicalCoverage GeographicalCoverage { get; set; }
        public string DevComment { get; set; }
    }

    public sealed class BranchCode
    {
        public string Internal { get; set; }
        public string VerkDK { get; set; }
    }

    public sealed class Employees
    {
        public int Internal { get; set; }
        public int VerkDK { get; set; }
    }

    public sealed class GeographicalCoverage
    {
        public bool Europe { get; set; }
        public bool USACanada { get; set; }
        public bool RestOfWorld { get; set; }
    }

    public sealed class TotalTurnover
    {
        public double? Internal { get; set; }
        public double? VerkDK { get; set; }
    }

    public sealed class Turnover
    {
        public TotalTurnover Total { get; set; }
        public double? Europe { get; set; }
        public double? USACanada { get; set; }
        public double? RestOfWorld { get; set; }
    }

}
