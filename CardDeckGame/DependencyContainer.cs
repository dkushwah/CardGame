using CardDeckGame.Contract;
using CardDeckGame.Core;
using CardDeckGame.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame
{
    public class DependencyContainer
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IFaceStore<Face>, FaceStore>();
            services.AddTransient<ISuitsStore<Suits>, SuitStore>();
            services.AddTransient<ICardRepository<Suits,Face>, CardRepository>();
            services.AddTransient<IDeck<Suits, Face>, Deck>();
            services.AddTransient<IPlayer,Player>();
            services.AddTransient<IPlayer,Player>();
            
            services.AddTransient<ConsoleApp>();
            return services;
        }
    }
   
}
