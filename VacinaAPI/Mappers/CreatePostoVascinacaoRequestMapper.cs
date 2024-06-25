﻿using AutoMapper;
using VacinaAPI.PostoVacinacao.Entities;

namespace VacinaAPI.Mappers;

public class CreatePostoVascinacaoRequestMapper : Profile
{
    public CreatePostoVascinacaoRequestMapper()
    {
        CreateMap<CreatePostoVacinacaoRequest, Infrastructure.Models.PostoVacinacaoModel>();
    }
}