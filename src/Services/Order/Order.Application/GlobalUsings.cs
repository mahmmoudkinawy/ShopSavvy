global using AutoMapper;
global using FluentValidation;
global using FluentValidation.Results;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using Order.Application.Contracts.Exceptions;
global using Order.Application.Contracts.Persistence;
global using Order.Application.Features.Orders.Commands.CheckoutOrder;
global using Order.Application.Features.Orders.Commands.UpdateOrder;
global using Order.Application.Features.Orders.Queries;
global using Order.Domain.Common;
global using Order.Domain.Entities;
global using System.Linq.Expressions;
global using Order.Application.Contracts.Infrastructure;
global using Microsoft.Extensions.DependencyInjection;
global using Order.Application.Behaviors;
global using System.Reflection;

