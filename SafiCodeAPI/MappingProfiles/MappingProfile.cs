using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafiCodeAPI.Modal.Modal;
using SafiCodeAPI.Modals;

namespace SafiCodeAPI.MappingProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //CreateMap<TblUserType, UserTypeViewModal>();
            CreateMap<TblUsers, UserViewmodal>();
        }

    }
}
