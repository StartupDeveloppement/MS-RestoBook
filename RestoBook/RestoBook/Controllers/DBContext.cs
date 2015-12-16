using System;

namespace RestoBook.Controllers
{
    internal class DBContext
    {
        public object User { get; internal set; }
        public object UserRole { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}