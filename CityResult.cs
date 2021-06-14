using System.Collections.Generic;

namespace CitySearch {
    public class CityResult : ICityResult {
        public ICollection<string> NextLetters { get; set; }
        public ICollection<string> NextCities { get; set; }
        public CityResult() {
            NextLetters = new List<string>();
            NextCities = new List <string>();
        }
    }
}