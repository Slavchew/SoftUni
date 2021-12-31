using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
