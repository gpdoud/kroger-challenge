/*
    Given a string a lowercase characters, return the index of 
    the first unique character within the string. If no characters
    are unique, return -1;
*/
int IndexOfFirstUniqueCharacter(string str) {
    // holds characters already found not unique
    // so the character can be skipped if encountered
    // more than once
    List<char> charsNotUnique = new List<char>();
    // iterate through each character in the string
    for(var idx = 0; idx < str.Length; idx++) {
        // get the character to check
        var targetChar = str[idx];
        // check if this character has already
        // been checked. If so, just skip it.
        if(charsNotUnique.Contains(targetChar)) continue;
        // if it is the last character and it has not
        // already been checked, it is unique
        if(str.Length == idx + 1) return idx;
        // create an array with the remaining characters
        var remainingString = str.Substring(idx + 1);
        // is the character found in the rest of
        // the characters?
        if(!remainingString.Contains(targetChar)) {
            // if not, it is unique! return the index.
            return idx;
        }
        // the character was found within the rest of the
        // array. It is NOT unique. Add it to the collection
        // of characters not unique, and continue
        charsNotUnique.Add(targetChar);
    }
    // if we get here, none of the characters are unique.
    return -1;
}

/*
    An anagram is a word whose letters can be rearranged to form
    another word when each characters is used only once.

    Given an array of strings, test each string to see if it
    is an anagram to another string. If so, discard the second
    anagram from the collection. Return the collection so that 
    none of the strings are anagrams to any other string.
*/
string[] RemoveAnagrams(string[] strings) {
    // a collection of the strings where the characters
    // within the string have been sorted. (i.e. "abcabe"
    // becomes "aabbcc")
    var sortedCharacterStrings = new List<string>();
    // a collection of the strings that have no others
    // that are anagrams
    var NoAnagrams = new List<string>();
    // iterate through all the input strings
    foreach(var str in strings) {
        // create a string where the characters are 
        // sorted. (See sortChars method) 
        var strSorted = sortChars(str);
        // check if the sorted string already exists
        // in the collection of other sorted strings
        if(sortedCharacterStrings.Contains(strSorted)) {
            // if found, original string is an anagram
            // skip it
            continue;
        }
        // if not found, add the sorted string to the 
        // collection of other sorted strings that 
        // are not anagrams
        sortedCharacterStrings.Add(strSorted);
        // add the original string to the collection
        // of non-anagrams
        NoAnagrams.Add(str);
    }
    // return the collection of all the strings that
    // were found to have no annagrams or where the 
    // the anagrams were removed.
    return NoAnagrams.ToArray();
}
// Takes a string and sorts the characters within 
// the string. Two strings are anagrams if the 
// sorted characters are identical.
//
// Give a string input like "dabcbdca", 
// this returns "aabbccdd";
string sortChars(string str) {
    // turn the string into a char[]
    var chArray = str.ToArray<char>();
    // sort the characters in ascending sequence
    Array.Sort(chArray);
    // return the sorted characters as a string
    return new string(chArray);
}


string[] stringsChars = {
"wolwvolgvkgqtratkyhp",
"kpwaqkhdnaoqxzyxxrsa",
"ehaydranjbqajatwddcy",
"wrstxeqzxvpernkfhnag",
"hpjffsyquzichtpoyijl",
"bakzvfeblhenmcaltmpv",
"xyoooicqobmlequcaemo",
"coqmkgfrtzgvmdfynske",
"osqypnokwvqfimwzbwsb",
"pqnapvfdlqozsxepwoep",
"abcabcabcabcabcabccx",
"abcabcabcabcabcabcca"
};
foreach(var str in stringsChars) {
    var index = IndexOfFirstUniqueCharacter(str);
    System.Console.WriteLine(
        (index == -1) 
            ? $"For {str}, none are unique" 
            : $"For {str}, char {str[index]} at [{index}] is unique"
    );
}

var WithoutAnagrams = RemoveAnagrams(new string[] { 
    "bac", "acb", "def", 
    "fed", "dfe", "edf", 
    "ghi", "hgi", "ihg"  
});
WithoutAnagrams.ToList().ForEach(x => {
    System.Console.WriteLine(x);
});
