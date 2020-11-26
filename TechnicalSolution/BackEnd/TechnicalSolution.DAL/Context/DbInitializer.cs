namespace TechnicalSolution.DAL.Context
{
    public static class DbInitializer
    {
        /// <summary>
        /// If database is not exist, its created.
        /// </summary>
        /// <param name="context">DB Context </param>
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
