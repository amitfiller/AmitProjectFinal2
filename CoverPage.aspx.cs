using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CoverPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {        
            DataService ds = new DataService();
            List<TimeTableRow> rows = new List<TimeTableRow>();
            ds.GetTimeTable(rows);

            List<TimeTableRow>[,] rowsTable = new List<TimeTableRow>[8, 6];
            for (int i = 1; i < 8; ++i)
            {
                for (int j = 1; j < 6; ++j)
                {
                    // Initializ
                    rowsTable[i, j] = new List<TimeTableRow>();
                }
            }

            foreach (var row in rows)
            {
                rowsTable[row.GetHourNum(), row.GetDayNum()].Add(row);
            }

            for (int i = 1; i < 8; ++i)
            {
                for (int j = 1; j < 6; ++j)
                {
                    List<TimeTableRow> daysPerHour = rowsTable[i, j];
                    string s = "";
                    foreach (TimeTableRow day in daysPerHour)
                    {
                        s += day.ToString() + "</BR>"; // Create ToString function!!!
                    }

                    TimeTable.Rows[i].Cells[j].Text = s;
                }
            }

        Comercial.Comercial comercialsService = new Comercial.Comercial();
        Comercial.ComercialData data = comercialsService.GetComercial();

        Image img = new Image();
        img.ImageUrl = data.ImageURL;
        img.AlternateText = data.ImageText;
        img.Width = data.Width;
        img.Height = data.Height;

        Comercial.Controls.Add(img);
        
    }    
}