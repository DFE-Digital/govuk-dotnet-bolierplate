﻿using CleanArchitecture.WebUI.Services;

namespace CleanArchitecture.WebUI.Models;

public interface IHeaderViewModel : ILinkCollection, ILinkHelper
{
    bool MenuIsHidden { get; }
    string SelectedMenu { get; }
    IUserContext UserContext { get; }
    void HideMenu();
    void SelectMenu(string menu);
    bool UseLegacyStyles { get; }
}
