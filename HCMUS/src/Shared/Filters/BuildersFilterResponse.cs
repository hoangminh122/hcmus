using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Shared.Filters
{
    public class BuildersFilterResponse<T>
    {
        public FilterDefinition<T> FilterResult { get; set; } = Builders<T>.Filter.Empty;
        public BuildersFilterResponse(T filter)
        {
        }

        public BuildersFilterResponse()
        {
        }

        public void AddNewFilter(FilterDefinition<T> newFilter)
        {
            FilterResult = Builders<T>.Filter.And(FilterResult, newFilter);
        }

    }
}
