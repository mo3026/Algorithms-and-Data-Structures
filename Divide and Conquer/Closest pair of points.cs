using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace ClosestPairPoints
{
    public class Program
    {
        string ClosestPairPoints(string[] stringSet)
        {
            int lengthWhole = stringSet.Length;
            PointsToSortByX[] pointsSortedByX = new PointsToSortByX[lengthWhole];
            PointsToSortByY[] pointsSortedByY = new PointsToSortByY[lengthWhole];
            for (int i = 0; i < lengthWhole - 1; i++)
            {
                string[] parts = stringSet[i].Split(' ');
                pointsSortedByX[i].x = int.Parse(parts[0]);
                pointsSortedByX[i].y = int.Parse(parts[1]);
                pointsSortedByY[i].x = int.Parse(parts[0]);
                pointsSortedByY[i].y = int.Parse(parts[1]);
            }

            sort(pointsSortedByX, 0, pointsSortedByX.Length - 1);
            sort(pointsSortedByY, 0, pointsSortedByY.Length - 1);

            PointsToSortByX[] u = ClosestPairPoints(pointsSortedByX, pointsSortedByY);
            return u[1].ToString() + "<--->" + u[0].ToString() + "\nLength: " + Math.Sqrt(Math.Pow(u[1].x - u[0].x, 2) + Math.Pow(u[1].y - u[0].y, 2)).ToString();
        }

        struct PointsToSortByX : IComparable<PointsToSortByX>
        {
            public int x;
            public int y;

            public int CompareTo(PointsToSortByX that)
            {
                if (this.x < that.x) return -1;
                if (this.x == that.x) return 0;
                return 1;
            }

            public override string ToString()
            {
                return "(" + x.ToString() + ", " + y.ToString() + ")";
            }
        }

        struct PointsToSortByY : IComparable<PointsToSortByY>
        {
            public int x;
            public int y;

            public int CompareTo(PointsToSortByY that)
            {
                if (this.y < that.y) return -1;
                if (this.y == that.y) return 0;
                return 1;
            }

            public static explicit operator PointsToSortByX(PointsToSortByY obj)
            {
                PointsToSortByX t = new PointsToSortByX();
                t.x = obj.x;
                t.y = obj.y;
                return t;
            }
        }

        public static void sort<T>(T[] Array, int Lower, int Higher) where T : IComparable<T>
        {
            int diference = Higher - Lower;
            if (diference <= 1) return;

            int middle = Lower + diference / 2;

            sort(Array, Lower, middle);
            sort(Array, middle, Higher);

            int i = Lower, j = middle;
            T[] auxilary = new T[diference];
            for (int k = 0; k < diference; k++)
            {
                if (i == middle) auxilary[k] = Array[j++];
                else if (j == Higher) auxilary[k] = Array[i++];
                else if (Array[j].CompareTo(Array[i]) < 0) auxilary[k] = Array[j++];
                else auxilary[k] = Array[i++];
            }

            for (int k = 0; k < diference; k++)
            {
                Array[Lower + k] = auxilary[k];
            }
        }


        PointsToSortByX[] ClosestPairPoints(PointsToSortByX[] X, PointsToSortByY[] Y)
        {
            if (X.Length <= 3)
            {
                return ClosestPairPointsBruteForce(X);
            }
            else
            {
                int mideanIndex = X.Length / 2;
                PointsToSortByX[] pointsSortedByX = new PointsToSortByX[mideanIndex];
                PointsToSortByX[] pointsSortedByY = new PointsToSortByX[X.Length - mideanIndex];
                int i = 0;
                for (; i < mideanIndex; i++)
                {
                    pointsSortedByX[i].x = X[i].x;
                    pointsSortedByX[i].y = X[i].y;
                }
                int j = 0;
                for (; j < X.Length - mideanIndex; j++, i++)
                {
                    pointsSortedByY[j].x = X[i].x;
                    pointsSortedByY[j].y = X[i].y;
                }
                PointsToSortByX[] left = ClosestPairPoints(pointsSortedByX, Y);
                PointsToSortByX[] right = ClosestPairPoints(pointsSortedByY, Y);

                double minLeft = Math.Sqrt(Math.Pow(left[1].x - left[0].x, 2) + Math.Pow(left[1].y - left[0].y, 2));
                double minRight = Math.Sqrt(Math.Pow(right[1].x - right[0].x, 2) + Math.Pow(right[1].y - right[0].y, 2));
                double min = Math.Min(minLeft, minRight);
                PointsToSortByX[] mina;
                if (min == minRight) mina = right;
                else mina = left;

                List<PointsToSortByY> psy = new List<PointsToSortByY>();
                for (i = 0; i < Y.Length; i++)
                {
                    if (X[mideanIndex].x - min < Y[i].x && Y[i].x < X[mideanIndex].x + min)
                    {
                        psy.Add(Y[i]);
                    }
                }

                for (i = 0; i < psy.Count; i++)
                {
                    for (int l = i + 1; l < i + 8 && l < psy.Count; l++)
                    {
                        double t4 = Math.Sqrt(Math.Pow(psy[l].x - psy[i].x, 2) + Math.Pow(psy[l].y - psy[i].y, 2));
                        if (t4 < min)
                        {
                            mina = new PointsToSortByX[2] { (PointsToSortByX)psy[l], (PointsToSortByX)psy[i] };
                        }
                    }
                }
                return mina;
            }
        }

        PointsToSortByX[] ClosestPairPointsBruteForce(PointsToSortByX[] S)
        {
            if (S.Length == 3)
            {
                double t1 = Math.Sqrt(Math.Pow(S[1].x - S[0].x, 2) + Math.Pow(S[1].y - S[0].y, 2));
                double t2 = Math.Sqrt(Math.Pow(S[2].x - S[1].x, 2) + Math.Pow(S[2].y - S[1].y, 2));
                double t3 = Math.Sqrt(Math.Pow(S[0].x - S[2].x, 2) + Math.Pow(S[0].y - S[2].y, 2));
                double t = Math.Min(t1, Math.Max(t2, t3));
                if (t == t1) return new PointsToSortByX[2] { S[1], S[0] };
                else
                {
                    if (t == t2) return new PointsToSortByX[2] { S[2], S[1] };
                    else
                    {
                        return new PointsToSortByX[2] { S[0], S[2] };
                    }
                }
            }
            else
            {
                return new PointsToSortByX[2] { S[1], S[0] };
            }
        }
    }
}
