﻿using Learun.Util;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.DM_APPManage
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-04-06 21:08
    /// 描 述：身份证实名
    /// </summary>
    public interface DM_CertificaRecordIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<dm_certifica_recordEntity> GetList( string queryJson );
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<dm_certifica_recordEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        dm_certifica_recordEntity GetEntity(int keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(int keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(int keyValue, dm_certifica_recordEntity entity);
        #endregion

        #region 实名认证

        /// <summary>
        /// 获取实名认证记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        dm_certifica_recordEntity GetCertificationRecord(int user_id);

        /// <summary>
        /// 实名信息审核
        /// </summary>
        /// <param name="entity"></param>
        void CheckCertificationRecord(dm_certifica_recordEntity entity);
        #endregion
    }
}
