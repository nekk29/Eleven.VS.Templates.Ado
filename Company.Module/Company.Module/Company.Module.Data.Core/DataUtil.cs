using System;

namespace Company.Module.Data.Core
{
    public static class DataUtil
    {
        public static Nullable<T> DbValueToNullable<T>(object dbValue) where T : struct
        {
            Nullable<T> returnValue = null;
    
            if ((dbValue != null) && (dbValue != DBNull.Value))
            {
                returnValue = (T)dbValue;
            }
    
            return returnValue;
        }
    
        public static T DbValueToDefault<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value) return default(T);
            else { return (T)obj; }
        }
    }
}
