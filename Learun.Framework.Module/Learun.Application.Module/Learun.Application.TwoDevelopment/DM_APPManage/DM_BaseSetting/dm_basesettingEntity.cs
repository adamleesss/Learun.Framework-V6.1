using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    public class dm_basesettingEntity
    {
        [Column("APPID")]
        public string appid
        {
            get;
            set;
        }

        [Column("TB_ACCOUNTID")]
        public int? tb_accountid
        {
            get;
            set;
        }

        [Column("TB_APPKEY")]
        public string tb_appkey
        {
            get;
            set;
        }

        [Column("TB_APPSECRET")]
        public string tb_appsecret
        {
            get;
            set;
        }

        [Column("TB_SESSIONKEY")]
        public string tb_sessionkey
        {
            get;
            set;
        }

        [Column("TB_RELATION_PID")]
        public string tb_relation_pid
        {
            get;
            set;
        }

        [Column("TB_AUTHORENDTIME")]
        public DateTime? tb_authorendtime
        {
            get;
            set;
        }

        [Column("JD_ACCOUNTID")]
        public int? jd_accountid
        {
            get;
            set;
        }

        [Column("JD_APPKEY")]
        public string jd_appkey
        {
            get;
            set;
        }

        [Column("JD_APPSECRET")]
        public string jd_appsecret
        {
            get;
            set;
        }

        [Column("JD_SESSIONKEY")]
        public string jd_sessionkey
        {
            get;
            set;
        }

        [Column("PDD_ACCOUNTID")]
        public int? pdd_accountid
        {
            get;
            set;
        }

        [Column("PDD_CLIENTID")]
        public string pdd_clientid
        {
            get;
            set;
        }

        [Column("PDD_CLIENTSECRET")]
        public string pdd_clientsecret
        {
            get;
            set;
        }

        [Column("OPENAGENT_ONE")]
        public int openagent_one
        {
            get;
            set;
        }

        [Column("OPENAGENT_TWO")]
        public int openagent_two
        {
            get;
            set;
        }

        [Column("OPENAGENT_ONE_PARTNERS")]
        public int openagent_one_partners
        {
            get;
            set;
        }

        [Column("OPENAGENT_TWO_PARTNERS")]
        public int openagent_two_partners
        {
            get;
            set;
        }

        /// <summary>
        /// ������Ӷ��(�߼�)
        /// </summary>
		[Column("TASK_DO_SENIOR")]
        public int task_do_senior
        {
            get;
            set;
        }

        /// <summary>
        /// ������Ӷ��(����)
        /// </summary>
        [Column("TASK_DO_JUNIOR")]
        public int task_do_junior { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        [Column("TASK_SERVICEFEE")]
        public int task_servicefee { get; set; }

        /// <summary>
        /// ������һ������Ӷ��
        /// </summary>
		[Column("TASK_ONE")]
        public int task_one
        {
            get;
            set;
        }
        /// <summary>
        /// �������������Ӷ��
        /// </summary>
		[Column("TASK_TWO")]
        public int task_two
        {
            get;
            set;
        }
        /// <summary>
        /// ������һ���ϻ���Ӷ��
        /// </summary>
		[Column("TASK_ONE_PARTNERS")]
        public int task_one_partners
        {
            get;
            set;
        }
        /// <summary>
        /// ����������ϻ���Ӷ��
        /// </summary>
		[Column("TASK_TWO_PARTNERS")]
        public int task_two_partners
        {
            get;
            set;
        }

        [Column("SHOPPING_PAY_JUNIOR")]
        public int shopping_pay_junior
        {
            get;
            set;
        }

        [Column("SHOPPING_PAY_MIDDLE")]
        public int shopping_pay_middle
        {
            get;
            set;
        }

        [Column("SHOPPING_PAY_SENIOR")]
        public int shopping_pay_senior
        {
            get;
            set;
        }

        [Column("SHOPPING_ONE")]
        public int shopping_one
        {
            get;
            set;
        }

        [Column("SHOPPING_TWO")]
        public int shopping_two
        {
            get;
            set;
        }

        [Column("SHOPPING_ONE_PARTNERS")]
        public int shopping_one_partners
        {
            get;
            set;
        }

        [Column("SHOPPING_TWO_PARTNERS")]
        public int shopping_two_partners
        {
            get;
            set;
        }

        [Column("FIRSTSIGN")]
        public int? firstsign
        {
            get;
            set;
        }

        [Column("SIGNSCREMENT")]
        public int? signscrement
        {
            get;
            set;
        }

        [Column("SIGNCAPPING")]
        public int? signcapping
        {
            get;
            set;
        }

        [Column("READTASK_MIN")]
        public int? readtask_min
        {
            get;
            set;
        }

        [Column("READTASK_MAX")]
        public int? readtask_max
        {
            get;
            set;
        }

        [Column("NEW_PEOPLE")]
        public int? new_people
        {
            get;
            set;
        }

        [Column("NEW_PEOPLE_PARENT")]
        public int? new_people_parent
        {
            get;
            set;
        }

        [Column("DTK_APPKEY")]
        public string dtk_appkey
        {
            get;
            set;
        }

        [Column("DTK_APPSECRET")]
        public string dtk_appsecret
        {
            get;
            set;
        }

        [Column("QIANZHUI_IMAGE")]
        public string qianzhui_image
        {
            get;
            set;
        }

        [Column("PREVIEWVERSION")]
        public string previewversion
        {
            get;
            set;
        }

        /// <summary>
        /// ����˽Կ
        /// </summary>
        [Column("MERCHANT_PRIVATE_KEY")]
        public string merchant_private_key { get; set; }

        /// <summary>
        /// ֧������Կ
        /// </summary>
        [Column("ALIPAY_PUBLIC_KEY")]
        public string alipay_public_key { get; set; }

        /// <summary>
        /// ֧����APPID
        /// </summary>
        [Column("ALIPAY_APPID")]
        public string alipay_appid { get; set; }

        /// <summary>
        /// ֧���ص���ַ
        /// </summary>
        [Column("ALIPAY_NOTIFYURL")]
        public string alipay_notifyurl { get; set; }

        /// <summary>
        /// ����APPKEY
        /// </summary>
        [Column("JG_APPKEY")]
        public string jg_appkey { get; set; }

        /// <summary>
        /// ����APPSECRET
        /// </summary>
        [Column("JG_APPSECRET")]
        public string jg_appsecret { get; set; }

        /// <summary>
        /// ����ǩ��ID
        /// </summary>
        [Column("SMS_SIGN_ID")]
        public string sms_sign_id { get; set; }

        /// <summary>
        /// ����ģ��ID
        /// </summary>
        [Column("SMS_TEMPLATE_ID")]
        public string sms_template_id { get; set; }

        /// <summary>
        /// ����������������
        /// </summary>
        [Column("REVICETASKCOUNTLIMIT")]
        public int revicetaskcountlimit { get; set; }

        /// <summary>
        /// OSS����ID
        /// </summary>
        [Column("OSS_ACCESSKEYID")]
        public string oss_accesskeyid { get; set; }

        /// <summary>
        /// OSS����Secret
        /// </summary>
        [Column("OSS_ACCESSKEYSECRET")]
        public string oss_accesskeysecret { get; set; }

        /// <summary>
        /// OSS����ڵ�
        /// </summary>
        [Column("OSS_ENDPOINT")]
        public string oss_endpoint { get; set; }

        /// <summary>
        /// Bucket����
        /// </summary>
        [Column("OSS_BUKETNAME")]
        public string oss_buketname { get; set; }

        /// <summary>
        /// ���ģʽ  1����  0�ر�
        /// </summary>
        [Column("OPENCHECKED")]
        public string openchecked { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [Column("TASK_RULE")]
        public string task_rule { get; set; }

        /// <summary>
        /// �������  1����  0�ر�
        /// </summary>
        [Column("TASKCHECKED")]
        public int taskchecked { get; set; }

        public void Create()
        {
            UserInfo userInfo = LoginUserInfo.Get();
            appid = userInfo.companyId;
        }

        public void Modify(string keyValue)
        {
            appid = keyValue;
        }
    }
}
