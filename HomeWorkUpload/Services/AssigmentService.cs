using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkUpload.Data;
using HomeWorkUpload.Model;
using HomeWorkUpload.Model.Views;
using LanguageExt;
using Microsoft.Extensions.Logging;

namespace HomeWorkUpload.Services
{
    public class AssigmentService
    {
        private readonly ILogger _logger;
        private readonly ApplicationContext _dbContext;

        public AssigmentService(ApplicationContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<AssigmentService>();
        }

        public Either<string, IEnumerable<AssigmentView>> GetAssigments()
        {
            try
            {
                _logger.LogInformation("getting assigment list");

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
            catch(Exception ex)
            {
                _logger.LogError("can't get assigment list: {0}", ex);
                return "can't get assigment list";
            }
        }

        public Either<string, AssigmentView> CreateAssigment(AssigmentView assigmentView)
        {
            try
            {
                var assigmentExists = _dbContext.Assigments.Exists(t => t.Name.Equals(assigmentView.Name));

                if (assigmentExists)
                {
                    return string.Format("Assigment with name: {0} already exists", assigmentView.Name);
                }

                var assigment = new Assigment()
                {
                    Name = assigmentView.Name,
                    Description = assigmentView.Description,
                    Email = assigmentView.Email,
                    CopyEmail = assigmentView.CopyEmail
                };

                _dbContext.Assigments.Add(assigment);
                _dbContext.SaveChanges();

                assigmentView.Id = assigment.Id;

                return assigmentView;
            }
            catch(Exception ex)
            {
                _logger.LogError("can't create assigment with name: {0} : {1}", assigmentView.Name, ex);
                return string.Format("can't create assigment with name: {0}", assigmentView.Name);
            }
        }

        public Either<string, AssigmentView> UpdateAssigment(AssigmentView assigmentView)
        {
            try
            {
                var assigment = _dbContext.Assigments.Find(assigmentView.Id);

                if (assigment == null)
                {
                    return string.Format("can't find assigment with name: {0}", assigmentView.Name);
                }

                assigment.Name = assigmentView.Name;
                assigment.Description = assigmentView.Description;
                assigment.Email = assigmentView.Email;
                assigment.CopyEmail = assigmentView.CopyEmail;

                _dbContext.Update(assigment);
                _dbContext.SaveChanges();

                return assigmentView;
            }
            catch(Exception ex)
            {
                _logger.LogError("can't update assigment with name: {0} : {1}", assigmentView.Name, ex);
                return string.Format("can't update assigment with name: {0}", assigmentView.Name);
            }
        }
    }
}