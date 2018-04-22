using DocSystDataAccess.UserDataAccessImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDependencyResolver;

namespace DocSystBusinessLogicImplementation
{
    class DependencyResolverBusinessLogic: IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserDataAccess, UserDataAccess>();
        }
    }
}
