using FluentFTP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Utils
    {
        private static String FTPAddr = "192.168.1.102";
        private static String FTPuser = "ftpuser";
        private static String FTPpw = "192.168.1.102";



        public static DataSet getXmlInfo( String xmlPath)
        {
            DataSet myds = new DataSet();
            myds.ReadXml(xmlPath);
            return myds;
        }



        public static Boolean DownLoadFile(String localPath,String remotFile)
        {
            Boolean result = true;
            FtpClient client = null;
            try
            {
                // create an FTP client
                 client = new FtpClient(FTPAddr);

                // specify the login credentials, unless you want to use the "anonymous" user account
                client.Credentials = new NetworkCredential(FTPuser, FTPpw);

                // begin connecting to the server
                client.Connect();

                client.DownloadFile(localPath, remotFile);
            }catch
            {
                result = false;
            }
            finally
            {
                client.Disconnect();

            }

            return result;

        }


        public static Boolean DownLoadDir(String localPath, String remotPath)
        {
            Boolean result = true;
            FtpClient client = null;
            try
            {
                // create an FTP client
                client = new FtpClient(FTPAddr);

                // specify the login credentials, unless you want to use the "anonymous" user account
                client.Credentials = new NetworkCredential(FTPuser, FTPpw);

                client.DataConnectionType = FtpDataConnectionType.EPSV;

                // begin connecting to the server
                client.Connect();

                client.DownloadDirectory(localPath, remotPath, FtpFolderSyncMode.Mirror);
            }
            catch
            {
                result = false;
            }
            finally
            {
                client.Disconnect();

            }

            return result;

        }
    }
}
