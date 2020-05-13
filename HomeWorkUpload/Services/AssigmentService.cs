using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkUpload.Data;
using HomeWorkUpload.Model.Views;

namespace HomeWorkUpload.Services
{
    public class AssigmentService
    {
        private readonly ApplicationContext _dbContext;

        public AssigmentService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AssigmentView> GetAssigments()
        {
            return _dbContext.Assigments.Select(assigment => 

                new AssigmentView()
                {
                    Id = assigment.Id,
                    Name = assigment.Name,
                    Description = assigment.Description,
                    Email = assigment.Email,
                    CopyEmail = assigment.CopyEmail
                }
                
            ).ToList();
        }
    }
}