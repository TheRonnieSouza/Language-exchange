﻿using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.Language;
using LanguageExchange.Application.Models.User;

namespace LanguageExchange.Application.Language
{
    public interface ILanguageService
    {
        ResultViewModel CreateLanguage(CreateLanguageInputModel languageModel);
        ResultViewModel DeleteLanguage(int id);
        ResultViewModel<IList<GetUserViewModel>> GetLanguage();
    }
}
