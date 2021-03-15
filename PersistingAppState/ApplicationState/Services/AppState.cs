using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ApplicationState.Services
{
    public class AppState 
    {
        [JsonProperty]
        public string Message { get; private set; } = "";
        [JsonProperty] 
        public bool Enabled { get; private set; } = false;
        [JsonProperty] 
        public int Counter { get; private set; } = 0;
        [JsonProperty]
        public int TimeToLiveInSeconds { get; set; } = 60;
        [JsonProperty]
        public DateTime LastAccessed { get; set; } = DateTime.Now;

        public void UpdateMessage(ComponentBase Source, string Message)
        {
            this.Message = Message;
            NotifyStateChanged(Source, "Message");
        }

        public void UpdateEnabled(ComponentBase Source, bool Enabled)
        {
            this.Enabled = Enabled;
            NotifyStateChanged(Source, "Enabled");
        }

        public void UpdateCounter(ComponentBase Source, int Counter)
        {
            this.Counter = Counter;
            NotifyStateChanged(Source, "Counter");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}
