using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MoneyConverter;

public partial class JoinCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DropDownListYear.Items.Count == 0)
        {
            ListItem item = new ListItem("--Select one option--", "-1");
            DropDownListYear.Items.Add(item);

            for (int year = DateTime.Now.Year; year < DateTime.Now.Year + 6; year++)
            {
                item = new ListItem(year.ToString(), year.ToString());
                DropDownListYear.Items.Add(item);
            }
        }
    }
    
    public void BindCourseGridView()
    {
        /// 
        string selectedCoursesCodes = string.Join(",", (HashSet<int>)Session["SelectedCourseTimeCode"]);
        if (string.IsNullOrEmpty(selectedCoursesCodes))
        {
            selectedCoursesCodes = "-1";
            CurrencyDropDown.Visible = false;
            ContToPayID.Visible = false;
            totalPriceLabel.Visible = false;
            totalPriceText.Visible = false;
        }
        else
        {
            CurrencyDropDown.Visible = true;

            if (PayBtnID.Visible == false)
                ContToPayID.Visible = true;

            totalPriceLabel.Visible = true;
            totalPriceText.Visible = true;
        }

        AccessDataSource DS = new AccessDataSource();
        DS.DataFile = "~/App_Data/Matnas_Database.accdb";
        DS.SelectCommand = @"SELECT TimeTable.CourseTimeCode, Courses.CourseName, Guides.FirstName + ' ' + Guides.LastName As 'Guide Name', WorkingDays.Name,  WorkingHours.HourName , Courses.PricePerMonth, Courses.Description 
                FROM (((((Courses INNER JOIN GuidesInCourses ON Courses.CourseCode = GuidesInCourses.CourseCode) 
                INNER JOIN Guides ON GuidesInCourses.GuideCode = Guides.GuideCode) 
                INNER JOIN TimeTable ON GuidesInCourses.GuideCourseCode = TimeTable.GuideCourseCode) 
                INNER JOIN WorkingDays ON TimeTable.[Day] = WorkingDays.DayCode) 
                INNER JOIN WorkingHours ON TimeTable.[Hour] = WorkingHours.HourCode)
                WHERE TimeTable.CourseTimeCode in (" + selectedCoursesCodes + ")";

        AddedCoursesGridView.DataSource = DS;
        AddedCoursesGridView.DataBind();

        if (AddedCoursesGridView.Rows.Count > 0)
        {
            AddedCoursesGridView.HeaderRow.Cells[1].Visible = false;
            AddedCoursesGridView.HeaderRow.Cells[2].Text = "Course Name";
            AddedCoursesGridView.HeaderRow.Cells[3].Text = "Guide Name";
            AddedCoursesGridView.HeaderRow.Cells[4].Text = "Day";
            AddedCoursesGridView.HeaderRow.Cells[5].Text = "Hour";
            AddedCoursesGridView.HeaderRow.Cells[6].Text = "Price";
        }     
        //הפעלת שירות רשת חיצוני - המרה משקל לדולר/הפוך
        ConverterSoapClient moneyConv = new ConverterSoapClient("ConverterSoap");
        
        CultureInfo info = new CultureInfo(CurrencyDropDown.SelectedItem.Value);
        string currencySymbol = info.NumberFormat.CurrencySymbol;

        decimal totalprice = 0.0m;
        for (int i = 0; i < AddedCoursesGridView.Rows.Count; ++i)
        {
            AddedCoursesGridView.Rows[i].Cells[1].Visible = false;

            decimal price = (decimal)double.Parse(AddedCoursesGridView.Rows[i].Cells[6].Text);
            if (CurrencyDropDown.SelectedItem.Value == "en-US")
            {
                // Translate to USD                
                price = moneyConv.GetConversionAmount("ILS", "USD", moneyConv.GetLastUpdateDate(), price);
                AddedCoursesGridView.Rows[i].Cells[6].Text = price.ToString("0,0.00");
            }

            totalprice += price;
            AddedCoursesGridView.Rows[i].Cells[6].Text += currencySymbol;
        }

        totalPriceText.Text = totalprice.ToString("0,0.00") + currencySymbol;
    }

    protected void Join_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true && CourseNameID.SelectedValue != "-1" && GuideNameID.SelectedValue != "-1" && CourseTimeID.SelectedValue != "-1")
        {
            char[] delimiterChars = {','};

            DataService d = new DataService();
            int guideCourseCode = d.GetGuideCourseCode(GuideNameID.SelectedItem.Value.ToString(), CourseNameID.SelectedItem.Value.ToString());

            string t = CourseTimeID.SelectedItem.Value.ToString();
            string[] parst = t.Split(delimiterChars);

            if (Session["SelectedCourseTimeCode"] == null)
                Session["SelectedCourseTimeCode"] = new HashSet<int>();

            int courseTimeCode = d.GetCourseTimeCode(guideCourseCode, parst[0], parst[1]);

            ((HashSet<int>)Session["SelectedCourseTimeCode"]).Add(courseTimeCode);
            BindCourseGridView();
            
            CourseNameID.ClearSelection();

            GuideNameID.Items.Clear();
            ListItem item = new ListItem("--Select one option--", "-1");
            GuideNameID.Items.Add(item);
            GuideNameID.Enabled = false;

            CourseTimeID.Items.Clear();
            item = new ListItem("--Select one option--", "-1");
            CourseTimeID.Items.Add(item);
            CourseTimeID.Enabled = false;
            JoinId.Enabled = false;
        }
    }
    
    protected void ChooseCourse_SelectedChanged(object sender, EventArgs e)
    {
        DataService d = new DataService();
        List<int> guides = d.GetTimeTableGuideForCourse(CourseNameID.SelectedItem.Value.ToString());
        string guide = string.Join(",", guides);

        AccessDataSource DS = new AccessDataSource();
        DS.DataFile = "~/App_Data/Matnas_Database.accdb";
        DS.SelectCommand = @"SELECT [FirstName] + ' ' + [LastName] As GuideName, [GuideCode] FROM [TimeTableGuideNameView] where GuideCode in (" + guide + ")";

        GuideNameID.Items.Clear();
        ListItem item = new ListItem("--Select one option--", "-1");
        GuideNameID.Items.Add(item);
        GuideNameID.DataTextField = "GuideName";
        GuideNameID.DataValueField = "GuideCode";
        GuideNameID.DataSource = DS;
        GuideNameID.DataBind();

        GuideNameID.Enabled = true;

    }

    protected void ChooseGuide_SelectedChanged(object sender, EventArgs e)
    {
        DataService d = new DataService();
        int guideCourseCode = d.GetGuideCourseCode(GuideNameID.SelectedItem.Value.ToString(), CourseNameID.SelectedItem.Value.ToString());
        List<KeyValuePair<string, string>> times = d.GetTimesForCourse(guideCourseCode);

        CourseTimeID.Items.Clear();

        ListItem item = new ListItem("--Select one option--", "-1");
        CourseTimeID.Items.Add(item);

        foreach (KeyValuePair<string, string> t in times)
        {
            item = new ListItem(t.Key, t.Value);
            CourseTimeID.Items.Add(item);
        }

        CourseTimeID.Enabled = true;
        JoinId.Enabled = true;

    }

    protected void ContinueToPayment(object sender, EventArgs e)
    {
        ChooseCourseID.Visible = false;
        CourseNameID.Visible = false;
        ChooseGuideID.Visible = false;
        GuideNameID.Visible = false;
        ChooseTime.Visible = false;
        CourseTimeID.Visible = false;
        JoinId.Visible = false;
        AddedCoursesGridView.Visible = false;
        ContToPayID.Visible = false;
        LabelCreditCardNum.Visible = true;
        TextBoxCreditCardNum.Visible = true;
        RegularExpressionValidator1.Visible = true;
        LabelCreditCardType.Visible = true;
        CreditCradTypeID.Visible = true;
        LabelIDNumber.Visible = true;
        TextBoxIDNumber.Visible = true;       
        LabelMonthValidity.Visible = true;
        DropDownListMonth.Visible = true;
        LabelYearValidity.Visible = true;
        DropDownListYear.Visible = true;
        PayBtnID.Visible = true;
    }
    

    protected void AddedCoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AddedCoursesGridView.PageIndex = e.NewPageIndex;
        BindCourseGridView();      
    }
    
    protected void AddedCoursesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = AddedCoursesGridView.Rows[e.RowIndex];

        int courseTimeCode = int.Parse(row.Cells[1].Text);

        ((HashSet<int>)Session["SelectedCourseTimeCode"]).Remove(courseTimeCode);

        BindCourseGridView();
    }

    protected void CurrencyDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCourseGridView();
    }

    protected void FunctionID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (TextBoxIDNumber.Text.Length == 9)
        {
            string text = TextBoxIDNumber.Text;
            int sum = 0;
            for (int index = 0; index < 9; index++)
            {
                int id = (int)Char.GetNumericValue(text[index]);

                int multy = 0;
                if (index % 2 == 0)
                    multy = id;
                else
                    multy = 2 * id;

                int result = (multy / 10) + (multy % 10);
                sum = sum + result;
            }

            args.IsValid = (sum % 10 == 0);
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void PayBtnID_Click(object sender, EventArgs e)
    {
        bool isValidate = true;
        if (CreditCradTypeID.SelectedItem.Value == "-1")
        {
            isValidate = false;
            MessageID.Text = "Credit card type is not selected. ";
        }
        else if (TextBoxCreditCardNum.Text.Count() != 16 || !TextBoxCreditCardNum.Text.All(c => char.IsDigit(c)))
        {
            isValidate = false;
            MessageID.Text = "Credit card number must contains 16 digits. ";
        }        
        else if (TextBoxIDNumber.Text.Count() != 9 || !TextBoxIDNumber.Text.All(c => char.IsDigit(c)))
        {
            isValidate = false;
            MessageID.Text = "Id number must contains 9 digits. ";
        }
        else if (Validator.ValidateUserIDNumber(TextBoxIDNumber.Text) == false)
        {
            isValidate = false;
            MessageID.Text = "Id number control number is incorrect. ";
        }
        else if (DropDownListMonth.SelectedItem.Value == "-1" || DropDownListYear.SelectedItem.Value == "-1")
        {
            isValidate = false;
            MessageID.Text = "Expiration date is incorrect. ";
        }

        if (isValidate)
        {
            try
            {
                CreditCard.Debit deb = new CreditCard.Debit();

                CreditCard.Credit card = new CreditCard.Credit();

                deb.CardNum = TextBoxCreditCardNum.Text;
                deb.CardType = CreditCradTypeID.SelectedItem.Value;
                deb.CardOwnerId = TextBoxIDNumber.Text;
                deb.ExpMonth = int.Parse(DropDownListMonth.SelectedItem.Value);
                deb.ExpYear = int.Parse(DropDownListYear.SelectedItem.Value);
                             
                string status = card.DebitCreditCard(deb);
                if (status == "OK")
                {
                    MessageID.Visible = false;

                    int studentCode = -1;
                    if(Session["LoggedInStudentCode"] != null)
                        studentCode = (int)Session["LoggedInStudentCode"];

                    if (studentCode > -1)
                    {
                        try
                        {
                            DataService d = new DataService();

                            // we have confirmation for the payment so add the student coureces .
                            for (int i = 0; i < AddedCoursesGridView.Rows.Count; ++i)
                            {
                                int courseTimeCode = int.Parse(AddedCoursesGridView.Rows[i].Cells[1].Text);
                                d.AddStudentToCourse(studentCode.ToString(), courseTimeCode.ToString());

                                ((HashSet<int>)Session["SelectedCourseTimeCode"]).Remove(courseTimeCode);
                            }

                            Server.Transfer("StudentPage.aspx");
                        }
                        catch(Exception)
                        {
                            MessageID.Visible = true;
                            MessageID.Text = "Failed to add the student to the course(s)";
                            MessageID.ForeColor = System.Drawing.Color.OrangeRed;
                        }
                    }
                    else
                    {
                        MessageID.Visible = true;
                        MessageID.Text = "Student not register";
                        MessageID.ForeColor = System.Drawing.Color.OrangeRed;
                    }
                }
                else
                {
                    MessageID.Visible = true;
                    MessageID.Text = "Failed, received status: " + status;
                    MessageID.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }
            catch (Exception)
            {
                MessageID.Visible = true;
                MessageID.Text = "An error occurred during communication with the credit card service.";
                MessageID.ForeColor = System.Drawing.Color.OrangeRed;
            }
        }
        else
        {
            MessageID.Visible = true;            
            MessageID.ForeColor = System.Drawing.Color.OrangeRed;
        }
    }
    
}