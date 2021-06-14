using System.Collections.Generic;

namespace CitySearch {
    public interface ICityResult {
        ICollection<string> NextLetters { get; set; }
        ICollection<string> NextCities { get; set; }
    }
}

// Implements list properties for the next letters and next cities into a class