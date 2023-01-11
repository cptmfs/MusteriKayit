using Business.Abstract;
using Business.ServiceAdapters;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DevFramework.Coree.Aspects.Postsharp;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal,IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }
        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            MusteriKayıtKontrolu(member);
            MusteriDogrulaması(member);
            _memberDal.Add(member);
        }

        private void MusteriDogrulaması(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kullanıcı doğrulaması geçerli değil");
            }
        }

        private void MusteriKayıtKontrolu(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur");
            }
        }
    }
}
