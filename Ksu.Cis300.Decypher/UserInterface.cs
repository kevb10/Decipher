/* UserInterface.cs
 * Author: Kevin Manase
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ksu.Cis300.WordLookup;

namespace Ksu.Cis300.Decypher
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The dictionary to be loaded
        /// </summary>
        private ITrie _dictionary;


        public UserInterface()
        {
            InitializeComponent();
        } 

        /// <summary>
        /// Handles events whenever user interface is being loaded
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">event arguments e</param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            _dictionary = new TrieWithNoChildren();
            try
            {
                using (StreamReader input = File.OpenText("dictionary.txt"))
                {
                    while (!input.EndOfStream)
                    {
                        string word = input.ReadLine();
                        _dictionary = _dictionary.Add(word);
                    }
                }
                MessageBox.Show("Dictionary successfully read.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader input = File.OpenText(uxOpenFile.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            string word = input.ReadToEnd();
                            uxInput.Text = word;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// The Decrypt method
        /// </summary>
        /// <param name="cipher">the words of the encrypted message</param>
        /// <param name="partial">the current partial solution to the cipher</param>
        /// <param name="alphaUsed">a size-26 array that keeps track of which lowercase
        ///                         letters have been used in the decryption
        /// </param>
        private bool Decrypt(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {
            if (IsSovled(partial) == true)
            {
               return true;
            }
            else if (HasCompletion(partial) == false)
            {
                return false;
            }

            int[] indexes = FirstOccurence(partial);
            if (indexes[0] > 0)
            {
                Replace(cipher, partial, alphaUsed);
            }
            if (Decrypt(cipher, partial, alphaUsed) == false)
            {
                if (indexes[0] > 0)
                {
                    BackTrack(cipher, partial, alphaUsed);
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if partial represents a solved puzzle
        /// </summary>
        /// <param name="partial"></param>
        /// <returns></returns>
        private bool IsSovled(StringBuilder[] partial)
        {
        for (int i = 0; i < partial.Length; i++)
            {
                if (partial[i].ToString().Contains('?') == true && _dictionary.Contains(partial[i].ToString()) == false)
                {
                    return false;
                }
            }
        return true;
        }

        /// <summary>
        /// Checks if any word in partial does NOT have a possible completion in the trie
        /// </summary>
        /// <param name="partial"></param>
        /// <returns>false if no completion</returns>
        private bool HasCompletion(StringBuilder[] partial)
        {
            for (int i=0; i<partial.Length; i++)
            {
                if (_dictionary.WildcardSearch(partial[i].ToString()) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find the first occurence of '?' in the string builder
        /// </summary>
        /// <param name="partial"></param>
        /// <returns>array of indexes. [1] is the charIndex and [2] is the wordIndex</returns>
        private int[] FirstOccurence(StringBuilder[] partial)
        {
            int[] index = new int[2];
            for (int i = 0; i < partial.Length; i++)
            {
                index[0] = partial[i].ToString().IndexOf('?');
                if (index[0] != -1)
                {
                    index[1] = i;
                    return index;                
                }
            }
            return null;
        }

        /// <summary>
        /// Replace corresponsing location in partial with l
        /// </summary>
        /// <param name="cipher"></param>
        /// <param name="partial"></param>
        /// <param name="alphaUsed"></param>
        private void Replace(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {
            int[] indexes = FirstOccurence(partial);
            int charIndex = indexes[0];
            int wordIndex = indexes[1];
            for (int i = 0; i < alphaUsed.Length; i++)
            {
                char v = cipher[wordIndex][charIndex];
                char l = (char)(i + 'a');
                for (int j = 0; j < cipher.Length; j++)
                {
                    for (int k = 0; k < cipher[j].Length; k++)
                        if (cipher[j][k] == v) partial[wordIndex][charIndex] = l;
                }
            }
        }

        private void BackTrack(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {
            int[] indexes = FirstOccurence(partial);
            int charIndex = indexes[0];
            int wordIndex = indexes[1];
            for (int i = 0; i < alphaUsed.Length; i++)
            {
                char v = cipher[wordIndex][charIndex];
                for (int j = 0; j < cipher.Length; j++)
                {
                    for (int k = 0; k < cipher[j].Length; k++)
                        if (cipher[j][k] == v) partial[wordIndex][charIndex] = '?';
                }
            }
        }

        /// <summary>
        /// Handles decrypt button click
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event argument</param>
        private void uxDecrypt_Click(object sender, EventArgs e)
        {
            List<string> word = new List<string>();
            foreach(int i in uxInput.Text)
            {
                word.Add(uxInput.Text.Split().ToString());
            }
            string[] s = word.ToArray();
            StringBuilder[] sb = new StringBuilder[s.Length];
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = new StringBuilder("?");

            }
            bool[] used = new bool[26];
            if (Decrypt(s, sb, used) == true)
            {
                for (int n = 0; n < sb.Length; n++)
                {
                    uxResult.Text += sb[n].ToString();
                }
            }
            else
                uxResult.Text = "No solution exists.";
        }

    }
}
