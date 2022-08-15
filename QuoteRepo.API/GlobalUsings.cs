﻿global using AutoMapper;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using QuoteRepo.API.CQRS.Commands.AuthorCommands;
global using QuoteRepo.API.CQRS.Commands.CountryCommands;
global using QuoteRepo.API.CQRS.Queries.AuthorQueries;
global using QuoteRepo.API.CQRS.Queries.CountryQueries;
global using QuoteRepo.API.CQRS.Queries.QuoteQueries;
global using QuoteRepo.Business.Abstract;
global using QuoteRepo.Business.Concrete;
global using QuoteRepo.Business.Profiles;
global using QuoteRepo.Data.Abstract.Repositories;
global using QuoteRepo.Data.Concrete.Contexts;
global using QuoteRepo.Data.Concrete.Repositories;
global using QuoteRepo.Entities.Dtos;
global using QuoteRepo.Shared.Results;
global using QuoteRepo.Shared.Utils;
global using System.Reflection;
global using IResult = QuoteRepo.Shared.Results.IResult;
