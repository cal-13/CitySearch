namespace CitySearch {
    public interface ICityFinder {
        ICityResult Search(string searchString);
    }
}

// Implements method called Search, which takes the user string and returns type ICityResult
// https://stackoverflow.com/questions/15392224/interface-as-return-type