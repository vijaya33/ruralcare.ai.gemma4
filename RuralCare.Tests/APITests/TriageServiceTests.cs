using FluentAssertions;
using Moq;
using RuralCare.API.Services;
using RuralCare.AI.Orchestrator.Services;
using RuralCare.Contracts.Models;

namespace RuralCare.Tests.APITests
{
    public class TriageServiceTests
    {
        [Fact]
        public async Task AnalyzeAsync_ShouldReturnTriageResponse_WhenValidRequestIsProvided()
        {
            // Arrange
            var request = new PatientIntakeRequest
            {
                PatientName = "Marie Dubois",
                Age = 55,
                //Gender = "Female",
                PreferredLanguage = "French",
                Symptoms = "Chest pain and difficulty breathing",
                VillageOrLocation = "Rural Clinic"
            };

            var expectedResponse = new TriageResponse
            {
                RiskLevel = "High",
                Confidence = "94%",
                SoapNote = "S: Chest pain reported. A: High-risk symptoms. P: Immediate escalation.",
                Recommendation = "Immediate clinician review required.",
                SuggestedActions = new List<string>
            {
                "Check vitals",
                "Administer oxygen",
                "Prepare emergency transport"
            }
            };

            var gemmaMock = new Mock<IGemmaOrchestrator>();

            gemmaMock
                .Setup(x => x.RunClinicalTriageAsync(request))
                .ReturnsAsync(expectedResponse);

            var service = new TriageService(gemmaMock.Object);

            // Act
            var result = await service.AnalyzeAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.RiskLevel.Should().Be("High");
            result.Confidence.Should().Be("94%");
            result.Recommendation.Should().Be("Immediate clinician review required.");

            gemmaMock.Verify(x => x.RunClinicalTriageAsync(request), Times.Once);
        }
    }
}