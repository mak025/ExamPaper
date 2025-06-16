using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDV.Models;

namespace ExamPaper
{
    public class ObjectRepo : IObjectRepo
    {
        private List<Object> _objects = new List<Object>();
        public void AddObject(Object obj)
        {
            _objects.Add(obj);
        }

        public Object GetObjectById(int id)
        {
            // Implementation for retrieving an object by ID
            Object foundObject = _objects.FirstOrDefault(o => o.ID == id);
            if (foundObject == null)
            {
                throw new KeyNotFoundException($"Object with ID: {id} not found.");
            }
            return foundObject;

        }
    }
}
