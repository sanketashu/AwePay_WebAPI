using System;
using System.Reflection;

namespace AwePay_Service
{
    public static class Enums
    {

        public enum StatusCode
        {
            [StringValue("200")] Ok200,
            [StringValue("201")] Created201,
            [StringValue("409")] AlreadyExists409,
            [StringValue("401")] Unauthorized401,
            [StringValue("404")] NotFound404,
            [StringValue("500")] InternalServerError500,
            [StringValue("400")] InvalidData,
            [StringValue("1034")] FailedAttemptExceeded,
            [StringValue("498")] Expired
        }

        public enum ReturnValue
        {
            [StringValue("-1")] Minus1, 
            [StringValue("-2")] Minus2,
            [StringValue("0")] Error
        }


        public static string GetStringValue(this Enum value)
        {
            /// Get the type
            Type type = value.GetType();

            /// Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            /// Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            /// Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }



    public class StringValueAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion


    }

}
