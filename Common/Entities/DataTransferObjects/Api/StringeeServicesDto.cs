using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class StringeeServicesDto
    {

    }

    public class StringeeCallResultDto
    {
        [JsonPropertyName("r")]
        public int R { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("call_id")]
        public string CallId { get; set; }
    }

    public class StringeeCallOutRequestDto
    {
        [JsonPropertyName("from")]
        public StringeeNumber From { get; set; }

        [JsonPropertyName("to")]
        public List<StringeeNumber> To { get; set; }

        [JsonPropertyName("answer_url")]
        public string AnswerUrl { get; set; }

        [JsonPropertyName("actions")]
        public List<StringeeCallAction> Actions { get; set; }

        public StringeeCallOutRequestDto(string callNumber, string text, string answerUrl, string fromNumber)
        {
            From = new StringeeNumber(fromNumber);
            To = new List<StringeeNumber>()
            {
                new StringeeNumber(callNumber)
            };

            this.AnswerUrl = answerUrl;
            var tmpAction = new StringeeCallAction
            {
                Action = "talk",
                Text = text,
                Voice = "banmai",
                Speed = 0
            };
            Actions = new List<StringeeCallAction>();
            Actions.Add(tmpAction);
        }
    }

    public class StringeeNumber
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        public StringeeNumber(string num)
        {
            Type = "external";
            Alias = num;
            Number = num;
        }
    }

    public class StringeeCallAction
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("voice")]
        public string Voice { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }

        public StringeeCallAction()
        {
            //voice = "hn_female_thutrang_phrase_48k-hsmm";
            //voice = "female";
            //voice = "lannhi";
            Voice = "banmai";
            Speed = 0;
        }
    }
}
