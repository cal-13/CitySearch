using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySearch {
    public class Trie {
        string userSearch;
        Node root;
        public void CreateRoot()
        {
            root = new Node();
        }
        public void Insert(char[] inputString) {
            Node tempRoot = root;
            int length = inputString.Count();
            for (int i = 0; i < length; i++) {
                Node newNode;
                if (tempRoot.children.Keys.Contains(inputString[i])) {
                    tempRoot = tempRoot.children[inputString[i]];
                }
                else {
                    newNode = new Node();
                    if ((length-1) == i) {
                        newNode.leaf = true;
                    }
                    tempRoot.children.Add(inputString[i], newNode);
                    tempRoot = newNode;
                }
            }
        }
        public List<string> ReturnAllNodes(string searchString, Node curNode)
        {
            if (curNode.children == null)
                return new List<string> { searchString };
            else
            {
                List<string> resultSet = new List<string>();
                if (searchString != userSearch && curNode.leaf) {
                    resultSet.Add(searchString);
                }
                foreach (var c in curNode.children)
                    resultSet.AddRange(ReturnAllNodes(searchString + c.Key, c.Value));
                return resultSet;
            }
        }
        public List<string> ListAllChildren(string inString)
        {
            Node curNode = root;
            StringBuilder bldr = new StringBuilder();
 
            foreach (char c in inString)
            {
                if (curNode.children.ContainsKey(c))
                {
                    curNode = curNode.children[c];
                    bldr.Append(c);
                }
                else
                    break;
            }
 
            return ReturnAllNodes(bldr.ToString(), curNode);
        }
        public bool BasicSearchPrefix(char[] searchChars) {
            Node tempRoot = root;
            int length = searchChars.Count();
            for (int i = 0; i < length; i++) {
                if (tempRoot.children.Keys.Contains(searchChars[i])) {
                    tempRoot = tempRoot.children[searchChars[i]];
                }
                else {
                    //Nothing Found
                    return false;
                }
            }
            //Prefix Found
            return true;
        }
        public bool BasicSearchFull(char[] searchChars) {
            Node tempRoot = root;
            int length = searchChars.Count();
            for (int i = 0; i < length; i++) {
                if (tempRoot.children.Keys.Contains(searchChars[i])) {
                    tempRoot = tempRoot.children[searchChars[i]];
                    if ((length-1) == i) {
                        if (tempRoot.leaf == true) {
                            //Full word found
                            return true;
                        }
                    }
                }
                else {
                    return false;
                }
            }
            return false;
        }
        public CityResult Search(string searchString) {
            userSearch = searchString;
            char[] searchChars = searchString.ToCharArray();
            CityResult result = new CityResult();
            Node leaf = root;
            if (BasicSearchFull(searchChars)) {
                result.NextCities.Add(searchString);
            }
            if (BasicSearchPrefix(searchChars)) {
                foreach (string word in ListAllChildren(searchString)) {
                    result.NextLetters.Add(word[(searchChars.Count())].ToString());
                    result.NextCities.Add(word);
                }
            }
            return result;
        }
        public class Node {
            public bool leaf;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
        }
    }
}