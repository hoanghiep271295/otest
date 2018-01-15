using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Comm;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace IS.LogFile
{    
    /// <summary>
    /// provides all common function for only this solution.
    /// </summary>   

    public static class logFile 
    {
        static public string fileName = "";
        static int mode = 3;
        
        /// <summary>
        /// Ghi thông báo vào log file; mode mặc định là 1
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        static public int write(string mes)
        {
            int debugMode = 1;
            if (mode < debugMode)
            {
                return 1;
            }
            try
            {
                StreamWriter file = new StreamWriter(fileName, true);
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t" + mes );
                file.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Ghi ra có thêm thông tin hàm
        /// </summary>
        /// <param name="function"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        static public int write(string function, string mes)
        {
            int debugMode = 1;
            if (mode < debugMode)
            {
                return 1;
            }
            try
            {
                StreamWriter file = new StreamWriter(fileName, true);
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+":\t" + function + ":\t" + mes);
                file.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
      /// <summary>
      /// Ghi ra có tên hàm và mức độ ghi
      /// </summary>
      /// <param name="debugMode"></param>
      /// <param name="function"></param>
      /// <param name="mes"></param>
      /// <returns></returns>
        static public int write(int debugMode,string function, string mes)
        {
            if (mode < debugMode)
            {
                return 1;
            }
            try
            {
                StreamWriter file = new StreamWriter(fileName, true);
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t" + function + ":\t" + mes);
                file.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// Ghi thông báo vào logfile; mode:1 luôn ghi, 3: thông báo thông thường sẽ tắt khi triển khai
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="debugMode"></param>
        /// <returns></returns>
        static public int write(int debugMode,string mes)
        {
            int ret = 0;
            if (mode < debugMode)
            {
                return 1;
            }
            try
            {
                StreamWriter file = new StreamWriter(fileName, true);
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t" + mes);
                file.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}