using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace SoImporter.MiscClass
{
    public static class Helper
    {
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static string FillZeroLeft(this string target_string, int result_digit)
        {
            string result = target_string;

            for (int i = 1; i < result_digit - target_string.Trim().Length; i++)
            {
                result = "0" + result;
            }

            return result;
        }

        //public static string formatErrorData(this WebExceptionStatus exception_status)
        //{
        //    switch (exception_status)
        //    {
        //        case WebExceptionStatus.CacheEntryNotFound:
        //            return "CACHE_ENTRY_NOT_FOUND";
        //        case WebExceptionStatus.ConnectFailure:
        //            return "CONNECT_FAILURE";
        //        case WebExceptionStatus.ConnectionClosed:
        //            return "CONNECTION_CLOSED";
        //        case WebExceptionStatus.KeepAliveFailure:
        //            return "KEEP_ALIVE_FAILURE";
        //        case WebExceptionStatus.MessageLengthLimitExceeded:
        //            return "MESSAGE_LENGTH_LIMIT_EXCEEDED";
        //        case WebExceptionStatus.NameResolutionFailure:
        //            return "NAME_RESOLUTION_FAILURE";
        //        case WebExceptionStatus.Pending:
        //            return "PENDING";
        //        case WebExceptionStatus.PipelineFailure:
        //            return "PIPE_LINE_FAILURE";
        //        case WebExceptionStatus.ProtocolError:
        //            return "PROTOCOL_ERROR";
        //        case WebExceptionStatus.ProxyNameResolutionFailure:
        //            return "PROXY_NAME_RESOLUTION_FAILURE";
        //        case WebExceptionStatus.ReceiveFailure:
        //            return "RECEIVE_FAILURE";
        //        case WebExceptionStatus.RequestCanceled:
        //            return "REQUEST_CANCEL";
        //        case WebExceptionStatus.RequestProhibitedByCachePolicy:
        //            return "REQUEST_PROHIBITED_BY_CACHE_POLICY";
        //        case WebExceptionStatus.RequestProhibitedByProxy:
        //            return "REQUEST_PROHIBITED_BY_PROXY";
        //        case WebExceptionStatus.SecureChannelFailure:
        //            return "SECURE_CHANNEL_FAILURE";
        //        case WebExceptionStatus.SendFailure:
        //            return "SEND_FAILURE";
        //        case WebExceptionStatus.ServerProtocolViolation:
        //            return "SERVER_PROTOCOL_VIOLATION";
        //        case WebExceptionStatus.Success:
        //            return "SUCCESS";
        //        case WebExceptionStatus.Timeout:
        //            return "TIME_OUT";
        //        case WebExceptionStatus.TrustFailure:
        //            return "TRUST_FAILURE";
        //        case WebExceptionStatus.UnknownError:
        //            return "UNKNOWN_ERROR";
        //        default:
        //            return "UNKNOWN_ERROR";
        //    }
        //}
    }
}
