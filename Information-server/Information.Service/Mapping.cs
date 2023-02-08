using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Information.Repository.Entity;
using Information.Common.DTOs;

namespace Information.Service
{
    public class Mapping:Profile
    {
        public Mapping()
        {
          
            CreateMap<Informations, InformationDTO>()
              .ReverseMap();
            CreateMap<Chaild, ChaildDTO>()
             .ReverseMap();
        }
    }
}
