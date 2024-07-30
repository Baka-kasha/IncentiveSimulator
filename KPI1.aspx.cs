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

public partial class KPI1 : System.Web.UI.Page
{
    string conn = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
    DataSet DsStockist = new DataSet();
    DataTable dtDsStockist = new DataTable();
    string sm = "SM";
    string asm = "ASM";
    string zbm = "ZBM";
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindGrid();
            binddropdown2();
            binddropdown1();
            binddropdown3();
            Organo.Columns[5].Visible = false;
           // Organo.Columns[2].Visible = false;
            binddropdown4();
            if (Session["DESG"].ToString() == "Admin")
            {
                Button7.Visible = false;
                Button1.Visible = false;
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
        string tea = Session["TEAM"].ToString();
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where SM='" + Session["FSCODE"] + "' order by ROW_ID ";
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
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where RBM='" + Session["FSCODE"] + "' order by ROW_ID ";
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
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where DSM='" + Session["FSCODE"] + "' order by ROW_ID ";
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
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where FS_Code ='" + Session["FSCODE"] + "'order by ROW_ID ";
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
        if (desgna == "Admin")
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] order by ROW_ID ";
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
        DataSet DsStockist = new DataSet();
        DataTable dtDsStockist = new DataTable();
        string StrQrry = "";
        string tea = Session["TEAM"].ToString();
        string desgna = Session["DESG"].ToString();
        if (sm == desgna)
        {
            StrQrry = " SELECT [DESIGNATION] ,[EMP_NAME],[CLIENT_HQ],[NOP_HQ],[Q1 VF%],[Q1 NPD%],[Q1 Expiry%],AMOUNT FROM [EMPLOYEE_Incentive_KPI1_TAB] where SM ='" + Session["FSCODE"] + "' order by ROW_ID;";

        }
        if (rbm == desgna || (rm == desgna && tea == "GT+MT"))
        {
            StrQrry = " SELECT [DESIGNATION] ,[EMP_NAME],[CLIENT_HQ],[NOP_HQ],[Q1 VF%],[Q1 NPD%],[Q1 Expiry%],AMOUNT FROM [EMPLOYEE_Incentive_KPI1_TAB] where RBM ='" + Session["FSCODE"] + "' order by ROW_ID;";

        }
        if (dsm == desgna || asm == desgna || (rm == desgna && tea == "AX") || nkam == desgna)
        {
            StrQrry = " SELECT [DESIGNATION] ,[EMP_NAME],[CLIENT_HQ],[NOP_HQ],[Q1 VF%],[Q1 NPD%],[Q1 Expiry%],AMOUNT FROM [EMPLOYEE_Incentive_KPI1_TAB] where DSM ='" + Session["FSCODE"] + "' order by ROW_ID;";

        }
        if (tbe == desgna || tbm == desgna || tso == desgna || kam == desgna || kae == desgna)
        {
            StrQrry = " SELECT [DESIGNATION] ,[EMP_NAME],[CLIENT_HQ],[NOP_HQ],[Q1 VF%],[Q1 NPD%],[Q1 Expiry%],AMOUNT FROM [EMPLOYEE_Incentive_KPI1_TAB] where FS_Code ='" + Session["FSCODE"] + "' order by ROW_ID;";

        }
        if (desgna == "Admin")
        {
            StrQrry = " SELECT [DESIGNATION] ,[EMP_NAME],[CLIENT_HQ],[NOP_HQ],[Q1 VF%],[Q1 NPD%],[Q1 Expiry%],AMOUNT FROM [EMPLOYEE_Incentive_KPI1_TAB] order by ROW_ID;";

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
        string FileName = "KPI 1 " + Session["FSCODE"] + "_" + DateTime.Now + ".xls";
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
                item.Cells[6].Attributes.Add("style", "mso-number-format:'0.00%'");
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
   
    protected void ddldesg_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddldesgvalue = string.Empty;
        ddldesgvalue = ddldesg.SelectedValue.ToString();
        Session["ddldesgvalue"] = ddldesgvalue;
       // //Lblwh.Text = //Lblwh.Text + "Showing calculation for <span style= 'color:Red;'>" + ddldesgvalue + "</span> division ";
        //  Lblwh.ForeColor = System.Drawing.Color.Red;

        //BindGrid2();
    }
    protected void Organo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sm = "SM";
            string rbm = "RBM";
            string dsm = "DSM";
            string TBE = "TBE";
            string TBM = "TBM";
            string TEAM = e.Row.Cells[2].Text;
            string Designation = e.Row.Cells[3].Text;
            string NAME1 = e.Row.Cells[6].Text;
            if (NAME1 == "YOGESH PRAKASH GADILOHAR")
            {
                NAME1 = "B";
            }

            if (e.Row.Cells[3].Text == rbm || e.Row.Cells[3].Text == sm)
            {

                if (e.Row.Cells[3].Text == rbm)
                {
                    e.Row.BackColor = Color.LightSeaGreen;
                    e.Row.ForeColor = Color.Black;
                }
                if (e.Row.Cells[3].Text == sm)
                {
                    e.Row.Font.Bold = true;
                    e.Row.BackColor = Color.DarkCyan;
                    e.Row.ForeColor = Color.Black;
                }

               

                string con1n = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(con1n))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KPI1$] where DESIGNATION = '" + Designation + "' and TEAM = '" + TEAM + "' ;", conn);
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    var logintbl = new DataTable();
                    logintbl.Load(read);
                    for (int i = 0; i < logintbl.Rows.Count; i += 3)
                    {
                        // Compare values within each set of 3 rows
                        string value1 = logintbl.Rows[i][4].ToString(); // Accessing first cell of the current row
                        decimal value11 = Convert.ToDecimal(value1);
                        string value12 = logintbl.Rows[i][3].ToString(); // Accessing first cell of the current row
                        decimal value112 = Convert.ToDecimal(value12);
                        string value2 = logintbl.Rows[i + 1][4].ToString();// Accessing first cell of the next row
                        decimal value21 = Convert.ToDecimal(value2);
                        string value22 = logintbl.Rows[i + 1][3].ToString();// Accessing first cell of the next row
                        decimal value212 = Convert.ToDecimal(value22);
                        string value3 = logintbl.Rows[i + 2][4].ToString(); // Accessing first cell of the next next row
                        decimal value31 = Convert.ToDecimal(value3);
                        string value32 = logintbl.Rows[i + 2][3].ToString(); // Accessing first cell of the next next row
                        decimal value312 = Convert.ToDecimal(value32);

                        string VF = e.Row.Cells[10].Text;
                        VF = VF.Replace("&nbsp;", "0");
                        decimal VFPR = Convert.ToDecimal(VF);
                        //VFPR = Math.Round(VFPR, 2);


                        if (VFPR <= value11 && VFPR > value112)
                        {
                            string AMOUNT = logintbl.Rows[i][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@VF", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                        if (VFPR <= value21 && VFPR > value212)
                        {
                            string AMOUNT = logintbl.Rows[i + 1][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@VF", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if (VFPR <= value31 && VFPR > value312)
                        {
                            string AMOUNT = logintbl.Rows[i + 2][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@VF", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                            
                        }
                        if (VFPR < value11)
                        {
                            string AMOUNT = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            string EXP = "0";
                            string NPD = "0";
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", VF.ToString());
                                cmmd.Parameters.AddWithValue("@VF", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                    }
                    conn.Close();
                }
            }
            if (e.Row.Cells[3].Text == dsm || (rm == e.Row.Cells[3].Text && e.Row.Cells[2].Text == "AX") || nkam == e.Row.Cells[3].Text)
            {
                string NAME = e.Row.Cells[6].Text;
                e.Row.BackColor = Color.MediumTurquoise;
                e.Row.ForeColor = Color.Black;
                string con1n = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(con1n))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KPI1$] where DESIGNATION = '" + Designation + "' and TEAM = '" + TEAM + "' ;", conn);
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    var logintbl = new DataTable();
                    logintbl.Load(read);
                    for (int i = 0; i < logintbl.Rows.Count; i += 3)
                    {
                        // Compare values within each set of 3 rows
                        string value1 = logintbl.Rows[i][4].ToString(); // Accessing first cell of the current row
                        decimal value11 = Convert.ToDecimal(value1);
                        string value12 = logintbl.Rows[i][3].ToString(); // Accessing first cell of the current row
                        decimal value112 = Convert.ToDecimal(value12);
                        string value2 = logintbl.Rows[i + 1][4].ToString();// Accessing first cell of the next row
                        decimal value21 = Convert.ToDecimal(value2);
                        string value22 = logintbl.Rows[i + 1][3].ToString();// Accessing first cell of the next row
                        decimal value212 = Convert.ToDecimal(value22);
                        string value3 = logintbl.Rows[i + 2][4].ToString(); // Accessing first cell of the next next row
                        decimal value31 = Convert.ToDecimal(value3);
                        string value32 = logintbl.Rows[i + 2][3].ToString(); // Accessing first cell of the next next row
                        decimal value312 = Convert.ToDecimal(value32);

                        string VF = e.Row.Cells[9].Text;
                        VF = VF.Replace("&nbsp;", "0");
                        decimal VFPR = Convert.ToDecimal(VF);
                        VFPR = Math.Round(VFPR, 2);
                        string PF = e.Row.Cells[11].Text;
                        PF = PF.Replace("&nbsp;", "0");
                        decimal PFPR = Convert.ToDecimal(PF);
                        PFPR = Math.Round(PFPR, 2);

                        if (((VFPR == value11 && VFPR < value212) && (PFPR >= value11 && PFPR > value11)) || ((PFPR == value11 && PFPR < value212) && (VFPR >= value11 && VFPR > value11)))
                        {
                            string AMOUNT = logintbl.Rows[i][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                        if (((VFPR <= value21 && VFPR >= value212) && (PFPR >= value212)) || ((PFPR <= value21 && PFPR >= value212) && (VFPR >= value212)))
                        {
                            string AMOUNT = logintbl.Rows[i + 1][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if ((VFPR >= value31) && (PFPR >= value31))
                        {
                            string AMOUNT = logintbl.Rows[i + 2][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if ((VFPR <= value112) && (PFPR <= value112))
                        {
                            string AMOUNT = "0";
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                       
                    }
                    conn.Close();
                }
            }

            if ( tbe == Designation || tbm == Designation || kam == Designation)
            {

                //e.Row.BackColor = Color.MediumTurquoise;
                //e.Row.ForeColor = Color.Black;
                string con1n = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(con1n))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KPI1$] where DESIGNATION = '" + Designation + "' and TEAM = '" + TEAM + "' ;", conn);
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    var logintbl = new DataTable();
                    logintbl.Load(read);
                    for (int i = 0; i < logintbl.Rows.Count; i += 3)
                    {
                        // Compare values within each set of 3 rows
                        string value1 = logintbl.Rows[i][4].ToString(); // Accessing first cell of the current row
                        decimal value11 = Convert.ToDecimal(value1);
                        string value12 = logintbl.Rows[i][3].ToString(); // Accessing first cell of the current row
                        decimal value112 = Convert.ToDecimal(value12);
                        string value2 = logintbl.Rows[i + 1][4].ToString();// Accessing first cell of the next row
                        decimal value21 = Convert.ToDecimal(value2);
                        string value22 = logintbl.Rows[i + 1][3].ToString();// Accessing first cell of the next row
                        decimal value212 = Convert.ToDecimal(value22);
                        string value3 = logintbl.Rows[i + 2][4].ToString(); // Accessing first cell of the next next row
                        decimal value31 = Convert.ToDecimal(value3);
                        string value32 = logintbl.Rows[i + 2][3].ToString(); // Accessing first cell of the next next row
                        decimal value312 = Convert.ToDecimal(value32);

                        string VF = e.Row.Cells[9].Text;
                        VF = VF.Replace("&nbsp;", "0");
                        decimal VFPR = Convert.ToDecimal(VF);
                        VFPR = Math.Round(VFPR, 2);
                        string PF = e.Row.Cells[11].Text;
                        PF = PF.Replace("&nbsp;", "0");
                        decimal PFPR = Convert.ToDecimal(PF);
                        PFPR = Math.Round(PFPR, 2);

                        if (((VFPR == value11 && VFPR < value212) && (PFPR >= value11 && PFPR > value11)) || ((PFPR == value11 && PFPR < value212) && (VFPR >= value11 && VFPR > value11)))
                        {
                            string AMOUNT = logintbl.Rows[i][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                        if (((VFPR <= value21 && VFPR >= value212) && (PFPR >= value212)) || ((PFPR <= value21 && PFPR >= value212) && (VFPR >= value212)))
                        {
                            string AMOUNT = logintbl.Rows[i + 1][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if ((VFPR >= value31) && (PFPR >= value31))
                        {
                            string AMOUNT = logintbl.Rows[i + 2][5].ToString();
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if ((VFPR <= value112) && (PFPR <= value112))
                        {
                            string AMOUNT = "0";
                            string EXP = PF;
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", NPD.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", EXP.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                       
                    }
                    conn.Close();
                }
            }
            if (tso == Designation || kae == Designation || asm == e.Row.Cells[3].Text || (rm == e.Row.Cells[3].Text && e.Row.Cells[2].Text == "GT+MT"))
            {
                if ((rm == e.Row.Cells[3].Text && e.Row.Cells[2].Text == "GT+MT"))
                {
                      e.Row.BackColor = Color.LightSeaGreen;
                e.Row.ForeColor = Color.Black;
                e.Row.Font.Bold = true;
                }

                if (asm == e.Row.Cells[3].Text)
                {
                     e.Row.BackColor = Color.MediumTurquoise;
                e.Row.ForeColor = Color.Black;
                }


                //e.Row.BackColor = Color.MediumTurquoise;
                //e.Row.ForeColor = Color.Black;
                string con1n = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(con1n))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KPI1$] where DESIGNATION = '" + Designation + "' and TEAM = '" + TEAM + "' ;", conn);
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    var logintbl = new DataTable();
                    logintbl.Load(read);
                    for (int i = 0; i < logintbl.Rows.Count; i += 3)
                    {
                        // Compare values within each set of 3 rows
                        string value1 = logintbl.Rows[i][4].ToString(); // Accessing first cell of the current row
                        decimal value11 = Convert.ToDecimal(value1);
                        string value12 = logintbl.Rows[i][3].ToString(); // Accessing first cell of the current row
                        decimal value112 = Convert.ToDecimal(value12);
                        string value2 = logintbl.Rows[i + 1][4].ToString();// Accessing first cell of the next row
                        decimal value21 = Convert.ToDecimal(value2);
                        string value22 = logintbl.Rows[i + 1][3].ToString();// Accessing first cell of the next row
                        decimal value212 = Convert.ToDecimal(value22);
                        string value3 = logintbl.Rows[i + 2][4].ToString(); // Accessing first cell of the next next row
                        decimal value31 = Convert.ToDecimal(value3);
                        string value32 = logintbl.Rows[i + 2][3].ToString(); // Accessing first cell of the next next row
                        decimal value312 = Convert.ToDecimal(value32);

                        string VF = e.Row.Cells[9].Text;
                        VF = VF.Replace("&nbsp;", "0");
                        decimal VFPR = Convert.ToDecimal(VF);
                        VFPR = Math.Round(VFPR, 2);

                        if (VFPR >= value11 && VFPR < value212)
                        {
                            string AMOUNT = logintbl.Rows[i][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }
                        }
                        if (VFPR <= value21 && VFPR >= value212)
                        {
                            string AMOUNT = logintbl.Rows[i + 1][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if (VFPR >= value31 || VFPR > value312)
                        {
                            string AMOUNT = logintbl.Rows[i + 2][5].ToString();
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }
                        if (VFPR < value112)
                        {
                            string AMOUNT = "0";
                            string EXP = "0";
                            string NPD = "0";
                            Label Incent1 = (Label)e.Row.FindControl("Incent1");
                            Incent1.Text = AMOUNT.ToString();
                            string INCENTSP = Incent1.Text;
                            SqlCommand cmmd = new SqlCommand("[EMPLOYEE_Incentive_KPI1]", conn);
                            {

                                string FSCODE = e.Row.Cells[5].Text;
                                cmmd.CommandType = CommandType.StoredProcedure;
                                cmmd.Parameters.AddWithValue("@AMOUNT", INCENTSP.ToString());
                                cmmd.Parameters.AddWithValue("@VF", VF.ToString());
                                cmmd.Parameters.AddWithValue("@FS_Code", FSCODE.ToString());
                                cmmd.Parameters.AddWithValue("@NPD", EXP.ToString());
                                cmmd.Parameters.AddWithValue("@EXPIRY", NPD.ToString());
                                // cmmd.Parameters.AddWithValue("@Datetime", Session["login"].ToString());
                                //cmd.ExecuteNonQuery();
                                string strRsslt = cmmd.ExecuteNonQuery().ToString();

                            }

                        }

                    }
                    conn.Close();
                }
            }
            
            
            double percentageValue;

            // Attempt to parse the text value to a double
            if (double.TryParse(e.Row.Cells[9].Text, out percentageValue))
            {
                string formattedPercentage = percentageValue.ToString("P");
                e.Row.Cells[9].Text = formattedPercentage;
            }
            else
            {
                // Parsing failed, handle the case where the text cannot be parsed as a double
                // You can log an error, show a message to the user, or take other appropriate action.
            }
            double percentageValue1;

            // Attempt to parse the text value to a double
            if (double.TryParse(e.Row.Cells[10].Text, out percentageValue1))
            {
                string formattedPercentage = percentageValue1.ToString("P");
                e.Row.Cells[10].Text = formattedPercentage;
            }
            else
            {
                // Parsing failed, handle the case where the text cannot be parsed as a double
                // You can log an error, show a message to the user, or take other appropriate action.
            }
            double percentageValue2;

            // Attempt to parse the text value to a double
            if (double.TryParse(e.Row.Cells[11].Text, out percentageValue2))
            {
                string formattedPercentage = percentageValue2.ToString("P");
                e.Row.Cells[11].Text = formattedPercentage;
            }
            else
            {
                // Parsing failed, handle the case where the text cannot be parsed as a double
                // You can log an error, show a message to the user, or take other appropriate action.
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

    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlzonevalue = string.Empty;
        ddlzonevalue = ddlzone.SelectedValue.ToString();
        Session["ddlzonevalue"] = ddlzonevalue;
       // //Lblwh.Text = //Lblwh.Text + ", <span style= 'color:Red;'>" + ddlzonevalue + "</span> zone ";
        // BindGrid2();
    }
    protected void ddlbu_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlbuvalue = string.Empty;
        ddlbuvalue = ddlbu.SelectedValue.ToString();
        Session["ddlbuvalue"] = ddlbuvalue;
       // //Lblwh.Text = //Lblwh.Text + "Showing calculation for <span style= 'color:Red;'>" + ddlbuvalue + "</span> division ";
        //  Lblwh.ForeColor = System.Drawing.Color.Red;

        //BindGrid2();
    }

    protected void ddlteam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddlteamvalue = string.Empty;
        ddlteamvalue = ddlteam.SelectedValue.ToString();
        Session["ddlteamvalue"] = ddlteamvalue;
       // //Lblwh.Text = //Lblwh.Text + ", <span style= 'color:Red;'>" + ddlteamvalue + "</span> Team ";
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
            StrQrry = "Select distinct [ZONE] from [Organogram$] where DSM='" + Session["FSCODE"] + "'  ";

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
    protected void refersh_Click(object sender, EventArgs e)
    {
        string sm = "SM";
        string rbm = "RBM";
        string dsm = "DSM";
        string tbe = "TBE";
        string tbm = "TBM";
        string desgna = Session["DESG"].ToString();

        string whreclase = " ";
        whreclase = "AND ";
        if (Session["ddlbuvalue"] != null)
        {
            whreclase += "[DIVISION] = '" + Session["ddlbuvalue"].ToString() + "' and ";
        }
        if (Session["ddlzonevalue"] != null)
        {
            whreclase += "[ZONE] = '" + Session["ddlzonevalue"].ToString() + "' and ";

        }
        if (Session["ddlteamvalue"] != null)
        {
            whreclase += "[TEAM] = '" + Session["ddlteamvalue"].ToString() + "' and ";
        }
        if (Session["ddldesgvalue"] != null)
        {
            whreclase += "[DESIGNATION] = '" + Session["ddldesgvalue"].ToString() + "' and ";
        }
        whreclase = whreclase.Substring(0, whreclase.Length - 4);
        //whreclase = whreclase;


        if (sm == desgna)
        {
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where SM='" + Session["FSCODE"] + "' " + whreclase + " order by ROW_ID ";
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
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where RBM='" + Session["FSCODE"] + "' " + whreclase + " order by ROW_ID ";
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
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where DSM='" + Session["FSCODE"] + "' " + whreclase + " order by ROW_ID ";
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
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where FS_Code ='" + Session["FSCODE"] + "  'order by ROW_ID ";
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
        if (desgna == "Admin")
        {
            whreclase = whreclase.Substring(4);
            DataSet DsStockist = new DataSet();
            DataTable dtDsStockist = new DataTable();
            string StrQrry = "";
            StrQrry = "";
            StrQrry = "	 SELECT * FROM [EMPLOYEE_Incentive_KPI1_TAB] where " + whreclase + " order by ROW_ID ";
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