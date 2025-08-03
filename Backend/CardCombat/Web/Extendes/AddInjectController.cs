using Business.Implements.Bases;
using Business.Interfaces.Commands;
using Data.Interfaces.Group.Querys;
using Data.Implements.Querys;
using Data.Interfaces.Group.Commands;
using Data.Implements.Commands;
using Business.Interfaces.Querys;
using Utilities.Helpers.Validations;
using Utilities.Helpers.Validations.implemets;
using Data.Implements.CQRS.Card;
using Entity.Model.Card;
using Entity.Dtos.Card;
using Business.Implements.CQRS.Card;


namespace Web.Extendes
{
    public static class AddInjectController
    {
        public static IServiceCollection AddInject(this IServiceCollection services)
        {

            // elementos de ejecucion
            services.AddScoped(
                  typeof(IQuerys<>),
                  typeof(BaseGenericQuerysData<>)
            );

            services.AddScoped(
                typeof(ICommands<>),
                typeof(BaseGenericCommandsData<>)
            );


            // servicios del controller
            services.AddScoped(
                  typeof(IQueryServices<,>),
                  typeof(BaseQueryBusiness<,>)
                );
            services.AddScoped(
                typeof(ICommandService<,>),
                typeof(BaseCommandsBusiness<,>)
            );



            // extensiones de ejecucion
            services.AddScoped(
                  typeof(IQuerys<MazoPlayer>),
                  typeof(MazoPlayerData)
            );

            services.AddScoped(
                  typeof(IQuerys<Move>),
                  typeof(MoveData)
            );

            services.AddScoped<IQueryAllMove, MoveData>();


            // extensiones de servicios del controlador
            //services.AddScoped(
            //     typeof(IQueryServices<Move,MoveDtoQuery>),
            //     typeof(MoveBusiness)
            //   );



            //services.AddScoped(
            //   typeof(IQueryServices<Move,MoveDtoQuery>),
            //   typeof(MoveBusiness)
            // );

            services.AddScoped<IGenericHerlpers, GenericHelpers>();
  




            return services;

        }
    }
}
