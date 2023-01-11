
using Business.KpsServiceReference;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceAdapters
{
    public class KpsServiceAdapters : IKpsService
    {

        public bool ValidateUser(Member member)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
           return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcNo),
                member.FirstName.ToUpper(), member.LastName.ToUpper(), member.DateOfBirth.Year);
        }
    }
}
