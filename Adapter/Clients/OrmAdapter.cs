using System;
using System.Linq;
using Example_04.Homework.Clients;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

public class OrmAdapter : IOrmAdapter
{
    private IFirstOrm<DbUserEntity> _firstOrm1;
    private IFirstOrm<DbUserInfoEntity> _firstOrm2;

    private ISecondOrm _secondOrm;

    private bool _useFirstOrm = true;

    public (DbUserEntity, DbUserInfoEntity) Get(int userId)
    {
        if (_useFirstOrm)
        {
            var user = _firstOrm1.Read(userId);
            var userInfo = _firstOrm2.Read(user.InfoId);
            return (user, userInfo);
        }
        else
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
            return (user, userInfo);
        }
    }

    public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
    {
        if (_useFirstOrm)
        {
            _firstOrm1.Add(user);
            _firstOrm2.Add(userInfo);
        }
        else
        {
            _secondOrm.Context.Users.Add(user);
            _secondOrm.Context.UserInfos.Add(userInfo);
        }
    }

    public void Remove(int userId)
    {
        if (_useFirstOrm)
        {
            var user = _firstOrm1.Read(userId);
            var userInfo = _firstOrm2.Read(user.InfoId);

            _firstOrm2.Delete(userInfo);
            _firstOrm1.Delete(user);
        }
        else
        {
            _secondOrm.Context.Users.RemoveWhere(i => i.Id == userId);
            _secondOrm.Context.UserInfos.RemoveWhere(i => i.Id == userId);
        }
    }
}
