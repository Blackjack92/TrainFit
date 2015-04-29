using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TrainFit.ViewModels;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace TrainFit
{
    public sealed partial class App : MvvmAppBase
    {
        #region fields
        private UnityContainer container;
        #endregion

        #region methods
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Login", null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var returnTask = base.OnInitializeAsync(args);

            container = new UnityContainer();
            container.RegisterInstance(NavigationService);
            container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ResolveViewModelType);

            return returnTask;
        }

        private Type ResolveViewModelType(Type viewType)
        {
            var viewModelNameSpace = viewType.FullName.Replace("Views", "ViewModels");
            var viewModelType = viewModelNameSpace.Replace("Page", "ViewModel");

            return Type.GetType(viewModelType);
        }

        protected override object Resolve(Type type)
        {
            return container.Resolve(type);
        }
        #endregion
    }
}