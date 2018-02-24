namespace DemoFaceRecognition.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoFaceRecognition.Context.FaceRecognitionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DemoFaceRecognition.Context.FaceRecognitionContext";
        }

        protected override void Seed(DemoFaceRecognition.Context.FaceRecognitionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
