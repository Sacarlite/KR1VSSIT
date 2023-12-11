using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1VSSIT
{
    public interface IAlgoritm
    {
        public List<bool> HorizontalControl(List<byte> byteList);
        public List<bool> VerticalControl(List<byte> byteList);
        public List<bool> CyclicControl(List<byte> byteList, List<bool> buffer);
    }

    public class Algoritms : IAlgoritm
    {
        private const int hexPolinomial = 0x4599;

        public  List<bool> HorizontalControl(List<byte> byteList)
        {
            List<bool> tmp = new List<bool>();
            for (int i = 0; i < byteList.Count; i++)
            {
                List<bool> bit = GetBitsStartingFromLSB(byteList[i]).ToList();
                int counter = 0;
                foreach (bool flag in bit)
                {
                    if (flag)
                    {
                        counter++;
                    }
                }

                if (counter % 2 != 0)
                {
                    tmp.Add(true);
                }
                else
                {
                    tmp.Add(false);
                }
                bit.Clear();
            }

            return tmp;
        }
        public  List<bool> VerticalControl(List<byte> byteList)
        {
            List<List<bool>> tmp = new List<List<bool>>();
            List<bool> tmp1 = new List<bool>();
            for (int i = 0; i < byteList.Count; i++)
            {
                tmp.Add(GetBitsStartingFromLSB(byteList[i]).ToList());
            }
            for (int i = 0; i < tmp.Count; i++)
            {
                int counter1 = 0;
                int counter2 = 0;
                for (int j = 0; j < tmp[i].Count; j++)
                {
                    if (tmp[i][j])
                    {
                        counter1++;
                    }

                    if (tmp[j][i])
                    {
                        counter2++;
                    }
                }
                if (counter1 % 2 != 0)
                {
                    tmp1.Add(true);
                }
                else
                {
                    tmp1.Add(false);
                }
                if (counter2 % 2 != 0)
                {
                    tmp1.Add(true);
                }
                else
                {
                    tmp1.Add(false);
                }

            }

            return tmp1;
        }

        public  List<bool> CyclicControl(List<byte> byteList, List<bool> buffer)
        {

            List<bool> HexPolin = new List<bool>();
            List<bool> tmp = new List<bool>();
            byte[] intBytes = BitConverter.GetBytes(hexPolinomial);
            for (int i = 0; i < intBytes.Length; i++)
            {
                HexPolin = HexPolin.Concat(GetBitsStartingFromLSB(intBytes[i]).ToList()).ToList();
            }
            for (int i = 0; i < byteList.Count; i++)
            {
                tmp = tmp.Concat(GetBitsStartingFromLSB(byteList[i]).ToList()).ToList();
            }

            foreach (var elem in tmp)
            {
                bool hexflag = buffer[0];
                buffer = BitShift(buffer, elem);
                if (hexflag)
                {
                    for (int j = 0; j < buffer.Count; j++)
                    {
                        buffer[j] = buffer[j] ^ HexPolin[j];
                    }
                }
            }

            return buffer;

        }

         IEnumerable<bool> GetBitsStartingFromLSB(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                yield return (b % 2 == 0) ? false : true;
                b = (byte)(b >> 1);
            }
        }
        public  List<bool> BitShift(List<bool> tmp, bool flag)
        {
            for (int i = 0; i < tmp.Count - 1; i++)
            {
                tmp[i] = tmp[i + 1];
            }
            tmp[tmp.Count - 1] = flag;
            return tmp;
        }
    }
}


