using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    interface IInOut
    {
        string ReadString();
        double ReadDouble();
        void Output(string value);
        int ReadInteger();
        void Output(IEnumerable<RestaurantInfo> restaurants);
        void Output(Dictionary<RestaurantInfo, double> restaurants);
        void Output(IEnumerable<string> stringList);
        void Output(IEnumerable<int> intList);
        void Output(IEnumerable<ReviewerInfo> reviews);
        void Output(ReviewerInfo review);
    }
}
