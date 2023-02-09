using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    public static class TimeSpanConverter
    {
        //----------to time span--------------
        public static TimeSpan SecondsToTimeSpan(float seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        //-----------to format string--------------
        public static string SecondsToFormatString(float seconds, string format = "hh':'mm':'ss")
        {
            return TimeSpan.FromSeconds(seconds).ToString(format);
        }
    }
}
