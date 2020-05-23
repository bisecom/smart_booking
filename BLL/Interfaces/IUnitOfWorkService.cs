﻿using BLL.Interfaces;
using BLL.Services;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {
        //UserDTMServiceRepo UsersDTM { get; }
        IUserServiceRepository UsersDTM { get; }
        IServiceRepository<CountryDTM> CountriesDTM { get; }
        IServiceRepository<Time_zoneDTM> TimezonesDTM { get; }
        //IServiceRepository<UserDTM> UsersDTM { get; }

        bool SaveChanges();
    }
}