// using System;
// using System.Threading.Tasks;
// using BuildingBlocks.Http;
// using BuildingBlocks.Vault;
// using BuildingBlocks.WebApi.Security;
//
// namespace University.Students.Infrastructure.Services.Clients
// {
//     public class CustomersServiceClient: ICustomersServiceClient
//     {
//         private readonly IHttpClient _client;
//         private readonly ICertificatesService _certificatesService;
//         private readonly VaultOptions _vaultOptions;
//         private readonly SecurityOptions _securityOptions;
//         private readonly string _url;
//
//         public CustomersServiceClient(IHttpClient client, HttpClientOptions options,
//             ICertificatesService certificatesService, VaultOptions vaultOptions, SecurityOptions securityOptions)
//         {
//             _client = client;
//             _certificatesService = certificatesService;
//             _vaultOptions = vaultOptions;
//             _securityOptions = securityOptions;
//             _url = options.Services["customers"];
//             if (!vaultOptions.Enabled || !vaultOptions.Pki.Enabled)
//             {
//                 return;
//             }
//
//             var certificate = certificatesService.Get(vaultOptions.Pki.RoleName);
//             if (certificate is null)
//             {
//                 return;
//             }
//
//             var header = securityOptions.Certificate.GetHeaderName();
//             var certificateData = certificate.GetRawCertDataString();
//             _client.SetHeaders(x=> x.Add(header,certificateData));
//         }
//         public Task<CustomerStateDto> GetStateAsync(Guid id)
//             => _client.GetAsync<CustomerStateDto>($"{_url}/customers/{id}/state");
//     }
// }

