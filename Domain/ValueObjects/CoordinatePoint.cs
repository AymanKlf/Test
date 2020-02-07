using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class CoordinatePoint : ValueObject
    {
        private CoordinatePoint()
        {

        }

        public static CoordinatePoint For(double? latitude, double? longitude)
        {
            var point = new CoordinatePoint();

            if (IsInRange(-90, 90, latitude) && IsInRange(-180, 180, longitude))
            {
                point.Latitude = latitude;
                point.Longitude = longitude;
            }

            else
            {
                throw new InvalidCoordinatePointException("Latitude/Longitude Ranges should be [-90,90],[-180, 180] ");
            }

            return point;
        }

        private static bool IsInRange(double min, double max, double? value)
        {
            if (value != null && value >= min && value <= max)
            {
                return true;
            }

            return false;
        }

        public double? Latitude { get; private set; }

        public double? Longitude { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
