﻿using DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
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
        }
    }
}
