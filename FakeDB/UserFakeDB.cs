namespace Api___clone_wpp.FakeDB
{
    public class UserFakeDB
    {
        public static readonly List<Users> Users =
        [
            new Users(id: new Guid("dbba0848-f2e9-467b-9393-3c4e5d008e92"), name: "Pablo Carvalho"),
            new Users(id: new Guid("52027687-761f-4f2a-8f1f-9c659855c3fb"), name: "Jessica Soares"),
            new Users(id: new Guid("0bb75bf8-052e-4c12-95b2-efa92c3b7a7f"), name: "Jurubeba da Silva")
        ];

        public static readonly List<UserImage> UserImages = [];
    }
}
