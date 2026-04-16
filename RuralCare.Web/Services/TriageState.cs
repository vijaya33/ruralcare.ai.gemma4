
using RuralCare.Web.Models;

namespace RuralCare.Web.Services;

public static class TriageState
{
    public static string LastPatientName { get; set; } = string.Empty;
    public static TriageResultModel? CurrentResult { get; set; }
}