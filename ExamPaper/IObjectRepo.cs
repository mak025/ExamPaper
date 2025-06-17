using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaper
{
    public interface IObjectRepo
    {
        void AddObject(Object obj);
        Object GetObjectById(int id);

    }
}
