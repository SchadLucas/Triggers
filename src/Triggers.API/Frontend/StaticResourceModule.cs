namespace Triggers.API.Frontend
{
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Triggers.API.Frontend.Mappers;

    public class StaticResourceModule : NancyModule
    {
        private readonly IEnumerable<IMapHttpRequestsToDisk> _requestMappers;

        public StaticResourceModule(IEnumerable<IMapHttpRequestsToDisk> requestMappers)
        {
            _requestMappers = requestMappers;
            Get["/{resource*}"] = x => Index();
        }

        private Response Index()
        {
            var path = Request.Url.Path;

            var mapper = _requestMappers.SingleOrDefault(m => m.CanHandle(path));

            if (mapper != null && mapper.CanHandle(path))
            {
                return mapper.GetResponse(path);
            }

            return new NotFoundResponse();
        }
    }
}