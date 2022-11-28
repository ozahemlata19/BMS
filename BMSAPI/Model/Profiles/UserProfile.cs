using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMSAPI.Model.Domains;
using BMSAPI.Model.DTO;
using AutoMapper;

namespace BMSAPI.Model.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
            CreateMap<LoanDetail, LoanDetailDTO>().ReverseMap();
        }
    }
}
