using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;

namespace CmsApi.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly IRepository<StudentSubject> _repository;

        public StudentSubjectRepository(IRepository<StudentSubject> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentSubject>> GetAsync(Expression<Func<StudentSubject, bool>>? filter = null)
        {
            return await _repository.GetAsync(filter);
        }

        public async Task<StudentSubject> GetByIdAsync(int id1, int id2)
        {
            return await _repository.GetByCompositeIdAsync(id1, id2);
        }

        public async Task<bool> AddAsync(StudentSubject studentSubject)
        {
            try
            {
                await _repository.AddAsync(studentSubject);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(StudentSubject studentSubject)
        {
            try
            {
                await _repository.UpdateAsync(studentSubject);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(StudentSubject studentSubject)
        {
            try
            {
                await _repository.DeleteAsync(studentSubject);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}