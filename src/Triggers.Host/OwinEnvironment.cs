using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers.Host
{
    using System.IO;
    using System.Threading;

    public class OwinEnvironment
    {
        public class OwinEnvironmentRequest
        {
            public Stream Body { get; private set; }
            public IDictionary<string, string[]> Headers { get; private set; }
            public String Method { get; private set; }
            public String Path { get; private set; }
            public String PathBase { get; private set; }
            public String Protocol { get; private set; }
            public String QueryString { get; private set; }
            public String Scheme { get; private set; }

            public OwinEnvironmentRequest(IDictionary<string, object> env)
            {
                Body = (Stream) env["owin.RequestBody"];
                Headers = (IDictionary<string, string[]>) env["owin.RequestHeaders"];
                Method = (string) env["owin.RequestMethod"];
                Path = (string) env["owin.RequestPath"];
                PathBase = (string) env["owin.RequestPathBase"];
                Protocol = (string) env["owin.RequestProtocol"];
                QueryString = (string) env["owin.RequestQueryString"];
                Scheme = (string) env["owin.RequestScheme"];
            }
        }

        public class OwinEnvironmentResponse
        {
            public Stream Body { get; private set; }
            public IDictionary<string, string[]> Headers { get; private set; }

            public OwinEnvironmentResponse(IDictionary<string, object> env)
            {
                Body = (Stream) env["owin.ResponseBody"];
                Headers = (IDictionary<string, string[]>) env["owin.ResponseHeaders"];
            }
        }

        public String Version { get; private set; }
        public CancellationToken CallCancelled { get; private set; }

        public OwinEnvironmentRequest Request { get; private set; }
        public OwinEnvironmentResponse Response { get; private set; }

        public OwinEnvironment(IDictionary<string, object> env)
        {
            Request = new OwinEnvironmentRequest(env);
            Response = new OwinEnvironmentResponse(env);
            Version = (string) env["owin.Version"];
            CallCancelled = (CancellationToken) env["owin.CallCancelled"];
        }
    }
}