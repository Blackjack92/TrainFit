using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainFit.Models;
using TrainFit.Services;
using TrainFit.ViewModels;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace TrainFit
{
    public sealed partial class App : MvvmAppBase
    {
        #region fields
        private UnityContainer container;
        private IDatabaseService databaseService;
        #endregion

        #region ctor
        public App() : base()
        {
            databaseService = new DatabaseService();
            databaseService.CreateTable<Exercise>();
        }
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

            // Initialize UI stuff
            if (App.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                // Remove light theme
                App.Current.Resources.MergedDictionaries.RemoveAt(1);
            }
            else
            {
                // Remove dark theme
                App.Current.Resources.MergedDictionaries.RemoveAt(2);
            }

            // Initialize IOC stuff
            container = new UnityContainer();
            container.RegisterInstance(NavigationService);
            container.RegisterInstance(databaseService);
            container.RegisterInstance(container);

            container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<RegisterViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<TrainingsViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<MapViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<ExerciseViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<ExercisesViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<IImageSourceProvider, ImageSourceProvider>("imageSourceProvider", new ContainerControlledLifetimeManager());
            container.RegisterType<IEnumerable<IImageSourceProvider>, IImageSourceProvider[]>(new ContainerControlledLifetimeManager());
            container.RegisterType<ImageService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlSerializerService>(new ContainerControlledLifetimeManager());

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