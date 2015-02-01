namespace Triggers.API.Frontend.Mappers
{
    using Nancy;

    public interface IMapHttpRequestsToDisk
    {
        string Map(string resourceUrl);
        bool CanHandle(string resourceUrl);
        Response GetResponse(string resourceUrl);
    }
}