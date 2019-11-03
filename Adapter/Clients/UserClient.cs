using System.Linq;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private IOrmAdapter _ormAdapter;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            return _ormAdapter.Get(userId);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _ormAdapter.Add(user, userInfo);
        }

        public void Remove(int userId)
        {
            _ormAdapter.Remove(userId);
        }

        public UserClient(IOrmAdapter ormAdapter)
        {
            _ormAdapter = ormAdapter;
        }
    }
}
