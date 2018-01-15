using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.basetype
{    
    public enum SubLevelTypeReport
    {
        Staff, Department, Faculty, None
    };
    public enum OrderType
    {
        DEFAULT, NAME, EDUPOINT, RESEARCHPOINT, TOTALPOINT
    };

    public enum OrderPaperType
    {
        DEFAULT, NAME, PUBLISHDATE, AMOUNT
    };

    public enum OrderProjectType
    {
        DEFAULT, NAME, BEGINDATE, LEVEL, AMOUNT
    };

    public enum ReportType
    {
        ACADEMY_REPORT, ACADEMY_REPORT_DETAIL, 
        FACULTY_REPORT, FACULTY_REPORT_DETAIL,
        DEPARTMENT_REPORT, DEPARTMENT_REPORT_DETAIL,
        PERSONAL_REPORT, PERSONAL_REPORT_DETAIL, NONE
    };    
}
