using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    public class DM_UserBLL : DM_UserIBLL
    {
        private DM_UserService dM_UserService = new DM_UserService();

        public IEnumerable<dm_userEntity> GetList(string queryJson)
        {
            try
            {
                return dM_UserService.GetList(queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public IEnumerable<dm_userEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dM_UserService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public DataTable GetPageListByDataTable(Pagination pagination, string queryJson)
        {
            try
            {
                return dM_UserService.GetPageListByDataTable(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity GetEntity(int? keyValue)
        {
            try
            {
                return dM_UserService.GetEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity GetEntityByPhone(string phone, string appid)
        {
            try
            {
                return dM_UserService.GetEntityByPhone(phone, appid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity GetEntityByCache(int id)
        {
            try
            {
                return dM_UserService.GetEntityByCache(id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        /// <summary>
        /// 通过邀请码获取实体信息
        /// </summary>
        /// <param name="InviteCode"></param>
        /// <returns></returns>
        public dm_userEntity GetEntityByInviteCode(string InviteCode, ref dm_user_relationEntity dm_User_RelationEntity)
        {
            try
            {
                return dM_UserService.GetEntityByInviteCode(InviteCode, ref dm_User_RelationEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        /// <summary>
        /// 导入用户信息
        /// </summary>
        /// <param name="Phone">手机号</param>
        /// <param name="RealName">真实姓名</param>
        /// <param name="NickName">用户昵称</param>
        /// <param name="identitycard">身份证号</param>
        /// <param name="userlevel">用户等级 0普通用户  1初级用户  2高级用户</param>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="down">区县</param>
        /// <param name="address">详细地址</param>
        /// <param name="wechat">微信号</param>
        /// <param name="parent_id">上级id</param>
        /// <param name="parent_nickname">上级昵称</param>
        /// <param name="partners_id">合伙人编号</param>
        /// <returns></returns>
        public bool ImportUserInfo(string AppID, string Phone, string RealName, string NickName, string identitycard, string userlevel, string province, string city, string down, string address, string wechat, string parent_id, string parent_nickname, string partners_id)
        {
            try
            {
                return dM_UserService.ImportUserInfo(AppID,Phone, RealName, NickName, identitycard, userlevel, province, city, down, address, wechat, parent_id, parent_nickname, partners_id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        public void DeleteEntity(int keyValue)
        {
            try
            {
                dM_UserService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public void SaveEntity(int keyValue, dm_userEntity entity)
        {
            try
            {
                dM_UserService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity Login(dm_userEntity entity)
        {
            try
            {
                return dM_UserService.Login(entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity Register(dm_userEntity dm_UserEntity, string VerifiCode, string ParentInviteCode, string appid, string SmsMessageID)
        {
            try
            {
                return dM_UserService.Register(dm_UserEntity, VerifiCode, ParentInviteCode, appid, SmsMessageID);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public string EncodeInviteCode(int? id)
        {
            try
            {
                return dM_UserService.EncodeInviteCode(id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public int? DecodeInviteCode(string InviteCode)
        {
            try
            {
                return dM_UserService.DecodeInviteCode(InviteCode);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dynamic SignIn(int userid)
        {
            try
            {
                return dM_UserService.SignIn(userid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public void SetUserLevel(string userids, int user_level)
        {
            try
            {
                dM_UserService.SetUserLevel(userids, user_level);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        /// <summary>
		/// 更改账户余额
		/// </summary>
		/// <param name="user_id">用户id</param>
		/// <param name="updateprice">变更金额</param>
		/// <param name="updatetype">变更类型 0减少  1增加</param>
		/// <param name="remark">描述信息</param>
        public void UpdateAccountPrice(int user_id, decimal updateprice, int updatetype, string remark)
        {
            try
            {
                dM_UserService.UpdateAccountPrice(user_id, updateprice, updatetype, remark);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #region 获取推广图片
        public List<string> GetShareImage(int user_id, string appid)
        {
            try
            {
                return dM_UserService.GetShareImage(user_id, appid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 获取用户数据
        public IEnumerable<dm_userEntity> GetParentUser(int user_id)
        {
            try
            {
                return dM_UserService.GetParentUser(user_id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        public IEnumerable<dm_userEntity> GetChildUser(int user_id)
        {
            try
            {
                return dM_UserService.GetChildUser(user_id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }

        public dm_userEntity GetUserByPartnersID(int partnersid)
        {
            try
            {
                return dM_UserService.GetUserByPartnersID(partnersid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 获取平台统计数据
        public DataTable GetStaticData1()
        {
            try
            {
                return dM_UserService.GetStaticData1();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        public DataTable GetStaticData2()
        {
            try
            {
                return dM_UserService.GetStaticData2();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        public DataTable GetStaticData3()
        {
            try
            {
                return dM_UserService.GetStaticData3();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        public DataTable GetStaticData4()
        {
            try
            {
                return dM_UserService.GetStaticData4();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 获取粉丝数据统计
        public FansStaticInfoEntity GetFansStaticInfo(int User_ID)
        {
            try
            {
                return dM_UserService.GetFansStaticInfo(User_ID);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 判断渠道ID是否存在
        public bool NoExistRelationID(string relationid)
        {
            try
            {
                return dM_UserService.NoExistRelationID(relationid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 生成融云Token
        public string GeneralRongTokne(int User_ID, string appid)
        {
            try
            {
                return dM_UserService.GeneralRongTokne(User_ID, appid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion

        #region 获取签到数据
        public List<SignRecord> GetSignData(int User_ID, ref int sign_Count, ref int finish_sign)
        {
            try
            {
                return dM_UserService.GetSignData(User_ID, ref sign_Count, ref finish_sign);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowBusinessException(ex);
            }
        }
        #endregion
    }
}
