using Learun.Util;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
	public interface DM_OrderIBLL
	{
		IEnumerable<dm_orderEntity> GetList(string queryJson);

		IEnumerable<dm_orderEntity> GetPageList(Pagination pagination, string queryJson);

		dm_orderEntity GetEntity(string keyValue);

		void DeleteEntity(string keyValue);

		void SaveEntity(string keyValue, dm_orderEntity entity);

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="user_id">�û�ID</param>
        /// <param name="appid">ƽ̨id</param>
        /// <param name="OrderSn">�������</param>
        void BindOrder(int user_id, string appid, string OrderSn);
        /// <summary>
        /// ��ȡ�ҵĶ���
        /// </summary>
        /// <param name="user_id">�û�ID</param>
        /// <param name="plaformType">��ƽ̨����:1=�Ա�����è,3=����,4=ƴ���</param>
        /// <param name="status">��վ��������״̬: 0=δ����,1=����,2=�ջ�δ��,3=ʧЧ,4=���������</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        IEnumerable<dm_orderEntity> GetMyOrder(int user_id, int plaformType, int status, Pagination pagination);

        /// <summary>
        /// ִ�з���(�ϸ��½���Ķ���)
        /// </summary>
        /// <param name="appid"></param>
        void ExcuteSubCommission(string appid);
    }
}
