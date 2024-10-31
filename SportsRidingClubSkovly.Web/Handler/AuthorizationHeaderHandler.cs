// using System.Net.Http.Headers;
//
// namespace SportsRidingClubSkovly.Web.Handler;
//
// public class AuthorizationHeaderHandler : DelegatingHandler
// {
//     
//     
//     protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//     {
//         // Get the JWT token from the provider
//         request
//
//         // Add the JWT token to the Authorization header
//         request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
//
//         // Call the inner handler
//         return await base.SendAsync(request, cancellationToken);
//     }
// }