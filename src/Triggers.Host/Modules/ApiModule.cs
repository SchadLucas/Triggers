namespace Triggers.Host.Modules
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Newtonsoft.Json;
    using NLog;

    public class JsonModel
    {
        public JsonModel()
        {
            ID = Guid.NewGuid();
        }

        [JsonProperty("id")]
        public Guid ID { get; private set; }
    }

    public class Notification : JsonModel
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class LogMessage : JsonModel
    {
        [JsonProperty("component")]
        public string Component { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api/")
        {
            var n = new List<Notification> {
                new Notification {Caption = "Ticket gefunden!", Message = "Eintracht Frankfurt gegen Schalke 04"},
                new Notification {Message = "bar"},
                new Notification {Message = "baz"},
            };

            var l = new List<LogMessage> {
                new LogMessage {Component="ApiModule", Caption="Wat", Message="Nix passiert", Level=LogLevel.Trace.ToString(), Timestamp = DateTime.Now},
                new LogMessage {Component="ApiModule", Caption="Was Anneres", Message="Auch nix passiert", Level=LogLevel.Debug.ToString(), Timestamp = DateTime.Now},
                new LogMessage {Component="ApiModule", Caption="IDK", Message="abc", Level=LogLevel.Info.ToString(), Timestamp = DateTime.Now},
                new LogMessage {Component="ApiModule", Caption="IDK", Message="foo", Level=LogLevel.Warn.ToString(), Timestamp = DateTime.Now},
                new LogMessage {Component="ApiModule", Caption="IstillDK", Message="bar", Level=LogLevel.Error.ToString(), Timestamp = DateTime.Now},
                new LogMessage {Component="ApiModule", Caption="WEman", Message="baz", Level=LogLevel.Fatal.ToString(), Timestamp = DateTime.Now},
            };

            var notificationsJson = JsonConvert.SerializeObject(new {Notifications = n});
            var logsJson = JsonConvert.SerializeObject(new {Logs = l});
            Get["notifications"] = _ => Response.AsText(notificationsJson, "application/json; charset=utf-8");
            Get["logs"] = _ => Response.AsText(logsJson, "application/json; charset=utf-8");
        }
    }
}