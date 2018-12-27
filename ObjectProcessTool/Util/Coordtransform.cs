using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Util
{
    class Coordtransform
    {

        const double a = 6378245.0;
        const double ee = 0.00669342162296594323;

        static public double[] wgs84togcj02(double lng, double lat)
        {

            if (out_of_china(lng, lat))
            {
                return new double[2] { lng, lat };
            }
            else
            {
                var dlat = transformlat(lng - 105.0, lat - 35.0);
                var dlng = transformlng(lng - 105.0, lat - 35.0);
                var radlat = lat / 180.0 * Math.PI;
                var magic = Math.Sin(radlat);
                magic = 1 - ee * magic * magic;
                var sqrtmagic = Math.Sqrt(magic);
                dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * Math.PI);
                dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * Math.PI);
                var mglat = lat + dlat;
                var mglng = lng + dlng;
                return new double[2] { mglng, mglat };
            }
        }
        static public double[] gcj02towgs84(double lng, double lat)
        {

            if (out_of_china(lng, lat))
            {
                return new double[2] { lng, lat };
            }
            else
            {
                var dlat = transformlat(lng - 105.0, lat - 35.0);
                var dlng = transformlng(lng - 105.0, lat - 35.0);
                var radlat = lat / 180.0 * Math.PI;
                var magic = Math.Sin(radlat);
                magic = 1 - ee * magic * magic;
                var sqrtmagic = Math.Sqrt(magic);
                dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * Math.PI);
                dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * Math.PI);
                var mglat = lat + dlat;
                var mglng = lng + dlng;
                return new double[2] { lng * 2 - mglng, lat * 2 - mglat };
            }
        }
        static public double transformlat(double lng, double lat)
        {

            var ret = -100.0 + 2.0 * lng + 3.0 * lat + 0.2 * lat * lat + 0.1 * lng * lat + 0.2 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * Math.PI) + 20.0 * Math.Sin(2.0 * lng * Math.PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lat * Math.PI) + 40.0 * Math.Sin(lat / 3.0 * Math.PI)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(lat / 12.0 * Math.PI) + 320 * Math.Sin(lat * Math.PI / 30.0)) * 2.0 / 3.0;
            return ret;
        }
        static public double transformlng(double lng, double lat)
        {
            var ret = 300.0 + lng + 2.0 * lat + 0.1 * lng * lng + 0.1 * lng * lat + 0.1 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * Math.PI) + 20.0 * Math.Sin(2.0 * lng * Math.PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lng * Math.PI) + 40.0 * Math.Sin(lng / 3.0 * Math.PI)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(lng / 12.0 * Math.PI) + 300.0 * Math.Sin(lng / 30.0 * Math.PI)) * 2.0 / 3.0;
            return ret;
        }
        static public bool out_of_china(double lng, double lat)
        {
            // 纬度3.86~53.55,经度73.66~135.05 
            return !(lng > 73.66 && lng < 135.05 && lat > 3.86 && lat < 53.55);
        }
    }
}
