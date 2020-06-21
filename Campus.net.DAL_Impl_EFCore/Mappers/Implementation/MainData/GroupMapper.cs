using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class GroupMapper : IGroupMapper
    {
        private readonly CampusDbContext _context;
        private readonly IStudentMapper _studentMapper;
        private readonly ITsgMapper _tsgMapper;
        public GroupMapper(CampusDbContext context)
        {
            _context = context;
            _studentMapper = new StudentMapper(context);
            _tsgMapper = new TsgMapper(context);
        }

        public GroupDbModel DomainToDb(Group item)
        {
            return new GroupDbModel(item.Id, item.GroupName, item.SpecializationId);
        }

        public Group DbToDomain(GroupDbModel item)
        {
            var groupDbModel = _context.Groups.Find(item.Id);
            _context.Entry(groupDbModel).Collection(g=>g.StudentDbModels).Load();
            var tsgDbModelList = _context.TeacherSubject_Groups.Where(i=>i.GroupDbModelId.Equals(groupDbModel.Id)).ToList();
            return new Group(
                (from studentDbModel in groupDbModel.StudentDbModels select _studentMapper.DbToDomain(studentDbModel)).ToList(),
                (from tsg in tsgDbModelList select _tsgMapper.DbToDomain(tsg)).ToList(),
                item.Id,
                item.GroupName, 
                item.SpecializationDbModelId
                );
        }
    }
}