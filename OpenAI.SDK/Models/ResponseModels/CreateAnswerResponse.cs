﻿using System.Text.Json.Serialization;

namespace OpenAI.SDK.Models.ResponseModels
{
    public record CreateAnswerResponse : BaseResponse
    {
        [JsonPropertyName("Answers")] public List<string> Answers { get; set; }

        [JsonPropertyName("completion")] public string Completion { get; set; }

        [JsonPropertyName("model")] public string Model { get; set; }

        [JsonPropertyName("search_model")] public string SearchModel { get; set; }

        [JsonPropertyName("selected_documents")]
        public SelectedDocument[] SelectedDocuments { get; set; }
    }

    public record SelectedDocument
    {
        [JsonPropertyName("document")] public int Document { get; set; }

        [JsonPropertyName("text")] public string Text { get; set; }
    }
}