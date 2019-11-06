using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.Clients;
using Example_04.Homework.Models;

namespace Example_04.Homework.FirstOrmLibrary
{
    class FirstOrmAdapter : IOrmAdapter
    {
        private IFirstOrm<DbUserEntity> _firstOrm1;
        private IFirstOrm<DbUserInfoEntity> _firstOrm2;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> firstOrm1, IFirstOrm<DbUserInfoEntity> firstOrm2)
        {
            _firstOrm1 = firstOrm1;
            _firstOrm2 = firstOrm2;
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _firstOrm1.Add(user);
            _firstOrm2.Add(userInfo);
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _firstOrm1.Read(userId);
            var userInfo = _firstOrm2.Read(user.InfoId);
            return (user, userInfo);
        }

        public void Remove(int userId)
        {
            var user = _firstOrm1.Read(userId);
            var userInfo = _firstOrm2.Read(user.InfoId);
        }
    }
}
