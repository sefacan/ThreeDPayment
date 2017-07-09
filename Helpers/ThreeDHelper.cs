using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ThreeDPayment.Helpers
{
    public class ThreeDHelper
    {
        public static string PrepareForm(string actionUrl, NameValueCollection collection)
        {
            string formID = "PaymentForm";
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + actionUrl + "\" method=\"POST\">");

            foreach (string key in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key + "\" value=\"" + collection[key] + "\">");
            }

            strForm.Append("</form>");
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script>");
            strScript.Append("var v" + formID + " = document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");

            return strForm.ToString() + strScript.ToString();
        }

        public static string ConvertSHA1(string text)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] inputbytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));

            return Convert.ToBase64String(inputbytes);
        }

        public static string CreateRandomValue(int Length, bool CharactersB, bool CharactersS, bool Numbers, bool SpecialCharacters)
        {
            string characters_b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters_s = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string special_characters = "-_*+/";
            string allowedChars = String.Empty;

            if (CharactersB)
                allowedChars += characters_b;

            if (CharactersS)
                allowedChars += characters_s;

            if (Numbers)
                allowedChars += numbers;

            if (SpecialCharacters)
                allowedChars += special_characters;

            char[] chars = new char[Length];
            Random rd = new Random();

            for (int i = 0; i < Length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}