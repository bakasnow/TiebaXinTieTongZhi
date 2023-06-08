using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiebaXinTieTongZhi
{
    public static class KaiJiQiDong
    {
        public static bool ZhuCe()
        {
            // 获取启动项注册表键
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            // 设置启动项
            registryKey?.SetValue("TiebaXinTieTongZhi", Application.ExecutablePath);

            if (IsZhuCe())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ShanChu()
        {
            // 获取启动项注册表键
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            // 删除启动项
            registryKey?.DeleteValue("TiebaXinTieTongZhi", false);

            if (IsZhuCe())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsZhuCe()
        {
            bool isKaiJiQiDong = false;
            // 获取启动项注册表键
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            // 判断是否存在启动项
            if (registryKey != null)
            {
                string[] valueNames = registryKey.GetValueNames();
                foreach (string valueName in valueNames)
                {
                    if (valueName.Equals("TiebaXinTieTongZhi"))
                    {
                        // 已注册开机启动
                        isKaiJiQiDong = true;
                        break;
                    }
                }
            }

            return isKaiJiQiDong;
        }

    }
}
