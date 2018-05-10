using DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation;
using DocSystBusinessLogicImplementation.AuthorizationBusinessLogicImplementation;
using DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation;
using DocSystBusinessLogicImplementation.StyleStructureBusinessLogic;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystBusinessLogicInterface.AuthorizationBusinessLogicInterface;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
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
            registerComponent.RegisterType<ITextBusinessLogic, TextBusinessLogic>();
            registerComponent.RegisterType<IMarginBusinessLogic, MarginBusinessLogic>();
            registerComponent.RegisterType<IParagraphBusinessLogic, ParagraphBusinessLogic>();
            registerComponent.RegisterType<IDocumentBusinessLogic, DocumentBusinessLogic>();
			registerComponent.RegisterType<IAuthorizationBusinessLogic, AuthorizationBusinessLogic>();
            registerComponent.RegisterType<ILoginBusinessLogic, LoginBusinessLogic>();
            registerComponent.RegisterType<ISpecificStyleBusinessLogic, SpecificStyleBusinessLogic>();
            registerComponent.RegisterType<IStyleBusinessLogic, StyleBusinessLogic>();
            registerComponent.RegisterType<IStyleClassBusinessLogic, StyleClassBusinessLogic>();
            registerComponent.RegisterType<IFormatBusinessLogic, FormatBusinessLogic>();
			registerComponent.RegisterType<IAuditLogBussinesLogic, AuditLogBussinesLogic>();
        }
    }
}