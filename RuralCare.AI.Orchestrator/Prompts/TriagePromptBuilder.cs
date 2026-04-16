using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuralCare.Web.Models;

namespace RuralCare.AI.Orchestrator.Prompts
{

    public static class TriagePromptBuilder
    {
        public static string Build(PatientIntakeModel request)
        {
            return $"""
        You are RuralCare AI powered by Gemma 4.

        Analyze the patient symptoms and generate:
        1. SOAP note
        2. risk level (Low, Moderate, High)
        3. recommendation
        4. escalation urgency

        Patient: {request.PatientName}
        Age: {request.Age}
        Language: {request.PreferredLanguage}
        Symptoms: {request.Symptoms}
        Location: {request.VillageOrLocation}

        Output in structured clinical format.
        """;
        }
    }
}