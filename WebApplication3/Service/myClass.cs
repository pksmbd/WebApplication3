using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data;
using System.Collections;
using Humanizer.Localisation.TimeToClockNotation;

namespace WebApplication3.Service
{
    public class myClass
    {
         
       static string connectionstring = "server=.\\SQLEXPRESS;database=FCS;Trusted_Connection=True;TrustServerCertificate=True";

        public DataSet fetchdata(string query)
        {
            //List<UsersModel> UsersModelobj = new List<UsersModel>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                if (con.State != ConnectionState.Open)
                { con.Open(); }
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds);
                if (con.State != ConnectionState.Closed)
                { con.Close(); }
            }
            return ds;
        }
        public bool executenonquery(string query)
        {
            int id;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                id = cmd.ExecuteNonQuery();
                if (con.State != ConnectionState.Closed)
                { con.Close(); }
            }
            return true;
        }


        //public static string caldate(string date1)
        //{
        //    DateTime date2 = Convert.ToDateTime(date1);
        //    String strdocmonth, strdocday;
        //    int docmonth, docday;
        //    docmonth = date2.Month;
        //    docday = date2.Day;
        //    if (docmonth < 10) { strdocmonth = "0" + docmonth.ToString(); }
        //    else { strdocmonth = docmonth.ToString(); }
        //    if (docday < 10) { strdocday = "0" + docday.ToString(); }
        //    else { strdocday = docday.ToString(); }
        //    string date3 = strdocday + "/" + strdocmonth + "/" + date2.Year.ToString();
        //    return date3;
        //}

        //public static string NumberToWords(long number)
        //{
        //    if (number == 0)
        //        return "zero";

        //    if (number < 0)
        //        return "minus " + NumberToWords(Math.Abs(number));

        //    string words = "";

        //    if ((number / 1000000) > 0)
        //    {
        //        words += NumberToWords(number / 1000000) + " million ";
        //        number %= 1000000;
        //    }

        //    if ((number / 1000) > 0)
        //    {
        //        words += NumberToWords(number / 1000) + " thousand ";
        //        number %= 1000;
        //    }

        //    if ((number / 100) > 0)
        //    {
        //        words += NumberToWords(number / 100) + " hundred ";
        //        number %= 100;
        //    }

        //    if (number > 0)
        //    {
        //        if (words != "")
        //            words += "and ";

        //        var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        //        var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        //        if (number < 20)
        //            words += unitsMap[number];
        //        else
        //        {
        //            words += tensMap[number / 10];
        //            if ((number % 10) > 0)
        //                words += "-" + unitsMap[number % 10];

        //        }
        //    }

        //    words = words.ToUpper();
        //    return words;
        //}
        ////money decimal to words


        //public static string DateToWritten(DateTime date)
        //{
        //    return string.Format("{0} {1} {2}", IntegerToWritten(date.Day), date.ToString("MMMM"), IntegerToWritten(date.Year));
        //}

        //public static string IntegerToWritten(int n)
        //{
        //    if (n == 0)
        //        return "Zero";
        //    else if (n < 0)
        //        return "Negative " + IntegerToWritten(-n);

        //    return FriendlyInteger(n, "", 0);
        //}

        //static readonly string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        //static readonly string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        //static readonly string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        //static readonly string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };

        //private static string FriendlyInteger(int n, string leftDigits, int thousands)
        //{
        //    if (n == 0)
        //        return leftDigits;

        //    string friendlyInt = leftDigits;
        //    if (friendlyInt.Length > 0)
        //        friendlyInt += " ";

        //    if (n < 10)
        //        friendlyInt += ones[n];
        //    else if (n < 20)
        //        friendlyInt += teens[n - 10];
        //    else if (n < 100)
        //        friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
        //    else if (n < 1000)
        //        friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
        //    else
        //        friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);

        //    return friendlyInt + thousandsGroups[thousands];
        //}

        //public static string caldate1(string date1)
        //{
        //    DateTime date2 = Convert.ToDateTime(date1, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //    String strdocmonth, strdocday;
        //    int docmonth, docday;
        //    docmonth = date2.Month;
        //    docday = date2.Day;
        //    if (docmonth < 10) { strdocmonth = "0" + docmonth.ToString(); }
        //    else { strdocmonth = docmonth.ToString(); }
        //    if (docday < 10) { strdocday = "0" + docday.ToString(); }
        //    else { strdocday = docday.ToString(); }
        //    string date3 = strdocday + "/" + strdocmonth + "/" + date2.Year.ToString();
        //    return date3;
        //}
        //public static string caldateformatymd(string date1)
        //{
        //    DateTime date2 = Convert.ToDateTime(date1, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //    String strdocmonth, strdocday;
        //    int docmonth, docday;
        //    docmonth = date2.Month;
        //    docday = date2.Day;
        //    if (docmonth < 10) { strdocmonth = "0" + docmonth.ToString(); }
        //    else { strdocmonth = docmonth.ToString(); }
        //    if (docday < 10) { strdocday = "0" + docday.ToString(); }
        //    else { strdocday = docday.ToString(); }
        //    string date3 = date2.Year.ToString() + "-" + strdocmonth + "-" + strdocday;
        //    return date3;
        //}
        //public static string caldatetodaydate(string date1)
        //{

        //    DateTime date2 = Convert.ToDateTime(date1);
        //    String strdocmonth, strdocday;
        //    int docmonth, docday;
        //    docmonth = date2.Month;
        //    docday = date2.Day;
        //    if (docmonth < 10) { strdocmonth = "0" + docmonth.ToString(); }
        //    else { strdocmonth = docmonth.ToString(); }
        //    if (docday < 10) { strdocday = "0" + docday.ToString(); }
        //    else { strdocday = docday.ToString(); }
        //    string date3 = date2.Year.ToString() + "-" + strdocmonth + "-" + strdocday;
        //    return date3;
        //}

        //public static void fileupload(FileUpload fileupload1, string filepath, int id, string deletefile)
        //{
        //    if (fileupload1.HasFile)
        //    {
        //        if (File.Exists(HttpContext.Current.Server.MapPath(filepath + deletefile)))
        //        {
        //            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(filepath + deletefile));
        //            file.Delete();
        //        }
        //        string FileName = Path.GetFileName(fileupload1.PostedFile.FileName);
        //        FileName = deletefile;
        //        fileupload1.SaveAs(HttpContext.Current.Server.MapPath(filepath + FileName));
        //    }
        //}

        //public static void filedelete(string filepath, int id, string deletefile)
        //{
        //    if (File.Exists(HttpContext.Current.Server.MapPath(filepath + deletefile)))
        //    {
        //        FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(filepath + deletefile));
        //        file.Delete();
        //    }
        //}

        //private static Random random = new Random();

        //public static string RandomString(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}

        //public static void fetchgridall(string query, GridView gv)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    gv.DataSource = dt;
        //    gv.DataBind();
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //}

        //public static void fetchdatalist(string query, DataList dl)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    dl.DataSource = ds;
        //    dl.DataBind();
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //}

        //public static string calcage(TextBox t1)
        //{
        //    DateTime dob = Convert.ToDateTime(t1.Text.Substring(3, 2) + "/" + t1.Text.Substring(0, 2) + "/" + t1.Text.Substring(6, 4));
        //    DateTime now = DateTime.UtcNow;

        //    // Swap them if one is bigger than the other
        //    if (now < dob)
        //    {
        //        DateTime date3 = now;
        //        now = dob;
        //        dob = date3;
        //    }
        //    TimeSpan ts = now - dob;
        //    //Debug.WriteLine(ts.TotalDays);

        //    int years = 0;
        //    int months = 0, days = 0;
        //    if ((now.Month <= dob.Month) && (now.Day < dob.Day))  // i.e.  now = 03Jan15,  dob = 23dec14  
        //    {
        //        // example: March 2010 (3) and January 2011 (1); this should be 10 months.  // 12 - 3 + 1 = 10
        //        years = now.Year - dob.Year - 1;
        //        months = 12 - dob.Month + now.Month - 1;
        //        days = DateTime.DaysInMonth(dob.Year, dob.Month) - dob.Day + now.Day;

        //        if (months == 12)
        //        {
        //            months = 0;
        //            years += 1;
        //        }
        //    }
        //    else if ((now.Month <= dob.Month) && (now.Day >= dob.Day)) // i.e.  now = 23Jan15,  dob = 20dec14  
        //    {
        //        // example: March 2010 (3) and January 2011 (1); this should be 10 months.  // 12 - 3 + 1 = 10
        //        years = now.Year - dob.Year - 1;
        //        months = 12 - dob.Month + now.Month;
        //        days = now.Day - dob.Day;
        //        if (months == 12)
        //        {
        //            months = 0;
        //            years += 1;
        //        }
        //    }
        //    else if ((now.Month > dob.Month) && (now.Day < dob.Day))  // i.e.  now = 18oct15,  dob = 22feb14  
        //    {
        //        years = now.Year - dob.Year;
        //        months = now.Month - dob.Month - 1;
        //        days = DateTime.DaysInMonth(dob.Year, dob.Month) - dob.Day + now.Day;
        //    }
        //    else if ((now.Month > dob.Month) && (now.Day >= dob.Day))  // i.e.  now = 22oct15,  dob = 18feb14  
        //    {
        //        years = now.Year - dob.Year;
        //        months = now.Month - dob.Month;
        //        days = now.Day - dob.Day;
        //    }
        //    string date = "y:" + years + ", m:" + months + ", d:" + days.ToString();
        //    return date;

        //}

        //public static int checkexistence(string strSql)
        //{
        //    try
        //    {
        //        if (con.State != ConnectionState.Open)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand(strSql, con);
        //        int a = Convert.ToInt32(cmd.ExecuteScalar());
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //        return a;
        //    }
        //    catch (Exception ex) { return 0; }
        //}

        //public static decimal checkexistencedecimal(string strSql)
        //{
        //    try
        //    {
        //        if (con.State != ConnectionState.Open)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand(strSql, con);
        //        decimal a = Convert.ToDecimal(cmd.ExecuteScalar());
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //        return a;
        //    }
        //    catch (Exception ex) { return 0; }
        //}



        //public static string checkexistencestring(string strSql)
        //{
        //    try
        //    {
        //        if (con.State != ConnectionState.Open)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand(strSql, con);
        //        string a = cmd.ExecuteScalar().ToString();
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //        return a;
        //    }
        //    catch (Exception ex) { return ""; }
        //}


        //public static void fetchdropdownall(string query, DropDownList drp, string textfeild, string valuefeild)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    drp.DataSource = dt;
        //    drp.DataTextField = textfeild;
        //    drp.DataValueField = valuefeild;
        //    drp.DataBind();
        //    //drp.Items.Insert(0, new ListItem("Select Category", ""));
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //}



        //public static string SendSMS(string msg, string no)
        //{
        //    string ApiUrl = "http://146.88.26.101/index.php/smsapi/httpapi/?";
        //    string createdURL = ApiUrl + "uname=parakiteclient&password=parakiteclient1324&msgtype=1&sender=PKSCLI&route=TA&receiver=" + no + "&sms=" + msg;
        //    try
        //    {
        //        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
        //        // Get response from SMS Gateway Server and read the answer
        //        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        //        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        //        string responseString = respStreamReader.ReadToEnd();
        //        respStreamReader.Close();
        //        myResp.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //    }
        //    return "success";
        //}


        //public static int executeprocedure(string procedurename)
        //{
        //    int id;
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand(procedurename, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    id = cmd.ExecuteNonQuery();
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //    return id;
        //}



        //public static DataTable fetchdatatable(string query)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {

        //        con.Open();
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //    return dt;
        //}


        //public static int fetchaccountidbygroupname(string name)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlCommand cmd1 = new SqlCommand("select * from tblaccount where name='" + name + "'", con);
        //    int id = Convert.ToInt32(cmd1.ExecuteScalar());
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //    return id;
        //}
        //public static string fetchaccountnamebyaccountid(int id)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Open();
        //    }
        //    SqlCommand cmd1 = new SqlCommand("select name from tblaccount  where id='" + id + "'", con);
        //    string name = cmd1.ExecuteScalar().ToString();
        //    if (con.State != ConnectionState.Closed)
        //    {
        //        con.Close();
        //    }
        //    return name;
        //}


        //[NonAction]
        //public static SelectList fetchmvcdropdownlist(string query, string valueField, string textField)
        //{
        //    DataTable table = myclass.fetchdatatable(query);
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(new SelectListItem()
        //        {
        //            Text = row[textField].ToString(),
        //            Value = row[valueField].ToString()
        //        });
        //    }
        //    return new SelectList(list, "Value", "Text");
        //}



    }
}
