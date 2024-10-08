﻿using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Profiles
{
    internal class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeletedCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();


        }
    }
}
