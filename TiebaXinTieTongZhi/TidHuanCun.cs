using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TiebaXinTieTongZhi.SQLite;

namespace TiebaXinTieTongZhi
{
    /// <summary>
    /// Tid缓存
    /// </summary>
    public static class TidHuanCun
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tidHuanCunBiaoJieGou"></param>
        /// <returns></returns>
        public static bool TianJia(TidHuanCunBiaoJieGou tidHuanCunBiaoJieGou)
        {
            if (sqlSugarClient.Insertable(tidHuanCunBiaoJieGou).ExecuteCommand() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static bool ShanChu(long tid)
        {
            if (sqlSugarClient.Deleteable<TidHuanCunBiaoJieGou>().Where(new TidHuanCunBiaoJieGou() { Tid = tid }).ExecuteCommand() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static bool IsCunZai(long tid)
        {
            if (sqlSugarClient.Queryable<TidHuanCunBiaoJieGou>().Where(thc => thc.Tid == tid).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
