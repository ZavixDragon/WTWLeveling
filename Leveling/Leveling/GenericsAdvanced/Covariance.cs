using System.Collections.Generic;
using System.Linq;

namespace Leveling.GenericsAdvanced
{
    public class Covariance
    {
        private readonly IEnumerable<string> _sortedTexts;

        public Covariance(List<string> texts)
        {
            //Here is an example of covariance where its allowing us to use the more specifc type list as one of its bases IEnumerable while keeping the generic 
            _sortedTexts = SortBySecondLetter(texts);
        }

        private IEnumerable<string> SortBySecondLetter(IEnumerable<string> texts)
        {
            return texts.OrderBy(x => x[1]);
        }
    }
}
