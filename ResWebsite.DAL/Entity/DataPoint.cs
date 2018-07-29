
using System;
using System.Runtime.Serialization;

namespace ResWebsite.DAL.Entity
{
    [DataContract]
    public class DataPoint
    {
        //DataContract for Serializing Data - required to serve in JSON format

        public DataPoint(int x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<int> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

    }
}
