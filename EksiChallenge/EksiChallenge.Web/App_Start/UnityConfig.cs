using EksiChallenge.Business.BusinessV1;
using EksiChallenge.Business.Interfaces;
using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Repositories.BreweryDbServiceRepository;
using EksiChallenge.Repositories.Interfaces;
using EksiChallenge.Web.ServiceReferences;
using System;
using System.Web.Configuration;
using Unity;
using Unity.Injection;

namespace EksiChallenge.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            string Url = WebConfigurationManager.AppSettings["apiUrl"];
            string apiKey = WebConfigurationManager.AppSettings["apiKey"];
            object[] parameters = { Url, apiKey };
            container.RegisterType<IRepository<Brewery>, BreweryRepository>(new InjectionConstructor(parameters));
            container.RegisterType<IBreweryServiceProxy, BinaryBreweryServiceProxy>();
            container.RegisterType<IBreweryBusiness, BreweryBusiness>();
        }
    }
}