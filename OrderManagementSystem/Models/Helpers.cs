using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace OrderManagementSystem.Models
{
    public static class Helpers
    {
        public static DataTable BuildObjectDataTable<T>(List<T> valueList, List<string> propertiesToInclude)
        {
            DataTable dt = new DataTable();
            propertiesToInclude = propertiesToInclude ?? new List<string>();
            bool testPropertyName = propertiesToInclude != null && propertiesToInclude.Any();
            Dictionary<string, string> dictNames = new Dictionary<string, string>();
            Dictionary<string, Type> dictTypes = new Dictionary<string, Type>();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if (propertiesToInclude.Contains(info.Name))
                {
                    dictNames.Add(info.Name, info.Name);
                    dictTypes.Add(info.Name, DeNullifiedType(info.PropertyType));
                }
            }

            foreach (string propName in propertiesToInclude)
            {
                dt.Columns.Add(dictNames[propName], dictTypes[propName]);
            }

            if (valueList != null && valueList.Count > 0)
            {
                foreach (T obj in valueList)
                {
                    DataRow dr = dt.NewRow();

                    foreach (PropertyInfo info in typeof(T).GetProperties())
                    {
                        if (propertiesToInclude.Contains(info.Name))
                        {
                            dr[info.Name] = info.GetValue(obj) ?? DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private static Type DeNullifiedType(Type type)
        {
            Type retType = type;

            if (type == typeof(int?))
            {
                retType = typeof(int);
            }
            else if (type == typeof(bool?))
            {
                retType = typeof(bool);
            }
            else if (type == typeof(double?))
            {
                retType = typeof(double);
            }
            else if (type == typeof(float?))
            {
                retType = typeof(float);
            }
            else if (type == typeof(decimal?))
            {
                retType = typeof(decimal);
            }
            else if (type == typeof(DateTime?))
            {
                retType = typeof(DateTime);
            }

            return retType;
        }


        public static void SendMail(string from, string to, string subject, string html)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailAddress fromMailAddress = new MailAddress(from);
            MailAddress toMailAddress = new MailAddress(to);
            MailMessage message = new MailMessage(fromMailAddress, toMailAddress);
            message.Body = html;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            string userState = "test mail";
            smtpClient.SendAsync(message, userState);
            message.Dispose();

        }


    }
}
