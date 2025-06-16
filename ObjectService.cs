using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaper
{
    public class ObjectService
    {
        private readonly IObjectRepo _objectRepo;
        public ObjectService(IObjectRepo objectRepo)
        {
            _objectRepo = objectRepo;
        }
        public void AddObject(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }
            _objectRepo.AddObject(obj);
        }
        public Object? GetObjectById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");
            }
            return _objectRepo.GetObjectById(id);
        }
    }
}
