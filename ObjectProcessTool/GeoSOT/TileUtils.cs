﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeoSOT
{
    public class TileUtils
    {
        #region 度分秒转换

        /// <summary>
        /// 将十进制经纬度转换为DMS字符串表达，秒保留4位精度
        /// </summary>
        /// <param name="dd">十进制经纬度</param>
        /// <returns>dms字符串</returns>
        private string DecimalDgreeToDMS(double dd, int precision = 5)
        {
            var degrees = (int)dd;
            var minutes = (dd - degrees) * 60;
            var seconds = ((minutes - (int)minutes) * 60);
            return string.Format("{0}° {1}' {2}\"",
                Math.Abs(degrees), Math.Abs((int)minutes),
                Math.Round(Math.Abs(seconds), precision));
        }

        /// <summary>
        /// 将DMS字符串转换为十进制经纬度，保留6位精度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        private double DMSToDecimalDgree(string dms, int precision = 6)
        {
            var list = dms.Split(new char[] { '°', '\'', '\"' });
            var degrees = double.Parse(list[0].Trim(' '));
            var minutes = double.Parse(list[1].Trim(' ')) / 60;
            var seconds = double.Parse(list[2].Trim(' ')) / 3600;
            return Math.Round(degrees + minutes + seconds, precision);
        }

        /// <summary>
        /// 纬度转换为度分秒
        /// </summary>
        /// <param name="lat">维度</param>
        /// <returns>*度*分*秒</returns>
        public string GetLatDMS(double lat)
        {
            var dms = DecimalDgreeToDMS(lat);
            return string.Format("{0} {1}",
                dms, lat < 0 ? "S" : "N");
        }

        /// <summary>
        /// 经度转换为度分秒
        /// </summary>
        /// <param name="lng">经度</param>
        /// <returns>*度*分*秒</returns>
        public string GetLngDMS(double lng)
        {
            var dms = DecimalDgreeToDMS(lng);
            return string.Format("{0} {1}",
                dms, lng < 0 ? "W" : "E");
        }

        /// <summary>
        /// 度分秒维度转换为十进制度
        /// </summary>
        /// <param name="lat"></param>
        /// <returns></returns>
        public double GetLat(string dms)
        {
            var result = DMSToDecimalDgree(dms);
            if (dms.IndexOf("S") >= 0) { result = -result; }
            else if (dms.IndexOf("N") >= 0) { }
            else { throw new ArgumentException(); }
            return result;
        }

        /// <summary>
        /// 度分秒经度转换为十进制度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        public double GetLng(string dms)
        {
            var result = DMSToDecimalDgree(dms);
            if (dms.IndexOf("W") >= 0) { result = -result; }
            else if (dms.IndexOf("E") >= 0) { }
            else { throw new ArgumentException(); }
            return result;
        }

        #endregion

        #region 经纬度与1d/2d编码转换

        public UInt32 EncodeLngLat(double x)
        {
            var segs = new LngLatSegments(x);
            return segs.G << 31 | segs.D << 23 | segs.M << 17 | segs.S << 11 | segs.S11;
        }

        public UInt64 EncodeLngLat(double lat, double lng)
        {
            var morton = new Morton2D();
            var L = EncodeLngLat(lng);
            var B = EncodeLngLat(lat);
            return morton.Magicbits(L, B);
        }

        public void DecodeLngLat(UInt64 code, ref double lat, ref double lng)
        {
            var morton = new Morton2D();
            UInt32 L = 0; // 横轴
            UInt32 B = 0; // 竖轴
            morton.Magicbits(code, ref L, ref B);
            lng = new LngLatSegments(L, true).Degree;
            lat = new LngLatSegments(B, false).Degree;
        }

        #endregion

        public UInt32 GetL(double lng, int level)
        {
            var L = EncodeLngLat(lng);
            return L >> (31-level);
        }

        public UInt32 GetB(double lat, int level)
        {
            var B = EncodeLngLat(lat);
            return B >> (31 - level);
        }

        public string GetLngLatCode(double lat, double lng, int level)
        {
            var code = EncodeLngLat(lat, lng);
            StringBuilder sb = new StringBuilder();
            sb.Append("G");
            for (int i = 31; i > 31 - level; i--)
            {
                var v = (code >> i * 2) & 0x3;
                sb.Append(v);
                if (i > 32 - level)
                {
                    if (i == 23 || i == 17)
                    {
                        sb.Append("-");
                    }
                    if (i == 11)
                    {
                        sb.Append(".");
                    }
                }

            }
            return sb.ToString();
        }
    }
}
