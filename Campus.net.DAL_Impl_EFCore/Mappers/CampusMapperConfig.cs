using AutoMapper;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal class CampusMapperConfig
    {
        public MapperConfiguration GetConfig(CampusDbContext context)
        {
            return new MapperConfiguration(
                config => {
                    config.CreateMap<StudentDbModel, Student>()
                    .ForMember(source => source.Group, options => options.MapFrom(c => context.Groups.Find(c.GroupDbModelId)))
                    .ForMember(source => source.PersonData, options => options.MapFrom(c => context.PersonDatas.Find(c.PersonDataDbModelId)))
                    .ForMember(source => source.StudentData, options => options.MapFrom(c => context.StudentDatas.Find(c.StudentDataDbModelId)));
                    config.CreateMap<Student, StudentDbModel>()
                    .ForMember(source => source.GroupDbModelId, options => options.MapFrom(c => c.Group.Id))
                    .ForMember(source => source.PersonDataDbModelId, options => options.MapFrom(c => c.PersonData.Id))
                    .ForMember(source => source.StudentDataDbModelId, options => options.MapFrom(c => c.StudentData.Id));


                    config.CreateMap<GroupDbModel, Group>()
                    .ForMember(source => source.Specialization, options => options.MapFrom(c => context.Specializations.Find(c.SpecializationDbModelId)))
                    .ForMember(source => source.Students, options => options.MapFrom(c => c.StudentDbModels))
                    .ForMember(source => source.TeacherSubjectGroups, options => options.MapFrom(c => c.TeacherSubject_GroupDbModels));
                    config.CreateMap<Group, GroupDbModel>()
                    .ForMember(source => source.SpecializationDbModelId, options => options.MapFrom(c => c.Specialization.Id))
                    .ForMember(source => source.StudentDbModels, options => options.MapFrom(c => c.Students))
                    .ForMember(source => source.TeacherSubject_GroupDbModels, options => options.MapFrom(c => c.TeacherSubjectGroups));
                    }
            );
        }
    }
}
