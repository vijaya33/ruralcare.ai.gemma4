# ruralcare-ai-gemma4 
RuralCare AI uses a layered architecture where the Blazor frontend captures multilingual patient intake, the .NET API coordinates workflow execution, and the AI Orchestrator invokes Gemma 4 for translation, summarization, SOAP note generation, and triage support. Shared contracts isolate transport models, while future modules support OCR, offline sync, and healthcare interoperability. It is A Kaggle Impact Submission Powered by Gemma 4 to demonstrate the method of harnessing the power of Gemma 4 to drive positive change and global impact. 

# Important note: In order test this application against real time Gemma 4 model on HUGGING FACE:
The model I chose on Hugging Face is: google/gemma-4-E2B-it

My ApiKey with READ ONLY ACCESS to Gemma 4 model on HUGIING FACE: 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 

(it is disabled now as I published it along wth code to GitHub reposiotry, so HUGGING FACE automtically disables the security key, hence a new Api Key / security code is required for testing this product). 

# Subtitle
An offline-first multimodal healthcare intelligence platform powered by Gemma 4

# Architecture Diagrams. 
<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/b918c19c-9b1a-48df-ae2c-a67f8e3ebf20" />


Actual Architecture diagram is below displaying classes and work flow: 

<img width="1934" height="1324" alt="ruralcare architecture diagram" src="https://github.com/user-attachments/assets/fb94c53f-5a3c-4d27-9f21-4c7520baab0b" />


# RuralCare AI

**An offline-first multimodal healthcare intelligence platform powered by Gemma 4**

> Kaggle Impact Submission • Health & Sciences Track • Built with Gemma 4 edge + cloud reasoning

---

##  Problem Statement

Rural and underserved healthcare environments often lack:

* specialist access
* reliable internet
* multilingual clinical documentation
* real-time triage support
* continuity of patient records

RuralCare AI solves this using **Gemma 4 edge intelligence**, **agentic retrieval**, and **multimodal clinical reasoning**.

---

##  Core Features of this application

*  Multilingual patient intake
*  SOAP note generation
*  Handwritten referral OCR + summarization
*  Wound image triage support
*  Risk scoring + escalation thresholds
*  Cloud sync when internet returns
*  WHO / CDC / VA medical guideline retrieval
*  Explainable and safe clinician-in-the-loop workflows

---

##  Gemma 4 Usage

### Edge inference

* Gemma 4 E4B
* local triage reasoning
* SOAP note generation
* referral summarization
* multilingual intake

### Cloud escalation

* Gemma 4 26B
* longitudinal case reasoning
* population risk analytics
* outbreak clustering
* advanced retrieval workflows

### Native function calling

* triage scoring
* FHIR patient lookup
* drug interaction checks
* offline sync queue
* escalation routing

---

##  Code File(s) and Folder Structure

```text
ruralcare-ai-gemma4/
│
├── README.md
├── LICENSE
├── .gitignore
├── RuralCareAI.sln
│
├── docs/
│   ├── architecture-diagram.png
│   ├── kaggle-writeup.md
│   ├── demo-storyboard.md
│   └── deployment-guide.md
│
├── media/
│   ├── cover-image.png
│   ├── screenshots/
│   └── demo-video-script.md
│
├── benchmarks/
│   ├── triage-accuracy.md
│   └── edge-vs-cloud-latency.md
│
├── src/
│   ├── RuralCare.Web/
│   │   ├── Pages/
│   │   │   ├── Home.razor
│   │   │   ├── Intake.razor
│   │   │   ├── Triage.razor
│   │   │   └── ReferralUpload.razor
│   │   └── Program.cs
│   │
│   ├── RuralCare.Api/
│   │   ├── Controllers/
│   │   │   ├── IntakeController.cs
│   │   │   ├── TriageController.cs
│   │   │   └── ReferralController.cs
│   │   ├── Services/
│   │   │   ├── TriageService.cs
│   │   │   └── GemmaOrchestrator.cs
│   │   ├── Models/
│   │   │   ├── PatientIntakeRequest.cs
│   │   │   └── TriageResponse.cs
│   │   └── Program.cs
│   │
│   ├── RuralCare.AI.Orchestrator/
│   │   ├── Agents/
│   │   │   ├── TriageAgent.cs
│   │   │   ├── ReferralAgent.cs
│   │   │   └── RetrievalAgent.cs
│   │   └── Functions/
│   │       ├── RiskScoreFunction.cs
│   │       └── FhirLookupFunction.cs
│   │
│   ├── RuralCare.OCR/
│   │   └── ReferralOcrService.cs
│   │
│   └── RuralCare.Infrastructure/
│       ├── Persistence/
│       ├── Logging/
│       └── Sync/
│
└── tests/
    ├── RuralCare.Api.Tests/
    └── RuralCare.AI.Tests/
```

