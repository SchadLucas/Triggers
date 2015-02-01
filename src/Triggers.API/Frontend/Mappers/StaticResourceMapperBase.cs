namespace Triggers.API.Frontend.Mappers
{
    using System.IO;
    using Nancy;
    using Nancy.Responses;

    public abstract class StaticResourceMapperBase : IMapHttpRequestsToDisk
    {
        private static readonly NotFoundResponse _notFoundResponse = new NotFoundResponse();

        public abstract string Map(string resourceUrl);

        public abstract bool CanHandle(string resourceUrl);

        public virtual Response GetResponse(string resourceUrl)
        {
            var filePath = Map(resourceUrl);

            if (File.Exists(filePath))
            {
                var response = new StreamResponse(() => GetContentStream(filePath), MimeTypes.GetMimeType(filePath));
                return response;
            }

            return _notFoundResponse;
        }

        protected virtual Stream GetContentStream(string filePath)
        {
            return File.OpenRead(filePath);
        }
    }
}