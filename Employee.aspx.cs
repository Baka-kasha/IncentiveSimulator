using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.IO;
using System.Data.Sql;


public partial class Employee : System.Web.UI.Page
{
    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            BindGrid();
            if (Session["DESG"].ToString() == "TBE" || Session["DESG"].ToString() == "TBM" || Session["DESG"].ToString() == "TSO" || Session["DESG"].ToString() == "KAM" || Session["DESG"].ToString() == "KAE-MT")
            {
                ddlparameters1.Visible = false;
                ddlparameters2.Visible = false;
                ddlparameters3.Visible = false;
                ddlmultiplier.Visible = false;
                ddlqualifiers.Visible = false;
                Button8.Visible = false;
                Button6.Visible = false;
            }
            if (Session["BU"].ToString() == "CX")
            {
                Label4.Text = "FWD";
                Label68.ToolTip = "Minimum FWD";
                TAB15.Visible = false;
                TAB11.Attributes["style"] = "height: 26px;";
                TAB12.Attributes["style"] = "height: 26px;";
                TAB13.Attributes["style"] = "height: 26px;";
                ListItem itemToRemove1 = ddlqualifiers.Items.FindByValue("snb");
                if (itemToRemove1 != null)
                {
                    //ddlqualifiers.Items.Remove(itemToRemove);
                    ddlqualifiers.Items.Remove(itemToRemove1);
                }
                TAB14.Attributes["style"] = "height: 26px;";
            }
            if (Session["BU"].ToString() == "AX")
            {
                TAB15.Visible = false;
                TAB14.Visible = false;
                TAB11.Attributes["style"] = "height: 35px;";
                TAB12.Attributes["style"] = "height: 35px;";
                TAB13.Attributes["style"] = "height: 35px;";

                Label46.Visible = false;
                Label47.Visible = false;
                Label48.Visible = false;
                Label49.Visible = false;
                Label50.Visible = false;
                Label51.Visible = false;
                Label52.Visible = false;
                Label53.Visible = false;
                Label54.Visible = false;
                Label55.Visible = false;
                ListItem itemToRemove = ddlqualifiers.Items.FindByValue("prisec");
                ListItem itemToRemove1 =  ddlqualifiers.Items.FindByValue("snb");
                if (itemToRemove != null)
                {
                    ddlqualifiers.Items.Remove(itemToRemove);
                    ddlqualifiers.Items.Remove(itemToRemove1);
                }
            }
        }
    }
    public void BindGrid()
    {
        Lblwelcm.Text = "EMPLOYEE ID: " + Session["EMPID"].ToString();
        Label82.Text = "TEAM: " + Session["TEAM"].ToString();
        Lbldetail.Text = "DESIGNATION: " + Session["DESG"].ToString();
        Label83.Text = "HQ: " + Session["HQ"].ToString();
        // string checkadmn = ;
        if (Session["FSCODE"].ToString() == "Admin")
        {

            Response.Redirect("Quailifiers.aspx");

        }

        else
        {
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[FINALGRID$] where DESIGNATION = '" + Session["DESG"] + "' and DIVISION = '" + Session["BU"] + "'", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    //Label11.Text = logintbl1.Rows[0][0].ToString();
                    Session["OVERALL"] = logintbl1.Rows[0][1].ToString();
                    Session["PRISEC"] = logintbl1.Rows[0][2].ToString();
                    Session["SNB"] = logintbl1.Rows[0][3].ToString();
                    Session["NXTMON"] = logintbl1.Rows[0][4].ToString();
                    Label68.Text = logintbl1.Rows[0][5].ToString();
                    Label68.ToolTip = "Minimum Call Avg";
                    Session["CALLAVG"] = logintbl1.Rows[0][5].ToString();
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [EMPLOYEE_Incentive_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {
                    double percentageValue1;
                    if (double.TryParse(logintbl1.Rows[0][13].ToString(), out percentageValue1))
                    {
                        double overall = Convert.ToDouble(Session["OVERALL"].ToString());
                        if (percentageValue1 >= overall)
                        {
                            string formattedPercentage1 = percentageValue1.ToString("P");
                            Label45.Text = "ELIGIBLE";
                        }
                        else
                        {
                            string formattedPercentage1 = percentageValue1.ToString("P");
                            Label45.Text = "NOT ELIGIBLE";
                            Label45.ForeColor = Color.Red;
                        }
                    }

                    double percentageValue2;
                    double PRISEC = Convert.ToDouble(Session["PRISEC"].ToString());
                    if (double.TryParse(logintbl1.Rows[0][21].ToString(), out percentageValue2))
                    {
                        if (percentageValue2 >= PRISEC)
                        {
                            string formattedPercentage1 = percentageValue2.ToString("P");
                            Label50.Text = "ELIGIBLE";
                        }
                        else
                        {
                            string formattedPercentage1 = percentageValue2.ToString("P");
                            Label50.Text = "NOT ELIGIBLE";
                            Label50.ForeColor = Color.Red;
                        }
                    }

                    double percentageValue3;
                    double SNB = Convert.ToDouble(Session["SNB"].ToString());
                    if (double.TryParse(logintbl1.Rows[0][17].ToString(), out percentageValue3))
                    {
                        if (percentageValue3 <= SNB)
                        {
                            string formattedPercentage1 = percentageValue3.ToString("P");
                            Label55.Text = "ELIGIBLE";
                        }
                        else
                        {
                            string formattedPercentage1 = percentageValue3.ToString("P");
                            Label55.Text = "NOT ELIGIBLE";
                            Label55.ForeColor = Color.Red;
                        }
                    }

                    double percentageValue4;
                    double NCXTMON = Convert.ToDouble(Session["NXTMON"].ToString());
                    if (double.TryParse(logintbl1.Rows[0][24].ToString(), out percentageValue4))
                    {
                        if (percentageValue4 >= NCXTMON)
                        {
                            string formattedPercentage1 = percentageValue4.ToString("P");
                            Label60.Text = "ELIGIBLE";
                        }
                        else
                        {
                            string formattedPercentage1 = percentageValue4.ToString("P");
                            Label60.Text = "NOT ELIGIBLE";
                            Label60.ForeColor = Color.Red;
                        }
                    }
                    double percentageValue5;
                    double CALLAVG = Convert.ToDouble(Session["CALLAVG"].ToString());
                    if (double.TryParse(logintbl1.Rows[0][26].ToString(), out percentageValue5))
                    {
                        if (percentageValue5 >= CALLAVG)
                        {
                            string formattedPercentage1 = percentageValue5.ToString("P");
                            Label72.Text = "ELIGIBLE";
                        }
                        else
                        {
                            string formattedPercentage1 = percentageValue5.ToString("P");
                            Label72.Text = "NOT ELIGIBLE";
                            Label72.ForeColor = Color.Red;
                        }
                    }
                    //Label66.Text = logintbl1.Rows[0][24].ToString();
                    //if (Label66.Text == "0")
                    //{
                    //    Label2.Text = "NOT ELIGIBLE";
                    //    Label2.ForeColor = Color.Red;
                    //}
                    //else
                    //{
                    //    Label2.Text = "ELIGIBLE";

                    //}
                    string NAME = logintbl1.Rows[0][7].ToString();
                    Label5.Text = " [Q1 INCENTIVE DASHBOARD OF " + NAME.ToString() + " ] ";
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [EMPLOYEE_Incentive_ELIGIBLE_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {
                    Label8.Text = logintbl1.Rows[0][11].ToString();
                    Label15.Text = logintbl1.Rows[0][12].ToString();
                    Label20.Text = logintbl1.Rows[0][13].ToString();
                    Label25.Text = logintbl1.Rows[0][14].ToString();
                    Label30.Text = logintbl1.Rows[0][15].ToString();
                    Label35.Text = logintbl1.Rows[0][16].ToString();
                    Label66.Text = "₹ " + logintbl1.Rows[0][21].ToString();
                    Label2.Text = "₹ " + logintbl1.Rows[0][19].ToString();
                    Label88.Text = "₹ " + logintbl1.Rows[0][19].ToString();
                    {
                        if (logintbl1.Rows[0][20].ToString() == "EXCEPTION")
                        {
                            if (Label66.Text == "0")
                            {
                                Label80.Text = "NOT ELIGIBLE";
                                Label80.ForeColor = Color.Red;
                            }
                            else
                            {
                                Label80.Text = "EXCEPTION";
                                Label80.ForeColor = Color.Red;
                                Label66.Text = Label66.Text + "<span style= 'color:Red;'>*</span> ";
                                Label80.ToolTip = logintbl1.Rows[0][22].ToString();

                            }
                        }
                        else
                        {
                            if (Label66.Text == "0")
                            {
                                Label80.Text = "NOT ELIGIBLE";
                                Label80.ForeColor = Color.Red;
                            }
                            else
                            {
                                Label80.Text = "ELIGIBLE";
                            }
                        }
                    }
                    {
                        if (Label35.Text == null || Label35.Text == "0")
                        {
                            Label32.Text = "2";
                            Label33.Text = "0";
                            Label34.Text = "0%";
                        }
                        else
                        {
                            Label32.Text = "2";
                            Label33.Text = "2";
                            Label34.Text = "100%";
                        }
                    }
                    decimal brand1 = Convert.ToDecimal(logintbl1.Rows[0][11].ToString());
                    decimal brand2 = Convert.ToDecimal(logintbl1.Rows[0][12].ToString());
                    decimal brand3 = Convert.ToDecimal(logintbl1.Rows[0][13].ToString());
                    decimal Kpi1 = Convert.ToDecimal(logintbl1.Rows[0][14].ToString());
                    decimal kpi2 = Convert.ToDecimal(logintbl1.Rows[0][15].ToString());
                    decimal Total = brand1 + brand2 + brand3 + Kpi1 + kpi2;
                    Label75.Text = "₹ " + Total.ToString();
                    decimal pcpm = Convert.ToDecimal(logintbl1.Rows[0][17].ToString());
                    decimal diq = Convert.ToDecimal(logintbl1.Rows[0][18].ToString());
                    decimal pcpmadd =  Total * pcpm;
                    int kk = Convert.ToInt32(pcpmadd);
                    Label40.Text = kk.ToString();
                    decimal diqadd = pcpmadd * diq;
                    int kkk = Convert.ToInt32(diqadd);
                    Label65.Text = kkk.ToString();
                    // decimal consisitency = Convert.ToDecimal(logintbl1.Rows[0][10].ToString());
                }
                conn1.Close();
            }

            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].['Brand Group 1$'] where TEAM = '" + Session["TEAM"]  + "' ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    //Label11.Text = logintbl1.Rows[0][0].ToString();
                    Label11.ToolTip = logintbl1.Rows[0][0].ToString();
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].['Brand Group 2$'] where TEAM = '" + Session["TEAM"] + "' ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    //Label11.Text = logintbl1.Rows[0][0].ToString();
                    Label10.ToolTip = logintbl1.Rows[0][0].ToString();
                }
                conn1.Close();
            }
           
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].['Brand Group 3$'] where TEAM = '" + Session["TEAM"] + "' ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    //Label11.Text = logintbl1.Rows[0][0].ToString();
                    Label16.ToolTip = logintbl1.Rows[0][0].ToString();
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_Brand_1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    string TGT = logintbl1.Rows[0][11].ToString();
                    decimal TGT1 = Convert.ToDecimal(TGT.ToString());
                    Label9.Text = (TGT1).ToString("0.00");
                    string VAL = logintbl1.Rows[0][12].ToString();
                    decimal VAL1 = Convert.ToDecimal(VAL.ToString());
                    Label6.Text = (VAL1).ToString("0.00");
                    string ACH = logintbl1.Rows[0][13].ToString();
                    decimal ACH1 = Convert.ToDecimal(ACH.ToString());
                    Label7.Text = (ACH1).ToString("P");
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_Brand_2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    string TGT = logintbl1.Rows[0][11].ToString();
                    decimal TGT1 = Convert.ToDecimal(TGT.ToString());
                    Label12.Text = (TGT1).ToString("0.00");
                    string VAL = logintbl1.Rows[0][12].ToString();
                    decimal VAL1 = Convert.ToDecimal(VAL.ToString());
                    Label13.Text = (VAL1).ToString("0.00");
                    string ACH = logintbl1.Rows[0][13].ToString();
                    decimal ACH1 = Convert.ToDecimal(ACH.ToString());
                    Label14.Text = (ACH1).ToString("P");
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_Brand_3_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    string TGT = logintbl1.Rows[0][11].ToString();
                    decimal TGT1 = Convert.ToDecimal(TGT.ToString());
                    Label17.Text = (TGT1).ToString("0.00");
                    string VAL = logintbl1.Rows[0][12].ToString();
                    decimal VAL1 = Convert.ToDecimal(VAL.ToString());
                    Label18.Text = (VAL1).ToString("0.00");
                    string ACH = logintbl1.Rows[0][13].ToString();
                    decimal ACH1 = Convert.ToDecimal(ACH.ToString());
                    Label19.Text = (ACH1).ToString("P");
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_PCPM_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    Label38.Text = logintbl1.Rows[0][11].ToString();
                    //  Label38.Text = logintbl1.Rows[0][10].ToString();
                    // Label39.Text = logintbl1.Rows[0][12].ToString();
                    Session["PCPM"] = logintbl1.Rows[0][11].ToString();
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[PCPM$] where TEAM = '" + Session["TEAM"] + "'  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    Label37.Text = logintbl1.Rows[0][1].ToString();
                    string KPI211 = logintbl1.Rows[0][1].ToString();
                            decimal KPI21 = Convert.ToDecimal(KPI211.ToString());
                    //  Label38.Text = logintbl1.Rows[0][10].ToString();
                    // Label39.Text = logintbl1.Rows[0][12].ToString();
                    string KPI1 = Session["PCPM"].ToString();
                    decimal KP1 = Convert.ToDecimal(KPI1.ToString());
                    decimal kpiach = (KP1 / KPI21);
                    string kpiach1 = kpiach.ToString("P");
                    Label39.Text = kpiach1;

                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_DIQ_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {
                    string DAYS = "90";
                    Label62.Text = DAYS + " days";
                    // Label63.Text = logintbl1.Rows[0][12].ToString();
                    Label63.Text = logintbl1.Rows[0][11].ToString();
                    Label63.Text = Label63.Text + " days";
                    // Label39.Text = logintbl1.Rows[0][12].ToString();
                    decimal Daysin = Convert.ToDecimal(DAYS.ToString());
                    decimal Daysout = Convert.ToDecimal(logintbl1.Rows[0][11].ToString());
                    decimal Ach = Daysout / Daysin;
                    if (Ach > 1)
                    {
                        Label64.Text = "100%";
                    }
                    else
                    {
                    string Achdays = Ach.ToString("P");
                    Label64.Text = Achdays;
                    }
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                string DESIGNATION = Session["DESG"].ToString();
                if (DESIGNATION == "SM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = logintbl1.Rows[0][12].ToString();
                        decimal KPI11 = Convert.ToDecimal(KPI1.ToString());
                        Label24.Text = KPI11.ToString("P");
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Label24.Text = KPI11.ToString("P");
                        Session["KPI1"] = KPI11.ToString();
                    }
                }
                if (DESIGNATION == "RBM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = logintbl1.Rows[0][12].ToString();
                        decimal KPI11 = Convert.ToDecimal(KPI1.ToString());
                        Label24.Text = KPI11.ToString("P");
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI1"] = KPI11.ToString();
                    }
                }
                if (DESIGNATION == "DSM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = logintbl1.Rows[0][11].ToString();
                        decimal KPI11 = Convert.ToDecimal(KPI1.ToString());
                        Label24.Text = KPI11.ToString("P");
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI1"] = KPI11.ToString();
                    }
                }
                if (DESIGNATION == "TBE" || DESIGNATION == "TBM" || DESIGNATION == "KAM" || DESIGNATION == "NKAM" || DESIGNATION == "ZBM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = logintbl1.Rows[0][11].ToString();
                        decimal KPI11 = Convert.ToDecimal(KPI1.ToString());
                        Label24.Text = KPI11.ToString("P");
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI1"] = KPI11.ToString();
                    }
                }
                if (DESIGNATION == "ASM" || DESIGNATION == "KAE-MT"  || DESIGNATION == "RM" || DESIGNATION == "TSO" )
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI1_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = logintbl1.Rows[0][11].ToString();
                        decimal KPI11 = Convert.ToDecimal(KPI1.ToString());
                        Label24.Text = KPI11.ToString("P");
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI1"] = KPI11.ToString();
                    }
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                string DESIGNATION = Session["DESG"].ToString();
                string TEAM = Session["TEAM"].ToString();
                if (DESIGNATION == "SM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][13].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI21.ToString("P");
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                if (DESIGNATION == "RBM" && TEAM == "CETAPHIL")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][12].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI21.ToString("P");
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                if (DESIGNATION == "RBM" && TEAM == "RX")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][12].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI2;
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                if (DESIGNATION == "DSM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][12].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI2;
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                if (DESIGNATION == "TBM" || DESIGNATION == "TBE" || DESIGNATION == "KAM" || DESIGNATION == "NKAM" || DESIGNATION == "ZBM")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][11].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI21.ToString("P");
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                if (DESIGNATION == "ASM" || DESIGNATION == "KAE-MT" || DESIGNATION == "RM" || DESIGNATION == "TSO")
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_KPI2_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string KPI2 = logintbl1.Rows[0][12].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2.ToString());
                        Label29.Text = KPI2;
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        Session["KPI2"] = KPI21.ToString();
                    }
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[KPI1$] where TEAM = '" + Session["TEAM"] + "' and DESIGNATION = '" + Session["DESG"] + "'  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {

                    // Label63.Text = logintbl1.Rows[0][12].ToString();
                    string PARA = logintbl1.Rows[0][0].ToString();
                    Label21.ToolTip = PARA;
                    string KPI2Criteria = logintbl1.Rows[0][4].ToString();
                    decimal KPI21 = Convert.ToDecimal(KPI2Criteria.ToString());
                    //int II = Convert.ToInt32(KPI21);
                    Label22.Text = KPI21.ToString("P");
                    // Label29.Text = logintbl1.Rows[0][10].ToString();
                    // Label39.Text = logintbl1.Rows[0][12].ToString();
                    string KPI1 = Session["KPI1"].ToString();
                    decimal KP1 = Convert.ToDecimal(KPI1.ToString());

                    decimal kpiach = (KP1 / KPI21);
                    string kpiach1 = kpiach.ToString("P");
                    Label23.Text = kpiach1;
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                string TEAM = Session["TEAM"].ToString();
                string DESIGNATION = Session["DESG"].ToString();
                string DIV = Session["BU"].ToString();
                if (((TEAM == "CETAPHIL" || TEAM == "RX") && DESIGNATION == "DSM") || (TEAM == "RX" && DESIGNATION == "RBM") || (TEAM == "RX" && DESIGNATION == "SM") || (DIV == "CX"))
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[KPI2$] where TEAM = '" + Session["TEAM"] + "' and DESIGNATION = '" + Session["DESG"] + "'  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string PARA = logintbl1.Rows[0][0].ToString();
                        Label26.ToolTip = PARA;
                        string KPI2Criteria = logintbl1.Rows[0][4].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2Criteria.ToString());
                        // int iii = Convert.ToInt32(KPI21.ToString());
                        Label27.Text = KPI21.ToString();
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = Session["KPI2"].ToString();
                        decimal KP1 = Convert.ToDecimal(KPI1.ToString());
                        decimal kpiach = (KP1 / KPI21);
                        string kpiach1 = kpiach.ToString("P");
                        Label28.Text = kpiach1;
                    }
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[KPI2$] where TEAM = '" + Session["TEAM"] + "' and DESIGNATION = '" + Session["DESG"] + "'  ", conn1);
                    conn1.Open();
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    var logintbl1 = new DataTable();
                    logintbl1.Load(read1);
                    if (logintbl1.Rows.Count > 0)
                    {

                        // Label63.Text = logintbl1.Rows[0][12].ToString();
                        string PARA = logintbl1.Rows[0][0].ToString();
                        Label26.ToolTip = PARA;
                        string KPI2Criteria = logintbl1.Rows[0][4].ToString();
                        decimal KPI21 = Convert.ToDecimal(KPI2Criteria.ToString());
                        //int iii = Convert.ToInt32(KPI21);
                        Label27.Text = KPI21.ToString("P");
                        // Label29.Text = logintbl1.Rows[0][10].ToString();
                        // Label39.Text = logintbl1.Rows[0][12].ToString();
                        string KPI1 = Session["KPI2"].ToString();
                        decimal KP1 = Convert.ToDecimal(KPI1.ToString());
                        decimal kpiach = (KP1 / KPI21);
                        string kpiach1 = kpiach.ToString("P");
                        Label28.Text = kpiach1;
                    }
                }
                conn1.Close();
            }
            using (SqlConnection conn1 = new SqlConnection(conn))
            {
                SqlCommand cmd1 = new SqlCommand(" SELECT * FROM [dbo].[EMPLOYEE_Incentive_TAB] where FS_Code = '" + Session["FSCODE"] + "' order by ROW_ID  ", conn1);
                conn1.Open();
                SqlDataReader read1 = cmd1.ExecuteReader();
                var logintbl1 = new DataTable();
                logintbl1.Load(read1);
                if (logintbl1.Rows.Count > 0)
                {
                    string TGT = logintbl1.Rows[0][11].ToString();
                    decimal TGT1 = Convert.ToDecimal(TGT.ToString());
                    Label42.Text = TGT1.ToString("0.00");
                    string VAL = logintbl1.Rows[0][19].ToString();
                    decimal VAL1 = Convert.ToDecimal(VAL.ToString());
                    Label43.Text = VAL1.ToString("0.00");
                    string ACH = logintbl1.Rows[0][13].ToString();
                    decimal ACH1 = Convert.ToDecimal(ACH.ToString());
                    Label44.Text = ACH1.ToString("P");

                    Label47.Text = VAL1.ToString("0.00");
                    string SEC = logintbl1.Rows[0][20].ToString();
                    decimal SEC1 = Convert.ToDecimal(SEC.ToString());
                    Label48.Text = SEC1.ToString("0.00");
                    string PRISEC = logintbl1.Rows[0][21].ToString();
                    decimal PRISEC1 = Convert.ToDecimal(PRISEC.ToString());
                   // PRISEC1 = PRISEC1 ;
                    Label49.Text = PRISEC1.ToString("P");

                    Label52.Text = "< 50%";
                    string SnB = logintbl1.Rows[0][15].ToString();
                    // SnB = SnB.Replace("", "0").Replace("&nbsp;", "0");
                    
                    decimal SNB1 = Convert.ToDecimal(SnB.ToString());
                    Label53.Text = SNB1.ToString("0.00");
                    string SNBPR = logintbl1.Rows[0][17].ToString();
                    decimal SNBPR1 = Convert.ToDecimal(SNBPR.ToString());
                    Label54.Text = SNBPR1.ToString("P");
                    //string ACH = logintbl1.Rows[0][13].ToString();
                    //decimal ACH1 = Convert.ToDecimal(ACH.ToString());
                    //Label44.Text = ACH1.ToString("P");
                    string NTGT = logintbl1.Rows[0][22].ToString();
                    decimal NTGT1 = Convert.ToDecimal(NTGT.ToString());
                    Label57.Text = NTGT1.ToString("0.00");
                    string NVAL = logintbl1.Rows[0][23].ToString();
                    decimal NVAL1 = Convert.ToDecimal(NVAL.ToString());
                    Label58.Text = NVAL1.ToString("0.00");
                    string NACH = logintbl1.Rows[0][24].ToString();
                    decimal NACH1 = Convert.ToDecimal(NACH.ToString());
                    //NACH1 = NACH1 / 100;
                    Label59.Text = NACH1.ToString("P");

                    //Label68.Text = "8";
                    decimal num = Convert.ToDecimal(Session["CALLAVG"].ToString());
                    string CALLAVG = logintbl1.Rows[0][26].ToString();
                    // SnB = SnB.Replace("", "0").Replace("&nbsp;", "0");
                    decimal CALLAVG1 = Convert.ToDecimal(CALLAVG.ToString());
                    Label70.Text = CALLAVG1.ToString("0.00");
                    decimal decAch = CALLAVG1 / num;
                    string Acga = decAch.ToString("P");
                    Label71.Text = Acga;
                }
                conn1.Close();
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
   
}
