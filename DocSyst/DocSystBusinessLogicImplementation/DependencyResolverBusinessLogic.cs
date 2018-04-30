using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDependencyResolver;
using System.ComponentModel.Composition;

namespace DocSystBusinessLogicImplementation
{
    [Export(typeof(IComponent))]
    public class DependencyResolverBusinessLogic: IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserBusinessLogic, UserBusinessLogic>();
            registerComponent.RegisterType<IAuthorizationBusinessLogic, AuthorizationBusinessLogic>();
            registerComponent.RegisterType<ILoginBusinessLogic, LoginBusinessLogic>();
        }
    }
}
