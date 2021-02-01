using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class BotMessagePayload
    {
        [JsonProperty("@context")]
        public string Context { get { return "https://schema.org/extensions"; } }

        [JsonProperty("@type")]
        public string Type { get { return "MessageCard"; } }

        public List<BotMessageAction> PotentialAction { get; set; }
        public List<BotMessageSection> Sections { get; set; }
        public string Summary { get { return "(Noc noc ✊✊🚪) Tem um alerta aqui para vocês ..."; } }
        public string ThemeColor { get { return "FF0303"; } }
        public string Title { get { return "✊✊🚪 - Tem um alerta aqui para vocês ..."; } }
    }

    public class BotMessageAction
    {
        [JsonProperty("@type")]
        public string @type { get { return "OpenUri"; } }
        public string Name { get; set; }

        [JsonProperty("targets")]
        public List<BotMessageTarget> Target { get; set; }
    }

    public class BotMessageTarget
    {
        [JsonProperty("os")]
        public string OS { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class BotMessageSection
    {
        public List<BotMessageFact> Facts { get; set; }
        public string Text { get; set; }
    }

    public class BotMessageFact
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
