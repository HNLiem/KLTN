using AutoMapper;
using WebApi.Commands.Auth.Register.Models;
using WebApi.Commands.Employees.InsertEmployee.Models;
using WebApi.Commands.Users.ChangePassword.Models;
using WebApi.Commands.Users.Models.PatchUpdateUser;
using WebApi.Commands.Users.UpdateUser.Models;
using WebApi.Entities;
using WebApi.Models.PhoneNumbers;
using WebApi.Models.Users;
using WebApi.Queries.Order.GetOrderByAdmin.Models;
using WebApi.Queries.Users.GetUserById.Models;
using WebApi.Queries.Users.GetUsers.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User Mapper
            CreateMap<RegisterModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<ChangePasswordModel, UserModel>();
            CreateMap<User, UpdateUserModel>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<User, UserPhoneNumber>();
            CreateMap<PhoneNumberModel, UserPhoneNumber>();
            CreateMap<UserPhoneNumber, PhoneNumberModel>();
            CreateMap<User, GetUserModel>();
            CreateMap<User, UsersModel>();
            CreateMap<User, PatchUpdateUserModel>();
            CreateMap<PatchUpdateUserModel, User>();

            // Order
            CreateMap<Order, OrderRepose>();
            CreateMap<OrderRepose, Order>();
            CreateMap<Warehouse, OrderRepose>();

            // Employee
            CreateMap<InsertEmployeeModel, Employee>();

        }
    }

}