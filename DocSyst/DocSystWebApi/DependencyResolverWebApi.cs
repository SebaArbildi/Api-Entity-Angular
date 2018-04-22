using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDependencyResolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace DocSystWebApi
{
    [Export(typeof(IComponent))]
    public class DependencyResolverWebApi : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserBusinessLogic, UserBusinessLogic>();
        }
    }
}