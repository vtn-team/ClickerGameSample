using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CostStringConverter
{
    static public string Convert(int number)
    {
        string ret = "";
        if (number < 10000)
        {
            while (true)
            {
                int tmp = number % 1000;
                if (number < 1000)
                {
                    ret = tmp + ret;
                    break;
                }
                else
                {
                    ret = string.Format(",{0, 3:000}{1}",tmp, ret);
                    number = number / 1000;
                }
            }
            return ret;
        }
        else
        {
            string[] DigString = new string[4]
            {
                "万",
                "億",
                "兆",
                "京"
            };
            int digIndex = 0;
            int num = number / 10000;
            while (true)
            {
                int tmp = num % 1000;
                if (num < 1000)
                {
                    if (digIndex == 0)
                    {
                        ret = string.Format("{0}{1}", (float)number / 10000.0f, DigString[digIndex]);
                    }
                    else
                    {
                        ret = string.Format("{0}{1}", (float)number / (10000.0f * digIndex * 1000.0f), DigString[digIndex]);
                    }
                    break;
                }
                else
                {
                    num = num / 1000;
                    digIndex++;
                }
            }
            return ret;
        }
    }
}
