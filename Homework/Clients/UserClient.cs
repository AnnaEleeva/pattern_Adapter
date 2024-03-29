﻿using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;
using System.Linq;


namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private IOrmAdapter _ormAdapter;

       // private IFirstOrm<DbUserEntity> _firstOrm1;
       // private IFirstOrm<DbUserInfoEntity> _firstOrm2;

       // private ISecondOrm _secondOrm;

       // private bool _useFirstOrm = true;

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            /*if (_useFirstOrm)
            {
                var user = _firstOrm1.Read(userId);
                var userInfo = _firstOrm2.Read(user.InfoId); 
                return (user, userInfo);
            }
            else
            {
                //First-получение элемента HashSet который точно содержит только один элемент

                //         ISecondOrm.ISecondOrmContext.HashSet<DbUserEntity>.First()
                var user = _secondOrm.Context.Users.First(i => i.Id == userId); //метод First только для тех i, у которых Id совпадает с параметром метода
                                                                               
                                                                       //Проверка
                var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
                return (user, userInfo);
            }*/
         
            var user = _ormAdapter.GetUser(userId); //а вот какой orm это пользователь в методе настроит
            var userInfo = _ormAdapter.GetUserInfo(user.InfoId);
            
            return (user, userInfo);
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            /* if (_useFirstOrm)
             {
                 _firstOrm1.Add(user);
                 _firstOrm2.Add(userInfo);
             }
             else
             {
                 _secondOrm.Context.Users.Add(user);
                 _secondOrm.Context.UserInfos.Add(userInfo);
                 // add realization by yourself
             }*/

            _ormAdapter.AddUser(user);
            _ormAdapter.AddUserInfo(userInfo);
        }

        public void Remove(int userId)
        {
            /* if (_useFirstOrm)
             {
                 var user = _firstOrm1.Read(userId);
                 var userInfo = _firstOrm2.Read(user.InfoId);

                 _firstOrm2.Delete(userInfo);
                 _firstOrm1.Delete(user);
             }
             else
             {
                 var user = _secondOrm.Context.Users.First(i => i.Id == userId); 
                 var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);

                 _secondOrm.Context.UserInfos.Remove(userInfo);
                 _secondOrm.Context.Users.Remove(user);
                 // add realization by yourself
             }*/

            _ormAdapter.RemoveUserInfo(userId);
            _ormAdapter.RemoveUser(userId);
        }

        public UserClient(IOrmAdapter ormAdapter)
        {
            _ormAdapter = ormAdapter;
        } 
    }
}
