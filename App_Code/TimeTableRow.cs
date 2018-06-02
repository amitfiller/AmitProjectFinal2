using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTableRow
/// </summary>
public class TimeTableRow
{
    string courseName;
    string guidesFirstName;
    string guideLastName;
    string day;
    string hour;
    string roomName;

    public TimeTableRow(string courseName, string guidesFirstName, string guideLastName, string day, string hour, string roomName)
    {
        this.courseName = courseName;
        this.guidesFirstName = guidesFirstName;
        this.guideLastName = guideLastName;
        this.day = day;
        this.hour = hour;
        this.roomName = roomName;
    }

    public override string ToString()
    {
        return guidesFirstName + " " + guideLastName + " - " + courseName + " " + roomName;        
    }

    public int GetDayNum()
    {
        int val = 0;

        switch (day)
            {
            case "Sunday":
                val = 1;
                break;
            case "Monday":
                val = 2;
                break;
            case "Tuesday":
                val = 3;
                break;
            case "Wednesday":
                val = 4;
                break;
            case "Thursday":
                val = 5;
                break;
                
        };

        return val;
    }


    public int GetHourNum()
    {
        int val = 0;

        switch (hour)
        {
            case "16:00":
                val = 1;
                break;
            case "17:00":
                val = 2;
                break;
            case "18:00":
                val = 3;
                break;
            case "19:00":
                val = 4;
                break;
            case "20:00":
                val = 5;
                break;
            case "21:00":
                val = 6;
                break;
            case "22:00":
                val = 7;
                break;

        };

        return val;
    }


}