using Microsoft.EntityFrameworkCore.Metadata;
using MPS.DataAccess.UnitOfWorks;
using TestBO = MPS.Services.BusinessObjects.Test;
using TestEO = MPS.DataAccess.Entities.Test;
using MPS.Services.Services.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Services.Services
{
   
    public class TestService : ITestService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public TestService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
       // public async Task CreateProject(TestBO project)
        public async Task CreateProject()
        {
            //var userId = project.ProjectUsers?.Select(x => x.ApplicationUserId).FirstOrDefault();
            //var user = await _applicationUserManager.FindByIdAsync(userId?.ToString());
            //if (user == null)
            //    throw new InvalidOperationException("User not found");

            //var count = _applicationUnitOfWork.Projects.GetCount(x => x.Title == project.Title && x.ProjectUsers.Any(x => x.ApplicationUserId == userId));

            //if (count > 0)
            //    throw new DuplicateException("Project title already exists.");

            //var projectEntity = _mapper.Map<ProjectEO>(project);
            //projectEntity.Invitations = new List<Invitation>
            //{
            //    new Invitation
            //    {
            //        Email = user.Email,
            //        Status = InvitationStatus.Accepted,
            //        Date = _timeService.Now
            //    }
            //};

            var testEO = new TestEO()
            {
                Name = "Test"
            };

            _applicationUnitOfWork.Tests.Add(testEO);
            _applicationUnitOfWork.Save();
        
        }
    }
}
