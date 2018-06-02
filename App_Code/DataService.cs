using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

public class DataService
{
    protected OleDbConnection conn;

    public DataService()
    {
        string connectionString = Connect.GetConnectionString();
        conn = new OleDbConnection(connectionString);
    }

    public void CloseConnection()
    {
        conn.Close();
    }

    public OleDbDataReader GetReader(string sqlString)
    {
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sqlString, this.conn);
        OleDbDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public void AddCourse(string courseName, string price, string description, string roomType)
    {
        string query = "INSERT INTO Courses (CourseName, PricePerMonth, Description, RoomType) VALUES('" + courseName + "', '" + price + "', '" + description + "', '" + roomType + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public void AddRoom(string roomName, string roomType)
    {
        string query = "INSERT INTO Rooms (RoomName, RoomType) VALUES('" + roomName + "', '" + roomType + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public bool RoomNameNotExist(string roomName)
    {
        string query = "SELECT RoomCode FROM Rooms WHERE RoomName='" + roomName + "'";
        OleDbCommand comm = new OleDbCommand(query, conn);
        object obj = null;

        try
        {
            conn.Open();
            obj = comm.ExecuteScalar();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return (obj == null);
    }

    public void SetGuideToCourse(string GuideCode, string CourseCode)
    {
        string query = "INSERT INTO GuidesInCourses (GuideCode, CourseCode) VALUES ('" + GuideCode + "','" + CourseCode + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public void SetTimeTable(string GuideCourseCode, string RoomCode, string DayCode, string HourCode)
    {
        string year = DateTime.Now.Year.ToString();

        string query = "INSERT INTO TimeTable (GuideCourseCode, RoomCode, [Day], [Hour], [Year]) VALUES ('" + GuideCourseCode + "', '" + RoomCode + "', '" + DayCode + "', '" + HourCode + "','" + year + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void EnterDetailsStudent(string idNumber, string firstName, string lastName, string birthDate, string gender, string cellphone, string address, string username, string password)
    {
        string passHash = CalculateMD5Hash(password);
        string query = "INSERT INTO Students (IDNumber, FirstName, LastName, BirthDate, Gender, Cellphone, Address, Email, PassHash) VALUES ('" + idNumber + "','" + firstName + "','" + lastName + "','" + birthDate + "','" + gender + "','" + cellphone + "','" + address + "','" + username + "','" + passHash + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public bool NoUsernameStudent(string email)
    {
        string query = "SELECT StudentCode FROM Students WHERE email='" + email + "'";
        OleDbCommand comm = new OleDbCommand(query, conn);
        object obj = null;

        try
        {
            conn.Open();
            obj = comm.ExecuteScalar();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return (obj == null);
    }

    public bool NoPasswordParticipant(string password)
    {
        string sql = "SELECT * FROM Student WHERE (password = '" + password + "')";
        OleDbCommand comm = new OleDbCommand(sql, conn);
        object obj = null;

        try
        {
            conn.Open();
            obj = comm.ExecuteScalar();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return (obj == null);
    }

    public bool IsStudentExist(string email, string password, out string userName, out int studentCode)
    {
        bool exist = false;
        userName = "";
        studentCode = -1;
        string passHash = CalculateMD5Hash(password);
        string sql = "SELECT Students.StudentCode, FirstName, LastName FROM Students WHERE (Students.email = '" + email + "' AND Students.passHash = '" + passHash + "')";

        try
        {
            OleDbDataReader reader = GetReader(sql);
            if (reader.Read())
            {
                exist = true;
                studentCode = reader.GetInt32(0);
                userName = reader.GetString(1) + " " + reader.GetString(2);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return exist;
    }

    public bool IsAdminExist(string email, string password, out string userName)
    {
        bool exist = false;
        userName = "";
        string passHash = CalculateMD5Hash(password); // how to create a password
        string sql = "SELECT Admin.AdminCode, AdminName, AdminFamilyName FROM Admin WHERE (Admin.email = '" + email + "'AND Admin.passHash = '" + passHash + "')";

        try
        {
            OleDbDataReader reader = GetReader(sql);
            if (reader.Read())
            {
                exist = true;
                userName = reader.GetString(1) + " " + reader.GetString(2);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return exist;
    }

    public bool IsGuideExist(string email, string password, out string userName)
    {
        bool exist = false;
        userName = "";
        string passHash = CalculateMD5Hash(password);
        string sql = "SELECT Guides.GuideCode, FirstName, LastName FROM Guides WHERE (Guides.email = '" + email + "' AND Guides.passHash = '" + passHash + "')";

        try
        {
            OleDbDataReader reader = GetReader(sql);
            if (reader.Read())
            {
                exist = true;
                userName = reader.GetString(1) + " " + reader.GetString(2);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return exist;
    }

    public void InsertGuidsDetails(string firstName, string lastName, string idNumber, string birthDate, string cellphone, string address, string email, string pass)
    {
        string date = DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year;
        string passHash = CalculateMD5Hash(pass);
        string query = "INSERT INTO Guides (FirstName, LastName, IDNumber, Email, BirthDate, CellPhone, Address, WorkBeginDate, PassHash) VALUES ('" + firstName + "','" + lastName + "','" + idNumber + "','" + email + "','" + birthDate + "','" + cellphone + "','" + address + "','" + date + "','" + passHash + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public bool NoCodeWorkerTogetherWithEmail(string email)
    {
        string sql = "SELECT Guides.GuideCode FROM Guides WHERE Guides.Email = '" + email + "'";
        OleDbCommand comm = new OleDbCommand(sql, conn);
        object obj = null;

        try
        {
            conn.Open();
            obj = comm.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return (obj == null);
    }
    
    //public bool ParticipantsNotExistsInCourse(string participantCode, string courseName)
    //{
    //    string sql = "SELECT StudentInCourses.CaseCode FROM(Student INNER JOIN ParticipantsInCourses ON Participants.ParticipantCode = ParticipantsInCourses.ParticipantCode) INNER JOIN Courses ON ParticipantsInCourses.CourseCode = Courses.CourseCode WHERE(Participant.ParticipantCode = '" + participantCode + "' AND Courses.Name = '" + courseName + "')";

    //    OleDbCommand comm = new OleDbCommand(sql, conn);
    //    object obj = null;

    //    try
    //    {
    //        conn.Open();
    //        obj = comm.ExecuteScalar();
    //    }

    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //    finally
    //    {
    //        conn.Close();
    //    }

    //    return (obj == null);
    //}

    public void AddStudentToCourse(string studentCode, string courseTimeCode)
    {
        DataService d = new DataService();
        string query = "INSERT INTO StudentsInCourse (StudentCode, CourseTimeCode) VALUES ('" + studentCode + "','" + courseTimeCode + "')";
        OleDbCommand comm = new OleDbCommand(query, conn);

        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public int CourseCodeByCourseName(string courseName)
    {
        string sql = "SELECT Courses.CourseCode FROM Courses WHERE (Courses.CourseName = '" + courseName + "')";
        OleDbCommand comm = new OleDbCommand(sql, conn);
        int courseCode = 0;

        try
        {
            conn.Open();
            courseCode = (int)comm.ExecuteScalar();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return courseCode;
    }

    //public void DeleteParticipantCourse(string participantCode, string courseName)
    //{
    //    DataService d = new DataService();
    //    int courseCode = d.CourseCodeByCourseName(courseName);
    //    string query = "DELETE StudentInCourses.CaseCode, StudentInCourses.StudentCode, ParticipantsInCourses.CourseCode FROM ParticipantsInCourses WHERE (ParticipantsInCourses.ParticipantCode = '" + participantCode + "' AND ParticipantsInCourses.CourseCode = '" + courseCode + "')";
    //    OleDbCommand comm = new OleDbCommand(query, conn);

    //    try
    //    {
    //        conn.Open();
    //        comm.ExecuteNonQuery();
    //    }

    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //    finally
    //    {
    //        conn.Close();
    //    }
    //}

    public string CourseDescriptionByCourseName(string courseName)
    {
        string sql = "SELECT Courses.CourseDescription FROM Courses WHERE (Courses.CourseName = '" + courseName + "')";
        OleDbCommand comm = new OleDbCommand(sql, conn);
        string courseDescription = null;

        try
        {
            conn.Open();
            courseDescription = Convert.ToString(comm.ExecuteScalar());
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return courseDescription;
    }

    public int NumParticipants(string courseName)
    {
        string sql = "SELECT Count(StudentsInCourses.StudentCode) FROM ParticipantsInCourses INNER JOIN Courses ON ParticipantsInCourses.CourseCode = Courses.CourseCode WHERE (Courses.CourseName = '" + courseName + "')";
        OleDbCommand comm = new OleDbCommand(sql, conn);
        int numParticipants = 0;

        try
        {
            conn.Open();
            numParticipants = Convert.ToInt32(comm.ExecuteScalar());
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return numParticipants;
    }


    public object ShowTable(string participantCode)
    {
        string sql = "SELECT Courses.Name, Courses.HourBegin, Courses.HourEnd, Courses.Day, Rooms.NameCode FROM Rooms INNER JOIN (CourcesInRooms INNER JOIN(Courses INNER JOIN(Participants INNER JOIN ParticipantsInCourses ON Participants.ParticipantCode = ParticipantsInCourses.ParticipantCode) ON Courses.CourseCode = ParticipantsInCourses.CourseCode) ON CourcesInRooms.CourseCode = Courses.CourseCode) ON Rooms.RoomCode = CourcesInRooms.RoomCode WHERE (Students.StudenttCode = '" + participantCode + "')";
        OleDbCommand command = new OleDbCommand(sql, conn);
        OleDbDataReader obj = null;

        try
        {
            conn.Open();
            obj = command.ExecuteReader();

        }

        catch (Exception exception)
        {
            throw exception;
        }


        return obj;
    }

    public void AddNewRank(int courseCode, string participantCourse, string rankings)
    {
        string sql = "INSERT INTO Rankings VALUES ('" + courseCode + "','" + participantCourse + "','" + rankings + "')";
        OleDbCommand comm = new OleDbCommand(sql, conn);

        try
        {
            conn.Open();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }
    }

    public object ShowLoozeHours(string guideCode)
    {
        string sql = "SELECT Courses.Day, Courses.HourBegin, Courses.HourEnd, Rooms.NameCode, Participants.FirstName, Participants.LastName FROM(Participants INNER JOIN ParticipantsInCourses ON Participants.ParticipantCode = ParticipantsInCourses.ParticipantCode) INNER JOIN (Rooms INNER JOIN(CourcesInRooms INNER JOIN((GuidesInCourses INNER JOIN Guides ON GuidesInCourses.GuideCode = Guides.GuideCode) INNER JOIN Courses ON GuidesInCourses.CourseCode = Courses.CourseCode) ON CourcesInRooms.CourseCode = Courses.CourseCode) ON Rooms.RoomCode = CourcesInRooms.RoomCode) ON ParticipantsInCourses.CourseCode = Courses.CourseCode WHERE(Guides.GuideCode = '" + guideCode + "') ORDER BY Courses.Day";
        OleDbCommand command = new OleDbCommand(sql, conn);
        OleDbDataReader obj = null;

        try
        {
            conn.Open();
            obj = command.ExecuteReader();

        }

        catch (Exception exception)
        {
            throw exception;
        }


        return obj;

    }


    public object ShowMatnasLooze()
    {
        string sql = "SELECT * from TimeTable where Year = '" + DateTime.Now.Year + "'";
        OleDbCommand command = new OleDbCommand(sql, conn);
        OleDbDataReader obj = null;

        try
        {
            conn.Open();
            obj = command.ExecuteReader();

        }
        catch (Exception exception)
        {
            throw exception;
        }

        return obj;
    }

    public string CalculateMD5Hash(string input)
    {
        // preliminary step add salt to the input data

        const string salt = "To make the hex string use lower-case letters instead of upper-case";

        string saltedInput = input + salt;

        // step 1, calculate MD5 hash from input

        MD5 md5 = System.Security.Cryptography.MD5.Create();

        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(saltedInput);

        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }

        return sb.ToString();

    }

    public void GetTimeTable(List<TimeTableRow> rows)
    {
        string query = @"SELECT Courses.CourseName, Guides.FirstName, Guides.LastName, WorkingDays.Name, WorkingHours.HourName, Rooms.RoomName
                         FROM((((((TimeTable INNER JOIN
                         WorkingDays ON TimeTable.[Day] = WorkingDays.DayCode) INNER JOIN
                         WorkingHours ON TimeTable.[Hour] = WorkingHours.HourCode) INNER JOIN
                         GuidesInCourses ON TimeTable.GuideCourseCode = GuidesInCourses.GuideCourseCode) INNER JOIN
                         Courses ON GuidesInCourses.CourseCode = Courses.CourseCode) INNER JOIN
                         Rooms ON TimeTable.RoomCode = Rooms.RoomCode) INNER JOIN
                         Guides ON GuidesInCourses.GuideCode = Guides.GuideCode)";


        try
        {
            OleDbDataReader reader = GetReader(query);
            while (reader.Read())
            {
                TimeTableRow row = new TimeTableRow(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                rows.Add(row);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

    }

    public int GetCourseTimeCode(int guideCourseCode, string day, string hour)
    {
        string query = @"SELECT CourseTimeCode
                            FROM TimeTable                            
                            WHERE TimeTable.GuideCourseCode= " + guideCourseCode +
                            " AND [Day]=" + day + " AND [Hour]=" + hour;

        OleDbCommand comm = new OleDbCommand(query, conn);
        int courseTimeCode = 0;

        try
        {
            conn.Open();
            courseTimeCode = (int)comm.ExecuteScalar();
        }

        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return courseTimeCode;
    }

    public int GetGuideCourseCode(string guideCode, string courseCode)
    {
        string query = @"SELECT GuideCourseCode 
                        FROM GuidesInCourses
                        WHERE GuideCode = " + guideCode + " AND CourseCode = " + courseCode;

        int value = -1;
        try
        {
            OleDbDataReader reader = GetReader(query);
            if (reader.Read())
            {
                value = reader.GetInt32(0);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return value;
    }



    public List<KeyValuePair<string, string>> GetTimesForCourse(int guideCorseCode)
    {
        string query = @"SELECT WorkingDays.Name, WorkingHours.HourName, WorkingDays.DayCode, WorkingHours.HourCode
                       FROM (TimeTable INNER JOIN WorkingDays ON TimeTable.[Day] = WorkingDays.DayCode) INNER JOIN WorkingHours ON TimeTable.[Hour] = WorkingHours.HourCode
                       WHERE TimeTable.GuideCourseCode = " + guideCorseCode;

        List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

        try
        {
            OleDbDataReader reader = GetReader(query);
            while (reader.Read())
            {
                string key = reader.GetString(0) + " " + reader.GetString(1);
                string value = reader.GetInt32(2).ToString() + "," + reader.GetInt32(3).ToString();
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(key, value);
                values.Add(pair);
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return values;
    }    

    public List<int> GetTimeTableGuideForCourse(string courseCode)
    {
        string query = @"SELECT GuidesInCourses.GuideCode
                    FROM(Courses INNER JOIN GuidesInCourses ON Courses.CourseCode = GuidesInCourses.CourseCode)
                    where Courses.CourseCode=" + courseCode;

        List<int> values = new List<int>();
        try
        {
            OleDbDataReader reader = GetReader(query);
            while (reader.Read())
            {
                values.Add(reader.GetInt32(0));
            }

            // Always call Close when done reading.
            reader.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            conn.Close();
        }

        return values;

    }
}







