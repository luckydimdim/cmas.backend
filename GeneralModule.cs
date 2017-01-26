using Nancy;

namespace cmas.backend
{

    /// <summary>
    ///
    /// </summary>
    public class GeneralModule : NancyModule
    {
        protected Repository Repository;

        private void Init(Repository repository)
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));

            this.Repository = repository;
        }

        public GeneralModule(Repository repository, string modulePath) : base(modulePath)
        {
            Init(repository);
        }

        public GeneralModule(Repository repository)
        {
            Init(repository);
        }

    }
}