using Learun.Application.TwoDevelopment.DM_APPManage;
using Learun.Application.Web.App_Start._01_Handler;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using System;
using System.Web.Mvc;

namespace Learun.Application.Web.Controllers.DM_APIControl
{
    public class DM_TaskCenterController : MvcAPIControllerBase
    {
        private ICache redisCache = CacheFactory.CaChe();

        private DM_ReadTaskIBLL dM_ReadTaskIBLL = new DM_ReadTaskBLL();

        private DM_BaseSettingIBLL dM_BaseSettingIBLL = new DM_BaseSettingBLL();

        private DM_TaskIBLL dm_TaskIBLL = new DM_TaskBLL();

        private DM_Task_ReviceIBLL dm_Task_ReviceIBLL = new DM_Task_ReviceBLL();

        private DM_Task_TypeIBLL dm_Task_TypeIBLL = new DM_Task_TypeBLL();

        #region 获取任务类型
        public ActionResult GetTaskType()
        {
            try
            {
                string appid = CheckAPPID();
                return SuccessList("获取成功!", dm_Task_TypeIBLL.GetList("{\"appid\":\"" + appid + "\"}"));
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 获取任务列表
        public ActionResult GetTaskList(int PageNo=1, int PageSize=20, string TaskType = "-1")
        {
            try
            {
                string appid = CheckAPPID();

                string queryDiction = "";
                if (TaskType == "-1")
                {
                    queryDiction = "{\"appid\":\"" + appid + "\"}";
                }
                else
                {
                    queryDiction = "{\"appid\":\"" + appid + "\",\"task_type\":\"" + TaskType + "\"}";
                }

                return SuccessList("获取成功!", dm_TaskIBLL.GetPageList(new Pagination
                {
                    page = PageNo,
                    rows = PageSize,
                    sidx = "sort",
                    sord = "desc"
                }, queryDiction));
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 发布任务
        public ActionResult ReleaseTask(dm_taskEntity dm_TaskEntity)
        {
            try
            {
                string appid = CheckAPPID();
                dm_TaskEntity.appid = appid;
                dm_TaskIBLL.ReleaseTask(dm_TaskEntity);
                return Success("发布成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 取消任务(发布方)
        public ActionResult CancelByReleasePerson(int TaskID)
        {
            try
            {
                dm_TaskIBLL.CancelByReleasePerson(TaskID);
                return Success("取消成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 取消任务(接受方)
        public ActionResult CancelByRevicePerson(int ReviceID)
        {
            try
            {
                dm_Task_ReviceIBLL.CancelByRevicePerson(ReviceID);
                return Success("取消成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 接受任务
        public ActionResult ReviceTask(dm_task_reviceEntity dm_Task_ReviceEntity)
        {
            try
            {
                dm_Task_ReviceIBLL.ReviceTask(dm_Task_ReviceEntity);
                return Success("接受成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 提交资料
        public ActionResult SubmitMeans(dm_task_reviceEntity dm_Task_ReviceEntity)
        {
            try
            {
                dm_Task_ReviceIBLL.ReviceTask(dm_Task_ReviceEntity);
                return Success("资料提交成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 任务审核
        public ActionResult AuditTask(int ReviceID)
        {
            try
            {
                dm_Task_ReviceIBLL.AuditTask(ReviceID);
                return Success("审核成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 获取我的发布
        public ActionResult GetMyReleaseTask()
        {
            return View();
        }
        #endregion

        #region 获取我的接受
        public ActionResult GetMyReviceTask()
        {
            return View();
        }
        #endregion

        #region 获取任务详情
        public ActionResult GetTaskDetail(int task_id, int user_id)
        {
            try
            {
                var obj= new {TaskInfo= dm_TaskIBLL };
                return Success("审核成功!");
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 获取阅赚任务
        public ActionResult GetReadEarnTaskList(int PageNo, int PageSize)
        {
            try
            {
                string appid = CheckAPPID();
                return SuccessList("获取成功", dM_ReadTaskIBLL.GetPageListByCache(new Pagination
                {
                    page = PageNo,
                    rows = PageSize
                }, appid));
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        #region 增加任务点击次数
        public ActionResult AddClickReadEarnTask(int id)
        {
            try
            {
                string appid = CheckAPPID();
                dm_basesettingEntity dm_BasesettingEntity = dM_BaseSettingIBLL.GetEntityByCache(appid);
                Random random = new Random();
                int clickCount = random.Next(dm_BasesettingEntity.readtask_min.ToInt(), dm_BasesettingEntity.readtask_max.ToInt());
                dM_ReadTaskIBLL.AddClickReadEarnTask(id, clickCount, appid);
                return Success("点击成功", new
                {
                    ClickCount = clickCount
                });
            }
            catch (Exception ex)
            {
                return FailException(ex);
            }
        }
        #endregion

        public string CheckAPPID()
        {
            if (base.Request.Headers["appid"].IsEmpty())
            {
                throw new Exception("缺少参数appid");
            }
            return base.Request.Headers["appid"].ToString();
        }
    }
}
