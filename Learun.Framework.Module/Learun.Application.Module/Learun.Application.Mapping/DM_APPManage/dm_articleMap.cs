﻿using Learun.Application.TwoDevelopment.DM_APPManage;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-04-06 21:10
    /// 描 述：文案管理
    /// </summary>
    public class dm_articleMap : EntityTypeConfiguration<dm_articleEntity>
    {
        public dm_articleMap()
        {
            #region 表、主键
            //表
            this.ToTable("DM_ARTICLE");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

