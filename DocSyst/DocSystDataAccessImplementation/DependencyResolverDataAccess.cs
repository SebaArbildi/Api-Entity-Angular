using DocSystDataAccessImplementation.AuditDataAccessImplementation;
using DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation;
using DocSystDataAccessImplementation.StyleStructureDataAccess;
using DocSystDataAccessImplementation.StyleStructureDataAccessImplementation;
using DocSystDataAccessImplementation.UserDataAccessImplementation;
using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystDataAccessInterface.StyleStructureDataAccessInterface;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDependencyResolver;
using System.ComponentModel.Composition;

namespace DocSystDataAccessImplementation
{
    [Export(typeof(IComponent))]
    public class DependencyResolverDataAccess : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserDataAccess, UserDataAccess>();
            registerComponent.RegisterType<IBodyDataAccess, BodyDataAccess>();
            registerComponent.RegisterType<IDocumentDataAccess, DocumentDataAccess>();
            registerComponent.RegisterType<IMarginDataAccess, MarginDataAccess>();
            registerComponent.RegisterType<IParagraphDataAccess, ParagraphDataAccess>();
            registerComponent.RegisterType<ITextDataAccess, TextDataAccess>();
            registerComponent.RegisterType<IAuditLogDataAccess, AuditLogDataAccess>();
			registerComponent.RegisterType<ISpecificStyleDataAccess, SpecificStyleDataAccess>();
            registerComponent.RegisterType<IStyleDataAccess, StyleDataAccess>();
            registerComponent.RegisterType<IStyleClassDataAccess, StyleClassDataAccess>();
            registerComponent.RegisterType<IFormatDataAccess, FormatDataAccess>();
        }
    }
}