namespace buckstore.manager.service.api.v1.Filters.AuthorizationFilters
{
    public class UserTypes
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        
        public static UserTypes Admin = new UserTypes(1, nameof(Admin));
        public static UserTypes Employee = new UserTypes(2, nameof(Employee));
        public static UserTypes Customer = new UserTypes(3, nameof(Customer));


        public UserTypes(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}