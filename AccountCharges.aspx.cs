using Contract.ContractClasses;
using Contract.ContractInterfaces;
using Mapper.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AccountCharges : System.Web.UI.Page
{
    #region Page Level Variables Declaretion

    private DataSet dsPage = null;
    private SessionMapper sessionMapper = null;
    private IAccountMaster objComponent;
    private MapperAccounts objMapper;
    private CommonLayer objCL = new CommonLayer();

    #endregion

    #region Page Controls Event

    protected void Page_Load(object sender, EventArgs e)
    {
        sessionMapper = new SessionMapper();
        sessionMapper = (SessionMapper)Session["userSession"];
        if (sessionMapper == null)
        {
            Response.Redirect("Login.aspx", false);
        }

        if (Request.QueryString["accId"] != null)
        {
            var accCode = Convert.ToInt32(Request.QueryString["accId"]);
            GetCurrency(accCode);
        }
    }

    #endregion

    //*********    Get Currency   *********//
    private void GetCurrency(int sAccId)
    {
        dsPage = new DataSet();
        objMapper = new MapperAccounts();
        objComponent = new AccountMaster();
        try
        {
            objMapper.AccountId = sAccId;
            dsPage = objComponent.GetAccountChargesDatabase(objMapper);
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            int iLoop = 1;
            int iCounter = 0;
            int jCounter = 0;
            int kCounter = 0;

            if (dsPage.Tables.Count > 0 && dsPage.Tables[0].Rows.Count > 0)
            {
                string[] arrTypeName = Convert.ToString(dsPage.Tables[0].Rows[0]["TypeName"]).Split('~');
                string[] arrTypeValue = Convert.ToString(dsPage.Tables[0].Rows[0]["TypeValue"]).Split('~');
                string[] arrTypePerc = Convert.ToString(dsPage.Tables[0].Rows[0]["PercentageValue"]).Split('~');
                if (arrTypeName.Length > 1)
                {
                    for (iLoop = 1; iLoop <= (arrTypeName.Length - 1) / 4; iLoop++)
                    {
                        sb.Append("<table id=\"dataTable\" border='1' class='table-design_2' style='margin-top:10px; border:1px solid #17657d'>");
                        sb.Append("<tr>");
                        sb.Append("<th style=\"width:148px\">" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th style=\"width:148px\">" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th style=\"width:148px\">" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th style=\"width:148px\">" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("</tr>");
                        sb.Append("<tr>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        //sb.Append("<td><table style='font-size: 10px;'><tr><td>Flat</td><td>Percentage</td></tr><tr><td>" + arrTypeValue[jCounter++] + "</td><td>" + arrTypePerc[kCounter++] + "</td></tr></table></td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("</tr></table>");
                    }
                    if ((arrTypeName.Length - 1) % 4 == 1)
                    {
                        sb.Append("<table id=\"dataTable\" border='1' class='table-design_2' style='margin-top:10px; border:1px solid #17657d'>");
                        sb.Append("<tr>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("</tr>");
                        sb.Append("<tr>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("</tr></table>");
                    }
                    else if ((arrTypeName.Length - 1) % 4 == 2)
                    {
                        sb.Append("<table id=\"dataTable\" border='1' class='table-design_2' style='margin-top:10px; border:1px solid #17657d'>");
                        sb.Append("<tr>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("</tr>");
                        sb.Append("<tr>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("</tr></table>");
                    }
                    else if ((arrTypeName.Length - 1) % 4 == 3)
                    {
                        sb.Append("<table id=\"dataTable\" border='1' class='table-design_2' style='margin-top:10px; border:1px solid #17657d'>");
                        sb.Append("<tr>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("<th>" + arrTypeName[iCounter++] + "</th>");
                        sb.Append("</tr>");
                        sb.Append("<tr>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("<td>" + arrTypeValue[jCounter++] + "</td>");
                        sb.Append("</tr></table>");
                    }
                    //qry += "<table id=\"dataTable\" border='1' class='table-design_2' style='border:1px solid #17657d'>";
                    //qry += "<tr><th style=\"width:148px\">TT CHARGES/PER TT</th><th style=\"width:148px\">LOCAL CHATS CHARGES/PER CHATS</th><th style=\"width:148px\">AMENDMENT CHARGES</th><th style=\"width:148px\">USD CASH TO TT/FOR TT</th></tr>";
                    //qry = qry + "<tr><td>" + myRow[3].ToString().ToUpper() + "</td><td>" + myRow[4].ToString().ToUpper() + "</td>";
                    //qry = qry + "<td>" + myRow[5].ToString().ToUpper() + " </td><td>" + myRow[6].ToString().ToUpper() + " </td>";
                    //qry = qry + "</table>";

                    //qry += "<table id=\"dataTable\" border='1' class='table-design_2' style='margin-top:10px; border:1px solid #17657d'>";
                    //qry += "<tr><th style=\"width:99px\">USD CASH TO TT/FOR LOCAL CHATS</th><th style=\"width:99px\">FC CASH TO FCTT</th><th style=\"width:99px\">TRACER CHARGES</th><th style=\"width:99px\">TT COMMISSION</th><th style=\"width:99px\">FC PIPS</th></tr>";

                    //qry = qry + "<tr><td>" + myRow[7].ToString().ToUpper() + " </td><td>" + myRow[8].ToString().ToUpper() + " </td>";
                    //qry = qry + "<td>" + myRow[9].ToString().ToUpper() + " </td><td>" + myRow[10].ToString().ToUpper() + " </td>";
                    //qry = qry + "<td>" + myRow[11].ToString().ToUpper() + " </td></tr>";

                    //qry = qry + "</table>";
                }
                else
                {
                    sb.Append("<span style=\"width:100%; text-align:center; font-weight:bold; margin-left: 200px;\">NO REOCRD FOUND!!</span>");
                }
            }
            else
            {
                sb.Append("<span style=\"width:100%; text-align:center; font-weight:bold; margin-left: 200px;\">NO REOCRD FOUND!!</span>");
            }
            myDiv.InnerHtml = sb.ToString();
        }
        catch (Exception ex)
        {

        }
    }
}