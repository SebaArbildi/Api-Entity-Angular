﻿using DocSystDataAccessImplementation.UserDataAccessImplementation;
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
        }
    }
}