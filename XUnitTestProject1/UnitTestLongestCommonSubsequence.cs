using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DS;
using FluentAssertions;

namespace XUnitTestProject1
{

    public class UnitTestLongestCommonSubsequence
    {
        [Fact]
        public void ReturnLongestCommonSubsequenceExample1()
        {
            SolutionLCS lcs = new SolutionLCS();
            string text1 = "abcde";
            string text2 = "ace";
            int len = lcs.LongestCommonSubsequence(text1, text2);

            Assert.True(len.Equals(3));
        }

        [Fact]
        public void ReturnLongestCommonSubsequenceExample2()
        {
            SolutionLCS lcs = new SolutionLCS();
            string text1 = "abc"; //"abc", text2 = "abc"
            string text2 = "abc";
            int len = lcs.LongestCommonSubsequence(text1, text2);

            Assert.True(len.Equals(3));
        }
       
        [Fact]
        public void ReturnLongestCommonSubsequenceExample3()
        {
            SolutionLCS lcs = new SolutionLCS();
            string text1 = "abc"; //"abc", text2 = "def"
            string text2 = "def";
            int len = lcs.LongestCommonSubsequence(text1, text2);

            Assert.True(len.Equals(0));
        }


        [Fact]
        public void ReturnLongestCommonSubsequenceExample5()
        {
            SolutionLCS lcs = new SolutionLCS();
            string text1 = "ylqpejqbalahwr"; //"abc", text2 = "def"
            string text2 = "yrkzavgdmdgtqpg";
            int?[,] DPMemory = new int?[text1.Length+1,text2.Length+1];
            int len = lcs.LongestCommonSubsequenceMemoized2(text1, text2, DPMemory);

            Assert.Equal(3, len);
        }

        [Fact]
        public void ReturnLongestCommonSubsequenceExample6()
        {
            SolutionLCS lcs = new SolutionLCS();
            string text1 = "fcvafurqjylclorwfoladwfqzkbebslwnmpmlkbezkxoncvwhstwzwpqxqtyxozkpgtgtsjobujezgrkvevklmludgtyrmjaxyputqbyxqvupojutsjwlwluzsbmvyxifqtglwvcnkfsfglwjwrmtyxmdgjifyjwrsnenuvsdedsbqdovwzsdghclcdexmtsbexwrszihcpibwpidixmpmxshwzmjgtadmtkxqfkrsdqjcrmxkbkfoncrcvoxuvcdytajgfwrcxivixanuzerebuzklyhezevonqdsrkzetsrgfgxibqpmfuxcrinetyzkvudghgrytsvwzkjulmhanankxqfihenuhmfsfkfepibkjmzybmlkzozmluvybyzsleludsxkpinizoraxonmhwtkfkhudizepyzijafqlepcbihofepmjqtgrsxorunshgpazovuhktatmlcfklafivivefyfubunszyvarcrkpsnglkduzaxqrerkvcnmrurkhkpargvcxefovwtapedaluhclmzynebczodwropwdenqxmrutuhehadyfspcpuxyzodifqdqzgbwhodcjonypyjwbwxepcpujerkrelunstebopkncdazexsbezmhynizsvarafwfmnclerafejgnizcbsrcvcnwrolofyzulcxaxqjqzunedidulspslebifinqrchyvapkzmzwbwjgbyrqhqpolwjijmzyduzerqnadapudmrazmzadstozytonuzarizszubkzkhenaxivytmjqjgvgzwpgxefatetoncjgjsdilmvgtgpgbibexwnexstipkjylalqnupexytkradwxmlmhsnmzuxcdkfkxyfgrmfqtajatgjctenqhkvyrgvapctqtyrufcdobibizihuhsrsterozotytubefutaxcjarknynetipehoduxyjstufwvkvwvwnuletybmrczgtmxctuny";
            string text2 = "nohgdazargvalupetizezqpklktojqtqdivcpsfgjopaxwbkvujilqbclehulatshehmjqhyfkpcfwxovajkvankjkvevgdovazmbgtqfwvejczsnmbchkdibstklkxarwjqbqxwvixavkhylqvghqpifijohudenozotejoxavkfkzcdqnoxydynavwdylwhatslyrwlejwdwrmpevmtwpahatwlaxmjmdgrebmfyngdcbmbgjcvqpcbadujkxaxujudmbejcrevuvcdobolcbstifedcvmngnqhudixgzktcdqngxmruhcxqxypwhahobudelivgvynefkjqdyvalmvudcdivmhghqrelurodwdsvuzmjixgdexonwjczghalsjopixsrwjixuzmjgxydqnipelgrivkzkxgjchibgnqbknstspujwdydszohqjsfuzstyjgnwhsrebmlwzkzijgnmnczmrehspihspyfedabotwvwxwpspypctizyhcxypqzctwlspszonsrmnyvmhsvqtkbyhmhwjmvazaviruzqxmbczaxmtqjexmdudypovkjklynktahupanujylylgrajozobsbwpwtohkfsxeverqxylwdwtojoxydepybavwhgdehafurqtcxqhuhkdwxkdojipolctcvcrsvczcxedglgrejerqdgrsvsxgjodajatsnixutihwpivihadqdotsvyrkxehodybapwlsjexixgponcxifijchejoxgxebmbclczqvkfuzgxsbshqvgfcraxytaxeviryhexmvqjybizivyjanwxmpojgxgbyhcruvqpafwjslkbohqlknkdqjixsfsdurgbsvclmrcrcnulinqvcdqhcvwdaxgvafwravunurqvizqtozuxinytafopmhchmxsxgfanetmdcjalmrolejidylkjktunqhkxchyjmpkvsfgnybsjedmzkrkhwryzan";
            int?[,] DPMemory = new int?[text1.Length + 1, text2.Length + 1];
            int len = lcs.LongestCommonSubsequenceMemoized2(text1, text2, DPMemory);

            Assert.Equal(323, len);
        }



    }
}
