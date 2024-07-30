using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.IO;
using System.Data.Sql;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;



public partial class Quailifiers : System.Web.UI.Page
{
    string conn1 = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();
    string sm = "SM";
    string zbm = "ZBM";
    string asm = "ASM";
    string kae = "KAE-MT";
    string kam = "KAM";
    string rm = "RM";
    string tso = "TSO";
    string nkam = "NKAM";
    string rbm = "RBM";
    string dsm = "DSM";
    string tbe = "TBE";
    string tbm = "TBM";
    string Admin = "Admin";
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindGrid();
            binddropdown2();
            binddropdown1();
            binddropdown3();
            binddropdown4();
            Organo.Columns[5].Visible = false;
          //  Organo.Columns[2].Visible = false;
            if (Session["DESG"].ToString() == "Admin" )
            {
                Button1.Visible = false;
                Button7.Visible = false;
            }
            if (Session["BU"].ToString() == "CX")
            {
                Organo.Columns[12].Visible = false;
               // Organo.Columns[12].Visible = false;
            }
            if (Session["BU"].ToString() == "AX")
            {
                Organo.Columns[12].Visible = false;
                 Organo.Columns[13].Visible = false;
            }
        }
    }
    public void BindGrid()
    {

        string sm = "SM";
        string rbm = "RBM";
        string dsm = "DSM";
        string tbe = "TBE";
        string tbm = "TBM";
        string admin = "Admin";
        string tea = Session["TEAM"].ToString();
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = " SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'RBM' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'RBM'  )) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
           // StrQrry = " SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "' and A.DESIGNATION = 'RBM' ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ;";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (rbm == desgna || (rm == desgna && tea == "GT+MT") || (zbm == desgna && tea == "AX"))
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = " SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.RBM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'DSM' or A.DESIGNATION = 'ASM' or  A.DESIGNATION = 'KAE-MT' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'DSM' or A.DESIGNATION = 'ASM' or  A.DESIGNATION = 'KAE-MT' )) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
           // StrQrry = "	  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ]A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.RBM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'DSM' or A.DESIGNATION = 'ASM' or  A.DESIGNATION = 'KAE-MT' )) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID  ; ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (dsm == desgna || asm == desgna || (rm == desgna && tea == "AX") || nkam == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM' or A.DESIGNATION = 'KAM' or A.DESIGNATION = 'TSO' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM' or A.DESIGNATION = 'KAM' or A.DESIGNATION = 'TSO' ) ) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
            //StrQrry = "	  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ]A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM')) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL)  order by ROW_ID ; ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (tbe == desgna || tbm == desgna || tso == desgna || kam == desgna || kae == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.FS_Code='" + Session["FSCODE"] + "' ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL)  order by ROW_ID  ;";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (admin == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code ) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        string sm = "SM";
        string rbm = "RBM";
        string dsm = "DSM";
        string tbe = "TBE";
        string tbm = "TBM";
        string admin = "Admin";
        string tea = Session["BU"].ToString();
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";

        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            StrQrry = "   SELECT ROW_ID,FS_CODE,DIVISION,TEAM,DESIGNATION,ZONE,EMP_ID,EMP_NAME,HQ,DOJ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT_Rs,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT_Rs,[Q1 VF% / MSL Availability% / % Customers cross selling],[Q1 NPD%],KPI1_AMT_Rs,[E-CALL% / %of Active accounts],[CME / SAVR Score],IQVIA [GROWTH in Rx as per IQVIA],KPI2_AMT_Rs,[POWER],PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1 [CONSISTENCY_Q1],[CALLAVG/FWD],Q1_TGT,Q1_PRI_VAL,Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,Q1_ACH,SECONDARY_VAL [Q1_SECONDARY_VAL],Q1_PRISEC_ACH,SnB [Q1_SNB_VAL],SnBPr [Q1_SNB_PR],NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,PAYOUT_AMT_Rs,ELIGIBLE,REMARKS,[FINAL_PAYOUT_Rs.] FROM (SELECT IW.*, WI.DOJ FROM ( SELECT KW.*, WK.ELIGIBLE,WK.REMARKS,WK.PAYOUT [FINAL_PAYOUT_Rs.] FROM (SELECT * FROM (SELECT distinct ROW_ID,FS_Code,DIVISION,[TEAM],DESIGNATION,[ZONE],EMP_ID,[EMP_NAME],[CLIENT_HQ] HQ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT BRAND1_AMT_Rs ,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT BRAND3_AMT_Rs,[Q1 VF%][Q1 VF% / MSL Availability% / % Customers cross selling] ,[Q1 NPD%],KPI1_AMT KPI1_AMT_Rs,[E-CALL][E-CALL% / %of Active accounts],CME [CME / SAVR Score],IQVIA,KPI2_AMT KPI2_AMT_Rs,PCPM [POWER],[POWER] PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1, CALLAVG [CALLAVG/FWD],TARGET_VAL Q1_TGT,PRIMARY_VAL Q1_PRI_VAL,PRIMARY_AFTER_DEDUCTING_SALES_RETUEN Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,OVERALL_ACH Q1_ACH,SECONDARY_VAL,PriSecPr Q1_PRISEC_ACH,SnB,SnBPr,NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,FINALAMT PAYOUT_AMT_Rs FROM ( SELECT Q.*,R.Consistency_Q1 FROM ( SELECT O.*,P.CALLAVG,P.SR SALES_RETURN,P.TARGET_VAL,P.PRIMARY_VAL,P.PrAfterSR PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,P.ACH OVERALL_ACH,P.SECONDARY_VAL,P.PriSecPr,P.SnB,P.SnBPr,P.NXTMON_TGT,P.NXTMON_VAL,P.NXTMON_Pr,P.FINALAMT FROM ( SELECT M.*,N.DIQ PRORATAFACTOR FROM ( SELECT K.*,L.PCPM,L.[POWER],L.[LEVEL] FROM ( SELECT I.*,J.[E-CALL],J.CME,J.IQVIA,J.AMOUNT KPI2_AMT FROM ( SELECT G.*,H.[Q1 VF%],H.[Q1 NPD%],H.AMOUNT KPI1_AMT   FROM ( SELECT E.*,F.TARGET_VAL BRAND3_TGT,F.PRIMARY_VAL BRAND3_VAL,F.ACH BRAND3_ACH,F.AMOUNT BRAND3_AMT FROM ( SELECT C.*,D.TARGET_VAL BRAND2_TGT,D.PRIMARY_VAL BRAND2_VAL,D.ACH BRAND2_ACH,D.AMOUNT BRAND2_AMT FROM ( SELECT A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.EMP_ID,A.[EMP_NAME],A.[CLIENT_HQ],A.FS_Code,B.TARGET_VAL BRAND1_TGT,B.PRIMARY_VAL BRAND1_VAL,B.ACH BRAND1_ACH,B.AMOUNT BRAND1_AMT FROM [dbo].[EMPLOYEE_Incentive_TAB] A INNER JOIN [dbo].[EMPLOYEE_Incentive_Brand_1_TAB] B ON A.FS_Code=B.FS_Code) C INNER JOIN [EMPLOYEE_Incentive_Brand_2_TAB] D ON C.FS_Code=D.FS_Code ) E INNER JOIN [EMPLOYEE_Incentive_Brand_3_TAB] F ON E.FS_Code=F.FS_Code) G INNER JOIN [EMPLOYEE_Incentive_KPI1_TAB] H ON G.FS_Code=H.FS_Code ) I INNER JOIN [EMPLOYEE_Incentive_KPI2_TAB] J ON I.FS_Code=J.FS_Code) K INNER JOIN [EMPLOYEE_Incentive_PCPM_TAB] L ON K.FS_Code=L.FS_Code) M INNER JOIN [EMPLOYEE_Incentive_DIQ_TAB] N ON M.FS_Code=N.FS_Code ) O INNER JOIN [EMPLOYEE_Incentive_TAB] P ON O.FS_Code=P.FS_Code) Q INNER JOIN [EMPLOYEE_Incentive_Consistency_TAB] R on Q.FS_Code=R.FS_Code  WHERE R.SM='" + Session["FSCODE"] + "') S where ROW_ID !='1000000000' and DESIGNATION!='CET') FFFF) KW INNER JOIN (SELECT FS_CODE,ELIGIBLE,PAYOUT,REMARKS FROM EMPLOYEE_Incentive_ELIGIBLE_TAB) WK on KW.FS_CODE=WK.FS_CODE ) IW INNER JOIN Organogram$ WI on IW.FS_CODE=WI.FS_CODE) HGF order by HGF.ROW_ID  ;";

        }
        if (rbm == desgna || (rm == desgna && tea == "CX"))
        {
            StrQrry = "    SELECT ROW_ID,FS_CODE,DIVISION,TEAM,DESIGNATION,ZONE,EMP_ID,EMP_NAME,HQ,DOJ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT_Rs,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT_Rs,[Q1 VF% / MSL Availability% / % Customers cross selling],[Q1 NPD%],KPI1_AMT_Rs,[E-CALL% / %of Active accounts],[CME / SAVR Score],IQVIA [GROWTH in Rx as per IQVIA],KPI2_AMT_Rs,[POWER],PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1 [CONSISTENCY_Q1],[CALLAVG/FWD],Q1_TGT,Q1_PRI_VAL,Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,Q1_ACH,SECONDARY_VAL [Q1_SECONDARY_VAL],Q1_PRISEC_ACH,SnB [Q1_SNB_VAL],SnBPr [Q1_SNB_PR],NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,PAYOUT_AMT_Rs,ELIGIBLE,REMARKS,[FINAL_PAYOUT_Rs.] FROM (SELECT IW.*, WI.DOJ FROM ( SELECT KW.*, WK.ELIGIBLE,WK.REMARKS,WK.PAYOUT [FINAL_PAYOUT_Rs.] FROM (SELECT * FROM (SELECT distinct ROW_ID,FS_Code,DIVISION,[TEAM],DESIGNATION,[ZONE],EMP_ID,[EMP_NAME],[CLIENT_HQ] HQ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT BRAND1_AMT_Rs ,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT BRAND3_AMT_Rs,[Q1 VF%][Q1 VF% / MSL Availability% / % Customers cross selling] ,[Q1 NPD%],KPI1_AMT KPI1_AMT_Rs,[E-CALL][E-CALL% / %of Active accounts],CME [CME / SAVR Score],IQVIA,KPI2_AMT KPI2_AMT_Rs,PCPM [POWER],[POWER] PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1, CALLAVG [CALLAVG/FWD],TARGET_VAL Q1_TGT,PRIMARY_VAL Q1_PRI_VAL,PRIMARY_AFTER_DEDUCTING_SALES_RETUEN Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,OVERALL_ACH Q1_ACH,SECONDARY_VAL,PriSecPr Q1_PRISEC_ACH,SnB,SnBPr,NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,FINALAMT PAYOUT_AMT_Rs FROM ( SELECT Q.*,R.Consistency_Q1 FROM ( SELECT O.*,P.CALLAVG,P.SR SALES_RETURN,P.TARGET_VAL,P.PRIMARY_VAL,P.PrAfterSR PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,P.ACH OVERALL_ACH,P.SECONDARY_VAL,P.PriSecPr,P.SnB,P.SnBPr,P.NXTMON_TGT,P.NXTMON_VAL,P.NXTMON_Pr,P.FINALAMT FROM ( SELECT M.*,N.DIQ PRORATAFACTOR FROM ( SELECT K.*,L.PCPM,L.[POWER],L.[LEVEL] FROM ( SELECT I.*,J.[E-CALL],J.CME,J.IQVIA,J.AMOUNT KPI2_AMT FROM ( SELECT G.*,H.[Q1 VF%],H.[Q1 NPD%],H.AMOUNT KPI1_AMT   FROM ( SELECT E.*,F.TARGET_VAL BRAND3_TGT,F.PRIMARY_VAL BRAND3_VAL,F.ACH BRAND3_ACH,F.AMOUNT BRAND3_AMT FROM ( SELECT C.*,D.TARGET_VAL BRAND2_TGT,D.PRIMARY_VAL BRAND2_VAL,D.ACH BRAND2_ACH,D.AMOUNT BRAND2_AMT FROM ( SELECT A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.EMP_ID,A.[EMP_NAME],A.[CLIENT_HQ],A.FS_Code,B.TARGET_VAL BRAND1_TGT,B.PRIMARY_VAL BRAND1_VAL,B.ACH BRAND1_ACH,B.AMOUNT BRAND1_AMT FROM [dbo].[EMPLOYEE_Incentive_TAB] A INNER JOIN [dbo].[EMPLOYEE_Incentive_Brand_1_TAB] B ON A.FS_Code=B.FS_Code) C INNER JOIN [EMPLOYEE_Incentive_Brand_2_TAB] D ON C.FS_Code=D.FS_Code ) E INNER JOIN [EMPLOYEE_Incentive_Brand_3_TAB] F ON E.FS_Code=F.FS_Code) G INNER JOIN [EMPLOYEE_Incentive_KPI1_TAB] H ON G.FS_Code=H.FS_Code ) I INNER JOIN [EMPLOYEE_Incentive_KPI2_TAB] J ON I.FS_Code=J.FS_Code) K INNER JOIN [EMPLOYEE_Incentive_PCPM_TAB] L ON K.FS_Code=L.FS_Code) M INNER JOIN [EMPLOYEE_Incentive_DIQ_TAB] N ON M.FS_Code=N.FS_Code ) O INNER JOIN [EMPLOYEE_Incentive_TAB] P ON O.FS_Code=P.FS_Code) Q INNER JOIN [EMPLOYEE_Incentive_Consistency_TAB] R on Q.FS_Code=R.FS_Code  WHERE R.RBM='" + Session["FSCODE"] + "') S where ROW_ID !='1000000000' and DESIGNATION!='CET') FFFF) KW INNER JOIN (SELECT FS_CODE,ELIGIBLE,PAYOUT,REMARKS FROM EMPLOYEE_Incentive_ELIGIBLE_TAB) WK on KW.FS_CODE=WK.FS_CODE ) IW INNER JOIN Organogram$ WI on IW.FS_CODE=WI.FS_CODE) HGF order by HGF.ROW_ID  ;";

        }
        if (dsm == desgna || asm == desgna || (rm == desgna && tea == "AX") || nkam == desgna)
        {
            StrQrry = "    SELECT ROW_ID,FS_CODE,DIVISION,TEAM,DESIGNATION,ZONE,EMP_ID,EMP_NAME,HQ,DOJ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT_Rs,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT_Rs,[Q1 VF% / MSL Availability% / % Customers cross selling],[Q1 NPD%],KPI1_AMT_Rs,[E-CALL% / %of Active accounts],[CME / SAVR Score],IQVIA [GROWTH in Rx as per IQVIA],KPI2_AMT_Rs,[POWER],PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1 [CONSISTENCY_Q1],[CALLAVG/FWD],Q1_TGT,Q1_PRI_VAL,Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,Q1_ACH,SECONDARY_VAL [Q1_SECONDARY_VAL],Q1_PRISEC_ACH,SnB [Q1_SNB_VAL],SnBPr [Q1_SNB_PR],NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,PAYOUT_AMT_Rs,ELIGIBLE,REMARKS,[FINAL_PAYOUT_Rs.] FROM (SELECT IW.*, WI.DOJ FROM ( SELECT KW.*, WK.ELIGIBLE,WK.REMARKS,WK.PAYOUT [FINAL_PAYOUT_Rs.] FROM (SELECT * FROM (SELECT distinct ROW_ID,FS_Code,DIVISION,[TEAM],DESIGNATION,[ZONE],EMP_ID,[EMP_NAME],[CLIENT_HQ] HQ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT BRAND1_AMT_Rs ,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT BRAND3_AMT_Rs,[Q1 VF%][Q1 VF% / MSL Availability% / % Customers cross selling] ,[Q1 NPD%],KPI1_AMT KPI1_AMT_Rs,[E-CALL][E-CALL% / %of Active accounts],CME [CME / SAVR Score],IQVIA,KPI2_AMT KPI2_AMT_Rs,PCPM [POWER],[POWER] PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q1, CALLAVG [CALLAVG/FWD],TARGET_VAL Q1_TGT,PRIMARY_VAL Q1_PRI_VAL,PRIMARY_AFTER_DEDUCTING_SALES_RETUEN Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,OVERALL_ACH Q1_ACH,SECONDARY_VAL,PriSecPr Q1_PRISEC_ACH,SnB,SnBPr,NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,FINALAMT PAYOUT_AMT_Rs FROM ( SELECT Q.*,R.Consistency_Q1 FROM ( SELECT O.*,P.CALLAVG,P.SR SALES_RETURN,P.TARGET_VAL,P.PRIMARY_VAL,P.PrAfterSR PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,P.ACH OVERALL_ACH,P.SECONDARY_VAL,P.PriSecPr,P.SnB,P.SnBPr,P.NXTMON_TGT,P.NXTMON_VAL,P.NXTMON_Pr,P.FINALAMT FROM ( SELECT M.*,N.DIQ PRORATAFACTOR FROM ( SELECT K.*,L.PCPM,L.[POWER],L.[LEVEL] FROM ( SELECT I.*,J.[E-CALL],J.CME,J.IQVIA,J.AMOUNT KPI2_AMT FROM ( SELECT G.*,H.[Q1 VF%],H.[Q1 NPD%],H.AMOUNT KPI1_AMT   FROM ( SELECT E.*,F.TARGET_VAL BRAND3_TGT,F.PRIMARY_VAL BRAND3_VAL,F.ACH BRAND3_ACH,F.AMOUNT BRAND3_AMT FROM ( SELECT C.*,D.TARGET_VAL BRAND2_TGT,D.PRIMARY_VAL BRAND2_VAL,D.ACH BRAND2_ACH,D.AMOUNT BRAND2_AMT FROM ( SELECT A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.EMP_ID,A.[EMP_NAME],A.[CLIENT_HQ],A.FS_Code,B.TARGET_VAL BRAND1_TGT,B.PRIMARY_VAL BRAND1_VAL,B.ACH BRAND1_ACH,B.AMOUNT BRAND1_AMT FROM [dbo].[EMPLOYEE_Incentive_TAB] A INNER JOIN [dbo].[EMPLOYEE_Incentive_Brand_1_TAB] B ON A.FS_Code=B.FS_Code) C INNER JOIN [EMPLOYEE_Incentive_Brand_2_TAB] D ON C.FS_Code=D.FS_Code ) E INNER JOIN [EMPLOYEE_Incentive_Brand_3_TAB] F ON E.FS_Code=F.FS_Code) G INNER JOIN [EMPLOYEE_Incentive_KPI1_TAB] H ON G.FS_Code=H.FS_Code ) I INNER JOIN [EMPLOYEE_Incentive_KPI2_TAB] J ON I.FS_Code=J.FS_Code) K INNER JOIN [EMPLOYEE_Incentive_PCPM_TAB] L ON K.FS_Code=L.FS_Code) M INNER JOIN [EMPLOYEE_Incentive_DIQ_TAB] N ON M.FS_Code=N.FS_Code ) O INNER JOIN [EMPLOYEE_Incentive_TAB] P ON O.FS_Code=P.FS_Code) Q INNER JOIN [EMPLOYEE_Incentive_Consistency_TAB] R on Q.FS_Code=R.FS_Code  WHERE R.DSM='" + Session["FSCODE"] + "') S where ROW_ID !='1000000000' and DESIGNATION!='CET') FFFF) KW INNER JOIN (SELECT FS_CODE,ELIGIBLE,PAYOUT,REMARKS FROM EMPLOYEE_Incentive_ELIGIBLE_TAB) WK on KW.FS_CODE=WK.FS_CODE ) IW INNER JOIN Organogram$ WI on IW.FS_CODE=WI.FS_CODE) HGF order by HGF.ROW_ID  ;";

        }
        if (tbe == desgna || tbm == desgna || tso == desgna || kam == desgna || kae == desgna)
        {
            StrQrry = "  SELECT  A.DESIGNATION,A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.FS_Code='" + Session["FSCODE"] + "' order by A.ROW_ID ;";

        }
        if (admin == desgna)
        {
            StrQrry = "  SELECT ROW_ID,FS_CODE,DIVISION,TEAM,DESIGNATION,ZONE,EMP_ID,EMP_NAME,HQ,DOJ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT_Rs,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT_Rs,[Q1 VF% / MSL Availability% / % Customers cross selling][QTR VF% / MSL Availability% / % Customers cross selling],[PHARMACY %],[Q1 NPD%][QTR NPD%],KPI1_AMT_Rs,[E-CALL% / %of Active accounts][QTR E-CALL% / %of Active accounts],[CME / SAVR Score][QTR CME / SAVR Score],IQVIA [QTR GROWTH in Rx as per IQVIA],KPI2_AMT_Rs,[POWER],PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q2 [QTR CONSISTENCY],[CALLAVG/FWD],Q1_TGT [QTR_TGT],Q1_PRI_VAL [QTR_PRI_VAL],Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN [QTR_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN],Q1_ACH [QTR_ACH],SECONDARY_VAL [QTR_SECONDARY_VAL],Q1_PRISEC_ACH [QTR_PRISEC_ACH],SnB [QTR_SNB_VAL],SnBPr [QTR_SNB_PR],NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,PAYOUT_AMT_Rs,ELIGIBLE,REMARKS,[FINAL_PAYOUT_Rs.] FROM (SELECT IW.*, WI.DOJ FROM ( SELECT KW.*, WK.ELIGIBLE,WK.REMARKS,WK.PAYOUT [FINAL_PAYOUT_Rs.] FROM (SELECT * FROM (SELECT distinct ROW_ID,FS_Code,DIVISION,[TEAM],DESIGNATION,[ZONE],EMP_ID,[EMP_NAME],[CLIENT_HQ] HQ,BRAND1_TGT,BRAND1_VAL,BRAND1_ACH,BRAND1_AMT BRAND1_AMT_Rs ,BRAND2_TGT,BRAND2_VAL,BRAND2_ACH,BRAND2_AMT BRAND2_AMT_Rs,BRAND3_TGT,BRAND3_VAL,BRAND3_ACH,BRAND3_AMT BRAND3_AMT_Rs,[Q1 VF%][Q1 VF% / MSL Availability% / % Customers cross selling] ,[Q1 Expiry%][PHARMACY %],[Q1 NPD%],KPI1_AMT KPI1_AMT_Rs,[E-CALL][E-CALL% / %of Active accounts],CME [CME / SAVR Score],IQVIA,KPI2_AMT KPI2_AMT_Rs,PCPM [POWER],[POWER] PCPM,[LEVEL],PRORATAFACTOR,Consistency_Q2, CALLAVG [CALLAVG/FWD],TARGET_VAL Q1_TGT,PRIMARY_VAL Q1_PRI_VAL,PRIMARY_AFTER_DEDUCTING_SALES_RETUEN Q1_PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,OVERALL_ACH Q1_ACH,SECONDARY_VAL,PriSecPr Q1_PRISEC_ACH,SnB,SnBPr,NXTMON_TGT,NXTMON_VAL,NXTMON_Pr,FINALAMT PAYOUT_AMT_Rs FROM ( SELECT Q.*,R.Consistency_Q2 FROM ( SELECT O.*,P.CALLAVG,P.SR SALES_RETURN,P.TARGET_VAL,P.PRIMARY_VAL,P.PrAfterSR PRIMARY_AFTER_DEDUCTING_SALES_RETUEN,P.ACH OVERALL_ACH,P.SECONDARY_VAL,P.PriSecPr,P.SnB,P.SnBPr,P.NXTMON_TGT,P.NXTMON_VAL,P.NXTMON_Pr,P.FINALAMT FROM ( SELECT M.*,N.DIQ PRORATAFACTOR FROM ( SELECT K.*,L.PCPM,L.[POWER],L.[LEVEL] FROM ( SELECT I.*,J.[E-CALL],J.CME,J.IQVIA,J.AMOUNT KPI2_AMT FROM ( SELECT G.*,H.[Q1 VF%],H.[Q1 Expiry%],H.[Q1 NPD%],H.AMOUNT KPI1_AMT   FROM ( SELECT E.*,F.TARGET_VAL BRAND3_TGT,F.PRIMARY_VAL BRAND3_VAL,F.ACH BRAND3_ACH,F.AMOUNT BRAND3_AMT FROM ( SELECT C.*,D.TARGET_VAL BRAND2_TGT,D.PRIMARY_VAL BRAND2_VAL,D.ACH BRAND2_ACH,D.AMOUNT BRAND2_AMT FROM ( SELECT A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.EMP_ID,A.[EMP_NAME],A.[CLIENT_HQ],A.FS_Code,B.TARGET_VAL BRAND1_TGT,B.PRIMARY_VAL BRAND1_VAL,B.ACH BRAND1_ACH,B.AMOUNT BRAND1_AMT FROM [dbo].[EMPLOYEE_Incentive_TAB] A INNER JOIN [dbo].[EMPLOYEE_Incentive_Brand_1_TAB] B ON A.FS_Code=B.FS_Code) C INNER JOIN [EMPLOYEE_Incentive_Brand_2_TAB] D ON C.FS_Code=D.FS_Code ) E INNER JOIN [EMPLOYEE_Incentive_Brand_3_TAB] F ON E.FS_Code=F.FS_Code) G INNER JOIN [EMPLOYEE_Incentive_KPI1_TAB] H ON G.FS_Code=H.FS_Code ) I INNER JOIN [EMPLOYEE_Incentive_KPI2_TAB] J ON I.FS_Code=J.FS_Code) K INNER JOIN [EMPLOYEE_Incentive_PCPM_TAB] L ON K.FS_Code=L.FS_Code) M INNER JOIN [EMPLOYEE_Incentive_DIQ_TAB] N ON M.FS_Code=N.FS_Code ) O INNER JOIN [EMPLOYEE_Incentive_TAB] P ON O.FS_Code=P.FS_Code) Q INNER JOIN [EMPLOYEE_Incentive_Consistency_TAB] R on Q.FS_Code=R.FS_Code ) S where ROW_ID !='1000000000' and DESIGNATION!='CET') FFFF) KW INNER JOIN (SELECT FS_CODE,ELIGIBLE,PAYOUT,REMARKS FROM EMPLOYEE_Incentive_ELIGIBLE_TAB) WK on KW.FS_CODE=WK.FS_CODE ) IW INNER JOIN Organogram$ WI on IW.FS_CODE=WI.FS_CODE) HGF order by HGF.ROW_ID  ;";

        }
        string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
        adpRpt.Fill(DsStockist, "DsStockist");
        adpRpt.Fill(dtDsStockist);
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "QUALIFIERS " + Session["FSCODE"] + "_" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-Disposition", "inline;  filename=" + FileName);
        DataGrid dg = new DataGrid();
        dg.DataSource = dtDsStockist;
        dg.DataBind();
        foreach (DataGridItem item in dg.Items)
        {
            for (int j = 0; j < item.Cells.Count; j++)
            {
                item.Cells[12].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[13].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[16].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[17].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[20].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[21].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[22].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[23].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[24].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[25].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[26].Attributes.Add("style", "mso-number-format:'0.00%'");
              //  item.Cells[27].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[28].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[29].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[34].Attributes.Add("style", "mso-number-format:'0,00,000'");
                item.Cells[39].Attributes.Add("style", "mso-number-format:'0.00%'");
              //  item.Cells[34].Attributes.Add("style", "mso-number-format:'0.00'");    
                item.Cells[41].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[43].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[46].Attributes.Add("style", "mso-number-format:'0.00%'");
                item.Cells[47].Attributes.Add("style", "mso-number-format:'#,##,###'");
                //item.Cells[49].Attributes.Add("style", "mso-number-format:'#,##,###'");
                item.Cells[50].Attributes.Add("style", "mso-number-format:'#,##,###'");
            }

        }
        dg.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        dg.Dispose();
        dtDsStockist.Dispose();
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void Organo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sm = "SM";
            string rbm = "RBM";
            string dsm = "DSM";
            if (e.Row.Cells[3].Text == sm)
            {
                e.Row.Font.Bold = true;
                e.Row.BackColor = Color.DarkCyan;
                e.Row.ForeColor = Color.Black;
            }
            if (e.Row.Cells[3].Text == rbm || (rm == e.Row.Cells[3].Text) || nkam == e.Row.Cells[3].Text)
            {

                e.Row.BackColor = Color.LightSeaGreen;
                e.Row.ForeColor = Color.Black;
            }
            if (e.Row.Cells[3].Text == dsm || asm == e.Row.Cells[3].Text)
            {

                e.Row.BackColor = Color.MediumTurquoise;
                e.Row.ForeColor = Color.Black;
            }
            string FSCODE = e.Row.Cells[5].Text;
            string TEAM = e.Row.Cells[2].Text;
            string DIV = e.Row.Cells[1].Text;
            if (DIV == "AX" && (e.Row.Cells[7].Text == "AX CC MUMBAI" || e.Row.Cells[7].Text == "AX CC BANGALORE" || e.Row.Cells[7].Text == "AX CC DELHI 1" || e.Row.Cells[7].Text == "AX CC DELHI 2"))
            {
                DIV = e.Row.Cells[7].Text;
                DIV = DIV.Substring(3, 2);
            }
            string NAME = e.Row.Cells[6].Text;
            string Designation = e.Row.Cells[3].Text;
            if (e.Row.Cells[19].Text == "Re-Evaluate")
            {
                e.Row.BackColor = Color.LightGray;
                e.Row.Cells[19].Font.Bold = true;
                e.Row.Cells[19].BackColor = Color.DarkGray;
                DropDownList chckhrw = (DropDownList)e.Row.FindControl("ddlapproval");
                    TextBox textBox = (TextBox)e.Row.FindControl("txtreason");
                    textBox.Enabled = false;
                    chckhrw.Enabled = false;
            }
            
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string con1n = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            if (Designation != "Admin")
            {
            using (SqlConnection conn = new SqlConnection(con1n))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[FINALGRID$] where DESIGNATION = '" + Designation + "' and Division ='" + DIV + "' ;", conn);
                conn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                var logintbl = new DataTable();
                logintbl.Load(read);
                string ACH = e.Row.Cells[10].Text;
                ACH = ACH.Replace("&nbsp;", "0").Replace("%", "0");
                decimal ACHIVEVEEMNT = Convert.ToDecimal(ACH);
                ACHIVEVEEMNT = ACHIVEVEEMNT / 100;
                string SnBpr = e.Row.Cells[12].Text;
                SnBpr = SnBpr.Replace("&nbsp;", "0");
                decimal SnB = Convert.ToDecimal(SnBpr);
                string PriSecpr = e.Row.Cells[13].Text;
                PriSecpr = PriSecpr.Replace("&nbsp;", "0");
                decimal PriSec = Convert.ToDecimal(PriSecpr);
                string NxtMonpr = e.Row.Cells[14].Text;
                NxtMonpr = NxtMonpr.Replace("&nbsp;", "0").Replace("%", "0"); 
                decimal NxtMon = Convert.ToDecimal(NxtMonpr);
                NxtMon = NxtMon / 100;
                string CALLAVGG = e.Row.Cells[11].Text;
                CALLAVGG = CALLAVGG.Replace("&nbsp;", "0");
                decimal CALLAVGG1 = Convert.ToDecimal(CALLAVGG);
                // Double AMOUNT = Convert.ToDouble(logintbl.Rows[0][1].ToString());
                // string AMT = logintbl.Rows[0][4].ToString();
                // AMT = ACH.Replace("&nbsp;", "0");
                //decimal AMOUNT = Convert.ToDecimal(AMT); 
                //X     double ACHH = x
                //logintbl.Rows[0][1].ToString())

                string SnBQ = logintbl.Rows[0][3].ToString();
                decimal dataTableValue1 = Convert.ToDecimal(SnBQ);
                string PriQ = logintbl.Rows[0][2].ToString();
                decimal dataTableValue2 = Convert.ToDecimal(PriQ);
                string NXTMQ = logintbl.Rows[0][4].ToString();
                decimal dataTableValue3 = Convert.ToDecimal(NXTMQ);
                string CALLAVG = logintbl.Rows[0][5].ToString();
                decimal dataTableValue4 = Convert.ToDecimal(CALLAVG);
                decimal dataTableValue;
                if (decimal.TryParse(logintbl.Rows[0][1].ToString(), out dataTableValue))
                {
                    
                    // Comparison
                    if (ACHIVEVEEMNT >= dataTableValue && PriSec >= dataTableValue2 && NxtMon >= dataTableValue3 && SnB <= dataTableValue1 && CALLAVGG1 >= dataTableValue4)
                     {
                        using (SqlConnection conn1 = new SqlConnection(con1n))
                        {
                            SqlCommand cmd1 = new SqlCommand("SELECT A.FS_Code,B.FINALAMT FROM [EMPLOYEE_Incentive_TAB] A INNER JOIN [EMPLOYEE_Incentive_FINAL_TAB] B ON A.FS_Code=B.FS_Code where A.[EMP_NAME]='" + NAME + "' ", conn1);
                            conn1.Open();
                            SqlDataReader read1 = cmd1.ExecuteReader();
                            var logintbl1 = new DataTable();
                            logintbl1.Load(read1);
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = logintbl1.Rows[0][1].ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_Qualifier]", conn);
                            {

                                //string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                            // INCENTSP = Incent1.Text;
                        }
                    }

                    else
                    {
                        SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_Qualifier]", conn);
                        {
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = "0";
                            string INCENTSP = Incent1.Text;
                            //string FSCODE = e.Row.Cells[5].Text;
                            cmmd.CommandType = CommandType.StoredProcedure;
                            cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                            cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                            // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                            //cmd.ExecuteNonQuery();
                            string strRsslt = cmmd.ExecuteNonQuery().ToString();

                        }
                    }

                }
                else
                {
                    // Handle the case where the value in the DataTable cannot be parsed to double
                    // You might want to throw an exception or handle it according to your application's logic
                }
                double percentageValue;

                // Attempt to parse the text value to a double
                if (double.TryParse(e.Row.Cells[12].Text, out percentageValue))
                {
                    double snb = Convert.ToDouble(dataTableValue1.ToString());

                    if (percentageValue > snb)
                    {
                        string formattedPercentage = percentageValue.ToString("P");
                        e.Row.Cells[12].Text = formattedPercentage;
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[12].Font.Bold = false;
                    }
                    else
                    {
                        string formattedPercentage = percentageValue.ToString("P");
                        e.Row.Cells[12].Text = formattedPercentage;
                    }
                }
                else
                {
                    // Parsing failed, handle the case where the text cannot be parsed as a double
                    // You can log an error, show a message to the user, or take other appropriate action.
                }
                double percentageValue1;

                if (double.TryParse(e.Row.Cells[11].Text, out percentageValue1))
                {
                    double callavg = Convert.ToDouble(dataTableValue4.ToString());
                    if (percentageValue1 < callavg)
                    {
                        string formattedPercentage1 = percentageValue1.ToString("0.00");
                        e.Row.Cells[11].Text = formattedPercentage1;
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[11].Font.Bold = false;
                    }
                    else
                    {
                        string formattedPercentage1 = percentageValue1.ToString("0.00");
                        e.Row.Cells[11].Text = formattedPercentage1;
                    }
                }
                else
                {
                    // Parsing failed, handle the case where the text cannot be parsed as a double
                    // You can log an error, show a message to the user, or take other appropriate action.
                }
                double percentageValue2;
                double ach = Convert.ToDouble(dataTableValue.ToString());
                if (double.TryParse(e.Row.Cells[10].Text, out percentageValue2))
                {
                    if (percentageValue2 < ach)
                    {
                        string formattedPercentage2 = percentageValue2.ToString("P");
                        e.Row.Cells[10].Text = formattedPercentage2;
                        e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[10].Font.Bold = false;
                    }
                    else
                    {
                        string formattedPercentage2 = percentageValue2.ToString("P");
                        e.Row.Cells[10].Text = formattedPercentage2;
                    }
                }
                else
                {
                    // Parsing failed, handle the case where the text cannot be parsed as a double
                    // You can log an error, show a message to the user, or take other appropriate action.
                }
                double percentageValue3;

                if (double.TryParse(e.Row.Cells[13].Text, out percentageValue3))
                {
                    double prisec = Convert.ToDouble(dataTableValue2.ToString());
                    if (percentageValue3 < prisec)
                    {
                        ///percentageValue3 = percentageValue3 / 100;
                        string formattedPercentage3 = percentageValue3.ToString("P");
                        e.Row.Cells[13].Text = formattedPercentage3;
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[13].Font.Bold = false;
                    }
                    else
                    {
                       // percentageValue3 = percentageValue3 / 100;
                        string formattedPercentage3 = percentageValue3.ToString("P");
                        e.Row.Cells[13].Text = formattedPercentage3;
                    }
                }
                else
                {
                    // Parsing failed, handle the case where the text cannot be parsed as a double
                    // You can log an error, show a message to the user, or take other appropriate action.
                }
                double percentageValue4;
                if (double.TryParse(e.Row.Cells[14].Text, out percentageValue4))
                {
                    double nxtmon = Convert.ToDouble(dataTableValue3.ToString());
                    if (percentageValue4 < nxtmon)
                    {
                       // percentageValue4 = percentageValue4 ;
                        string formattedPercentage4 = percentageValue4.ToString("P");
                        e.Row.Cells[14].Text = formattedPercentage4;
                        e.Row.Cells[14].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[14].Font.Bold = false;
                    }
                    else
                    {
                       // percentageValue4 = percentageValue4 / 100;
                        string formattedPercentage4 = percentageValue4.ToString("P");
                        e.Row.Cells[14].Text = formattedPercentage4;
                    }
                }
                else
                {
                    // Parsing failed, handle the case where the text cannot be parsed as a double
                    // You can log an error, show a message to the user, or take other appropriate action.
                }

                
            }}
            {
                DropDownList DropDownList1 = (e.Row.FindControl("ddlapproval") as DropDownList);
                using (SqlConnection conn22 = new SqlConnection(con1n))
                {
                    conn22.Open();
                    SqlCommand cmd = new SqlCommand("Select * from [APPROVAL_TAB];", conn22);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn22.Close();
                    DropDownList1.DataSource = dt;

                    DropDownList1.DataTextField = "Approval_matrix";
                    DropDownList1.DataValueField = "Approval_matrix";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("APPROVED", "0"));
                }
                using (SqlConnection conn22 = new SqlConnection(con1n))
                {
                    conn22.Open();
                    DropDownList DropDownList2 = (e.Row.FindControl("ddlaudit") as DropDownList);
                    SqlCommand cmd1 = new SqlCommand("Select * from [AUDITOR_TAB];", conn22);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    conn22.Close();
                    DropDownList2.DataSource = dt1;

                    DropDownList2.DataTextField = "Approval_matrix";
                    DropDownList2.DataValueField = "Approval_matrix";
                    DropDownList2.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem("NOT CHECKED", "0"));
                }
            }
           
        }
        }

    protected void ddlparameters1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;

        ddlvalrep = ddlparameters1.SelectedValue.ToString();
        if (ddlvalrep == "Brnd1")
        {
            Response.Redirect("BRAND1.aspx");
        }
        if (ddlvalrep == "Brnd2")
        {
            Response.Redirect("BRAND2.aspx");
        }
        if (ddlvalrep == "Brnd3")
        {
            Response.Redirect("BRAND3.aspx");
        }
        Session["ddlsesrep"] = ddlvalrep;

    }
    protected void ddlparameters2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;

        ddlvalrep = ddlparameters2.SelectedValue.ToString();
        if (ddlvalrep == "K1")
        {
            Response.Redirect("KPI1.aspx");
        }
        if (ddlvalrep == "K2")
        {
            Response.Redirect("KPI2.aspx");
        }
        Session["ddlsesrep"] = ddlvalrep;
    }
    protected void ddlparameters3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;

        ddlvalrep = ddlparameters3.SelectedValue.ToString();
        if (ddlvalrep == "cnstncy")
        {
            Response.Redirect("Consistency.aspx");
        }
        Session["ddlsesrep"] = ddlvalrep;
    }
    protected void ddlmultiplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;

        ddlvalrep = ddlmultiplier.SelectedValue.ToString();
        if (ddlvalrep == "pcpm")
        {
            Response.Redirect("PCPM.aspx");
        }
        if (ddlvalrep == "pfactor")
        {
            Response.Redirect("Proratafactor.aspx");
        }
        Session["ddlsesrep"] = ddlvalrep;
    }
    protected void ddlqualifiers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlvalrep = string.Empty;

        ddlvalrep = ddlqualifiers.SelectedValue.ToString();
        if (ddlvalrep == "ovrall")
        {
            Response.Redirect("OVERALLACH.aspx");
        }
        if (ddlvalrep == "prisec")
        {
            Response.Redirect("PRISEC.aspx");
        }
        if (ddlvalrep == "snb")
        {
            Response.Redirect("SnB.aspx");
        }
        if (ddlvalrep == "nxtmon")
        {
            Response.Redirect("NXTMON.aspx");
        }
        if (ddlvalrep == "callavg")
        {
            Response.Redirect("CallAvg.aspx");
        }
        Session["ddlsesrep"] = ddlvalrep;
    }
    protected void btnQuailifiers(object sender, EventArgs e)
    {
        Response.Redirect("Quailifiers.aspx");
    }
    protected void btnFINAL(object sender, EventArgs e)
    {
        Response.Redirect("FINALBOARD.aspx");
    }
    protected void btnLOGOUT(object sender, EventArgs e)
    {
        Response.Redirect("IncentLOGIN.aspx");
    }

    protected void btnEMP(object sender, EventArgs e)
    {
        Response.Redirect("Employee.aspx");
    }
    protected void btnsimi(object sender, EventArgs e)
    {
        Response.Redirect("SimulatorACH.aspx");
    }

   
    protected void ddldesg_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddldesgvalue = string.Empty;
        ddldesgvalue = ddldesg.SelectedValue.ToString();
        Session["ddldesgvalue"] = ddldesgvalue;
     //   //Lblwh.Text = //Lblwh.Text + "Showing calculation for <span style= 'color:Red;'>" + ddldesgvalue + "</span> division ";
        //  Lblwh.ForeColor = System.Drawing.Color.Red;

        //BindGrid2();
    }
    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlzonevalue = string.Empty;
        ddlzonevalue = ddlzone.SelectedValue.ToString();
        Session["ddlzonevalue"] = ddlzonevalue;
     //   //Lblwh.Text = //Lblwh.Text + ", <span style= 'color:Red;'>" + ddlzonevalue + "</span> zone ";
        // BindGrid2();
    }
    protected void ddlbu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlbuvalue = string.Empty;
        ddlbuvalue = ddlbu.SelectedValue.ToString();
        Session["ddlbuvalue"] = ddlbuvalue;
     //   //Lblwh.Text = //Lblwh.Text + "Showing calculation for <span style= 'color:Red;'>" + ddlbuvalue + "</span> division ";
        //  Lblwh.ForeColor = System.Drawing.Color.Red;

        //BindGrid2();
    }

    protected void ddlteam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlteamvalue = string.Empty;
        ddlteamvalue = ddlteam.SelectedValue.ToString();
        Session["ddlteamvalue"] = ddlteamvalue;
      //  //Lblwh.Text = //Lblwh.Text + ", <span style= 'color:Red;'>" + ddlteamvalue + "</span> Team ";
        //  Lblwh.ForeColor = System.Drawing.Color.Red;

        //  BindGrid2();
    }

    public void binddropdown1()
    {
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [ZONE] from [Organogram$] where SM='" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlzone.DataSource = dtDsStockist;
                ddlzone.DataTextField = "ZONE";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (rbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [ZONE] from [Organogram$] where RBM='" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlzone.DataSource = dtDsStockist;
                ddlzone.DataTextField = "ZONE";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (dsm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [ZONE] from [Organogram$] where DSM='" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlzone.DataSource = dtDsStockist;
                ddlzone.DataTextField = "ZONE";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (tbe == desgna || tbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [ZONE] from [Organogram$] where FS_Code='" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlzone.DataSource = dtDsStockist;
                ddlzone.DataTextField = "ZONE";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (Admin == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [ZONE] from [Organogram$]";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlzone.DataSource = dtDsStockist;
                ddlzone.DataTextField = "ZONE";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }



    }
    public void binddropdown2()
    {
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [BU] from [Organogram$] where SM = '" + Session["FSCODE"] + "'";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlbu.DataSource = dtDsStockist;
                ddlbu.DataTextField = "BU";
                ddlbu.DataBind();
                ddlbu.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (rbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [BU] from [Organogram$] where RBM = '" + Session["FSCODE"] + "'";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlbu.DataSource = dtDsStockist;
                ddlbu.DataTextField = "BU";
                ddlbu.DataBind();
                ddlbu.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (dsm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [BU] from [Organogram$] where DSM = '" + Session["FSCODE"] + "'";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlbu.DataSource = dtDsStockist;
                ddlbu.DataTextField = "BU";
                ddlbu.DataBind();
                ddlbu.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (tbe == desgna || tbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [BU] from [Organogram$] where FS_Code = '" + Session["FSCODE"] + "'";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlbu.DataSource = dtDsStockist;
                ddlbu.DataTextField = "BU";
                ddlbu.DataBind();
                ddlbu.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (Admin == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [BU] from [Organogram$]";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlbu.DataSource = dtDsStockist;
                ddlbu.DataTextField = "BU";
                ddlbu.DataBind();
                ddlbu.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }


    }
    public void binddropdown3()
    {
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Team] from [Organogram$] where SM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlteam.DataSource = dtDsStockist;
                ddlteam.DataTextField = "TEAM";
                ddlteam.DataBind();
                ddlteam.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (rbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Team] from [Organogram$] where RBM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlteam.DataSource = dtDsStockist;
                ddlteam.DataTextField = "TEAM";
                ddlteam.DataBind();
                ddlteam.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (dsm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Team] from [Organogram$] where DSM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlteam.DataSource = dtDsStockist;
                ddlteam.DataTextField = "TEAM";
                ddlteam.DataBind();
                ddlteam.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (tbe == desgna || tbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Team] from [Organogram$] where FS_Code = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlteam.DataSource = dtDsStockist;
                ddlteam.DataTextField = "TEAM";
                ddlteam.DataBind();
                ddlteam.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (Admin == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Team] from [Organogram$] ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddlteam.DataSource = dtDsStockist;
                ddlteam.DataTextField = "TEAM";
                ddlteam.DataBind();
                ddlteam.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
    }
    public void binddropdown4()
    {
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Design] from [Organogram$]  where SM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddldesg.DataSource = dtDsStockist;
                ddldesg.DataTextField = "Design";
                ddldesg.DataBind();
                ddldesg.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (rbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Design] from [Organogram$]  where RBM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddldesg.DataSource = dtDsStockist;
                ddldesg.DataTextField = "Design";
                ddldesg.DataBind();
                ddldesg.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (dsm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Design] from [Organogram$]  where DSM = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddldesg.DataSource = dtDsStockist;
                ddldesg.DataTextField = "Design";
                ddldesg.DataBind();
                ddldesg.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }
        }
        if (tbe == desgna || tbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Design] from [Organogram$]  where FS_Code = '" + Session["FSCODE"] + "' ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddldesg.DataSource = dtDsStockist;
                ddldesg.DataTextField = "Design";
                ddldesg.DataBind();
                ddldesg.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }

        }
        if (Admin == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "Select distinct [Design] from [Organogram$] ";

            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                ddldesg.DataSource = dtDsStockist;
                ddldesg.DataTextField = "Design";
                ddldesg.DataBind();
                ddldesg.Items.Insert(0, "Select");
                //ddlempname.SelectedIndex = 0;
            }

        }

    }   
    protected void onclicksubmit(object sender, EventArgs e)
    {
        var checkedbox = 0;
        var count = 0;
        foreach (GridViewRow row in Organo.Rows)
        {
            count++;
            DropDownList chckhrw = (DropDownList)row.FindControl("ddlapproval");
            if (chckhrw.SelectedValue == "NOT APPROVED")
            {
                checkedbox++;
                string desig = row.Cells[3].Text;
                string name = row.Cells[6].Text;
                string HQ = row.Cells[7].Text;
                string finalamt = "Re-Evaluate";
                DropDownList ddlapproval = (DropDownList)row.FindControl("ddlapproval");
                string ddlunb = ddlapproval.SelectedValue;

                TextBox txtreasn = (TextBox)row.FindControl("txtreason");
                string txtrsn = txtreasn.Text;
                SqlCommand cmd1 = new SqlCommand("APPROVAL_SP", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@DESIGNATION", desig);
                cmd1.Parameters.AddWithValue("@NAME", name);
                cmd1.Parameters.AddWithValue("@HQ", HQ);
                cmd1.Parameters.AddWithValue("@FINAL_PAYOUT", finalamt);
                cmd1.Parameters.AddWithValue("@Approval", ddlunb);
                cmd1.Parameters.AddWithValue("@Remarks", txtrsn);
                conn.Open();
                // cmd1.ExecuteNonQuery();
                string strRslt = cmd1.ExecuteNonQuery().ToString();
                conn.Close();
                txtreasn.Enabled = false;
                chckhrw.Enabled = false;
            }
            
        }
    }
  
    protected void refersh_Click(object sender, EventArgs e)
    {
        string sm = "SM";
        string rbm = "RBM";
        string dsm = "DSM";
        string tbe = "TBE";
        string tbm = "TBM";
        string admin = "Admin";
        string desgna = Session["DESG"].ToString();

        string whreclase = " ";
        whreclase = "AND ";
        if (Session["ddlbuvalue"] != null)
        {
            whreclase += "A.[DIVISION] = '" + Session["ddlbuvalue"].ToString() + "' and ";
        }
        if (Session["ddlzonevalue"] != null)
        {
            whreclase += "A.[ZONE] = '" + Session["ddlzonevalue"].ToString() + "' and ";

        }
        if (Session["ddlteamvalue"] != null)
        {
            whreclase += "A.[TEAM] = '" + Session["ddlteamvalue"].ToString() + "' and ";
        }
        if (Session["ddldesgvalue"] != null)
        {
            whreclase += "A.[DESIGNATION] = '" + Session["ddldesgvalue"].ToString() + "' and ";
        }
        whreclase = whreclase.Substring(0, whreclase.Length - 4);
        //whreclase = whreclase;


        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "'  " + whreclase + "and (A.DESIGNATION = 'RBM' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "' " + whreclase + " and (A.DESIGNATION = 'RBM'  )) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID";
          //  StrQrry = "	  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE  FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON A.FS_Code=B.FS_Code where A.SM='" + Session["FSCODE"] + "' " + whreclase + " and A.DESIGNATION = 'RBM' ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID  ; ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (rbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.RBM='" + Session["FSCODE"] + "' " + whreclase + " and (A.DESIGNATION = 'DSM' or A.DESIGNATION = 'ASM' or  A.DESIGNATION = 'KAE-MT' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN [EMPLOYEE_Incentive_ELIGIBLE_TAB] B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' " + whreclase + " and (A.DESIGNATION = 'DSM' or A.DESIGNATION = 'ASM' or  A.DESIGNATION = 'KAE-MT' )) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID";
         //   StrQrry = "	SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.RBM='" + Session["FSCODE"] + "' " + whreclase + " and A.DESIGNATION = 'DSM') NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID  ;  ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (dsm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' " + whreclase + "  and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM' or A.DESIGNATION = 'KAM' or A.DESIGNATION = 'TSO' ) ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' " + whreclase + "  and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM' or A.DESIGNATION = 'KAM' or A.DESIGNATION = 'TSO' ) ) NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
           // StrQrry = "	SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.DSM='" + Session["FSCODE"] + "' " + whreclase + " and (A.DESIGNATION = 'TBE' or A.DESIGNATION = 'TBM')) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID  ; ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (tbe == desgna || tbm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION,A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr,A.NXTMON_Pr,A.FINALAMT PAYOUT FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_FINAL_TAB B ON A.FS_Code=B.FS_Code where A.FS_Code='" + Session["FSCODE"] + "' " + whreclase + ") NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID  ; ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
        if (admin == desgna)
        {
            whreclase = whreclase.Substring(4);
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,B.PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where " + whreclase + " ) NN where KEEY NOT IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) UNION  SELECT * FROM (select A.DESIGNATION+A.[EMP_NAME]+A.[HQ] KEEY,A.ROW_ID,A.DIVISION,A.[TEAM],A.DESIGNATION, A.[ZONE],A.[EMP_NAME],A.[CLIENT_HQ],A.NOP_HQ,A.FS_Code,B.FINALAMT,A.CALLAVG,A.ACH OVERALL_ACH,A.PriSecPr,A.SnBPr, A.NXTMON_Pr,('Re-Evaluate') PAYOUT,B.ELIGIBLE FROM EMPLOYEE_Incentive_TAB A INNER JOIN EMPLOYEE_Incentive_ELIGIBLE_TAB B ON  A.FS_Code=B.FS_Code where " + whreclase + ") NN where KEEY  IN (Select distinct DESIGNATION+NAME+HQ from APPROVAL) order by ROW_ID ";
            string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            SqlDataAdapter adpRpt = new SqlDataAdapter(StrQrry, conn);
            adpRpt.Fill(DsStockist, "DsStockist");
            adpRpt.Fill(dtDsStockist);
            if (DsStockist.Tables[0].Rows.Count > 0)
            {
                Organo.DataSource = dtDsStockist;
                Organo.DataBind();
                Session.Add("dtDsStockist", dtDsStockist);
                //GridView1.Visible = false;
            }
        }
    }
    protected void Clear_Click(object sender, EventArgs e)
    {


        //Lblwh.Text = null;
        BindGrid();
        binddropdown2();
        binddropdown1();
        binddropdown3();

    }
}