using Learun.Cache.Factory;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
	public class dm_userEntity
	{
        /// <summary>
        /// �û�id
        /// </summary>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ID")]
		public int? id
		{
			get;
			set;
		}
        /// <summary>
        /// ��ʵ����
        /// </summary>
		[Column("REALNAME")]
        public string realname
        {
            get;
            set;
        }

        /// <summary>
        /// ֧�����˺�
        /// </summary>
        [Column("ZFB")]
        public string zfb {
            get;set;
        }
        /// <summary>
        /// ���֤��
        /// </summary>
		[Column("IDENTITYCARD")]
		public string identitycard
		{
			get;
			set;
		}

        /// <summary>
        /// ���֤����
        /// </summary>
        [Column("FRONTCARD")]
        public string frontcard { get; set; }

        /// <summary>
        /// ���֤����
        /// </summary>
        [Column("FACECARD")]
        public string facecard { get; set; }

        /// <summary>
        /// �Ƿ�ʵ�� 0δʵ��  1��ʵ��
        /// </summary>
        [Column("ISREAL")]
		public int? isreal
		{
			get;
			set;
		}
        /// <summary>
        /// �ֻ���
        /// </summary>
		[Column("PHONE")]
		public string phone
		{
			get;
			set;
		}
        /// <summary>
        /// ����token
        /// </summary>
		[Column("TOKEN")]
		public string token
		{
			get;
			set;
		}
        /// <summary>
        /// ����
        /// </summary>
		[Column("PWD")]
		public string pwd
		{
			get;
			set;
		}
        /// <summary>
        /// �û��ǳ�
        /// </summary>
		[Column("NICKNAME")]
		public string nickname
		{
			get;
			set;
		}

        /// <summary>
        /// �û�ͷ��
        /// </summary>
        [Column("HEADPIC")]
        public string headpic { get; set; }

        /// <summary>
        /// �˻����
        /// </summary>
		[Column("ACCOUNTPRICE")]
		public decimal? accountprice
		{
			get;
			set;
		}
        /// <summary>
        /// ������
        /// </summary>
		[Column("INVITECODE")]
		public string invitecode
		{
			get;
			set;
		}
        /// <summary>
        /// �ϻ���id
        /// </summary>
		[Column("PARTNERS")]
		public int partners
		{
			get;
			set;
		}
        /// <summary>
        /// �ϻ���״̬(0�Ǻϻ���  1�ϻ���)
        /// </summary>
		[Column("PARTNERSSTATUS")]
		public int? partnersstatus
		{
			get;
			set;
		}
        /// <summary>
        /// �Ա�pid
        /// </summary>
		[Column("TB_PID")]
		public string tb_pid
		{
			get;
			set;
		}
        /// <summary>
        /// ����id
        /// </summary>
		[Column("TB_RELATIONID")]
		public int? tb_relationid
		{
			get;
			set;
		}
        /// <summary>
        /// ��������id
        /// </summary>
		[Column("TB_ORDERRELATIONID")]
		public int? tb_orderrelationid
		{
			get;
			set;
		}
        /// <summary>
        /// ������վid
        /// </summary>
        [Column("JD_SITE")]
        public string jd_site { get; set; }
        /// <summary>
        /// ����pid
        /// </summary>
		[Column("JD_PID")]
		public string jd_pid
		{
			get;
			set;
		}
        /// <summary>
        /// ƴ���pid
        /// </summary>
		[Column("PDD_PID")]
		public string pdd_pid
		{
			get;
			set;
		}
        /// <summary>
        /// �û��ȼ�  0��ͨ�û�   1�����û�  2�߼��û�
        /// </summary>
		[Column("USERLEVEL")]
		public int? userlevel
		{
			get;
			set;
		}
        /// <summary>
        /// ����ʱ��
        /// </summary>
		[Column("CREATETIME")]
		public DateTime? createtime
		{
			get;
			set;
		}
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
		[Column("UPDATETIME")]
		public DateTime? updatetime
		{
			get;
			set;
		}
        /// <summary>
        /// ƽ̨id
        /// </summary>
		[Column("APPID")]
		public string appid
		{
			get;
			set;
		}
        /// <summary>
        /// ʡ��
        /// </summary>
		[Column("PROVINCE")]
		public string province
		{
			get;
			set;
		}
        /// <summary>
        /// ����
        /// </summary>
		[Column("CITY")]
		public string city
		{
			get;
			set;
		}
        /// <summary>
        /// ����
        /// </summary>
		[Column("DOWN")]
		public string down
		{
			get;
			set;
		}
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
		[Column("ADDRESS")]
		public string address
		{
			get;
			set;
		}
        /// <summary>
        /// �˻�����
        /// </summary>
		[Column("INTEGRAL")]
		public int? integral
		{
			get;
			set;
		}

		public void Create()
		{
			userlevel = 0;
			createtime = DateTime.Now;
			isreal = 0;
			accountprice = default(decimal);
		}

		public void Modify(int? keyValue)
		{
			id = keyValue;
			int? num = keyValue;
			string cacheKey = "UserInfo" + num.ToString();
			CacheFactory.CaChe().Remove(cacheKey, 7L);
		}
	}
}
