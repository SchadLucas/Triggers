namespace Triggers.API.Modules
{
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Triggers.Host.Frontend.Mappers;

    public class StaticResourceModule : NancyModule
    {
        public StaticResourceModule(IEnumerable<IMapHttpRequestsToDisk> requestMappers)
        {
            _requestMappers = requestMappers;
            Get["/{resource*}"] = x => Index();
        }

        private readonly IEnumerable<IMapHttpRequestsToDisk> _requestMappers;

        private Response Index()
        {
            var path = Request.Url.Path;

            var mapper = _requestMappers.SingleOrDefault(m => m.CanHandle(path));

            if (mapper != null && mapper.CanHandle(path)) {
                return mapper.GetResponse(path);
            }

            return new NotFoundResponse();
        }
    }
}