using Learun.Application.TwoDevelopment.Common;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.DataBase.Repository;
using Learun.Loger;
//using Learun.Loger;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    public class DM_UserService : RepositoryFactory
    {
        private ICache redisCache = CacheFactory.CaChe();

        private DM_UserRelationService dm_UserRelationService = new DM_UserRelationService();

        private DM_BaseSettingService dm_BaseSettingService = new DM_BaseSettingService();

        private DM_IntergralDetailService dM_IntergralDetailService = new DM_IntergralDetailService();

        private string fieldSql;

        private static object lockObject = new object();

        private static char[] r = new char[32]
        {
            'Q',
            'W',
            'E',
            '8',
            'A',
            'S',
            '2',
            'D',
            'Z',
            '9',
            'C',
            '7',
            'P',
            '5',
            'I',
            'K',
            '3',
            'M',
            'J',
            'U',
            'F',
            'R',
            '4',
            'V',
            'Y',
            'L',
            'T',
            'N',
            '6',
            'B',
            'G',
            'H'
        };

        private static char b = 'X';

        private static int binLen = r.Length;

        private static int s = 6;

        public DM_UserService()
        {
            fieldSql = "    t.id,    t.realname,    t.identitycard,    t.isreal,    t.phone,    t.token,    t.pwd,    t.nickname,    t.accountprice,    t.invitecode,    t.partners,    t.partnersstatus,    t.tb_pid,    t.tb_relationid,    t.tb_orderrelationid,    t.jd_pid,    t.pdd_pid,    t.userlevel,    t.createtime,    t.updatetime,    t.appid,    t.province,    t.city,    t.down,    t.address";
        }

        public IEnumerable<dm_userEntity> GetList(string queryJson)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM dm_user t ");
                return BaseRepository("dm_data").FindList<dm_userEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public IEnumerable<dm_userEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM dm_user t ");
                return BaseRepository("dm_data").FindList<dm_userEntity>(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public DataTable GetPageListByDataTable(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select u.*,r.parent_id,r.partners_id,r.parent_nickname from dm_user u left join dm_user_relation r on u.id=r.user_id where 1=1 ");

                if (!queryParam["txt_user_id"].IsEmpty())
                {
                    strSql.Append(" and u.id=" + queryParam["txt_user_id"].ToString());
                }

                if (!queryParam["txt_phone"].IsEmpty())
                {
                    strSql.Append(" and u.phone like '%" + queryParam["txt_phone"].ToString() + "%'");
                }

                if (!queryParam["txt_nickname"].IsEmpty())
                {
                    strSql.Append(" and u.nickname like '%" + queryParam["txt_nickname"].ToString() + "%'");
                }

                if (!queryParam["txt_realname"].IsEmpty())
                {
                    strSql.Append(" and u.realname like '%" + queryParam["txt_realname"].ToString() + "%'");
                }

                if (!queryParam["txt_invitecode"].IsEmpty())
                {
                    strSql.Append(" and u.invitecode like '%" + queryParam["txt_invitecode"].ToString() + "%'");
                }

                if (!queryParam["txt_partners"].IsEmpty())
                {
                    strSql.Append(" and r.partners_id = '" + queryParam["txt_partners"].ToString() + "'");
                }

                return BaseRepository("dm_data").FindTable(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public dm_userEntity GetEntity(int? keyValue)
        {
            try
            {
                return BaseRepository("dm_data").FindEntity<dm_userEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public dm_userEntity GetEntityByPhone(string phone, string appid)
        {
            try
            {
                return BaseRepository("dm_data").FindEntity((dm_userEntity t) => t.phone == phone && t.appid == appid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public dm_userEntity GetEntityByCache(int id)
        {
            try
            {
                string cacheKey = "UserInfo" + id.ToString();
                dm_userEntity dm_UserEntity = redisCache.Read<dm_userEntity>(cacheKey, 7L);
                if (dm_UserEntity.IsEmpty())
                {
                    dm_UserEntity = GetEntity(id);

                    if (!dm_UserEntity.IsEmpty())
                    {
                        dm_user_relationEntity dm_User_RelationEntity = dm_UserRelationService.GetEntityByUserID(id);

                        if (!dm_User_RelationEntity.IsEmpty())
                        {
                            dm_UserEntity.currentmontheffect = dm_User_RelationEntity.CurrentMonthEffect;
                            dm_UserEntity.currentmonthreceiveeffect = dm_User_RelationEntity.CurrentMonthReceiveEffect;
                            dm_UserEntity.upmonthreceiveeffect = dm_User_RelationEntity.UpMonthReceiveEffect;
                        }

                        redisCache.Write(cacheKey, dm_UserEntity, DateTime.Now.AddMinutes(10), 7L);
                    }
                }

                return dm_UserEntity;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public void DeleteEntity(int keyValue)
        {
            try
            {
                BaseRepository("dm_data").Delete((dm_userEntity t) => t.id == (int?)keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public void SaveEntity(int keyValue, dm_userEntity entity)
        {
            try
            {
                if (keyValue > 0)
                {
                    entity.Modify(keyValue);
                    BaseRepository("dm_data").Update(entity);
                }
                else
                {
                    BaseRepository("dm_data").Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public dm_userEntity Login(dm_userEntity entity)
        {
            try
            {
                entity.pwd = Md5Helper.Encrypt(entity.pwd, 16);
                return BaseRepository("dm_data").FindEntity((dm_userEntity t) => t.phone == entity.phone && t.appid == entity.appid && t.pwd == entity.pwd);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public dm_userEntity Register(dm_userEntity dm_UserEntity, string VerifiCode, string appid)
        {
            lock (lockObject)
            {
                IRepository db = null;
                int parent_id = 0;
                int? id = 0;
                try
                {
                    parent_id = DecodeInviteCode(VerifiCode);
                    if (parent_id <= 0)
                    {
                        throw new Exception("邀请码错误!");
                    }
                    dm_userEntity parent_user_entity = GetEntity(parent_id.ToInt());
                    if (parent_user_entity == null)
                    {
                        throw new Exception("您的邀请人用户异常!");
                    }
                    dm_user_relationEntity dm_Parent_User_RelationEntity = dm_UserRelationService.GetEntityByUserID(parent_id);
                    dm_userEntity dm_UserEntity_exist = GetEntityByPhone(dm_UserEntity.phone, appid);
                    if (dm_UserEntity_exist != null)
                    {
                        throw new Exception("该手机号已注册!");
                    }
                    dm_basesettingEntity dm_BasesettingEntity = dm_BaseSettingService.GetEntityByCache(appid);
                    dm_UserEntity.pwd = Md5Helper.Encrypt(dm_UserEntity.pwd, 16);
                    dm_UserEntity.token = Guid.NewGuid().ToString();
                    BaseRepository("dm_data").Insert(dm_UserEntity);
                    dm_userEntity updateEntity = new dm_userEntity();
                    id = (updateEntity.id = BaseRepository("dm_data").FindObject("SELECT LAST_INSERT_ID();").ToInt());
                    updateEntity.invitecode = EncodeInviteCode(updateEntity.id);
                    updateEntity.integral = dm_BasesettingEntity.new_people;
                    updateEntity.Create();
                    db = BaseRepository("dm_data").BeginTrans();
                    db.Update(updateEntity);
                    db.Insert(new dm_intergraldetailEntity
                    {
                        createtime = DateTime.Now,
                        currentvalue = updateEntity.integral,
                        title = "新用户注册奖励",
                        stepvalue = dm_BasesettingEntity.new_people,
                        type = 1,
                        user_id = id
                    });
                    parent_user_entity.integral += dm_BasesettingEntity.new_people_parent;
                    db.Update(parent_user_entity);
                    db.Insert(new dm_intergraldetailEntity
                    {
                        createtime = DateTime.Now,
                        currentvalue = parent_user_entity.integral,
                        title = "邀请好友奖励",
                        stepvalue = dm_BasesettingEntity.new_people_parent,
                        type = 3,
                        user_id = parent_id
                    });
                    dm_user_relationEntity dm_User_RelationEntity = new dm_user_relationEntity
                    {
                        user_id = id,
                        parent_id = parent_id,
                        parent_nickname = parent_user_entity.nickname,
                        partners_id = parent_user_entity.partnersstatus == 1 ? parent_user_entity.partners : dm_Parent_User_RelationEntity.partners_id,//如果上级用户为合伙人，此时邀请下级需要绑定自己的合伙人编号，如果非合伙人则继承自己的所属团队
                    };
                    dm_User_RelationEntity.Create();
                    db.Insert(dm_User_RelationEntity);
                    db.Commit();
                    return GetEntity(id.ToInt());
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    Log log = LogFactory.GetLogger("workflowapi");
                    string[] obj = new string[6]
                    {
                        "上下级绑定失败,当前用户",
                        null,
                        null,
                        null,
                        null,
                        null
                    };
                    int? num2 = id;
                    obj[1] = num2.ToString();
                    obj[2] = ",上级用户";
                    num2 = parent_id;
                    obj[3] = num2.ToString();
                    obj[4] = ex.Message;
                    obj[5] = ex.StackTrace;
                    log.Error(string.Concat(obj));
                    if (ex is ExceptionEx)
                    {
                        throw;
                    }
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        public dynamic SignIn(int userid)
        {
            IRepository db = null;
            try
            {
                dm_userEntity dm_UserEntity = GetEntityByCache(userid);
                if (dm_UserEntity.IsEmpty())
                {
                    throw new Exception("用户信息异常!");
                }
                dm_basesettingEntity dm_BasesettingEntity = dm_BaseSettingService.GetEntityByCache(dm_UserEntity.appid);
                if (dm_BasesettingEntity.IsEmpty())
                {
                    throw new Exception("获取基础配置信息异常!");
                }
                int? currentIntegral = 0;
                int signCount = 0;
                dm_intergraldetailEntity dm_IntergraldetailEntity = dM_IntergralDetailService.GetLastSignData(userid);
                if (dm_IntergraldetailEntity == null)
                {
                    currentIntegral = dm_BasesettingEntity.firstsign;
                    signCount = 1;
                }
                else
                {
                    if (dm_IntergraldetailEntity.createtime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        throw new Exception("今日已签到!");
                    }
                    if (dm_IntergraldetailEntity.createtime.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-1.0).ToString("yyyy-MM-dd"))
                    {
                        int? todayIntegral = dm_IntergraldetailEntity.stepvalue + dm_BasesettingEntity.signscrement;
                        currentIntegral = ((todayIntegral > dm_BasesettingEntity.signcapping) ? dm_BasesettingEntity.signcapping : todayIntegral);
                        signCount = int.Parse(dm_IntergraldetailEntity.remark) + 1;
                    }
                    else
                    {
                        currentIntegral = dm_BasesettingEntity.firstsign;
                        signCount = 1;
                    }
                }
                dm_UserEntity.integral += currentIntegral;
                dm_UserEntity.Modify(dm_UserEntity.id);
                db = BaseRepository("dm_data").BeginTrans();
                db.Update(dm_UserEntity);
                db.Insert(new dm_intergraldetailEntity
                {
                    currentvalue = dm_UserEntity.integral,
                    stepvalue = currentIntegral,
                    user_id = userid,
                    title = "签到奖励",
                    remark = signCount.ToString(),
                    type = 2,
                    createtime = DateTime.Now
                });
                db.Commit();
                return new
                {
                    CurrentIntegral = currentIntegral,
                    SignCount = signCount
                };
            }
            catch (Exception ex)
            {
                if (db != null)
                    db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        public string EncodeInviteCode(int? id)
        {
            char[] buf = new char[32];
            int charPos = 32;
            while (id / binLen > 0)
            {
                int ind = (id % binLen).Value;
                buf[--charPos] = r[ind];
                id /= binLen;
            }
            buf[--charPos] = r[(id % binLen).Value];
            string str = new string(buf, charPos, 32 - charPos);
            if (str.Length < s)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(b);
                Random rnd = new Random();
                for (int i = 1; i < s - str.Length; i++)
                {
                    sb.Append(r[rnd.Next(binLen)]);
                }
                str += sb.ToString();
            }
            return str;
        }

        public int DecodeInviteCode(string InviteCode)
        {
            char[] chs = InviteCode.ToCharArray();
            int res = 0;
            for (int i = 0; i < chs.Length; i++)
            {
                int ind = 0;
                for (int j = 0; j < binLen; j++)
                {
                    if (chs[i] == r[j])
                    {
                        ind = j;
                        break;
                    }
                }
                if (chs[i] == b)
                {
                    break;
                }
                res = ((i <= 0) ? ind : (res * binLen + ind));
            }
            return res;
        }

        #region 根据关系获取用户
        /// <summary>
        /// 获取上级用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<dm_userEntity> GetParentUser(int? user_id)
        {
            try
            {
                return BaseRepository("dm_data").FindList<dm_userEntity>("select * from dm_user where FIND_IN_SET(id,getParList(" + user_id + "));");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        /// <summary>
        /// 获取下级用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<dm_userEntity> GetChildUser(int user_id)
        {
            try
            {
                return BaseRepository("dm_data").FindList<dm_userEntity>("select * from dm_user where FIND_IN_SET(id,getChildList(" + user_id + ",2)) and id<>" + user_id + ";");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 更改账户余额
        public void UpdateAccountPrice(int user_id, decimal updateprice, int updatetype, string remark)
        {
            IRepository db = null;
            try
            {
                dm_userEntity dm_UserEntity = GetEntity(user_id);
                dm_accountdetailEntity dm_AccountdetailEntity = new dm_accountdetailEntity();
                dm_AccountdetailEntity.user_id = user_id;
                if (updatetype == 0)
                {
                    if (dm_UserEntity.accountprice < updateprice)
                        throw new Exception("当前账户余额不足!");

                    dm_AccountdetailEntity.title = "余额扣除";
                    dm_UserEntity.accountprice -= updateprice;
                    dm_AccountdetailEntity.type = 20;
                }
                else
                {
                    dm_AccountdetailEntity.title = "余额返还";
                    dm_UserEntity.accountprice += updateprice;
                    dm_AccountdetailEntity.type = 19;
                }
                dm_AccountdetailEntity.remark = remark;
                dm_AccountdetailEntity.stepvalue = updateprice;
                dm_AccountdetailEntity.currentvalue = dm_UserEntity.accountprice;
                dm_AccountdetailEntity.Create();

                db = BaseRepository("dm_data").BeginTrans();

                db.Insert(dm_AccountdetailEntity);
                db.Update(dm_UserEntity);
                db.Commit();
            }
            catch (Exception ex)
            {
                if (db != null)
                    db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 根据合伙人编号获取用户信息
        public dm_userEntity GetUserByPartnersID(int? partnersid)
        {
            try
            {
                string querySql = "select * from dm_user where partners=" + partnersid + " and partnersstatus=1";
                return BaseRepository("dm_data").FindEntity<dm_userEntity>(querySql, null);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 获取推广码
        public List<string> GetShareImage(int user_id, string appid)
        {
            try
            {
                dm_userEntity dm_UserEntity = GetEntityByCache(user_id);
                if (dm_UserEntity.IsEmpty())
                    throw new Exception("用户信息异常!");
                if (dm_UserEntity.headpic.IsEmpty())
                    throw new Exception("您先上传个人头像!");

                List<string> shareList = new List<string>();

                string basePath = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd("\\".ToCharArray());

                string newPath1 = "/Resource/ShareImage/Share" + user_id + "1.jpg";
                string newPath2 = "/Resource/ShareImage/Share" + user_id + "2.jpg";
                string newPath3 = "/Resource/ShareImage/Share" + user_id + "3.jpg";

                dm_basesettingEntity dm_BasesettingEntity = dm_BaseSettingService.GetEntityByCache(appid);

                if (File.Exists(basePath + newPath1) && File.Exists(basePath + newPath2) && File.Exists(basePath + newPath3))
                {
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath1);
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath2);
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath3);
                }
                else
                {
                    //Bitmap qrCode = QRCodeHelper.Generate3(dm_UserEntity.invitecode, 380, 380, basePath + dm_UserEntity.headpic);
                    Bitmap qrCode = QRCodeHelper.GenerateQRCode(dm_UserEntity.invitecode, 280, 280);

                    //背景图片，海报背景
                    string path1 = basePath + @"/Resource/ShareImage/1.jpg";
                    string path2 = basePath + @"/Resource/ShareImage/2.jpg";
                    string path3 = basePath + @"/Resource/ShareImage/3.jpg";
                    GeneralShareImage(basePath + newPath1, path1, qrCode, dm_UserEntity.invitecode);
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath1);
                    GeneralShareImage(basePath + newPath2, path2, qrCode, dm_UserEntity.invitecode);
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath2);
                    GeneralShareImage(basePath + newPath3, path3, qrCode, dm_UserEntity.invitecode);
                    shareList.Add(dm_BasesettingEntity.qianzhui_image + newPath3);
                }

                return shareList;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        /// <summary>
        /// 生成分享图片
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="bj_image_path">背景图片地址</param>
        /// <param name="qrCode">二维码</param>
        /// <param name="index">图片索引</param>
        /// <returns></returns>
        string GeneralShareImage(string newPath, string bj_image_path, Bitmap qrCode, string InviteCode)
        {
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(bj_image_path);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                //画专属推广二维码
                /*g.DrawImage(qrCode, new Rectangle(imgSrc.Width - qrCode.Width - 420,//-450这个数，越小越靠左，可以调整二维码在背景图的位置
                imgSrc.Height - qrCode.Height - 400,//同理-650越小越靠上
                qrCode.Width,
                qrCode.Height),
                0, 0, qrCode.Width, qrCode.Height, GraphicsUnit.Pixel);*/
                g.DrawImage(qrCode, new Rectangle(260,//-450这个数，越小越靠左，可以调整二维码在背景图的位置
                1080,//同理-650越小越靠上
                qrCode.Width,
                qrCode.Height),
                0, 0, qrCode.Width, qrCode.Height, GraphicsUnit.Pixel);

                //画头像
                //g.DrawImage(titleImage, 8, 8, titleImage.Width, titleImage.Height);

                Font font = new Font("宋体", 24, FontStyle.Bold);

                g.DrawString("邀请码:" + InviteCode, font, new SolidBrush(Color.Black), 290, 1010);
            }
            imgSrc.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            return newPath;
        }
        #endregion

        #region 设置用户等级
        public void SetUserLevel(string userids, int user_level)
        {
            try
            {
                List<dm_userEntity> dm_UserEntity_UpdateList = new List<dm_userEntity>();
                List<string> user_ids = userids.Split(',').ToList();
                IEnumerable<dm_userEntity> dm_UserEntities = BaseRepository("dm_data").FindList<dm_userEntity>(t => user_ids.Contains(t.id.ToString()));
                if (dm_UserEntities.Count() > 0)
                {
                    foreach (dm_userEntity item in dm_UserEntities)
                    {
                        if (user_level == 3)
                        { //等级为合伙人  并且等级为初级代理
                            //item.userlevel = 1;
                            if (item.userlevel == 0)
                                throw new Exception("普通用户无法直接晋升为合伙人!");
                            item.partners = 20000 + item.id;
                            item.partnersstatus = 2;
                        }
                        else
                        {
                            if (user_level == 0 && item.partnersstatus == 2)
                                throw new Exception("合伙人无法降级到普通会员!");
                            item.userlevel = user_level;
                        }
                        item.Modify(item.id);
                        dm_UserEntity_UpdateList.Add(item);
                    }

                    BaseRepository("dm_data").Update(dm_UserEntity_UpdateList);
                }
                else
                {
                    throw new Exception("用户信息异常!");
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 获取平台数据统计
        ///获取用户数量、订单数量、任务数量、订单交易金额、订单总佣金
        public DataTable GetStaticData1()
        {
            try
            {
                return BaseRepository("dm_data").FindTable("select (select count(id) from dm_user) usercount,(select count(id) from dm_order where order_type_new<>3) ordercount,(select count(id) from dm_task where task_status<>2) taskcount,(select sum(payment_price) from dm_order where order_type_new<>3) totalpayprice,(select sum(estimated_effect) from dm_order where order_type_new<>3) totalcommission");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }

        /// <summary>
        /// 获取前5条订单
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaticData2()
        {
            try
            {
                return BaseRepository("dm_data").FindTable("select type_big,title,order_createtime from dm_order ORDER BY order_createtime DESC limit 5");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 获取前5条任务
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaticData3()
        {
            try
            {
                return BaseRepository("dm_data").FindTable("select plaform,task_title,createtime from dm_task ORDER BY createtime DESC limit 5");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 获取近12个月数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetStaticData4()
        {
            try
            {
                return BaseRepository("dm_data").FindTable("select order_create_month,sum(payment_price) as month_pay,sum(estimated_effect) month_effect from dm_order where order_type_new<>3 GROUP BY order_create_month ORDER BY order_create_month DESC limit 12");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 粉丝数据统计
        public FansStaticInfoEntity GetFansStaticInfo(int User_ID)
        {
            try
            {
                dm_user_relationEntity dm_User_RelationEntity = dm_UserRelationService.GetEntityByUserID(User_ID);
                if (dm_User_RelationEntity.IsEmpty())
                    throw new Exception("未检测到您的上级信息!");

                dm_userEntity dm_UserEntity = GetEntityByCache(dm_User_RelationEntity.parent_id);
                if (dm_UserEntity.IsEmpty())
                    throw new Exception("用户信息异常!");

                return new FansStaticInfoEntity
                {
                    Parent_WX = dm_UserEntity.mywechat,
                    Parent_NickName = dm_UserEntity.nickname,
                    MyChildCount = dm_UserEntity.mychildcount,
                    MySonChildCount = dm_UserEntity.mysonchildcount,
                    MyPartnersCount = dm_UserEntity.mypartnerscount,
                    HeadPic = dm_UserEntity.headpic
                };
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion
    }
}
