namespace JwtAuth.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel(){ Username="naeem",Password="naeem_admin",Role="Admin",FirstName="Naeem"},
            new UserModel(){ Username="arshi",Password="arshi_seller",Role="seller",FirstName="Arshi"}
        };
    }
}
