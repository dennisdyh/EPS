using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Framework.Web
{
    public class Uploads
    {
        private string _state = "SUCCESS";
        private string _stateCode = "1";
        private string _url = null;
        private string _currentType = null;
        private string _uploadpath = null;
        private string _filename = null;
        private string _originalName = null;
        private HttpPostedFile _uploadFile = null;

        /**
          * 上传文件的主处理方法
          * @param HttpContext
          * @param string
          * @param  string[]
          *@param int
          * @return Hashtable
          */
        public Hashtable upFile(string pathbase, string[] filetype, int size, string name = "")
        {
            _uploadpath = HttpContext.Current.Server.MapPath(pathbase);
            try
            {
                _uploadFile = name == string.Empty ? HttpContext.Current.Request.Files[0] : HttpContext.Current.Request.Files[name];

                if (_uploadFile == null)
                    throw new ArgumentNullException("Upload File");

                _originalName = _uploadFile.FileName;

                CreateFolder();

                if (CheckType(filetype))
                {
                    _stateCode = "2";
                    _state = "File type is invalid";
                }
                if (CheckSize(size))
                {
                    _stateCode = "3";
                    _state = "File size is too large";
                }
                if (_state == "SUCCESS")
                {
                    _stateCode = "1";
                    _filename = ReName();
                    _uploadFile.SaveAs(_uploadpath + _filename);
                    _url = pathbase + _filename;
                }
            }
            catch (Exception ex)
            {
                _state = ex.Message;
                _url = string.Empty;
            }
            return GetUploadInfo();
        }
        /**
        * 获取文件信息
        * @param context
        * @param string
        * @return string
        */
        public string getOtherInfo(string field)
        {
            var cxt = HttpContext.Current;
            string info = null;
            if (cxt.Request.Form[field] != null && !String.IsNullOrEmpty(cxt.Request.Form[field]))
            {
                info = field == "fileName" ? cxt.Request.Form[field].Split(',')[1] : cxt.Request.Form[field];
            }
            return info;
        }

        /**
         * 获取上传信息
         * @return Hashtable
         */
        private Hashtable GetUploadInfo()
        {
            var infoList = new Hashtable();

            infoList.Add("state", _state);
            infoList.Add("url", _url);
            infoList.Add("filename", _filename);
            infoList.Add("code", _stateCode);

            if (_currentType != null)
            {
                infoList.Add("currentType", _currentType);
            }
            if (_originalName != null)
            {
                infoList.Add("originalName", _originalName);
            }
            return infoList;
        }

        /**
         * 重命名文件
         * @return string
         */
        private string ReName()
        {
            return DateTime.UtcNow.Ticks + GetFileExt();
        }

        /**
         * 文件类型检测
         * @return bool
         */
        private bool CheckType(string[] filetype)
        {
            _currentType = GetFileExt();
            return Array.IndexOf(filetype, _currentType) == -1;
        }

        /**
         * 文件大小检测
         * @param int
         * @return bool
         */
        private bool CheckSize(int size)
        {
            return _uploadFile.ContentLength >= (size * 1024 * 1024);
        }

        /**
         * 获取文件扩展名
         * @return string
         */
        private string GetFileExt()
        {
            var temp = _uploadFile.FileName.Split('.');
            return "." + temp[temp.Length - 1].ToLower();
        }

        /**
         * 按照日期自动创建存储文件夹
         */
        private void CreateFolder()
        {
            if (!Directory.Exists(_uploadpath))
            {
                Directory.CreateDirectory(_uploadpath);
            }
        }
        /**
         * 删除存储文件夹
         * @param string
         */
        public void DeleteFolder(string path)
        {
            var info = new DirectoryInfo(path);
            if (info.Exists)
            {
                var infoArr = info.GetDirectories();
                foreach (DirectoryInfo tmpInfo in infoArr)
                {
                    foreach (FileInfo fi in tmpInfo.GetFiles())
                    {
                        fi.Delete();
                    }
                }
            }
        }
    }
}
