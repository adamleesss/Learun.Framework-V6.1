using Learun.Util;
using System.Collections.Generic;
using System.Data;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
	public interface DM_UserIBLL
	{
		IEnumerable<dm_userEntity> GetList(string queryJson);

		IEnumerable<dm_userEntity> GetPageList(Pagination pagination, string queryJson);
		DataTable GetPageListByDataTable(Pagination pagination, string queryJson);

		dm_userEntity GetEntity(int? keyValue);

		dm_userEntity GetEntityByPhone(string phone, string appid);

		dm_userEntity GetEntityByCache(int id);

		void DeleteEntity(int keyValue);

		void SaveEntity(int keyValue, dm_userEntity entity);

		dm_userEntity Login(dm_userEntity entity);

		dm_userEntity Register(dm_userEntity dm_UserEntity, string VerifiCode, string appid);

		string EncodeInviteCode(int? id);

		int? DecodeInviteCode(string InviteCode);

		dynamic SignIn(int userid);
		/// <summary>
		/// �����˻����
		/// </summary>
		/// <param name="user_id">�û�id</param>
		/// <param name="updateprice">������</param>
		/// <param name="updatetype">������� 0����  1����</param>
		/// <param name="remark">������Ϣ</param>
		void UpdateAccountPrice(int user_id, decimal updateprice, int updatetype, string remark);
		#region ��ȡ�ƹ�ͼƬ
		List<string> GetShareImage(int user_id, string appid);
        #endregion

        #region ��ȡ�û�����
        IEnumerable<dm_userEntity> GetParentUser(int user_id);
        IEnumerable<dm_userEntity> GetChildUser(int user_id);

        dm_userEntity GetUserByPartnersID(int partnersid);
		#endregion

		#region ��ȡƽ̨ͳ������
		DataTable GetStaticData1();
		DataTable GetStaticData2();
		DataTable GetStaticData3();
		DataTable GetStaticData4();
		#endregion
	}
}
