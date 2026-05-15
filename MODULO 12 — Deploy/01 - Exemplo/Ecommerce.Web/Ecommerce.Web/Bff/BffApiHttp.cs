namespace Ecommerce.Web.Bff;

internal static class BffApiHttp
{
    internal static async Task<IResult> SendOrServiceUnavailableAsync(
        Func<Task<HttpResponseMessage>> sendAsync,
        Func<HttpResponseMessage, Task<IResult>> handleResponseAsync)
    {
        try
        {
            using var response = await sendAsync();
            return await handleResponseAsync(response);
        }
        catch (Exception ex) when (IsBackendUnreachable(ex))
        {
            return BffBackendUnavailableResult.Create();
        }
    }

    private static bool IsBackendUnreachable(Exception ex) =>
        ex is HttpRequestException or TaskCanceledException;
}
