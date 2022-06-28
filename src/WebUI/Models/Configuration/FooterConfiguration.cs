﻿namespace CleanArchitecture.WebUI.Models.Configuration;

public class FooterConfiguration : IFooterConfiguration
{
    public string ManageApprenticeshipsBaseUrl { get; set; } = default!;
    public string AuthenticationAuthorityUrl { get; set; } = default!;
}
