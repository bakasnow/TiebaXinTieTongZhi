using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiebaXinTieTongZhi
{
    public static class SQLite
    {
        /// <summary>
        /// 连接符字串
        /// </summary>
        private static readonly string ConnectionString = $"DataSource={Path.Combine(Environment.CurrentDirectory, "TiebaXinTieTongZhi.sqlite")}";

        public static SqlSugarClient sqlSugarClient = null;

        /// <summary>
        /// 创建SqlSugarClient 
        /// </summary>
        /// <returns></returns>
        public static void ChuangJianShuJuKu()
        {
            //创建数据库对象
            sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,//连接符字串
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
            });
        }

        /// <summary>
        /// 创建表
        /// </summary>
        public static void ChuangJianBiao()
        {
            sqlSugarClient.CodeFirst.InitTables(typeof(DingYueLieBiaoJieGou));
            sqlSugarClient.CodeFirst.InitTables(typeof(SheZhiBiaoJieGou));
            sqlSugarClient.CodeFirst.InitTables(typeof(TidHuanCunBiaoJieGou));

            if (sqlSugarClient.Queryable<SheZhiBiaoJieGou>().Any(sz => sz.SheZhiID == 1) == false)
            {
                SheZhiBiaoJieGou sheZhiBiaoJieGou = new SheZhiBiaoJieGou
                {
                    SheZhiID = 1,
                    TongZhiZiDongGuanBiShiJian = "15"
                };

                if (sqlSugarClient.Insertable(sheZhiBiaoJieGou).ExecuteCommand() != 1)
                {
                    MessageBox.Show(text: "设置初始化失败，请联系作者。", caption: "笨蛋雪说：", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
        }

        [SugarTable("DingYueLieBiao")]
        public class DingYueLieBiaoJieGou
        {
            [SugarColumn(IsPrimaryKey = true, ColumnDataType = "text")]
            public string TiebaName { get; set; }

            [SugarColumn(ColumnDataType = "integer", IsNullable = true)]
            public long SaoMiaoJianGe { get; set; }
        }

        [SugarTable("SheZhiBiao")]
        public class SheZhiBiaoJieGou
        {
            /// <summary>
            /// 设置ID
            /// </summary>
            [SugarColumn(IsPrimaryKey = true, ColumnDataType = "integer")]
            public int SheZhiID { set; get; }

            /// <summary>
            /// 通知自动关闭时间
            /// </summary>
            [SugarColumn(ColumnDataType = "text", IsNullable = true)]
            public string TongZhiZiDongGuanBiShiJian { set; get; }
        }

        [SugarTable("TidHuanCunBiao")]
        public class TidHuanCunBiaoJieGou
        {
            [SugarColumn(IsPrimaryKey = true, ColumnDataType = "integer")]
            public long Tid { set; get; }

            [SugarColumn(ColumnDataType = "text", IsNullable = true)]
            public string TiebaName { set; get; }

            [SugarColumn(ColumnDataType = "datetime", IsNullable = true)]
            public DateTime TianJiaShiJian { set; get; }
        }
    }
}
