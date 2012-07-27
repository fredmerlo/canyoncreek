using System;
using System.Globalization;
using System.Text;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
    public static class CouponEncode
    {
        public static string EncodeCPT(string pinCode, int offerCode)
        {
            string shortKey = "rke184ulgt";
            string longKey = "2rdAinvOmFoVXBa58sp1EZkSucftCg6eqxWlPKRNGzw7YQHJ4Db9UIyM3jTLh";
            string decodeX = " abcdefghijklmnopqrstuvwxyz0123456789!$%()*+,-.@;<=>?[]^_{|}~";
            int[] encodeModulo = new int[256];
            int[] vob = new int[2];

            vob[0] = offerCode % 100;
            vob[1] = (offerCode / 100) % 100;

            for (int i = 0; i < 61; i++)
                encodeModulo[(int)Char.Parse(decodeX.Substring(i, 1))] = i;
            pinCode = pinCode.ToLower() + offerCode.ToString(CultureInfo.InvariantCulture);
            if (pinCode.Length < 20)
            {
                pinCode = pinCode + " couponsincproduction";
                pinCode = pinCode.Substring(0, 20);
            }
            int q = 0;
            int j = pinCode.Length;
            int k = shortKey.Length;
            int s1, s2, s3;
            StringBuilder cpt = new StringBuilder();
            for (int i = 0; i < j; i++)
            {
                s1 = encodeModulo[(int)Char.Parse(pinCode.Substring(i, 1))];
                s2 = 2 * encodeModulo[(int)Char.Parse(shortKey.Substring(i % k, 1))];
                s3 = vob[i % 2];
                q = (q + s1 + s2 + s3) % 61;
                cpt.Append(longKey.Substring(q, 1));
            }
            return cpt.ToString();

        }
    }
}
