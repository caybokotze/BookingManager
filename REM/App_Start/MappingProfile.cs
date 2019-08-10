using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using REM.Core.Domain;
using REM.Dto;
using REM.Models;
using REM.ViewModels;
using REM.ViewModels.Booking;
using REM.ViewModels.Venue;

namespace REM.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();
            CreateMap<BookingViewModel, Booking>();
            CreateMap<Booking, BookingViewModel>();
            //
            CreateMap<Venue, VenueViewModel>();
            CreateMap<VenueViewModel, Venue>();
            //
            CreateMap<MaintenanceReport, MaintenanceReportViewModel>();
            CreateMap<MaintenanceReportViewModel, MaintenanceReport>();
            //


        }
    }
}