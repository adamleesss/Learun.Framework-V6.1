using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
	public class dm_accountdetailEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID")]
		public int? id
		{
			get;
			set;
		}

		[Column("CURRENTVALUE")]
		public decimal? currentvalue
		{
			get;
			set;
		}

		[Column("STEPVALUE")]
		public decimal? stepvalue
		{
			get;
			set;
		}

		[Column("USER_ID")]
		public int? user_id
		{
			get;
			set;
		}

		[Column("TITLE")]
		public string title
		{
			get;
			set;
		}

        /// <summary>
        /// �˻��������Դ ���� 1����Ӷ��  2һ����˿����  3������˿����  4�ŶӶ���  5�¼��ŶӶ���  6�¼���ͨ����  7���¼���ͨ���� 8�Ŷӳ�Ա  9�¼��Ŷӳ�Ա 10������������ 11�������� 12�������� 13ȡ���������� 14�Լ�������  15�¼�������  16���¼������� 17�Ŷӳ�Ա������  18�¼��Ŷӳ�Ա������
        /// </summary>
		[Column("TYPE")]
		public int? type
		{
			get;
			set;
		}

		[Column("REMARK")]
		public string remark
		{
			get;
			set;
		}

		[Column("CREATETIME")]
		public DateTime? createtime
		{
			get;
			set;
		}

		[Column("CREATECODE")]
		public string createcode
		{
			get;
			set;
		}

		public void Create()
		{
		}

		public void Modify(int? keyValue)
		{
			id = keyValue;
		}
	}
}
