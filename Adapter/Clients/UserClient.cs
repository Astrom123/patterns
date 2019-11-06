using System.Linq;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private readonly IOrmAdapter _firstOrm;

        private readonly IOrmAdapter _secondOrm;

        private bool _useFirstOrm = true;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            if (_useFirstOrm)
            {
               return _firstOrm.Get(userId);
            }

            return _secondOrm.Get(userId);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            if (_useFirstOrm)
            {
                _firstOrm.Add(user, userInfo);
            }
            else
            {
                _secondOrm.Add(user, userInfo);
            }
        }

        public void Remove(int userId)
        {
            if (_useFirstOrm)
            {
                _firstOrm.Remove(userId);
            }
            else
            {
                _secondOrm.Remove(userId);
            }
        }

        public UserClient(IOrmAdapter firstOrm, IOrmAdapter secondOrm)
        {
            _firstOrm = firstOrm;
            _secondOrm = secondOrm;
        }
    }
}
