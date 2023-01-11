using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceAdapters
{
    public class TestKpsService : IKpsService
    {
        public bool ValidateUser(Member member)
        {
            return true;
        }
    }
}
