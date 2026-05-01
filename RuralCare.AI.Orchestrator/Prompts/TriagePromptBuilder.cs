using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuralCare.Contracts.Models;

namespace RuralCare.AI.Orchestrator.Prompts
{

    public static class TriagePromptBuilder
    {
        // Rwad only access token for 
        static string Gemma4ReadOnlyAccessTokenOnHuggingFace = "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";
        static string Gemma4ModelUrl = "https://huggingface.co/google/gemma-4-E2B-it";

        public static string Build(PatientIntakeRequest request)
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