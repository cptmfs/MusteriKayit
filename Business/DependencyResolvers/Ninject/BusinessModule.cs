﻿using Business.Abstract;
using Business.Concrete;
using Business.ServiceAdapters;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMemberService>().To<MemberManager>().InSingletonScope();
            Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();
            Bind<IKpsService>().To<KpsServiceAdapters>().InSingletonScope();
            
        }
    }
}
