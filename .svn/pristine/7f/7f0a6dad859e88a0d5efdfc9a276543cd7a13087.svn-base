using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.localcomm;
using Spire.Xls;
using System.Data;
using System.Runtime.Remoting.Channels;
using IS.fitframework;
using IS.uni;
namespace IS.report
{
    public class Excelprocess
    {
        public delegate void MyFunction(int x);

        localcommonlib com = new localcommonlib();
        #region Các hàm hỗ trợ việc mở file; mở file là template, mở file để đọc
        /// <summary>
        /// Mở một workbook từ template thường để ghi ra
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        Workbook workbookFromTemplate(string filename, out string mes)
        {
            Workbook wb = new Workbook();
            mes = "";
            try
            {
                wb.LoadTemplateFromFile(filename);
            }
            catch (Exception ex)
            {

//                AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                mes = ex.Message;
                return null;
            }
            return wb;
        }
        /// <summary>
        /// Mở một file để đọc dữ liệu
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        Workbook workbookFromFile(string filename, out string mes)
        {
            Workbook wb = new Workbook();
            mes = "";
            try
            {
                wb.LoadFromFile(filename);
            }
            catch (Exception ex)
            {

//                AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                mes = ex.Message;
                return null;
            }
            return wb;
        }
        /// <summary>
        /// Load một file cấu hình
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected DataSet loadConfig(string fileName)
        {
            DataSet ds;
            ds = new DataSet();
            try
            {
                ds.ReadXml(fileName);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// get datarow based on filter id
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        protected DataRow getDataRow(DataTable dt, string filterValue)
        {
            if (dt == null)
            {
                return null;
            }
            filterValue = filterValue.Replace("'", "''");

            DataRow[] row = dt.Select(string.Format("id='{0}'", filterValue));
            if (row.Length < 1)
            {
                return null;
            }
            return row[0];
        }
        /// <summary>
        /// Copy style form so to de
        /// </summary>
        /// <param name="so"></param>
        /// <param name="de"></param>
        /// <returns></returns>
        public int copyStyle(CellRange so, CellRange de)
        {
            int ret = 0;
            int fr = so.Row;
            int lr = so.LastRow;
            int fc = so.Column;
            int lc = so.LastColumn;
            int dfr = de.Row;
            int dfc = de.Column;
            int i, j;
            for (i = 0; i <= lr - fr; i++)
            {
                for (j = 0; j <= lc - fc; j++)
                {
                    de[dfr + i, dfc + j].Style = so[fr + i, fc + j].Style;
                }
            }
            return ret;
        }
        /// <summary>
        /// Chuyển từ chuỗi cột sang số; dựa trên cột A -> 1
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        int column2int(string column)
        {
            if (column.Length < 1)
            {
                return 1;
            }
            if (column.Length == 1)
            {
                return (int)column[0] - 'A' + 1;
            }
            if (column.Length == 2)
            {
                int t = (int)column[0] - 'A' + 1;
                t = t * 26 + column[1] - 'A' + 1;
                return t;
            }
            return 1;
        }
        #endregion
        #region xử lý đọc bài cho hệ thống ngoại ngữ
        /// <summary>
        /// Upload dữ liệu một bài học lên; Hiện tại nội dung bài học chỉ thêm mới cần chỉnh lại để có thể cập nhật được nội dung đã tồn tại theo mã chương mục đã quy định
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="lang"></param>
        /// <param name="universitycode"></param>
        /// <returns></returns>
        public int processSubjectContent(string filename, string lang, string universitycode)
        {
            int ret = 0;
            string mes = "";
            Workbook wb = workbookFromFile(filename, out mes);
            if (wb == null)
            {
                ret = -1;
                return ret;
            }

            Worksheet ws = wb.Worksheets[0];
            const int colTitle = 1;
            const int rowTitle = 1;
            const int colSubjectCodeview = 2;
            const int rowSubjectCodeview = 2;
            const int colCodeview = 2;
            const int colName = 3;
            const int colContent = 4;
            const int rowStart = 4;
            int ccol=1, crow=1;
            string currentCode = "";
            string value = ws.Range[rowTitle, colTitle].Value;
            if (value != "Môn học")
            {
                ret = -2;
                return ret;
            }
            ccol = 2;
            crow = 2;
            string subjectCodeview = ws.Range[rowSubjectCodeview, colSubjectCodeview].Value;
            string subjectName = ws.Range[rowSubjectCodeview, colSubjectCodeview+1].Value;
            SUBJECT_BUS bus =  new SUBJECT_BUS();
            SUBJECT_OBJ obj = bus.GetByKey(new fieldpara("CODEVIEW", subjectCodeview));
            if (obj != null)
            {
                obj._ID.CODE = obj.CODE;
            }
            else
            {
                obj = new SUBJECT_OBJ();
                obj._ID.CODE = "";
                obj.CODE = bus.genNextCode(obj);
                obj.CODEVIEW = subjectCodeview;
                obj.UNIVERSITYCODE = universitycode;
                obj.LANG = lang;
                obj.EDUCATIONLEVELCODE ="DH";
                //add some in form mation for subject
            }
            obj.NAME = subjectName;
            bus.CloseConnection();
            SUBJECTCONTENT_BUS busContent = new SUBJECTCONTENT_BUS();
            SUBJECTCONTENT_OBJ objContent = new SUBJECTCONTENT_OBJ();
            List<SUBJECTCONTENT_OBJ> li = new List<SUBJECTCONTENT_OBJ>();
            currentCode = busContent.genNextCode(objContent);
            crow = rowStart;
            value = ws.Range[crow, colCodeview].Value;
            int i = 1;
            while (!string.IsNullOrEmpty(value))
            {
                //process
                objContent = new SUBJECTCONTENT_OBJ();
                objContent.CODE = currentCode;
                currentCode = busContent.genNextCode(objContent, currentCode);//for next code
                objContent.CODEVIEW = value;
                //name
                objContent.NAME = ws.Range[crow, colName].Value; 
                //content
                objContent.NOTE = ws.Range[crow, colContent].Value; 
                //type
                objContent.CONTENTTYPE = "LT";//Nên lấy từ codeview
                //uni
                objContent.UNIVERSITYCODE= universitycode;
                //uni
                objContent.LANG = lang;
                //Số thứ tự
                objContent.THEORDER = i;
                i++;//for next record
                objContent.SUBJECTCODE = obj.CODE;
                objContent.PARENTCODE = "";
                objContent.EXTCODE = objContent.CODE;
                li.Add(objContent);
                //go next record
                crow++;
                value = ws.Range[crow, colCodeview].Value;
            }
            //Process for parentcode
            foreach (SUBJECTCONTENT_OBJ objTemp in li)
            {
                string[] key = objTemp.CODEVIEW.Split('.');
                if (key.Length == 1)
                {
                    objTemp.THEORDER = com.convert2Int(key[0], 0);//Gán lại các chỉ mục lớn
                }
                else
                {
                    value = objTemp.CODEVIEW.Substring(0, objTemp.CODEVIEW.Length - key[key.Length - 1].Length - 1);
                    SUBJECTCONTENT_OBJ parent = locateObject(li,value);
                    if (parent != null)
                    {
                        objTemp.PARENTCODE = parent.CODE;
                        objTemp.EXTCODE = parent.EXTCODE + "." + objTemp.CODE;
                    }

                }

            }
            //write to database
            bus.BeginTransaction();
            busContent.setConnection(bus);
            if (obj._ID.CODE == "")
            {
                ret = bus.Insert(obj);
            }
            else
            {
                ret = bus.Update(obj);
            }
            if (ret >= 0)
            {
                ret = busContent.InsertMultiItems(li);
            }
            if (ret >= 0)
            {
                bus.CommitTransaction();
            }
            else
            {
                bus.RollbackTransaction();
            }
            bus.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Tìm một phần tử trong danh sách thông qua codeview
        /// </summary>
        /// <param name="li"></param>
        /// <param name="codeview"></param>
        /// <returns></returns>
        private SUBJECTCONTENT_OBJ locateObject(List<SUBJECTCONTENT_OBJ> li, string codeview)
        {
            SUBJECTCONTENT_OBJ obj = null;
            foreach (var objTemp in li)
            {
                if (objTemp.CODEVIEW==codeview)
                {
                    obj = objTemp;
                    break;
                }
            }
            return obj;
        }
        public int processQuestion(string filename, string lang, string universitycode)
        {
            int ret = 0;
            string mes = "";
            Workbook wb = workbookFromFile(filename, out mes);
            if (wb == null)
            {
                ret = -1;
                return ret;
            }

            Worksheet ws = wb.Worksheets[0];
            const int colTitle = 1;
            const int rowTitle = 1;
            const int colQuestiontypeCodeview = 3;
            const int rowQuestiontypeCodeview = 2;

            const int colSubjectcontentCodeview = 1;
            const int colQuestionuse = 2;
            const int colCodeview = 3;
            const int colContent = 4;
            const int colTrue = 5;
            const int rowStart = 3;
            int ccol = 1, crow = 1;
            string currentCode = "";
            string value = ws.Range[rowTitle, colTitle].Value;
            if (value != "Loại đề")
            {
                ret = -2;
                return ret;
            }
            ccol = 2;
            crow = 2;
            string QuestiontypeCodeview = ws.Range[rowQuestiontypeCodeview, colQuestiontypeCodeview].Value;
//            string subjectName = ws.Range[rowSubjectCodeview, colSubjectCodeview + 1].Value;
            QUESTIONTYPE_BUS bus = new QUESTIONTYPE_BUS();
            QUESTIONTYPE_OBJ obj = bus.GetByKey(new fieldpara("CODEVIEW", QuestiontypeCodeview));
            if (obj != null)
            {
                obj._ID.CODE = obj.CODE;
            }
            else
            {
                ret = -3;//Không xác định được loại câu hỏi
                return ret;
            }

            QUESTIONGROUP_BUS busQuestiongroup = new QUESTIONGROUP_BUS();
            QUESTIONGROUP_OBJ objQuestiongroup = new QUESTIONGROUP_OBJ();
            List<QUESTIONGROUP_OBJ> liQuestiongroup = new List<QUESTIONGROUP_OBJ>();
            QUESTION_BUS busQuestion = new QUESTION_BUS();
            QUESTION_OBJ objQuestion = new QUESTION_OBJ();
            List<QUESTION_OBJ> liQuestion = new List<QUESTION_OBJ>();
            ANSWER_BUS busAnswer = new ANSWER_BUS();
            ANSWER_OBJ objAnswer = new ANSWER_OBJ();
            List<ANSWER_OBJ> liAnswer = new List<ANSWER_OBJ>();
            QUESTIONUSE_BUS busQuestionuse = new QUESTIONUSE_BUS();
            QUESTIONUSE_OBJ objQuestionuse =  new QUESTIONUSE_OBJ();
            List<QUESTIONUSE_OBJ> liQuestionuse = busQuestionuse.getAllBy2();
            busQuestionuse.CloseConnection();
            QUESTIONGROUPUSE_BUS busQuestiongroupuse = new QUESTIONGROUPUSE_BUS();
            List<QUESTIONGROUPUSE_OBJ> liQuestiongroupuse = new List<QUESTIONGROUPUSE_OBJ>();
            QUESTIONGROUPUSE_OBJ objQuestiongroupuse = new QUESTIONGROUPUSE_OBJ();


            string questionCode = "", questiongroupCode = "", answerCode = "", questiontrue="";
            questionCode = busQuestion.genNextCode(objQuestion);
            questiongroupCode = busQuestiongroup.genNextCode(objQuestiongroup);
            answerCode = busAnswer.genNextCode(objAnswer);
            //Scan for content
            string subjectcontentcodeview, questionusecodeview, questioncodeview, questioncontent;
            crow = rowStart;
            questioncodeview = ws.Range[crow, colCodeview].Value;
            int i = 1;
            while (!string.IsNullOrEmpty(questioncodeview))
            {
                //process
                subjectcontentcodeview= ws.Range[crow, colSubjectcontentCodeview].Value;
                questionusecodeview = ws.Range[crow, colQuestionuse].Value;
                questioncontent = ws.Range[crow, colContent].Value;
                questiontrue = ws.Range[crow, colTrue].Value;
                string[] level = questioncodeview.Split('.');
                switch (level.Length)
                {
                    case 1:
                        objQuestiongroup = new QUESTIONGROUP_OBJ();
                        objQuestiongroup.CODE = questiongroupCode;
                        //4 next object
                        questiongroupCode = busQuestiongroup.genNextCode(objQuestiongroup, questiongroupCode);
                        objQuestiongroup.CODEVIEW = questioncodeview;
                        objQuestiongroup.CONTENT = questioncontent;
                        objQuestiongroup.LOCK = 0;
                        objQuestiongroup.NAME = questioncodeview;
                        objQuestiongroup.QUESTIONTYPECODE = obj.CODE;
                        string[] ar = subjectcontentcodeview.Split('_');
                        if (ar.Length != 2)
                        {
                            ret = -5;
                            break;
                        }
                        SUBJECT_BUS busSubject = new SUBJECT_BUS();
                        SUBJECT_OBJ objSubject = busSubject.GetByKey(new fieldpara("CODEVIEW", ar[0]));
                        busSubject.CloseConnection();
                        if (objSubject == null)
                        {
                            ret = -6;
                            break;
                        }
                        SUBJECTCONTENT_BUS busSubjectcontent = new SUBJECTCONTENT_BUS();
                        SUBJECTCONTENT_OBJ objSubjectcontent =
                            busSubjectcontent.GetByKey(new fieldpara("codeview", ar[1]),
                                new fieldpara("SUBJECTCODE", objSubject.CODE));
                        busSubjectcontent.CloseConnection();
                        objQuestiongroup.SUBJECTCODE = objSubject.CODE;
                        objQuestiongroup.SUBJECTCONTENTCODE = objSubjectcontent.CODE;
                        objQuestiongroup.QUESTIONUSECODELIST = questionusecodeview;
                        liQuestiongroup.Add(objQuestiongroup);
                        ar = questionusecodeview.Split('.');
                        value = "";
                        foreach (string item in ar)
                        {
                            objQuestionuse = locateQuestionuse(liQuestionuse, item);
                            if (objQuestionuse != null)
                            {
                                objQuestiongroupuse = new QUESTIONGROUPUSE_OBJ();
                                objQuestiongroupuse.QUESITONGROUPCODE = objQuestiongroup.CODE;
                                objQuestiongroupuse.QUESTIONUSECODE = objQuestionuse.CODE;
                                objQuestiongroupuse.LOCK = 0;
                                liQuestiongroupuse.Add(objQuestiongroupuse);
                                if(value!="")
                                {
                                    value += ",";
                                }
                                value += objQuestionuse.CODE;
                            }
                        }

                        //objQuestiongroup.
                        break;
                    case 2:
                        if (obj.CODEVIEW == "MC" || obj.CODEVIEW == "PA" || obj.CODEVIEW == "FI" || obj.CODEVIEW == "FG" ||
                            obj.CODEVIEW == "CO")
                        {
                            objQuestion = new QUESTION_OBJ();
                            objQuestion.CODE = questionCode;
                            //4 next 
                            questionCode = busQuestion.genNextCode(objQuestion, questionCode);
                            objQuestion.CODEVIEW = questioncodeview;
                            objQuestion.CONTENT = questioncontent;
                            objQuestion.LOCK = 0;
                            objQuestion.MARK = 1;
                            objQuestion.NAME = objQuestion.CODEVIEW;
                            objQuestion.ORD = com.convert2Int(level[1], 0); //Thứ tự trong nhóm
                            liQuestion.Add(objQuestion);
                        }
                        else
                        {
                            //Check the exist codeview
                            value = level[0] + ".1";//Chỉ là một câu hỏi đầu tiên không có
                            objQuestion = locateQuestion(liQuestion,value);
                            if (objQuestion == null)
                            {
                                objQuestion= new QUESTION_OBJ();
                                objQuestion.CODE = questionCode;
                                //4 next 
                                questionCode = busQuestion.genNextCode(objQuestion, questionCode);
                                objQuestion.CODEVIEW = value;
                                objQuestion.CONTENT = "";
                                objQuestion.LOCK = 0;
                                objQuestion.MARK = 1;
                                objQuestion.NAME = objQuestion.CODEVIEW;
                                objQuestion.ORD = 1; //Thứ tự trong nhóm
                                liQuestion.Add(objQuestion);
                            }
                            //Thêm chính thức đáp án
                            objAnswer = new ANSWER_OBJ();
                            objAnswer.CODE = answerCode;
                            //4 next object
                            answerCode = busAnswer.genNextCode(objAnswer, answerCode);
                            objAnswer.CODEVIEW = level[0] + ".1." + level[1];//new codeview to meet the rule
                            objAnswer.CONTENT = questioncontent;
                            objAnswer.NAME = objAnswer.CODEVIEW;
                            objAnswer.THEORDER = com.convert2Int(level[1], 0);
                            objAnswer.TRUEANSWER = (questiontrue == "D" ? 1 : 0);
                            liAnswer.Add(objAnswer);
                        }
                        break;
                    case 3:
                        objAnswer = new ANSWER_OBJ();
                        objAnswer.CODE = answerCode;
                        //4 next object
                        answerCode = busAnswer.genNextCode(objAnswer, answerCode);
                        objAnswer.CODEVIEW = questioncodeview;
                        objAnswer.CONTENT = questioncontent;
                        objAnswer.NAME = questioncodeview;
                        objAnswer.THEORDER = com.convert2Int(level[2], 0);
                        objAnswer.TRUEANSWER = (questiontrue == "D" ? 1 : 0);
                        liAnswer.Add(objAnswer);
                        break;

                }

                //3 Cấp: MC, PA, FI, FG, CO
                //2 Cấp: MS, RW, LA, WR, RA                
                crow++;
                questioncodeview = ws.Range[crow, colCodeview].Value;
            }
            //Process for question
            if (ret >= 0)
            {
                foreach (QUESTION_OBJ objTemp in liQuestion)
                {
                    string[] key = objTemp.CODEVIEW.Split('.');
                    if (key.Length != 2)
                    {
                        ret = -7;
                        break;
                    }
                    QUESTIONGROUP_OBJ objQG = locateQuestiongroup(liQuestiongroup, key[0]);
                    if (objQG == null)
                    {
                        ret = -8;
                        break;
                    }
                    objTemp.QUESTIONGROUPCODE = objQG.CODE;
                }
            }
            //process for answer
            if (ret >= 0)
            {
                foreach (ANSWER_OBJ objTemp in liAnswer)
                {
                    string[] key = objTemp.CODEVIEW.Split('.');
                    if (key.Length != 3)
                    {
                        ret = -9;
                        break;
                    }
                    value = objTemp.CODEVIEW.Substring(0, objTemp.CODEVIEW.Length - key[2].Length - 1);
                    QUESTION_OBJ objQG = locateQuestion(liQuestion, value);
                    if (objQG == null)
                    {
                        ret = -10;
                        break;
                    }
                    objTemp.QUESTIONGROUPCODE = objQG.QUESTIONGROUPCODE;
                    objTemp.QUESTIONCODE = objQG.CODE;
                }
            }

            ////write to database
            busQuestiongroup.BeginTransaction();
            busQuestion.setConnection(busQuestiongroup);
            busQuestionuse.setConnection(busQuestiongroup);
            busAnswer.setConnection(busQuestiongroup);
            if (ret >= 0)
            {
                ret = busQuestiongroup.InsertMultiItems(liQuestiongroup);
            }
            if (ret >= 0)
            {
                ret = busQuestion.InsertMultiItems(liQuestion);
            }
            if (ret >= 0)
            {
                ret = busAnswer.InsertMultiItems(liAnswer);
            }
            if (ret >= 0)
            {
                ret = busQuestiongroupuse.InsertMultiItems(liQuestiongroupuse);
            }
            if (ret >= 0)
            {
                busQuestiongroup.CommitTransaction();
            }
            else
            {
                busQuestiongroup.RollbackTransaction();
            }
            busQuestiongroup.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Lấy mã của questionuse base on codeview
        /// </summary>
        /// <param name="li"></param>
        /// <param name="codeview"></param>
        /// <returns></returns>
        private QUESTIONUSE_OBJ locateQuestionuse(List<QUESTIONUSE_OBJ> li, string codeview)
        {
            QUESTIONUSE_OBJ obj = null;
            foreach (var temp in li)
            {
                if (temp.CODEVIEW == codeview)
                {
                    obj = temp;
                    break;
                }    
            }
            return obj;
        }
        /// <summary>
        /// Xác đinh theo nhóm
        /// </summary>
        /// <param name="li"></param>
        /// <param name="codeview"></param>
        /// <returns></returns>
        private QUESTIONGROUP_OBJ locateQuestiongroup(List<QUESTIONGROUP_OBJ> li, string codeview)
        {
            QUESTIONGROUP_OBJ obj = null;
            foreach (var temp in li)
            {
                if (temp.CODEVIEW == codeview)
                {
                    obj = temp;
                    break;
                }
            }
            return obj;
        }
        /// <summary>
        /// Xác định mã của câu hỏi
        /// </summary>
        /// <param name="li"></param>
        /// <param name="codeview"></param>
        /// <returns></returns>
        private QUESTION_OBJ locateQuestion(List<QUESTION_OBJ> li, string codeview)
        {
            QUESTION_OBJ obj = null;
            foreach (var temp in li)
            {
                if (temp.CODEVIEW == codeview)
                {
                    obj = temp;
                    break;
                }
            }
            return obj;
        }
        #endregion
        #region các hàm đã làm để làm mẫu

        ///// <summary>
        ///// Đọc dữ liệu đăng ký chính thức từ bộ giáo dục và đào tọa để tính toán phương án tuyển sinh - 2017
        ///// </summary>
        ///// <param name="universitycode"></param>
        ///// <param name="filename"></param>
        ///// <param name="universityFilename"></param>
        ///// <param name="li"></param>
        ///// <param name="li_uni"></param>
        ///// <param name="fn"></param>
        ///// <param name="fn1"></param>
        ///// <returns></returns>
        //public int loadEDUStudent(string universitycode, string filename, string universityFilename, ref List<STUDENTENROLMENT_OBJ> li, ref List<STUDENTENROLMENT_OBJ> li_asstudent, ref List<STUDENT_OBJ> li_uni, MyFunction fn, MyFunction fn1)
        //{
        //    const int fileColumn = 20;
        //    const int headerrow = 1;
        //    const int fileColumnuni = 70;
        //    const int headerrowuni = 1;

        //    int[] fileColumns = { 0, 0, 0, 0, 0, 0, 0 };
        //    string[] realheader = { "STT", "Số báo danh", "Thứ tự nguyện vọng", "Mã trường", "Mã ngành", "Mã tổ hợp", "Điểm KK" };

        //    int[] fileColumnsuni = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //    string[] realheaderuni = { "STT", "SBD", "Họ Tên", "CMND", "Ngày sinh", "Giới tính", "ĐTƯT", "KVƯT", "Diện ưu tiên xét tuyển", "Loại huy chương", "Môn đạt giải", "Năm TN THPT", "Hạnh kiểm", "Học lực", "Điểm TB Lớp 12", "Hộ khẩu - Mã tỉnh", "Hộ khẩu - Mã Quận huyện", "Hộ khẩu - Mã xã phường", "Mã tỉnh lớp 12", "Mã trường lớp 12", "KQ Sơ Tuyển", "TO", "VA", "LI", "HO", "SI", "SU", "DI", "GDCD", "NN", "Mã môn NN" };


        //    Workbook wk = new Workbook();
        //    Workbook wkuni = new Workbook();
        //    try
        //    {
        //        wk.LoadFromFile(filename);
        //    }
        //    catch (Exception ex)
        //    {

        //        AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
        //        return -1;
        //    }
        //    try
        //    {
        //        wkuni.LoadFromFile(universityFilename);
        //    }
        //    catch (Exception ex)
        //    {

        //        AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
        //        return -2;
        //    }
        //    Worksheet ws = wk.Worksheets[0];
        //    Worksheet wsuni = wkuni.Worksheets[0];

        //    //Open is ok
        //    string value;
        //    int i;
        //    int j;
        //    //           CellRange sourceRange = ws.Range[0, 0, 0, fileColumn];
        //    //            string[] columnname = sourceRange.Value2;
        //    //Xử lý file nguyện vọng
        //    for (i = 1; i <= fileColumn; i++)
        //    {
        //        //based on the 1
        //        value = ws.Range[headerrow, i].Value;
        //        if (value == null)
        //        {
        //            break;
        //        }
        //        if (value == "")
        //        {
        //            break;
        //        }
        //        value = value.ToUpper().Trim();
        //        for (j = 0; j < fileColumns.Length; j++)
        //        {
        //            if (realheader[j].ToUpper() == value)
        //            {
        //                fileColumns[j] = i;
        //                break;
        //            }

        //        }
        //    }
        //    STUDENTENROLMENT_OBJ obj_re;
        //    j = headerrow + 1;
        //    while (true)//do all
        //    {
        //        value = ws.Range[j, 1].Value;
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            break;
        //        }
        //        obj_re = new STUDENTENROLMENT_OBJ();
        //        //read for all
        //        value = ws.Range[j, fileColumns[(int)studentindex.STT]].Value;
        //        obj_re.ORD = com.convert2Int(value, 0);
        //        value = ws.Range[j, fileColumns[(int)studentindex.SOBAODANH]].Value;
        //        obj_re.RECODE = value.Trim();

        //        value = ws.Range[j, fileColumns[(int)studentindex.THUTUNGUYENVONG]].Value;
        //        obj_re.THETIME = com.convert2Int(value, 1);//Thứ tự nguyện vọng

        //        value = ws.Range[j, fileColumns[(int)studentindex.MATRUONG]].Value;
        //        obj_re.UNIVERSITYCODE = value;


        //        value = ws.Range[j, fileColumns[(int)studentindex.MANGANH]].Value;
        //        obj_re.FIELD1 = value.Trim();

        //        value = ws.Range[j, fileColumns[(int)studentindex.MATOHOP]].Value;
        //        obj_re.EDUCATIONGROUPCODE1 = value.Trim();


        //        value = ws.Range[j, fileColumns[(int)studentindex.DIEMKK]].Value;
        //        obj_re.EXTMARK = com.convert2Decimal(value, 0);



        //        if (obj_re.UNIVERSITYCODE == universitycode)
        //        {
        //            li.Add(obj_re);
        //        }
        //        //next row
        //        if (fn != null)
        //        {
        //            fn(j);
        //        }
        //        j++;
        //    }
        //    //Đọc file thứ 2- Danh sách thí sinh
        //    //           CellRange sourceRange = ws.Range[0, 0, 0, fileColumn];
        //    //            string[] columnname = sourceRange.Value2;
        //    for (i = 1; i <= fileColumnuni; i++)
        //    {
        //        //based on the 1
        //        value = wsuni.Range[headerrowuni, i].Value;
        //        if (value == null)
        //        {
        //            break;
        //        }
        //        if (value == "")
        //        {
        //            break;
        //        }
        //        value = value.ToUpper().Trim();
        //        for (j = 0; j < fileColumnsuni.Length; j++)
        //        {
        //            if (realheaderuni[j].ToUpper() == value)
        //            {
        //                fileColumnsuni[j] = i;
        //                break;
        //            }

        //        }
        //    }
        //    STUDENT_OBJ obj;
        //    string ngoaingu = "";
        //    //Đọc duwxl iệu
        //    //, , , , , , , , , , ,, 
        //    j = headerrowuni + 1;
        //    while (true)//do all
        //    {
        //        value = wsuni.Range[j, 1].Value;
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            break;
        //        }
        //        if (fn1 != null)
        //        {
        //            fn1(j);
        //        }
        //        obj = new STUDENT_OBJ();
        //        obj_re = new STUDENTENROLMENT_OBJ();
        //        //read for all
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.STT]].Value;
        //        obj.ORD = com.convert2Int(value, 0);
        //        obj_re.ORD = obj.ORD;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.SBD]].Value;
        //        obj.RECODE = value.Trim();
        //        obj_re.RECODE = obj.RECODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HOTEN]].Value;
        //        obj.NAME = value.Trim();
        //        obj_re.NAME = obj.NAME;
        //        string faname, finame;
        //        com.parseName(obj.NAME, out faname, out finame);
        //        obj.NOTE = finame + " " + faname;
        //        obj_re.NOTE = obj.NOTE;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.CMND]].Value;
        //        obj.REGISTERCODE = value.Trim();
        //        obj_re.REGISTERCODE = obj.REGISTERCODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.NGAYSINH]].Value;
        //        if (com.checkDate(value) == 0)
        //        {
        //            obj.BIRTHDAY = com.convert2date(value, DateTime.Now);
        //        }
        //        obj_re.BIRTHDAY = obj.BIRTHDAY;
        //        obj.BIRTHDAYSHOW = value;//Ghi  nhận lại 
        //        obj_re.BIRTHDAYSHOW = obj.BIRTHDAYSHOW;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.GIOITINH]].Value;
        //        if (value.Trim().ToUpper() == "NAM")
        //        {
        //            obj.SEX = 0;
        //        }
        //        else
        //        {
        //            obj.SEX = 1;
        //        }
        //        obj_re.SEX = obj.SEX;
        //        //value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.DIACHINHANGIAYBAO]].Value;
        //        //obj.INFORMADDRESS = value;
        //        //obj_re.INFORMADDRESS = obj.INFORMADDRESS;
        //        //value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.SODIENTHOAI]].Value;
        //        //obj.PHONE = value;
        //        //obj_re.PHONE = obj.PHONE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.DTUT]].Value;
        //        obj.STATUSMARKCODE = value.Trim();
        //        obj_re.STATUSMARKCODE = obj.STATUSMARKCODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.KVUT]].Value;
        //        obj.REGIONMARKCODE = value.Trim();
        //        obj_re.REGIONMARKCODE = obj.REGIONMARKCODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.DIENUUTIENXETTUYEN]].Value;
        //        obj.EXTMARK = com.convert2Decimal(value, 0);
        //        obj_re.EXTMARK = obj.EXTMARK;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.LOAIHUYCHUONG]].Value;
        //        obj.AWARD = value;
        //        obj_re.AWARD = obj.AWARD;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.MONDATGIAI]].Value;
        //        obj.AWARDSUBJECT = value;
        //        obj_re.AWARDSUBJECT = obj.AWARDSUBJECT;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.NAMTNTHPT]].Value;
        //        obj.HIGHSCHOOLYEAR = com.convert2Int(value, 0);
        //        obj_re.HIGHSCHOOLYEAR = obj.HIGHSCHOOLYEAR;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HANHKIEM]].Value;
        //        obj.CONDUCTRESULT = value;
        //        obj_re.CONDUCTRESULT = obj.CONDUCTRESULT;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HOCLUC]].Value;
        //        obj.LEARNRESULT = value;
        //        obj_re.LEARNRESULT = obj.LEARNRESULT;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.DIEMTB12]].Value;
        //        obj.GRADE12MARK = value;
        //        obj_re.GRADE12MARK = obj.GRADE12MARK;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HOKHAUTINH]].Value;
        //        obj.PROVINCECODE = value;
        //        obj_re.PROVINCECODE = obj.PROVINCECODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HOKHAUHUYEN]].Value;
        //        obj.DISTRICTCODE = value;
        //        obj_re.DISTRICTCODE = obj.DISTRICTCODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HOKHAUXA]].Value;
        //        obj.TOWNCODE = value;
        //        obj_re.TOWNCODE = obj.TOWNCODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.MATINHTINH12]].Value;
        //        obj.GRADE12PROVINCECODE = value;
        //        obj_re.GRADE12PROVINCECODE = obj.GRADE12PROVINCECODE;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.MATRUONG12]].Value;
        //        obj.GRAD12SCHOOLCODE = value;
        //        obj_re.GRAD12SCHOOLCODE = obj.GRAD12SCHOOLCODE;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.KQSOTUYEN]].Value;
        //        obj.EDUARMYCODECHECK = value;
        //        obj_re.EDUARMYCODECHECK = obj.EDUARMYCODECHECK;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.TO]].Value;
        //        obj.TO = com.convert2Decimal(value, 0);
        //        obj_re.TO = obj.TO;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.VA]].Value;
        //        obj.VA = com.convert2Decimal(value, 0);
        //        obj_re.VA = obj.VA;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.LI]].Value;
        //        obj.LI = com.convert2Decimal(value, 0);
        //        obj_re.LI = obj.LI;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.HO]].Value;
        //        obj.HO = com.convert2Decimal(value, 0);
        //        obj_re.HO = obj.HO;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.SI]].Value;
        //        obj.SI = com.convert2Decimal(value, 0);
        //        obj_re.SI = obj.SI;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.SU]].Value;
        //        obj.SU = com.convert2Decimal(value, 0);
        //        obj_re.SU = obj.SU;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.DI]].Value;
        //        obj.DI = com.convert2Decimal(value, 0);
        //        obj_re.DI = obj.DI;
        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.GDCD]].Value;
        //        obj.GDCD = com.convert2Decimal(value, 0);
        //        obj_re.GDCD = obj.GDCD;
        //        ngoaingu = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.NN]].Value;
        //        obj.N1 = com.convert2Decimal(ngoaingu, 0);
        //        obj_re.N1 = obj.N1;

        //        value = wsuni.Range[j, fileColumnsuni[(int)studentuniindex.MAMONNN]].Value;
        //        obj.FOREIGNTYPE = value;
        //        obj_re.FOREIGNTYPE = obj.FOREIGNTYPE;
        //        switch (value)
        //        {
        //            case "N2":
        //                obj.N2 = obj.N1;
        //                obj_re.N2 = obj.N1;
        //                break;
        //            case "N3":
        //                obj.N3 = obj.N1;
        //                obj_re.N3 = obj.N1;
        //                break;
        //            case "N4":
        //                obj.N4 = obj.N1;
        //                obj_re.N4 = obj.N1;
        //                break;
        //            case "N5":
        //                obj.N5 = obj.N1;
        //                obj_re.N5 = obj.N1;
        //                break;
        //            case "N6":
        //                obj.N6 = obj.N1;
        //                obj_re.N6 = obj.N1;
        //                break;
        //        }
        //        obj.UNIVERSITYCODE = universitycode;
        //        obj_re.UNIVERSITYCODE = obj.UNIVERSITYCODE;

        //        li_uni.Add(obj);
        //        li_asstudent.Add(obj_re);
        //        //next row
        //        j++;
        //    }
        //    //STUDENTCOMPARER a = new STUDENTCOMPARER();
        //    //STUDENTENROLMENTCOMPARER b = new STUDENTENROLMENTCOMPARER();
        //    sort(li);//.Sort(b);
        //    sort(li_uni);//.Sort(a);
        //    sort(li_asstudent);//.Sort(b);

        //    return 0;
        //}

        ///// <summary>
        ///// Thống kê các vấn đề liên quan đến sơ tuyển và đăng ký
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="li"></param>
        ///// <param name="saveto"></param>
        ///// <param name="univeristyname"></param>
        ///// <param name="title"></param>
        ///// <returns></returns>
        //public int writeArmyEDU(DataTable dt, List<ARMYEDU_OBJ> li, string saveto, string univeristyname, string title)
        //{
        //    const int universityrow = 1;
        //    const int universitycol = 1;
        //    const int titlerow = 2;
        //    const int titlecol = 1;
        //    const int groupnamerow = 3;
        //    const int headerrow = 4;
        //    const int detailrow = 5;
        //    const int grouptotal = 6;
        //    const int countcolumn = 13;
        //    const int sumall = 7;
        //    int count = 0;
        //    int ord = 0;
        //    int therun = 0;
        //    int thegroup = 1;
        //    int countall = 0;
        //    int column = 1;
        //    ARMYEDU_OBJ obj = new ARMYEDU_OBJ();
        //    string code;
        //    int ret = 0;
        //    string filename = AppConfig.rungningPath + "armycheckfirst.xltx";
        //    Workbook wb = new Workbook();
        //    try
        //    {
        //        wb.LoadTemplateFromFile(filename);
        //    }
        //    catch (Exception ex)
        //    {

        //        AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
        //        return -1;
        //    }
        //    Worksheet ws = wb.Worksheets[0];//get the first
        //    Worksheet wss = wb.Worksheets.AddCopy(ws);
        //    //            Worksheet wss = wb.Worksheets[1];
        //    //university name
        //    string value = ws.Range[universityrow, universitycol].Value;
        //    value = com.replace(value, "{%UNIVERSITYNAME%}", univeristyname);
        //    ws.Range[universityrow, universitycol].Value = value;
        //    //tittle
        //    value = ws.Range[titlerow, titlecol].Value;
        //    value = com.replace(value, "{%TITLE%}", title);
        //    ws.Range[titlerow, titlecol].Value = value;

        //    //processdata
        //    if (dt.Rows.Count > 0)
        //    {
        //        code = com.string4Row(dt.Rows[0], "armyeducode", "");
        //        obj = getArmyeduObject(li, code);
        //    }
        //    //first armyedu
        //    therun = groupnamerow;
        //    ws.Copy(wss.Range[groupnamerow, 1, groupnamerow, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //    copyStyle(wss.Range[groupnamerow, 1, groupnamerow, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //    value = ws.Range[therun, 1].Value;
        //    value = com.replaceIf(value, "{%CODE%}", obj.CODEVIEW, "{%NAME%}", obj.NAME, "{%THEGROUP%}", thegroup.ToString());
        //    ws.Range[therun, 1].Value = value;
        //    therun++;
        //    //first header
        //    therun = headerrow;
        //    ws.Copy(wss.Range[headerrow, 1, headerrow, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //    copyStyle(wss.Range[headerrow, 1, headerrow, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //    therun++;
        //    //first row
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        code = com.string4Row(dr, "armyeducode", "").Trim().ToUpper();
        //        if (code != obj.CODE.ToUpper().Trim())
        //        {
        //            thegroup++;
        //            //finish curretn group 
        //            ws.Copy(wss.Range[grouptotal, 1, grouptotal, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //            copyStyle(wss.Range[grouptotal, 1, grouptotal, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //            value = ws.Range[therun, 1].Value;
        //            value = com.replaceIf(value, "{%COUNT%}", count.ToString());
        //            ws.Range[therun, 1].Value = value;
        //            therun++;
        //            ord = 0;
        //            count = 0;
        //            //and begin next
        //            obj = getArmyeduObject(li, code);
        //            //group title
        //            ws.Copy(wss.Range[groupnamerow, 1, groupnamerow, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //            copyStyle(wss.Range[groupnamerow, 1, groupnamerow, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //            value = ws.Range[therun, 1].Value;
        //            value = com.replaceIf(value, "{%CODE%}", obj.CODEVIEW, "{%NAME%}", obj.NAME, "{%THEGROUP%}", thegroup.ToString());
        //            ws.Range[therun, 1].Value = value;
        //            therun++;
        //            //first header
        //            ws.Copy(wss.Range[headerrow, 1, headerrow, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //            copyStyle(wss.Range[headerrow, 1, headerrow, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //            therun++;

        //        }
        //        ord++;
        //        count++;
        //        countall++;
        //        ws.Copy(wss.Range[detailrow, 1, detailrow, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //        copyStyle(wss.Range[detailrow, 1, detailrow, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //        //set the data
        //        column = 1;
        //        //STT
        //        ws.Range[therun, column].Value = ord.ToString();
        //        column++;
        //        //BANTS
        //        ws.Range[therun, column].Text = com.string4Row(dr, "armyeducode", "") + "-" + com.int4Row(dr, "ord", 0).ToString() + "-" + com.string4Row(dr, "oganization", "");
        //        column++;
        //        //Trường
        //        ws.Range[therun, column].Text = com.string4Row(dr, "universitycode", "");
        //        column++;
        //        //Khối
        //        ws.Range[therun, column].Text = com.string4Row(dr, "educationgroup_codeview", "");
        //        column++;
        //        //Mã ngành
        //        ws.Range[therun, column].Text = com.string4Row(dr, "specializecode", "");
        //        column++;
        //        //Tên
        //        ws.Range[therun, column].Text = com.string4Row(dr, "name", "");
        //        column++;
        //        //sex
        //        ws.Range[therun, column].Text = com.int4Row(dr, "sex", 0).ToString();
        //        column++;
        //        //Ngày sinh
        //        ws.Range[therun, column].Text = com.string4Row(dr, "birthdayshow", "");
        //        column++;
        //        //Dân tộc
        //        ws.Range[therun, column].Text = com.int4Row(dr, "ethnic", 0).ToString();
        //        column++;
        //        //Tôn giáo
        //        ws.Range[therun, column].Text = com.int4Row(dr, "religion", 0).ToString();
        //        column++;
        //        //Khư vực ưu tiên
        //        ws.Range[therun, column].Text = com.string4Row(dr, "regionmarkcode", "");
        //        column++;
        //        //Đối tượng ưu tiên
        //        ws.Range[therun, column].Text = com.string4Row(dr, "statusmarkcode", "");
        //        column++;
        //        //Chứng minh thư
        //        ws.Range[therun, column].Text = com.string4Row(dr, "registercode", "");
        //        column++;

        //        //next
        //        therun++;
        //    }
        //    //finish the last group
        //    ws.Copy(wss.Range[grouptotal, 1, grouptotal, countcolumn], ws.Range[therun, 1, therun, countcolumn], true);
        //    copyStyle(wss.Range[grouptotal, 1, grouptotal, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //    value = ws.Range[therun, 1].Value;
        //    value = com.replaceIf(value, "{%COUNT%}", count.ToString());
        //    ws.Range[therun, 1].Value = value;
        //    therun++;
        //    ws.Copy(wss.Range[sumall, 1, sumall, 1], ws.Range[therun, 1, therun, 1], true);
        //    copyStyle(wss.Range[sumall, 1, sumall, countcolumn], ws.Range[therun, 1, therun, countcolumn]);
        //    value = ws.Range[therun, 1].Value;
        //    value = com.replaceIf(value, "{%COUNTALL%}", countall.ToString());
        //    ws.Range[therun, 1].Value = value;

        //    //write file
        //    wb.Worksheets.Remove(wss);
        //    wb.SaveToFile(saveto, ExcelVersion.Version2007);
        //    return ret;
        //}
        #endregion
        /// <summary>
        /// Thống kê các vấn đề liên quan đến sơ tuyển và đăng ký
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <param name="saveto"></param>
        /// <param name="univeristyname"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int writeClasslist(string saveto, List<CLASS_OBJ> li, GRADE_OBJ obj, string univeristyname, string title)
        {
            int ret = 0;
            //string fileConfig = AppConfig.rungningPath + "templatefile\\classlist.xml";
            //DataSet ds = loadConfig(fileConfig);
            //if (ds == null)
            //{
            //    return -4;
            //}
            ////trương
            //DataRow drLoop = getDataRow(ds.Tables["topvalue"], "uniname");
            //int universityrow = com.int4Row(drLoop, "row", 0);
            //int universitycol = column2int(com.string4Row(drLoop, "col", "A"));
            ////Phòng đào tạo
            //drLoop = getDataRow(ds.Tables["topvalue"], "edudepartmentname");
            //int departmentrow = com.int4Row(drLoop, "row", 0);
            //int departmentcol = column2int(com.string4Row(drLoop, "col", "A"));
            ////gradename
            //drLoop = getDataRow(ds.Tables["topvalue"], "gradename");
            //int graderow = com.int4Row(drLoop, "row", 0);
            //int gradecol = column2int(com.string4Row(drLoop, "col", "A"));
            //string gradesource = com.string4Row(drLoop, "source", "");
            ////Thông tin về vòng lặp
            //drLoop = getDataRow(ds.Tables["loop"], "allclass");
            //int detailrow = com.int4Row(drLoop, "row", 0);
            //int detailcol = com.int4Row(drLoop, "col", 0);
            //string detailname = com.string4Row(drLoop, "name", "");
            ////Chi tiết
            //drLoop = getDataRow(ds.Tables[detailname], "order");
            //int detailordcol = column2int(com.string4Row(drLoop, "col", "A"));
            //drLoop = getDataRow(ds.Tables[detailname], "classcode");
            //int detailclasscodecol = column2int(com.string4Row(drLoop, "col", "A"));
            //drLoop = getDataRow(ds.Tables[detailname], "classname");
            //int detailclassnamecol = column2int(com.string4Row(drLoop, "col", "A"));
            //drLoop = getDataRow(ds.Tables[detailname], "countstudent");
            //int detailcountstudentcol = column2int(com.string4Row(drLoop, "col", "A"));
            //drLoop = getDataRow(ds.Tables[detailname], "note");
            //int detailnotecol = column2int(com.string4Row(drLoop, "col", "A"));
            ////Nội dung ở dưới
            ////Tổng số sinh viên
            //drLoop = getDataRow(ds.Tables["bottomvalue"], "sumstudent");
            //int sumstudentrow = com.int4Row(drLoop, "row", 0);
            //int sumstudentcol = column2int(com.string4Row(drLoop, "col", "A"));
            ////ngày in
            //drLoop = getDataRow(ds.Tables["bottomvalue"], "printdate");
            //int printdaterow = com.int4Row(drLoop, "row", 0);
            //int printdatecol = column2int(com.string4Row(drLoop, "col", "A"));
            //string printdatesource = com.string4Row(drLoop, "source", "");



            //int ord = 0;
            //int therun = 0;
            //int countstudent = 0;
            //string filename = AppConfig.rungningPath + "templatefile\\classlist.xltx"; ;
            //Workbook wb = new Workbook();
            //try
            //{
            //    wb.LoadTemplateFromFile(filename);
            //}
            //catch (Exception ex)
            //{

            //    AppConfig.writeLog(1, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            //    return -1;
            //}
            //Worksheet ws = wb.Worksheets[0];//get the first
            //Worksheet wss = wb.Worksheets.AddCopy(ws);

            ////university name
            //string value = ws.Range[universityrow, universitycol].Value;
            ////            value = com.replace(value, "{%UNIVERSITYNAME%}", univeristyname);
            ////trường
            //ws.Range[universityrow, universitycol].Value = univeristyname;
            ////phòng
            //ws.Range[departmentrow, departmentcol].Value = title;

            ////Khóa
            //value = ws.Range[graderow, gradecol].Value;
            //value = com.repalce(value, gradesource, obj.NAME);
            //ws.Range[graderow, gradecol].Value = value;

            ////Danh sách chi tiết
            //therun = detailrow;
            //foreach (CLASS_OBJ obj_class in li)
            //{
            //    ord++;
            //    //prepare the row
            //    ws.Copy(wss.Range[detailrow, 1, detailrow, detailcol], ws.Range[therun, 1, therun, detailcol], true);
            //    copyStyle(wss.Range[detailrow, 1, detailrow, detailcol], ws.Range[therun, 1, therun, detailcol]);
            //    //Thứ tự
            //    ws.Range[therun, detailordcol].Value = ord.ToString();
            //    //mã lớp
            //    ws.Range[therun, detailclasscodecol].Value = obj_class.CODEVIEW;
            //    //Tên lớp
            //    ws.Range[therun, detailclassnamecol].Value = obj_class.NAME;
            //    //Sỹ số
            //    ws.Range[therun, detailcountstudentcol].Value = obj_class.AMOUNT.ToString();
            //    //Ghi chú
            //    ws.Range[therun, detailnotecol].Text = obj_class.NOTE;
            //    countstudent += obj_class.AMOUNT;
            //    therun++;
            //}

            //ws.Copy(wss.Range[sumstudentrow, 1, sumstudentrow, detailcol], ws.Range[therun, 1, therun, detailcol], true);
            //copyStyle(wss.Range[detailrow, 1, detailrow, detailcol], ws.Range[therun, 1, therun, detailcol]);
            //ws.Range[therun, sumstudentcol].Value = countstudent.ToString();
            //therun++;
            ////skip
            //ws.Copy(wss.Range[printdaterow - 1, 1, printdaterow, detailcol], ws.Range[therun, 1, therun + 1, detailcol], true);
            //copyStyle(wss.Range[printdaterow - 1, 1, printdaterow, detailcol], ws.Range[therun, 1, therun + 1, detailcol]);
            //therun++;//skip one row
            //value = ws.Range[therun, printdatecol].Value;
            //value = com.replacepara(value, printdatesource, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
            //ws.Range[therun, printdatecol].Value = value;

            ////write file
            //wb.Worksheets.Remove(wss);
            //wb.SaveToFile(saveto, ExcelVersion.Version2007);
            return ret;
        }
    }
}
