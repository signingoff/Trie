using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Reflection;
using Trie;

namespace TrieTest
{
    [TestClass]
    public class TrieTreeTest
    {
        [TestMethod]
        public void TwoAnd()
        {
            TrieTree tree = new TrieTree();

            Assert.AreEqual(1, tree.AddNodes("and").Frequence);
            Assert.AreEqual(2, tree.AddNodes("and").Frequence);
            Assert.AreEqual(1, tree.AddNodes("ande").Frequence);
        }

        [TestMethod]
        public void When_Root_Has_MoreThanOneNode()
        {
            TrieTree tree = new TrieTree();

            Assert.AreEqual(1, tree.AddNodes("and").Frequence);
            Assert.AreEqual(1, tree.AddNodes("bne").Frequence);
            Assert.AreEqual(1, tree.AddNodes("bnd").Frequence);
            Assert.AreEqual(1, tree.AddNodes("cnee").Frequence);
        }

        [TestMethod]
        public void Performance()
        {
            TrieTree tree = new TrieTree();
            string words = GetEmbededResource(this.GetType().Assembly, "words.txt");

            foreach (var item in words.Split('\n'))
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (item.Trim().All(c => char.IsLetter(c)))
                {
                    Assert.AreEqual(1, tree.AddNodes(item.Trim()).Frequence);
                }
            }

            Assert.AreEqual(1,tree.Search("good").Frequence);
         }

        protected static string GetEmbededResource(Assembly assembly, string name)
        {
            string xml = string.Empty;
            using (Stream stream = assembly
                .GetManifestResourceStream(assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(name))))
            {
                using (var reader = new StreamReader(stream))
                {
                    xml = reader.ReadToEnd();
                }
            }
            return xml;
        }
    }
}
