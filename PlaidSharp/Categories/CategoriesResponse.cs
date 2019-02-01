using System.Collections.Generic;

namespace PlaidSharp.Categories
{
    public class CategoriesResponse : PlaidResponse
    {
        public List<Category> Categories { get; set; }

        public struct Category
        {
            public string Group { get; set; }

            public List<string> Hierarchy { get; set; }

            public string CategoryId { get; set; }
        }
    }
}
