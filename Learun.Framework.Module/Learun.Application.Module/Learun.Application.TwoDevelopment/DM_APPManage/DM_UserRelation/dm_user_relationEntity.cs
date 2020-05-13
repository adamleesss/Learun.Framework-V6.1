using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    public class dm_user_relationEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? id
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
        /// <summary>
        /// �ϼ��û�id
        /// </summary>
        [Column("PARENT_ID")]
        public int parent_id
        {
            get;
            set;
        }
        /// <summary>
        /// �ϼ��û��ǳ�
        /// </summary>
        [Column("PARENT_NICKNAME")]
        public string parent_nickname {
            get;set;
        }

        [Column("PARTNERS_ID")]
        public int? partners_id
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

        /// <summary>
        /// ������
        /// </summary>
        [Column("ORDERCOUNT")]
        public int ordercount { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("TASKCOUNT")]
        public int taskcount { get; set; }

        /// <summary>
        /// ����ٱ���
        /// </summary>
        [Column("TASKREPORTCOUNT")]
        public int taskreportcount { get; set; }

        /// <summary>
        /// ����Ӷ��Ԥ��
        /// </summary>
        [Column("CURRENTMONTHEFFECT")]
        public decimal? CurrentMonthEffect { get; set; }

        /// <summary>
        /// �����ջ�Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTMONTHRECEIVEEFFECT")]
        public decimal? CurrentMonthReceiveEffect { get; set; }
        /// <summary>
        /// �����ջ�Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("UPMONTHRECEIVEEFFECT")]
        public decimal? UpMonthReceiveEffect { get; set; }
        /// <summary>
        /// �����ջ�Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("TODAYREVICEEFFECT")]
        public decimal? TodayReviceEffect { get; set; }
        /// <summary>
        /// �����ջ�Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("YESTODAYREVICEEFFECT")]
        public decimal? YesTodayReviceEffect { get; set; }
        /// <summary>
        /// ���¸�����
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTMONTHPAYMENTPRICE")]
        public decimal? CurrentMonthPayMentPrice { get; set; }
        /// <summary>
        /// ���¸�����
        /// </summary>
        /// <returns></returns>
        [Column("UPMONTHPAYMENTPRICE")]
        public decimal? UpMonthPayMentPrice { get; set; }
        /// <summary>
        /// ���ո�����
        /// </summary>
        /// <returns></returns>
        [Column("TODAYPAYMENTPRICE")]
        public decimal? TodayPayMentPrice { get; set; }
        /// <summary>
        /// YesTodayPayMentPrice
        /// </summary>
        /// <returns></returns>
        [Column("YESTODAYPAYMENTPRICE")]
        public decimal? YesTodayPayMentPrice { get; set; }
        /// <summary>
        /// ���¶�����
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTMONTHORDERCOUNT")]
        public int? CurrentMonthOrderCount { get; set; }
        /// <summary>
        /// ���¶�����
        /// </summary>
        /// <returns></returns>
        [Column("UPMONTHORDERCOUNT")]
        public int? UpMonthOrderCount { get; set; }
        /// <summary>
        /// ���ն�����
        /// </summary>
        /// <returns></returns>
        [Column("TODAYORDERCOUNT")]
        public int? TodayOrderCount { get; set; }
        /// <summary>
        /// ���ն�����
        /// </summary>
        /// <returns></returns>
        [Column("YESTODAYORDERCOUNT")]
        public int? YesTodayOrderCount { get; set; }
        /// <summary>
        /// ��������Ӷ��
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTMONTHREVICETASKPRICE")]
        public decimal? CurrentMonthReviceTaskPrice { get; set; }
        /// <summary>
        /// ��������Ӷ��
        /// </summary>
        /// <returns></returns>
        [Column("UPMONTHREVICETASKPRICE")]
        public decimal? UpMonthReviceTaskPrice { get; set; }
        /// <summary>
        /// ��������Ӷ��
        /// </summary>
        /// <returns></returns>
        [Column("TODAYREVICETASKPRICE")]
        public decimal? TodayReviceTaskPrice { get; set; }
        /// <summary>
        /// ��������Ӷ��
        /// </summary>
        /// <returns></returns>
        [Column("YESTODAYREVICETASKPRICE")]
        public decimal? YesTodayReviceTaskPrice { get; set; }
        /// <summary>
        /// ���½���������
        /// </summary>
        /// <returns></returns>
        [Column("CURRENTMONTHREVICETASKCOUNT")]
        public int? CurrentMonthReviceTaskCount { get; set; }
        /// <summary>
        /// ���½���������
        /// </summary>
        /// <returns></returns>
        [Column("UPMONTHREVICETASKCOUNT")]
        public int? UpMonthReviceTaskCount { get; set; }
        /// <summary>
        /// ���ս���������
        /// </summary>
        /// <returns></returns>
        [Column("TODAYREVICETASKCOUNT")]
        public int? TodayReviceTaskCount { get; set; }
        /// <summary>
        /// ���ս���������
        /// </summary>
        /// <returns></returns>
        [Column("YESTODAYREVICETASKCOUNT")]
        public int? YesTodayReviceTaskCount { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("REVICETASKCOUNT")]
        public int? ReviceTaskCount { get; set; }

        public void Create()
        {
        }

        public void Modify(int? keyValue)
        {
            id = keyValue;
        }
    }
}
