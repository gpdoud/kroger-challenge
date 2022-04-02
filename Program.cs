int FirstUniqueCharacter(string str) {

    List<char> chars = new List<char>();
    for(var idx = 0; idx < str.Length-1; idx++) {
        var ch = str[idx];
        // have already checked this ch
        if(chars.Contains(ch)) continue;
        var subStr = str.Substring(idx + 1);
        // does substr contain another ch?
        if(!subStr.Contains(ch)) {
            return idx;
        }
        chars.Add(ch);
    }
    return -1;
}

string[] Anagram(string[] strings) {
    var sortedStrings = new List<string>();
    var nonAnagramStrings = new List<string>();
    foreach(var str in strings) {
        var strSorted = sortChars(str);
        if(sortedStrings.Contains(strSorted)) {
            continue;
        }
        sortedStrings.Add(strSorted);
        nonAnagramStrings.Add(str);
    }
    return nonAnagramStrings.ToArray();
}
string sortChars(string str) {
    var chArray = str.ToArray<char>();
    Array.Sort(chArray);
    return new string(chArray);
}

// var strings = Anagram(new string[] { "bac", "acb", "def", "fed", "dfe" });
// strings.ToList().ForEach(x => System.Console.WriteLine(x));


string[] strings = {
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
"abcabc"
};
foreach(var str in strings) {
    var index = FirstUniqueCharacter(str);
    if(index == -1)
        System.Console.WriteLine($"For {str}, none are unique");
    else
        System.Console.WriteLine($"For {str}, index is {index}; char is {str[index]}");
}