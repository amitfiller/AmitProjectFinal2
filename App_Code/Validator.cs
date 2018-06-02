using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Validator
/// </summary>
public class Validator
{
    public Validator()
    {        

    }
    
    public static bool ValidateUserIDNumber(string idNumber)
    {
        if (idNumber.Count() != 9)
            return false;

        int sum = 0;
        for (int index = 0; index < 9; index++)
        {
            int id = (int)Char.GetNumericValue(idNumber[index]);

            int multy = 0;
            if (index % 2 == 0)
                multy = id;
            else
                multy = 2 * id;

            int result = (multy / 10) + (multy % 10);
            sum = sum + result;
        }
        return (sum % 10 == 0);
    }
}