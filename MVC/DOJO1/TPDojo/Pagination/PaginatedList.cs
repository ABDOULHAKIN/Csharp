using Microsoft.EntityFrameworkCore;

namespace TPDojo.Pagination {
    public class PaginatedList<T> : List<T> {
        public int NumPage { get; private set; }
        public int NbPages { get; private set; }

        private PaginatedList(List<T> elements, int total, int page, int nbElementsParPage) {
            NumPage = page;
            NbPages = (int)Math.Ceiling(total / (double)nbElementsParPage);
            this.AddRange(elements);
        }

        public bool APrecedent {
            get {
                return (NumPage > 1);
            }
        }

        public bool ASuivant {
            get {
                return (NumPage < NbPages);
            }
        }

        public static async Task<PaginatedList<T>> CreerAsync(IQueryable<T> source, int page, int nbElementsParPage) {
            var nb = await source.CountAsync();
            var elements = await source.Skip((page-1) * nbElementsParPage).Take(nbElementsParPage).ToListAsync();
            return new PaginatedList<T>(elements, nb, page, nbElementsParPage);
        }
    }
}
