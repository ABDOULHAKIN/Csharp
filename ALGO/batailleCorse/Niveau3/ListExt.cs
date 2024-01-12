using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niveau3 {
    public static class ListExt {
        private static Random r = new Random();
        public static T RetirerAleatoirement<T>(this List<T> liste) {
            int pos = r.Next(liste.Count);
            T ret = liste[pos];
            liste.RemoveAt(pos);
            return ret;
        }
    }
}
