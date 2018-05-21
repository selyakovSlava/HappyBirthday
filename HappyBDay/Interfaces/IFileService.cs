using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyBDay.Interfaces
{
    public interface IFileService
    {
        List<Model.Person> Open(string filename);
        void Save(string filename, List<Model.Person> people);
    }
}
