using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodyType
{
    public class txtReadWrite
    {
        #region field
        /// <summary>
        /// 시리얼포트로 받은 데이터를 저장하기위한 List<string>
        /// </summary>
        private List<string> strList;
        #endregion

        #region init
        public txtReadWrite()
        {
            strList = new List<string>();
        }
        #endregion init

        #region public method
        /// <summary>
        /// List에 string 데이터를 저장
        /// </summary>
        /// <param name="str">저장할 데이터(string)</param>
        public void saveStr(string str)
        {
            string now = DateTime.Now.ToString("yyyy/MM/dd,HH:mm,ss.fff");
            strList.Add(str + "," + now);
        }

        /// <summary>
        /// 리스트 초기화
        /// </summary>
        public void clearList()
        {
            strList.Clear();
        }

        /// <summary>
        /// 리스트를 가져옴
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> getList()
        {
            return strList;
        }

        /// <summary>
        /// 텍스트파일로 저장
        /// </summary>
        /// <param name="name">파일 이름</param>
        public void txtWriter(string name)
        {
            fileWrite(name, 0);
        }

        /// <summary>
        /// 파일 읽기
        /// </summary>
        /// <param name="path">읽을 경로</param>
        /// <returns></returns>
        public bool txtReader(string path)
        {
            StreamReader sr = new StreamReader(path);

            try
            {
                //파일의 끝까지 Read
                while (!sr.EndOfStream)
                {
                    try
                    {
                        // 파일을 한줄씩 읽고 맨앞의 DateTime은 제거
                        string readLine = sr.ReadLine();
                        string[] ary = readLine.Split(',');

                        string extraTimeData = ary[0] + "," + ary[1] + "," + ary[2] + "," + ary[3];

                        strList.Add(extraTimeData);
                    }
                    catch (Exception) { }

                }
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                sr.Close();
            }

            return true;
        }
        #endregion

        #region private method
        /// <summary>
        /// 텍스트파일 저장
        /// </summary>
        /// <param name="name">파일 이름</param>
        /// <param name="cnt">파일 중복 방지</param>
        private void fileWrite(string name, int cnt)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            //파일 이름이 없다면, Data로 변경
            if (name == "")
                name = "Data";

            try
            {
                //현재 폴더의 Data폴더안에 저장
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Data");
                //폴더가 없다면 생성
                if (!di.Exists) { di.Create(); }

                fs = new FileStream(Application.StartupPath + @"\Data\" + name + "_" + cnt + ".txt", FileMode.CreateNew, FileAccess.Write);
                sw = new StreamWriter(fs);

                if (strList.Count > 0)
                {
                    foreach (string x in strList)
                        sw.Write(x);
                }
            }
            catch (IOException)
            {
                //만약 같은 파일이름이 있다면, cnt를 증가시켜 다시 함수 동작
                fileWrite(name, ++cnt);
            }

            if (sw != null)
                sw.Close();
            if (fs != null)
                fs.Close();
        }
        #endregion
    }
}
