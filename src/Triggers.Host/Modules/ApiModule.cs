namespace Triggers.Host.Modules
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Newtonsoft.Json;

    public class Notification
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public Guid ID { get; set; }
    }

    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api/")
        {
            var n = new List<Notification> {
                new Notification {ID = Guid.NewGuid(), Caption = "Ticket gefunden!", Message = "Eintracht Frankfurt gegen Schalke 04"},
                new Notification {ID = Guid.NewGuid(), Message = "bar"},
                new Notification {ID = Guid.NewGuid(), Message = "baz"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "schmutzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzisdfsdfbuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
                new Notification {ID = Guid.NewGuid(), Message = "fuzzibuzzi"},
            };
            var json = JsonConvert.SerializeObject(new {Notifications = n});

            Get["notifications"] = _ => Response.AsText(json, "application/json; charset=utf-8");
        }
    }
}