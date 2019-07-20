// https://leetcode.com/problems/implement-trie-prefix-tree/

/**
    * Your Trie object will be instantiated and called as such:
    * Trie obj = new Trie();
    * obj.Insert(word);
    * bool param_2 = obj.Search(word);
    * bool param_3 = obj.StartsWith(prefix);
    */

public class Trie
{
    Node root;
    /** Initialize your data structure here. */
    public Trie()
    {
        this.root = new Node("", false);
    }

    /** Inserts a word into the trie. */
    public void Insert(string word)
    {
        var currentNode = this.root;
        var key = "";
        var exists = false;
        for (int i = 0; i < word.Length; i++)
        {
            key = key + word[i];
            if (i == word.Length - 1)
            {
                exists = true;
            }
            if (currentNode.children.ContainsKey(key))
            {
                currentNode = currentNode.children[key];
                currentNode.exists |= exists;
            }
            else
            {
                currentNode.children.Add(key, new Node(key, exists));
                currentNode = currentNode.children[key];
            }
        }
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        var currentNode = root;
        var key = "";
        for (int i = 0; i < word.Length; i++)
        {
            key = key + word[i];

            if (currentNode.children.ContainsKey(key))
            {
                currentNode = currentNode.children[key];
                if (i == word.Length - 1 && currentNode.exists)
                {
                    return true;
                }
            }
            else
            {
                break;
            }
        }
        return false;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
        var currentNode = root;
        var key = "";
        for (int i = 0; i < prefix.Length; i++)
        {
            key = key + prefix[i];

            if (currentNode.children.ContainsKey(key))
            {
                currentNode = currentNode.children[key];
                if (i == prefix.Length - 1)
                {
                    return true;
                }
            }
            else
            {
                break;
            }
        }
        return false;
    }
}

public class Node
{
    public Dictionary<string, Node> children;
    public string key;
    public bool exists;

    public Node(string key, bool exists)
    {
        this.key = key;
        this.exists = exists;
        this.children = new Dictionary<string, Node>();
    }
}