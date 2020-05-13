using Learun.Util;
using System;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    public class DM_OrderBLL : DM_OrderIBLL
    {
        private DM_OrderService dM_OrderService = new DM_OrderService();

        public IEnumerable<dm_orderEntity> GetList(string queryJson)
        {
            try
            {
                return dM_OrderService.GetList(queryJson);
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

        public IEnumerable<dm_orderEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dM_OrderService.GetPageList(pagination, queryJson);
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

        public dm_orderEntity GetEntity(string keyValue)
        {
            try
            {
                return dM_OrderService.GetEntity(keyValue);
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

        public void DeleteEntity(string keyValue)
        {
            try
            {
                dM_OrderService.DeleteEntity(keyValue);
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

        public void SaveEntity(string keyValue, dm_orderEntity entity)
        {
            try
            {
                dM_OrderService.SaveEntity(keyValue, entity);
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
        /// ������
        /// </summary>
        /// <param name="user_id">�û�ID</param>
        /// <param name="appid">ƽ̨id</param>
        /// <param name="OrderSn">�������</param>
        public void BindOrder(int user_id, string appid, string OrderSn)
        {
            try
            {
                dM_OrderService.BindOrder(user_id, appid, OrderSn);
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
        /// ��ȡ�ҵĶ���
        /// </summary>
        /// <param name="user_id">�û�ID</param>
        /// <param name="plaformType">��ƽ̨����:1=�Ա�����è,3=����,4=ƴ���</param>
        /// <param name="status">��վ��������״̬: 0=δ����,1=����,2=�ջ�δ��,3=ʧЧ,4=���������</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public IEnumerable<dm_orderEntity> GetMyOrder(int user_id, int plaformType, int status, Pagination pagination)
        {
            try
            {
                return dM_OrderService.GetMyOrder(user_id, plaformType, status, pagination);
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
        /// ִ�з���
        /// </summary>
        /// <param name="appid">Ӧ��id</param>
        public void ExcuteSubCommission(string appid) {
            try
            {
                dM_OrderService.ExcuteSubCommission(appid);
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
        /// �ֶ�ͬ������
        /// </summary>
        /// <param name="plaform">ƽ̨</param>
        /// <param name="timetype">ʱ������</param>
        /// <param name="status">����״̬</param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        public void SyncOrder(int plaform, int timetype, int status, string startTime, string endTime) {
            try
            {
                dM_OrderService.SyncOrder(plaform, timetype, status, startTime, endTime);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
