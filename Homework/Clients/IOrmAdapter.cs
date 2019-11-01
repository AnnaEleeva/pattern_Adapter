using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{
    public interface IOrmAdapter // ITarget
    {
        DbUserEntity GetUser(int userId);
        DbUserInfoEntity GetUserInfo(int u_nfoId ); //user.infoId

        void AddUser(DbUserEntity user);
        void AddUserInfo(DbUserInfoEntity userInfo);

        void RemoveUserInfo(int userId);
        void RemoveUser(int userId);
    }
}
