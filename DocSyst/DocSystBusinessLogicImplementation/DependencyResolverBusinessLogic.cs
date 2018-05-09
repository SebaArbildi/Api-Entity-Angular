using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.StyleStructureBusinessLogicInterface;
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
            registerComponent.RegisterType<ISpecificStyleBusinessLogic, SpecificStyleBusinessLogic>();
            registerComponent.RegisterType<IStyleBusinessLogic, StyleBusinessLogic>();
            registerComponent.RegisterType<IStyleClassBusinessLogic, StyleClassBusinessLogic>();
            registerComponent.RegisterType<IFormatBusinessLogic, FormatBusinessLogic>();
        }
    }
}
